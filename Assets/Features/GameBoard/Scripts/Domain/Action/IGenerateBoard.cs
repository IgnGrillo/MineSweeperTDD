namespace Features.GameBoard.Scripts.Domain.Action
{
    public interface IGenerateBoard
    {
        void Invoke(BoardConfiguration boardConfiguration);
    }
}