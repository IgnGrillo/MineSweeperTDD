using Features.GameBoard.Scripts.Domain.Action;

namespace Features.GameBoard.Scripts.Domain
{
    public interface IBoardService
    {
        MineBoard GenerateBoard(BoardConfiguration boardConfig);
    }
}