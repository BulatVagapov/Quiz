using Quiz.Models;
using Quiz.ScriptableObjects;
using System.Collections.Generic;
using UnityEngine;

namespace Quiz.GameLayer
{
    public class CellsDataForLevelGenerator
    {
        private DataForCells dataForCells;

        private UniqueIndexProvider[] winCellIndexProviders;
        private UniqueIndexProvider[] regularCellIndexProviders;

        private int randomCategoryIndex = -1;
        private int winCellIndex = -1;
        private int placeWinCellInAllCells = -1;
        private int regularCellIndex = -1;

        public CellDataModel CurrentWinningCell { get; private set; }
        public List<CellDataModel> AllCellsForLevel { get; private set; } = new List<CellDataModel>();

        public event System.Action DataForLevelGeneratedEvent;

        public CellsDataForLevelGenerator(DataForCells dataForCells)
        {
            this.dataForCells = dataForCells;

            winCellIndexProviders = new UniqueIndexProvider[this.dataForCells.Data.Length];
            regularCellIndexProviders = new UniqueIndexProvider[this.dataForCells.Data.Length];

            for(int i = 0; i < this.dataForCells.Data.Length; i++)
            {
                winCellIndexProviders[i] = new UniqueIndexProvider(this.dataForCells.Data[i].Category.Length);
                regularCellIndexProviders[i] = new UniqueIndexProvider(this.dataForCells.Data[i].Category.Length);
            }
        }

        public void GenerateCellsDataForLevel(int cellForLevelCount)
        {
            AllCellsForLevel.Clear();
            randomCategoryIndex = Random.Range(0, dataForCells.Data.Length);
            winCellIndex = winCellIndexProviders[randomCategoryIndex].GetUniqueIndex();
            regularCellIndexProviders[randomCategoryIndex].SetExcludedIndex(winCellIndex);
            placeWinCellInAllCells = Random.Range(0, cellForLevelCount);

            for (int i = 0; i < cellForLevelCount; i++)
            {
                if(i == placeWinCellInAllCells)
                {
                    CurrentWinningCell = dataForCells.Data[randomCategoryIndex].Category[winCellIndex];
                    AllCellsForLevel.Add(CurrentWinningCell);
                }
                else
                {
                    regularCellIndex = regularCellIndexProviders[randomCategoryIndex].GetUniqueIndex();
                    AllCellsForLevel.Add(dataForCells.Data[randomCategoryIndex].Category[regularCellIndex]);
                }
            }

            DataForLevelGeneratedEvent?.Invoke();
        }
    }
}