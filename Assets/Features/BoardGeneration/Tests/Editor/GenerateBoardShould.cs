using Features.BoardGeneration.Scripts.Domain;
using Features.BoardGeneration.Scripts.Domain.Action;
using Features.BoardGeneration.Scripts.Domain.Services;
using NSubstitute;
using NUnit.Framework;

namespace Features.BoardGeneration.Tests.Editor
{
    public class GenerateBoardShould
    {
        private GenerateBoard _action;
        private const int Once = 1;

        [Test]
        public void InvokeGenerateBoardService()
        {
            var boardConfig = new BoardConfiguration(3, 3, 3);
            var boardService = Substitute.For<IBoardGenerationService>();
            GivenAnActionWith(boardService);
            WhenInvoke(boardConfig);
            ThenGenerateBoardWithConfig(boardService, boardConfig);
        }

        private void GivenAnActionWith(IBoardGenerationService boardService) => _action = new GenerateBoard(boardService);
        private void WhenInvoke(BoardConfiguration boardConfig) => _action.Invoke(boardConfig);

        private static void ThenGenerateBoardWithConfig(IBoardGenerationService boardService, BoardConfiguration boardConfig) =>
                boardService.Received(Once).GenerateBoard(boardConfig);
    }
}