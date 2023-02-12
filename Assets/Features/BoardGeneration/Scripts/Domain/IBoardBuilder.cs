using Features.GameBoard.Scripts.Domain;

namespace Features.BoardGeneration.Scripts.Domain
{
    public interface IBoardBuilder
    {
        Board BuildWith(BoardConfiguration boardConfig);
    }
}