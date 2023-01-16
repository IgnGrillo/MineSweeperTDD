namespace Features.GameBoard.Scripts.Domain
{
    public class Cell
    {
        private bool _isBomb;

        public bool IsBomb
        {
            set => _isBomb = value;
        }
    }
}