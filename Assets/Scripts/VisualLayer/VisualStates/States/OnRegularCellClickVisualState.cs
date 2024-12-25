using Quiz.GameLayer;

namespace Quiz.VisualLayer
{
    public class OnRegularCellClickVisualState : AbstractVisualState
    {
        private CellClickHandler cellClickHandler;

        public OnRegularCellClickVisualState(CellClickHandler cellClickHandler
            , AbstractVisualStateBehaviour stateBehaviour, params IEndOfVisualStateEventObserver[] observers)
            : base(stateBehaviour, observers)
        {
            this.cellClickHandler = cellClickHandler;
        }

        public override void Initialize()
        {
            base.Initialize();
            cellClickHandler.PlayerLostEvent += ExetuteState;
        }
    }
}