using Features.GameBoard.Scripts.Domain;
using Features.GameBoard.Scripts.Domain.Action;
using NSubstitute;
using NUnit.Framework;

namespace Features.GameBoard.Tests.Editor
{
    public class GenerateBoardShould
    {
        private GenerateBoard _action;
        private const int Once = 1;

        [Test]
        public void InvokeGenerateBoardService()
        {
            var boardConfig = new BoardConfiguration(3, 3, 3);
            var boardService = Substitute.For<IBoardService>();
            GivenAnActionWith(boardService);
            WhenInvoke(boardConfig);
            ThenGenerateBoardWithConfig(boardService, boardConfig);
        }

        private void GivenAnActionWith(IBoardService boardService) => _action = new GenerateBoard(boardService);
        private void WhenInvoke(BoardConfiguration boardConfig) => _action.Invoke(boardConfig);

        private static void ThenGenerateBoardWithConfig(IBoardService boardService, BoardConfiguration boardConfig) =>
                boardService.Received(Once).GenerateBoard(boardConfig);
    }
}