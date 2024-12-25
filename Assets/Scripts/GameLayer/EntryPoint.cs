using VContainer.Unity;

namespace Quiz.GameLayer
{
    public class EntryPoint : IStartable
    {
        private GameCyclePresenter gameCyclePresenter;

        public EntryPoint(GameCyclePresenter gameCyclePresenter)
        {
            this.gameCyclePresenter = gameCyclePresenter;
        }

        public void Start()
        {
            gameCyclePresenter.StartGameCycle();
        }
    }
}