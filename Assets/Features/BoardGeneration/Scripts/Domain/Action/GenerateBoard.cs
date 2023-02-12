using Features.BoardGeneration.Scripts.Domain.Services;
using Features.GameBoard.Scripts.Domain;

namespace Features.BoardGeneration.Scripts.Domain.Action
{
    public class GenerateBoard : IGenerateBoard
    {
        private readonly IBoardGenerationService _service;

        public GenerateBoard(IBoardGenerationService service) => _service = service;

        public Board Invoke(BoardConfiguration boardConfiguration) => _service.GenerateBoard(boardConfiguration);
    }
}