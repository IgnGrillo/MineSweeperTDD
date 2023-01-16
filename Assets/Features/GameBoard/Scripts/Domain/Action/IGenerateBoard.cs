namespace Features.GameBoard.Scripts.Domain.Action
{
    public interface IGenerateBoard
    {
        MineBoard Invoke(BoardConfiguration boardConfiguration);
    }
}