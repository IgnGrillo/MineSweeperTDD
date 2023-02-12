using Features.GameBoard.Scripts.Domain;

namespace Features.BoardGeneration.Scripts.Domain.Services
{
    public interface IBoardGenerationService
    {
        Board GenerateBoard(BoardConfiguration boardConfig);
    }
}