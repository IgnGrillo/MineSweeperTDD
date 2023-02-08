using System.Collections;
using System.Linq;
using UnityEngine;

namespace Features.GameBoard.Scripts.Domain
{
    public class BoardBuilder : IBoardBuilder
    {
        public MineBoard BuildWith(BoardConfiguration boardConfig)
        {
            var cells = new Cell[boardConfig.Height, boardConfig.Width];
            InitializeCells(cells);
            PlaceMinesInCells(boardConfig.AmountOfMines, cells);
            return new MineBoard(cells);
        }

        private static void InitializeCells(Cell[,] cells)
        {
            for (var i = 0; i < cells.GetLength(0); i++)
                for (var j = 0; j < cells.GetLength(1); j++)
                    cells[i, j] = new Cell();
        }

        private static void PlaceMinesInCells(int amountOfMines, IEnumerable cells)
        {
            var random = new System.Random();
            cells.Cast<Cell>()
                 .OrderBy(x => random.Next(0, 100))
                 .Take(amountOfMines)
                 .AsParallel()
                 .ForAll(it=> it.IsBomb = true);
        }
    }
}