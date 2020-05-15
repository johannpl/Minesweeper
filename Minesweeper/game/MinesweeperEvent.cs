using System;
    public enum GameEvent {
        Started, Uncovered, Flagged, Unflagged, Won, Lost
    }
    
    public class MinesweeperEvent : EventArgs {
        public GameEvent Event { get; set; }

        public MinesweeperEvent(GameEvent e) {
            Event = e;
        }
    }


