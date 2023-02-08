namespace Features.GameBoard.Scripts.Domain
{
    public class BoardService : IBoardService
    {
        private readonly IBoardBuilder _boardBuilder;

        public BoardService(IBoardBuilder boardBuilder)
        {
            _boardBuilder = boardBuilder;
        }

        public MineBoard GenerateBoard(BoardConfiguration boardConfig)
        {
            return _boardBuilder.BuildWith(boardConfig);
        }
    }
}