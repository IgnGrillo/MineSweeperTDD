using System.Linq;
using Features.BoardGeneration.Scripts.Domain;
using Features.BoardGeneration.Scripts.Domain.Services;
using Features.GameBoard.Scripts.Domain;
using NSubstitute;
using NUnit.Framework;

namespace Features.BoardGeneration.Tests.Editor
{
    public class BoardGenerationServiceShould
    {
        private BoardGenerationService _generationService;
        private IBoardBuilder _boardBuilder;

        [SetUp]
        public void SetUp()
        {
            _boardBuilder = Substitute.For<IBoardBuilder>();
            _generationService = new BoardGenerationService(_boardBuilder);
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
                _boardBuilder.BuildWith(boardConfig).Returns(new Board(cells));

        private Board WhenGenerateBoard(BoardConfiguration boardConfig) => _generationService.GenerateBoard(boardConfig);

        private static void ThenAssertBoardConfigurationsAreEqualToBoardValues(
                Board board, int width, int height, int mines)
        {
            Assert.That(width, Is.EqualTo(board.Cells.GetLength(1)));
            Assert.That(height, Is.EqualTo(board.Cells.GetLength(0)));
            Assert.That(mines, Is.EqualTo(board.Cells.Cast<Cell>().Count(cell => cell.IsBomb)));
        }
    }
}