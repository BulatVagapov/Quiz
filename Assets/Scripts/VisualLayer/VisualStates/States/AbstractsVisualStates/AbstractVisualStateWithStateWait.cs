using Cysharp.Threading.Tasks;

namespace Quiz.VisualLayer
{
    public abstract class AbstractVisualStateWithStateWait : AbstractVisualState
    {
        private AbstractVisualState expectedState;
        
        public AbstractVisualStateWithStateWait(AbstractVisualState expectedState, AbstractVisualStateBehaviour stateBehaviour, params IEndOfVisualStateEventObserver[] observers)
            : base(stateBehaviour, observers)
        {
            this.expectedState = expectedState;
        }

        public void AddExecuteToStateIsIverEvent()
        {
            expectedState.StateIsOverEvent += ExetuteState;
        }

        protected override async UniTask ExecuteStateAsync()
        {
            await base.ExecuteStateAsync();
            expectedState.StateIsOverEvent -= ExetuteState;
        }
    }
}