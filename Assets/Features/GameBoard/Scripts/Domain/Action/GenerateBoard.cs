namespace Features.GameBoard.Scripts.Domain.Action
{
    public class GenerateBoard : IGenerateBoard
    {
        private readonly IBoardService _service;

        public GenerateBoard(IBoardService service) => _service = service;

        public MineBoard Invoke(BoardConfiguration boardConfiguration) => _service.GenerateBoard(boardConfiguration);
    }
}