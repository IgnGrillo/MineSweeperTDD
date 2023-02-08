using Features.GameBoard.Scripts.Domain;
using System.Linq;
using NSubstitute;
using NUnit.Framework;

namespace Features.GameBoard.Tests.Editor
{
    public class BoardServiceShould
    {
        private BoardService _service;
        private IBoardBuilder _boardBuilder;

        [SetUp]
        public void SetUp()
        {
            _boardBuilder = Substitute.For<IBoardBuilder>();
            _service = new BoardService(_boardBuilder);
        }

        [Test]
        public void ReturnABoardUsingConfiguration()
        {
            const int width = 5;
            const int height = 3;
            const int mines = 5;
            var boardConfig = new BoardConfiguration(width, height, mines);
            GivenABoardBuilderThatReturns(boardConfig, GivenACellArrayWith(width, height, mines));
            var board = WhenGenerateBoard(boardConfig);
            ThenAssertBoardConfigurationsAreEqualToBoardValues(board, width, height, mines);
        }

        private static Cell[,] GivenACellArrayWith(int width, int height, int amountOfMines)
        {
            var cells = new Cell[height, width];

            for (var i = 0; i < cells.GetLength(0); i++)
                for (var j = 0; j < cells.GetLength(1); j++)
                    cells[i, j] = new Cell();

            cells.Cast<Cell>().Take(amountOfMines).AsParallel().ForAll(it => it.IsBomb = true);

            return cells;
        }

        private void GivenABoardBuilderThatReturns(BoardConfiguration boardConfig, Cell[,] cells) =>
                _boardBuilder.BuildWith(boardConfig).Returns(new MineBoard(cells));

        private MineBoard WhenGenerateBoard(BoardConfiguration boardConfig) => _service.GenerateBoard(boardConfig);

        private static void ThenAssertBoardConfigurationsAreEqualToBoardValues(
                MineBoard board, int width, int height, int mines)
        {
            Assert.That(width, Is.EqualTo(board.Cells.GetLength(1)));
            Assert.That(height, Is.EqualTo(board.Cells.GetLength(0)));
            Assert.That(mines, Is.EqualTo(board.Cells.Cast<Cell>().Count(cell => cell.IsBomb)));
        }
    }
}