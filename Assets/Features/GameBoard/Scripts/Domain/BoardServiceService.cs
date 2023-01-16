using Features.GameBoard.Scripts.Domain.Action;

namespace Features.GameBoard.Scripts.Domain
{
    public class BoardServiceService : IBoardServiceService
    {
        public MineBoard GenerateBoard(BoardConfiguration boardConfig)
        {
            return new MineBoard();
        }
    }
}