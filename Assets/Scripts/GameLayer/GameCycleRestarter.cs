using System;
using VContainer.Unity;

namespace Quiz.GameLayer
{
    public class GameCycleRestarter : IInitializable
    {
        private GameCyclePresenter gameCyclePresenter;
        private EndOfGameCycleScreen endOfGameCycleScreen;
        private Loading loading;

        public event Action GameRestartedEvent;

        public GameCycleRestarter(EndOfGameCycleScreen endOfGameCycleScreen, GameCyclePresenter gameCyclePresenter, Loading loading)
        {
            this.endOfGameCycleScreen = endOfGameCycleScreen;
            this.gameCyclePresenter = gameCyclePresenter;
            this.loading = loading;
        }

        public void RestartGameCycle()
        {
            gameCyclePresenter.ResetGameCycle();
            GameRestartedEvent?.Invoke();
            loading.StartLoading();
        }

        public void Initialize()
        {
            endOfGameCycleScreen.RestartButton.onClick.AddListener(RestartGameCycle);
            loading.LoadingIsOverEvent += gameCyclePresenter.StartGameCycle;
        }
    }
}