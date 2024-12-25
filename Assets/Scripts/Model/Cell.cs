using Quiz.GameLayer;
using Quiz.VisualLayer;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Quiz.Models
{
    public class Cell : MonoBehaviour, IPointerClickHandler
    {
        private CellClickObserver cellClickObserver;
        public string Symbol { get; private set; }

        [SerializeField] private CellView cellView;
        public Transform SymbolViewTransform => cellView.SymbolSpriteRenderer.transform;

        public void SetCell(CellDataModel cellData, Color backgroundColor)
        {
            Symbol = cellData.Symbol;
            cellView.SetCellSymbolView(cellData, backgroundColor);
        }

        public void SetCellClickObserver(CellClickObserver cellClickObserver)
        {
            this.cellClickObserver = cellClickObserver;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            cellClickObserver.OnCellClick(this);
        }
    }
}