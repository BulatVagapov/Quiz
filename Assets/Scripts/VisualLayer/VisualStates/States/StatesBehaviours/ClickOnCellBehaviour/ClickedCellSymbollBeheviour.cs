using Cysharp.Threading.Tasks;
using Quiz.GameLayer;
using Quiz.Models;
using UnityEngine;

namespace Quiz.VisualLayer
{
    public class ClickedCellSymbollBeheviour : AbstractVisualStateBehaviour
    {
        protected IEntityVisualStateHandler<Transform> transformEffect;
        protected CellClickHandler cellClickHandler;
        protected Cell currentClickedCell;

        public ClickedCellSymbollBeheviour(IEntityVisualStateHandler<Transform> transformEffect, CellClickHandler cellClickHandler)
        {
            this.transformEffect = transformEffect;
            this.cellClickHandler = cellClickHandler;
        }

        public override async UniTask ExecutBenaviour()
        {
            await OnCellClickBehaviourAsync(cellClickHandler.CurrentCell);
        }

        protected async UniTask OnCellClickBehaviourAsync(Cell clicckedCell)
        {
            if (currentClickedCell != null && currentClickedCell.Equals(clicckedCell)) return;
            currentClickedCell = clicckedCell;
            await AwaitableBehaviourAsync(clicckedCell);
            currentClickedCell = null;
        }

        protected virtual async UniTask AwaitableBehaviourAsync(Cell clicckedCell)
        {
            await transformEffect.SetVisualState(clicckedCell.SymbolViewTransform);
        }
    }
}