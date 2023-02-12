namespace Features.GameBoard.Scripts.Domain
{
    public class Board
    {
        public Cell[,] Cells { get; }

        public Board(Cell[,] cells) => Cells = cells;
    }
}