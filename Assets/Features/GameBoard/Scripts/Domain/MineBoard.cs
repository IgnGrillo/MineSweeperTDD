namespace Features.GameBoard.Scripts.Domain.Action
{
    public class MineBoard
    {
        private readonly Cell[,] _cells;

        public MineBoard(Cell[,] cells)
        {
            _cells = cells;
        }
    }
}