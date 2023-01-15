using Features.GameBoard.Scripts.Domain;
using Features.GameBoard.Scripts.Domain.Action;

namespace Features.GameBoard.Scripts.Presentation
{
    public class GameBoardPresenter
    {
        private readonly IGenerateBoard _generateBoard;

        public GameBoardPresenter(IGenerateBoard generateBoard)
        {
            _generateBoard = generateBoard;
        }
        
        public void Initialize(BoardConfiguration boardConfiguration)
        {
            _generateBoard.Invoke(boardConfiguration);
        }
    }
}