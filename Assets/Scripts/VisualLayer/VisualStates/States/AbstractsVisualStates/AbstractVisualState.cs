using Cysharp.Threading.Tasks;
using System;
using VContainer.Unity;

namespace Quiz.VisualLayer
{
    public abstract class AbstractVisualState : IInitializable
    {
        protected AbstractVisualStateBehaviour stateBehaviour;
        protected IEndOfVisualStateEventObserver[] observers;

        public event Action StateIsOverEvent;

        protected AbstractVisualState(AbstractVisualStateBehaviour stateBehaviour, params IEndOfVisualStateEventObserver[] observers)
        {
            this.stateBehaviour = stateBehaviour;
            this.observers = observers;
        }

        public virtual void Initialize()
        {
            if (observers.Length == 0) return;
            StateIsOverEvent += OnStateIsOver;
        }

        protected virtual async UniTask ExecuteStateAsync()
        {
            await stateBehaviour.ExecutBenaviour();
            StateIsOverEvent?.Invoke();
        }

        public void ExetuteState()
        {
            ExecuteStateAsync().Forget();
        }

        protected virtual void OnStateIsOver()
        {
            for (int i = 0; i < observers.Length; i++)
            {
                observers[i].OnVisualStateIsOver();
            }
        }
    }
}