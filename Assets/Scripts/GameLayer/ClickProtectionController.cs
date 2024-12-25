using Quiz.VisualLayer;
using UnityEngine;
using VContainer.Unity;

namespace Quiz.GameLayer
{
    public class ClickProtectionController : IInitializable, IEndOfVisualStateEventObserver
    {
        private GameObject clickProtectionPanel;
        private CellClickHandler cellClickHandler;

        public ClickProtectionController(GameObject clickProtectionPanel, CellClickHandler cellClickHandler)
        {
            this.clickProtectionPanel = clickProtectionPanel;
            this.cellClickHandler = cellClickHandler;
        }

        public void Initialize()
        {
            cellClickHandler.PlayerWinEvent += OnPlayerWin;
        }

        public void OnVisualStateIsOver()
        {
            clickProtectionPanel.gameObject.SetActive(false);
        }

        private void OnPlayerWin()
        {
            clickProtectionPanel.gameObject.SetActive(true);
        }
    }
}