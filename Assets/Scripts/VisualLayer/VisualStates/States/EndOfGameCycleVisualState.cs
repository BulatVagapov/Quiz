using Quiz.GameLayer;

namespace Quiz.VisualLayer
{
    public class EndOfGameCycleVisualState : AbstractVisualStateWithStateWait
    {
        private GameCyclePresenter gameCyclePresenter;

        public EndOfGameCycleVisualState(GameCyclePresenter gameCyclePresenter
            , AbstractVisualState expectedState, AbstractVisualStateBehaviour stateBehaviour, params IEndOfVisualStateEventObserver[] observers)
            : base(expectedState, stateBehaviour, observers)
        {
            this.gameCyclePresenter = gameCyclePresenter;
        }

        public override void Initialize()
        {
            gameCyclePresenter.GameCycleIsOverEvent += AddExecuteToStateIsIverEvent;
        }
    }
}