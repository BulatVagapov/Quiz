using Quiz.ScriptableObjects;
using System;
using VContainer.Unity;

namespace Quiz.GameLayer
{
    public class GameCyclePresenter : IInitializable
    {
        private GridSizes gridSizes;
        private LevelGenerator levelGenerator;
        private CellClickHandler cellClickHandler;
        private int currentLevel = 0;

        public GameCyclePresenter(GridSizes gridSizes, LevelGenerator levelGenerator, CellClickHandler cellClickHandler)
        {
            this.gridSizes = gridSizes;
            this.levelGenerator = levelGenerator;
            this.cellClickHandler = cellClickHandler;
        }

        public int CurrrenLevel => currentLevel;

        public event Action GameCycleStartedEvent;
        public event Action NewLevelStartedEvent;
        public event Action GameCycleIsOverEvent;

        public void ResetGameCycle()
        {
            currentLevel = 0;
        }

        public void StartGameCycle()
        {
            levelGenerator.GenerateLevel(gridSizes.Sizes[currentLevel]);
            GameCycleStartedEvent?.Invoke();
        }

        public void Initialize()
        {
            cellClickHandler.PlayerWinEvent += OnPlayerWin;
            currentLevel = 0;
        }

        private void OnPlayerWin()
        {
            currentLevel++;

            if (currentLevel >= gridSizes.Sizes.Length)
            {
                GameCycleIsOverEvent?.Invoke();
            }
            else
            {
                levelGenerator.GenerateLevel(gridSizes.Sizes[currentLevel]);
                NewLevelStartedEvent?.Invoke();
            }
        }
    }
}