using Quiz.GameLayer;

namespace Quiz.VisualLayer
{
    public class StartGameCycleVisualState : AbstractVisualState
    {
        private GameCyclePresenter gameCyclePresenter;

        public StartGameCycleVisualState(GameCyclePresenter gameCyclePresenter
            , AbstractVisualStateBehaviour stateBehaviour, params IEndOfVisualStateEventObserver[] observers)
            : base(stateBehaviour, observers)
        {
            this.gameCyclePresenter = gameCyclePresenter;
        }

        public override void Initialize()
        {
            base.Initialize();
            gameCyclePresenter.GameCycleStartedEvent += ExetuteState;
        }
    }
}