using Features.GameBoard.Scripts.Domain.Action;

namespace Features.GameBoard.Scripts.Domain
{
    public class BoardService : IBoardService
    {
        public MineBoard GenerateBoard(BoardConfiguration boardConfig)
        {
            return new MineBoard();
        }
    }
}