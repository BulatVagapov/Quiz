using Quiz.Models;
using System;

namespace Quiz.GameLayer
{
    public class CellClickObserver
    {
        public event Action<Cell> CellClickedEvent;

        public void OnCellClick(Cell clickedCell)
        {
            CellClickedEvent?.Invoke(clickedCell);
        }
    }
}