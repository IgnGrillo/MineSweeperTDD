using Features.GameBoard.Scripts.Domain;

namespace Features.BoardGeneration.Scripts.Domain.Action
{
    public interface IGenerateBoard
    {
        Board Invoke(BoardConfiguration boardConfiguration);
    }
}