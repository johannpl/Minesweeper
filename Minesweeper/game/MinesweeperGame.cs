using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Minesweeper.game {

    class MinesweeperGame {
        private Panel gamePanel;

        private Tile[,] field;
        private List<Tile> minedTiles = new List<Tile>();   //keep a list of the mines for instant access
        private int fieldWidth;

        public event EventHandler<GameEvent> MineCounterChanged;
        public event EventHandler<GameEvent> GameStatusChange;
        public int Mines { get; private set; }
        public int FlaggedMines { get; private set; }
        public int UncoveredTiles { get; set; }
        public bool Started { get; private set; }
        public bool GameOver { get; private set; }

        public MinesweeperGame(Panel gamePanel, (int width, int mines) t) {
            this.gamePanel = gamePanel;
            fieldWidth = t.width;
            Mines = t.mines;
            Started = false;
            GameOver = false;
            CreateField();
            PlaceMines();
        }

        //create the gamefield based on the given width
        private void CreateField() {
            gamePanel.Visible = false;
            field = new Tile[fieldWidth, fieldWidth];
            
            for(int x=0; x < fieldWidth; x++) {
                for(int y=0; y < fieldWidth; y++) {
                    field[x, y] = new Tile(this, x, y);
                    field[x, y].GameChange += new EventHandler<GameEvent>(OnGameEventOccured);
                    gamePanel.Controls.Add(field[x, y].Button);
                }
            }
            gamePanel.Visible = true;
        }

        //randomly place mines on the field
        private void PlaceMines() {
            Random rndGen = new Random();

            int x, y;
            int minesLeft = Mines;

            while(minesLeft > 0) {
                x = rndGen.Next(fieldWidth);
                y = rndGen.Next(fieldWidth);

                if(!field[x, y].HasMine) {
                    Tile tile = field[x, y];
                    tile.HasMine = true;
                    minedTiles.Add(tile);
                    minesLeft--;
                }
            }
        }

        //util function for checking surrounding tiles for mines
        public bool IsMine(int x, int y) {
            if(x < fieldWidth && x >= 0 && y < fieldWidth && y >= 0) {
                return field[x, y].HasMine;
            }
            return false;
        }

        //util function for uncovering surrounding tiles
        public void OpenAdjacent(int x, int y) {
            if (x < fieldWidth && x >= 0 && y < fieldWidth && y >= 0) {
                field[x, y].UncoverTile(false);
            }
        }

        //uncover all mines
        private void DetonateMines() {
            foreach(Tile m in minedTiles) {
                m.Button.Text = "X";
                m.Button.ForeColor = Color.White;
                m.Button.BackColor = Color.FromArgb(247, 57, 57);
            }
        }

        //tile interaction has occured
        protected virtual void OnGameEventOccured(object sender, GameEvent e) {
            switch(e) {
                case GameEvent.Started:
                    Started = true;
                    GameStatusChange(this, e);
                    break;
                case GameEvent.Lost:
                    GameOver = true;
                    DetonateMines();
                    GameStatusChange(this, e);
                    break;
                case GameEvent.Uncovered:
                    //win condition once all tiles without mines have been uncovered
                    if(UncoveredTiles == (fieldWidth*fieldWidth - Mines)) {
                        GameOver = true;
                        DetonateMines();
                        GameStatusChange(this, GameEvent.Won);
                    }
                    break;
                case GameEvent.Flagged:
                    FlaggedMines += 1;
                    MineCounterChanged(this, e);
                    break;
                case GameEvent.Unflagged:
                    FlaggedMines -= 1;
                    MineCounterChanged(this, e);
                    break;
            }
        }
    }
}
