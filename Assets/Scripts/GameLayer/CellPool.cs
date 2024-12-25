using Quiz.Models;
using System.Collections.Generic;
using VContainer.Unity;

namespace Quiz.GameLayer
{
    public class CellPool : IInitializable
    {
        private CellSpawner cellSpawner;
        private List<Cell> cellPool;
        private int startCellQuantity;

        public List<Cell> CellsForCurrentLevel { get; private set; }
        public List<Cell> CellsForPreviousLevel { get; private set; }

        public CellPool(CellSpawner cellSpawner, int startCellQuantity)
        {
            this.cellSpawner = cellSpawner;
            this.startCellQuantity = startCellQuantity;
            CellsForCurrentLevel = new List<Cell>();
            CellsForPreviousLevel = new List<Cell>();
        }

        private void InitialPool(int poolCount)
        {
            cellPool = new List<Cell>();

            for(int i = 0; i < poolCount; i++)
            {
                cellPool.Add(cellSpawner.SpawnCell());
            }
        }

        public void GenerateCellsFroLevel(int cellsCount)
        {
            for(int i = 0; i < CellsForPreviousLevel.Count; i++)
            {
                cellPool.Add(CellsForPreviousLevel[i]);
            }

            CellsForPreviousLevel.Clear();

            for (int i = 0; i < CellsForCurrentLevel.Count; i++)
            {
                CellsForPreviousLevel.Add(CellsForCurrentLevel[i]);
            }

            CellsForCurrentLevel.Clear();

            for(int i = 0; i < cellsCount; i++)
            {
                if (cellPool.Count > 0)
                {
                    CellsForCurrentLevel.Add(cellPool[cellPool.Count - 1]);
                    cellPool.RemoveAt(cellPool.Count - 1);
                }
                else
                {
                    CellsForCurrentLevel.Add(cellSpawner.SpawnCell());
                }

                CellsForCurrentLevel[i].gameObject.SetActive(false);
            }
        }

        public void Initialize()
        {
            InitialPool(startCellQuantity);
        }
    }
}