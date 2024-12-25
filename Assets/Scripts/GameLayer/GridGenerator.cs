using Quiz.Models;
using System.Collections.Generic;
using UnityEngine;

namespace Quiz.GameLayer
{
    public class GridGenerator
    {
        private List<Vector3> gridPositions = new List<Vector3>();
        private Vector3 centerOfGrid = Vector3.zero;
        private CellSpawner cellSpawner;

        public GridGenerator(CellSpawner cellSpawner)
        {
            this.cellSpawner = cellSpawner;
        }

        public GridModel Build(GridSize gridData)
        {
            gridPositions.Clear();

            for (int x = 0; x < gridData.Columns; x++)
            {
                for (int y = 0; y < gridData.Rows; y++)
                {
                    gridPositions.Add(new Vector3(x * cellSpawner.CellWidth, y * cellSpawner.Cellheight, 0));
                }
            }

            centerOfGrid.x = ((gridData.Columns * cellSpawner.CellWidth) / 2) - (cellSpawner.CellWidth / 2);
            centerOfGrid.y = ((gridData.Rows * cellSpawner.Cellheight) / 2) - (cellSpawner.Cellheight / 2);
            return new GridModel(gridPositions, centerOfGrid);
        }
    }
}

