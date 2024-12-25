using Quiz.Models;
using Quiz.ScriptableObjects;
using System.Collections.Generic;
using UnityEngine;

namespace Quiz.VisualLayer
{
    public class CellForLeveViewlTuner
    {
        private CellBackgroundColors cellBackgroundColors;

        public CellForLeveViewlTuner(CellBackgroundColors cellBackgroundColors)
        {
            this.cellBackgroundColors = cellBackgroundColors;
        }

        public void TuneCellForLevel(List<Cell> cells, List<CellDataModel> cellsData, List<Vector3> cellpositions)
        {
            for (int i = 0; i < cells.Count; i++)
            {
                cells[i].SetCell(cellsData[i], cellBackgroundColors.Colors[Random.Range(0, cellBackgroundColors.Colors.Length)]);
                cells[i].transform.position = cellpositions[i];
            }
        }
    }
}