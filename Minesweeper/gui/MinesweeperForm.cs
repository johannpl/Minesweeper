using System;
using System.Windows.Forms;
using Minesweeper.game;

namespace Minesweeper {
    public partial class MinesweeperForm : Form {
        private enum Difficulty { Easy, Normal, Hard};  //available difficulties

        private Difficulty difficulty = Difficulty.Easy;    //default difficulty on startup is easy
        private MinesweeperGame game;
        private int timePassedInSeconds;
        private bool paused;

        public MinesweeperForm() {
            InitializeComponent();
            SetUpGame();
        }

        private void StartGame() {
            timePassedInSeconds = 0;

            //start the game time
            GameTimer.Enabled = true;
            GameTimer.Start();
        }

        //general setup whenever a new game is started
        private void SetUpGame() {
            //time setup
            timePassedInSeconds = 0;
            TimeLabel.Text = "000";
            GameTimer.Interval = (1000);    //set the timer to count passed time in seconds
            GameTimer.Enabled = false;

            //gamefield setup
            GameStatusLabel.Visible = false;
            GameField.Controls.Clear();
            GameField.Enabled = true;
            paused = false;

            //resize controls to their base size
            GameStatusLabel.Size = new System.Drawing.Size(247, 89);
            MenuPanel.Size = new System.Drawing.Size(320, 66);
            GameField.Size = new System.Drawing.Size(320, 335);
            ClientSize = new System.Drawing.Size(346, 470);
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);

            //minesweeper setup
            game = new MinesweeperGame(GameField, SetDifficulty());
            game.MineCounterChanged += new EventHandler<GameEvent>(MineCounterChange);
            game.GameStatusChange += new EventHandler<GameEvent>(GameStatusChanged);
            MineLabel.Text = game.Mines.ToString();
        }

        //the size of the gamefield and number mines is determined by the selected difficulty
        private (int, int) SetDifficulty() {
            var setting = (width: 0, mines: 0);
            switch(difficulty) {
                case Difficulty.Easy:
                    setting = (width: 10, mines: 10);
                    break;
                case Difficulty.Normal:
                    setting = (width: 18, mines: 40);
                    break;
                case Difficulty.Hard:
                    setting = (width: 24, mines: 99);
                    break;
            }
            return setting;
        }

        //called whenever the game is over
        private void GameStatusChanged(object sender, GameEvent e) {
            if(e.Equals(GameEvent.Started)) {
                StartGame();
                return;
            }
            if(e.Equals(GameEvent.Lost)) {
                GameStatusLabel.Text = "Game Over.";
                GameStatusLabel.Visible = true;
            } else {
                GameStatusLabel.Text = "You Won!";
            }

            MineLabel.Text = "0";
            GameStatusLabel.Visible = true;
            GameField.Enabled = false;
            GameTimer.Enabled = false;
        }

        private void MineCounterChange(object sender, GameEvent e) {
            MineLabel.Text = (game.Mines - game.FlaggedMines).ToString();
        }

        private void EasyDifficulty_Click(object sender, EventArgs e) {
            difficulty = Difficulty.Easy;
            SetUpGame();
        }

        private void NormalDifficulty_Click(object sender, EventArgs e) {
            difficulty = Difficulty.Normal;
            SetUpGame();
        }

        private void HardDifficulty_Click(object sender, EventArgs e) {
            difficulty = Difficulty.Hard;
            SetUpGame();
        }

        private void ResetButton_Click(object sender, EventArgs e) {
            SetUpGame();
            timePassedInSeconds = 0;
        }

        private void PauseButton_Click(object sender, EventArgs e) {
            if (!game.Started || game.GameOver) return;
            if(paused) {
                GameStatusLabel.Visible = false;
                paused = false;
                GameField.Enabled = true;
            } else {
                GameStatusLabel.Text = "Game Paused.";
                GameStatusLabel.Visible = true;
                paused = true;
                GameField.Enabled = false;
            }
            GameTimer.Enabled = !GameTimer.Enabled;
        }

        private void GameTimer_Tick(object sender, EventArgs e) {
            timePassedInSeconds++;
            TimeLabel.Text = timePassedInSeconds.ToString();
            GameTimer.Interval = (1000);   //1 second passed
            GameTimer.Enabled = true;
            GameTimer.Start();

        }

        private void DifficultySetting_Click(object sender, EventArgs e) {

        }
    }
}
