using Features.GameBoard.Scripts.Domain;
using NUnit.Framework;

namespace Features.GameBoard.Tests.Editor
{
    public class BoardServiceShould
    {
        private BoardService _service;
        
        [Test]
        public void ReturnABoardUsingConfiguration()
        {
            var width = 5;
            var height = 3;
            var mines = 5;
            var boardConfig = new BoardConfiguration(width, height, mines);
            _service = new BoardService();
            var board = _service.GenerateBoard(boardConfig);
            Assert.IsNotNull(board);
        }
    }
}