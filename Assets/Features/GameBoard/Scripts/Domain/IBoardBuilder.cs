namespace Features.GameBoard.Scripts.Domain
{
    public interface IBoardBuilder
    {
        MineBoard BuildWith(BoardConfiguration boardConfig);
    }
}