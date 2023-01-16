namespace Features.GameBoard.Scripts.Domain.Action
{
    public class GenerateBoard : IGenerateBoard
    {
        private readonly IBoardServiceService _service;

        public GenerateBoard(IBoardServiceService service) => _service = service;

        public MineBoard Invoke(BoardConfiguration boardConfiguration) => _service.GenerateBoard(boardConfiguration);
    }
}