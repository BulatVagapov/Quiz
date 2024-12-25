using Cysharp.Threading.Tasks;
using Quiz.GameLayer;
using Quiz.Models;
using System.Collections.Generic;
using TMPro;

namespace Quiz.VisualLayer
{
    public class ShowGameViewEntitiesBehaviour : AbstractVisualStateBehaviour
    {
        private CellForLeveViewlTuner cellForLevelTuner;
        private CellsDataForLevelGenerator cellsDataForLevelprovider;
        private LevelGenerator levelGenerator;
        private IEntityVisualStateHandler<List<Cell>> showingCellsHandler;
        private IEntityVisualStateHandler<TMP_Text> showingTaskTextsHandler;
        private CellPool cellPool;
        private TaskView taskView;

        public ShowGameViewEntitiesBehaviour(IEntityVisualStateHandler<List<Cell>> showingCellsHandler, IEntityVisualStateHandler<TMP_Text> showingTaskTextsHandler
            , CellPool cellPool, TaskView taskView, CellForLeveViewlTuner cellForLevelTuner, CellsDataForLevelGenerator cellsDataForLevelprovider, LevelGenerator levelGenerator)
        {
            this.showingCellsHandler = showingCellsHandler;
            this.showingTaskTextsHandler = showingTaskTextsHandler;
            this.cellPool = cellPool;
            this.taskView = taskView;
            this.cellForLevelTuner = cellForLevelTuner;
            this.cellsDataForLevelprovider = cellsDataForLevelprovider;
            this.levelGenerator = levelGenerator;
        }

        public override async UniTask ExecutBenaviour()
        {
            cellForLevelTuner.TuneCellForLevel(cellPool.CellsForCurrentLevel, cellsDataForLevelprovider.AllCellsForLevel, levelGenerator.Grid.Cellpositions);
            taskView.SetTaskText(cellsDataForLevelprovider.CurrentWinningCell.Symbol);
            await showingCellsHandler.SetVisualState(cellPool.CellsForCurrentLevel);
            await showingTaskTextsHandler.SetVisualState(taskView.TaskText);
        }
    }
}