using System;
using System.Drawing;
using System.Windows.Forms;

namespace Minesweeper.game {
    class Tile {
        private const int WIDTH = 34;   //width of a tile
        private Point pos;  //position on the field
        private MinesweeperGame game;
        private bool covered;
        private bool flagged;

        public event EventHandler<GameEvent> GameChange;
        public bool HasMine { get; set; }
        public Button Button { get; private set; }
 

        public Tile(MinesweeperGame game, int x, int y) {
            this.game = game;
            pos = new Point(x, y);
            HasMine = false;
            covered = true;
            CreateButton();
        }

        //create a button representing the tile on the gamefield
        private void CreateButton() {
            Button = new Button();
            Button.MouseDown += new MouseEventHandler(ClickTile);

            Button.Size = new Size(WIDTH, WIDTH);
            Button.Top = WIDTH * pos.Y;
            Button.Left = WIDTH * pos.X;
            Button.Margin = new Padding(0);
            Button.FlatStyle = FlatStyle.Flat;
            Button.Font = new Font("Impact", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            //settings for unturned tiles
            Button.ForeColor = SystemColors.ControlDarkDark;
            Button.Text = "";
            Button.BackColor = SystemColors.ControlDark;
        }

        //uncovers a selected tile, if no mine is present it will be called recursively to uncover adjacent tiles with no mines
        public void UncoverTile(bool initialCall) {
            if (!covered || flagged) return;

            if (HasMine && initialCall) {   //only detonate mines when method is called from ClickTile()
                GameChange(this, GameEvent.Lost);
            } else {
                game.UncoveredTiles += 1;
                OnGameEvent(GameEvent.Uncovered);
                int mines = CheckAdjacentTiles();

                //assign a number and color based on surrounding tiles
                if(mines > 0) {
                    ChangeTile(mines);
                } else {
                    //if no mines found uncover surrounding tiles
                    Button.ForeColor = SystemColors.ControlDarkDark;
                    Button.BackColor = SystemColors.ControlLight;
                    covered = false;

                    for (int x = pos.X - 1; x <= pos.X + 1; x++) {
                        for (int y = pos.Y - 1; y <= pos.Y + 1; y++) {
                            game.OpenAdjacent(x, y);
                        }
                    }
                }
            }
        }

        //set the tile with the corresponding number of mines adjacent to it
        private void ChangeTile(int mines) {
            switch (mines) {
                case 1:
                    Button.ForeColor = Color.Blue;
                    break;
                case 2:
                    Button.ForeColor = Color.Green;
                    break;
                case 3:
                    Button.ForeColor = Color.Red;
                    break;
                case 4:
                    Button.ForeColor = Color.Purple;
                    break;
                case 5:
                    Button.ForeColor = Color.Maroon;
                    break;
                case 6:
                    Button.ForeColor = Color.Turquoise;
                    break;
                case 7:
                    Button.ForeColor = Color.Black;
                    break;
                case 8:
                    Button.ForeColor = Color.Gray;
                    break;
            }

            Button.Text = mines.ToString();
            Button.BackColor = SystemColors.ControlLight;
            covered = false;
        }

        //checks the adjacent tiles and counts how many mines are around the current tile
        private int CheckAdjacentTiles() {
            int counter = 0;
            for(int x=pos.X-1; x <= pos.X+1; x++) {
                for (int y = pos.Y - 1; y <= pos.Y+1; y++) {
                    if (game.IsMine(x, y)) {
                        counter++;
                    } else {
                    }
                }
            }
            return counter;
        }

        //method for placing a mine flag, unflags tiles with existing flag
        private void FlagMine() {
            //unflag tile
            if (flagged) {   
                Button.ForeColor = SystemColors.ControlDarkDark;
                Button.Text = "";
                Button.BackColor = SystemColors.ControlDark;
                flagged = false;
                OnGameEvent(GameEvent.Unflagged);
            } else {
                //flag tile
                if (game.FlaggedMines >= game.Mines) return;
                Button.Text = "F";
                Button.ForeColor = Color.Black;
                Button.BackColor = Color.Yellow;
                flagged = true;
                OnGameEvent(GameEvent.Flagged);
            }
        }

        //uncover a tile with left click and flag/unflag it with right click
        private void ClickTile(object sender, MouseEventArgs e) {
            if (!game.Started) OnGameEvent(GameEvent.Started);
            if(covered) {
                if (e.Button.Equals(MouseButtons.Left)) {
                    UncoverTile(true);
                } else {
                    FlagMine();
                }
            }
        }

        //notify Minesweepergame of occured game event
        protected virtual void OnGameEvent(GameEvent e) {
            GameChange(this, e);
        }

    }
}
