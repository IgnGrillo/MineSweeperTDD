namespace Features.GameBoard.Scripts.Domain
{
    public readonly struct BoardConfiguration
    {
        private readonly int _width;
        private readonly int _height;
        private readonly int _amountOfMines;

        public int Width => _width;
        public int Height => _height;
        public int AmountOfMines => _amountOfMines;
        
        public BoardConfiguration(int width, int height, int amountOfMines)
        {
            _width = width;
            _height = height;
            _amountOfMines = amountOfMines;
        }
    }
}