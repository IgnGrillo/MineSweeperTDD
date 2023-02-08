namespace Features.GameBoard.Scripts.Domain
{
    public readonly struct BoardConfiguration
    {
        public int Width { get; }
        public int Height { get; }
        public int AmountOfMines { get; }

        public BoardConfiguration(int width, int height, int amountOfMines)
        {
            Width = width;
            Height = height;
            AmountOfMines = amountOfMines;
        }
    }
}