using Quiz.GameLayer;

namespace Quiz.VisualLayer
{
    public class LoadingVisualState : AbstractVisualState
    {
        private GameCycleRestarter gameCycleRestarter;
        
        public LoadingVisualState(GameCycleRestarter gameCycleRestarter
            , AbstractVisualStateBehaviour stateBehaviour, params IEndOfVisualStateEventObserver[] observers)
            : base(stateBehaviour, observers)
        {
            this.gameCycleRestarter = gameCycleRestarter;
        }

        public override void Initialize()
        {
            base.Initialize();
            gameCycleRestarter.GameRestartedEvent += ExetuteState;
        }
    }
}