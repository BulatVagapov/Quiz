using Quiz.Models;
using UnityEngine;

namespace Quiz.GameLayer
{
    public class CellSpawner
    {
        private Cell cellPrefab;
        private CellClickObserver cellClickObserver;
        private Cell spawnedCell;

        public float CellWidth { get; private set; }
        public float Cellheight { get; private set; }

        public CellSpawner(Cell cellPrefab, CellClickObserver cellClickObserver)
        {
            this.cellPrefab = cellPrefab;
            this.cellClickObserver = cellClickObserver;
            CellWidth = this.cellPrefab.transform.localScale.x;
            Cellheight = this.cellPrefab.transform.localScale.y;
        }

        public Cell SpawnCell()
        {
            spawnedCell = Object.Instantiate(cellPrefab);
            spawnedCell.SetCellClickObserver(cellClickObserver);
            return spawnedCell;
        }
    }
}