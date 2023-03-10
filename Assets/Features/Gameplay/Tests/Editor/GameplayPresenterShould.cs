using Features.BoardGeneration.Scripts.Domain;
using Features.BoardGeneration.Scripts.Domain.Action;
using Features.GameBoard.Scripts.Presentation;
using NSubstitute;
using NUnit.Framework;

namespace Features.Gameplay.Tests.Editor
{
    public class GameplayPresenterShould
    {
        private GameplayPresenter _presenter;
        private const int Once = 1;

        [Test]
        public void GenerateABoardOnInitialization()
        {
            var width = 3;
            var height = 3;
            var amountOfMines = 3;
            var boardConfiguration = new BoardConfiguration(width, height, amountOfMines);
            var generateBoard = GivenAGenerateBoard();
            _presenter = GivenAPresenterWith(generateBoard);
            WhenPresenterIsInitialized(boardConfiguration);
            ThenGenerateBoardIsInvoked(generateBoard, boardConfiguration);
        }

        private static GameplayPresenter GivenAPresenterWith(IGenerateBoard generateBoard) => new(generateBoard);
        private static IGenerateBoard GivenAGenerateBoard() => Substitute.For<IGenerateBoard>();
        private void WhenPresenterIsInitialized(BoardConfiguration boardConfiguration) => _presenter.Initialize(boardConfiguration);
        private static void ThenGenerateBoardIsInvoked(IGenerateBoard generateBoard, BoardConfiguration boardConfiguration) => generateBoard.Received(Once).Invoke(boardConfiguration);
        
    }
}