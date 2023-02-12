using Features.BoardGeneration.Scripts.Domain;
using Features.BoardGeneration.Scripts.Domain.Action;

namespace Features.GameBoard.Scripts.Presentation
{
    public class GameplayPresenter
    {
        private readonly IGenerateBoard _generateBoard;

        public GameplayPresenter(IGenerateBoard generateBoard)
        {
            _generateBoard = generateBoard;
        }
        
        public void Initialize(BoardConfiguration boardConfiguration)
        {
            _generateBoard.Invoke(boardConfiguration);
        }
    }
}