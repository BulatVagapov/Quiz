using Quiz.GameLayer;

namespace Quiz.VisualLayer
{
    public class TransitionBetweenLevelsVisualState : AbstractVisualStateWithStateWait
    {
        private GameCyclePresenter gameCyclePresenter;
        
        public TransitionBetweenLevelsVisualState(GameCyclePresenter gameCyclePresenter
            , AbstractVisualState expectedState, AbstractVisualStateBehaviour stateBehaviour, params IEndOfVisualStateEventObserver[] observers)
            : base(expectedState, stateBehaviour, observers)
        {
            this.gameCyclePresenter = gameCyclePresenter;
        }

        public override void Initialize()
        {
            base.Initialize();
            gameCyclePresenter.NewLevelStartedEvent += AddExecuteToStateIsIverEvent;
        }
    }
}