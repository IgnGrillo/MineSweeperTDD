using Features.GameBoard.Scripts.Domain;

namespace Features.BoardGeneration.Scripts.Domain.Services
{
    public class BoardGenerationService : IBoardGenerationService
    {
        private readonly IBoardBuilder _boardBuilder;

        public BoardGenerationService(IBoardBuilder boardBuilder)
        {
            _boardBuilder = boardBuilder;
        }

        public Board GenerateBoard(BoardConfiguration boardConfig)
        {
            return _boardBuilder.BuildWith(boardConfig);
        }
    }
}