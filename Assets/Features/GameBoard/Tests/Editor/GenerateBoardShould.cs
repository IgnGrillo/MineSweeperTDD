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
            var service = Substitute.For<IBoardServiceService>();
            _action = new GenerateBoard(service);
            _action.Invoke(boardConfig);
            service.Received(Once).GenerateBoard(boardConfig);
        }
    }
}