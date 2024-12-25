using Quiz.Models;
using System;

namespace Quiz.GameLayer
{
    public class LevelGenerator
    {
        private GridGenerator gridGenerator;
        private CellsDataForLevelGenerator cellsDataForLevelprovider;
        private CellPool cellPool;
        public GridModel Grid { get; private set; }
        public event Action GridIsGeneratedEvent;

        public LevelGenerator(GridGenerator gridGenerator, CellsDataForLevelGenerator cellsDataForLevelprovider, CellPool cellPool)
        {
            this.gridGenerator = gridGenerator;
            this.cellsDataForLevelprovider = cellsDataForLevelprovider;
            this.cellPool = cellPool;
        }

        public void GenerateLevel(GridSize gridSize)
        {
            Grid = gridGenerator.Build(gridSize);
            GridIsGeneratedEvent?.Invoke();
            cellsDataForLevelprovider.GenerateCellsDataForLevel(gridSize.Size);
            cellPool.GenerateCellsFroLevel(gridSize.Size);
        }
    }
}