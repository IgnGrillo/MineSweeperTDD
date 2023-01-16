using System.Collections.Generic;
using System.Linq;
using Features.GameBoard.Scripts.Domain.Action;
using UnityEngine;

namespace Features.GameBoard.Scripts.Domain
{
    public class BoardService : IBoardService
    {
        public MineBoard GenerateBoard(BoardConfiguration boardConfig)
        {
            var cells = new Cell[boardConfig.Height, boardConfig.Width];
            GenerateCells(cells);
            PlaceMinesInCells(boardConfig, cells);
            return new MineBoard(cells);
        }

        private static void GenerateCells(Cell[,] cells)
        {
            for (var i = 0; i < cells.GetLength(0); i++)
                for (var j = 0; j < cells.GetLength(1); j++)
                    cells[i, j] = new Cell();
        }

        private static void PlaceMinesInCells(BoardConfiguration boardConfig, Cell[,] cells)
        {
            var minePositions = GetMinesPositions();
            foreach (var currentMinePosition in minePositions)
            {
                var translatedPos = TranslateMineNumberToXYCoordinate(boardConfig.Width, currentMinePosition);
                cells[translatedPos.x, translatedPos.y].IsBomb = true;
            }

            (int x, int y) TranslateMineNumberToXYCoordinate(int width, int mineNumber)
            {
                var yPosition = (mineNumber - 1) / width;
                var xPosition = mineNumber - yPosition * width - 1;
                return (yPosition, xPosition);
            }

            IEnumerable<int> GetMinesPositions()
            {
                var currentCellsWithMines = new List<int>();
                var unselectedPositions = new List<int>();
                for (var i = 0; i < boardConfig.Width * boardConfig.Height; i++)
                    unselectedPositions.Add(i + 1);

                for (var i = 0; i < boardConfig.AmountOfMines; i++)
                {
                    var randomIndex = Random.Range(0, unselectedPositions.Count);
                    currentCellsWithMines.Add(unselectedPositions[randomIndex]);
                    unselectedPositions.RemoveAt(randomIndex);
                }

                return currentCellsWithMines;
            }
        }
    }
}