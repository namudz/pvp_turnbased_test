namespace Game.Turn
{
    public class TurnTypes
    {
        public enum Turn
        {
            Player_1,
            Player_2,
            CPU
        }

        public enum PlayerTurnStates
        {
            Select,
            Action
        }
    }
}