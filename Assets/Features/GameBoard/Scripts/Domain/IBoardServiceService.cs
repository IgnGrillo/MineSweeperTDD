using Features.GameBoard.Scripts.Domain.Action;

namespace Features.GameBoard.Scripts.Domain
{
    public interface IBoardServiceService
    {
        MineBoard GenerateBoard(BoardConfiguration boardConfig);
    }
}