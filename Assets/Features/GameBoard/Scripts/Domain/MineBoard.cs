namespace Features.GameBoard.Scripts.Domain
{
    public class MineBoard
    {
        public Cell[,] Cells { get; }

        public MineBoard(Cell[,] cells) => Cells = cells;
    }
}