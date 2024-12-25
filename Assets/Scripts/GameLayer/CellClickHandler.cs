using Quiz.Models;
using System;
using VContainer.Unity;

namespace Quiz.GameLayer
{
    public class CellClickHandler : IInitializable
    {
        private CellClickObserver cellClickObserver;
        private CellsDataForLevelGenerator cellsDataProvider;
        public Cell CurrentCell { get; private set; }

        public event Action PlayerWinEvent;
        public event Action PlayerLostEvent;

        public CellClickHandler(CellClickObserver cellClickObserver, CellsDataForLevelGenerator cellsDataProvider)
        {
            this.cellClickObserver = cellClickObserver;
            this.cellsDataProvider = cellsDataProvider;
        }

        public void Initialize()
        {
            cellClickObserver.CellClickedEvent += OnCellClicked;
        }

        private void OnCellClicked(Cell clickedCell)
        {
            CurrentCell = clickedCell;
            if (clickedCell.Symbol.Equals(cellsDataProvider.CurrentWinningCell.Symbol))
            {
                PlayerWinEvent?.Invoke();
            }
            else
            {
                PlayerLostEvent?.Invoke();
            }
        }
    }
}