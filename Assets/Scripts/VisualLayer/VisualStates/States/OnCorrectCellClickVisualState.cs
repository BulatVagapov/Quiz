using Quiz.GameLayer;

namespace Quiz.VisualLayer
{
    public class OnCorrectCellClickVisualState : AbstractVisualState
    {
        private CellClickHandler cellClickHandler;
        
        public OnCorrectCellClickVisualState(CellClickHandler cellClickHandler
            , AbstractVisualStateBehaviour stateBehaviour, params IEndOfVisualStateEventObserver[] observers)
            : base(stateBehaviour, observers)
        {
            this.cellClickHandler = cellClickHandler;
        }

        public override void Initialize()
        {
            base.Initialize();
            cellClickHandler.PlayerWinEvent += ExetuteState;
        }
    }
}