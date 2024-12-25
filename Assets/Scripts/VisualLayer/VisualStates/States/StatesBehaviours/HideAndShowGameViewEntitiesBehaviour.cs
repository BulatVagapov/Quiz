using Cysharp.Threading.Tasks;
using Quiz.GameLayer;
using Quiz.Models;
using System.Collections.Generic;
using TMPro;

namespace Quiz.VisualLayer
{
    public class HideAndShowGameViewEntitiesBehaviour : AbstractVisualStateBehaviour
    {
        private CellForLeveViewlTuner cellForLevelTuner;
        private CellsDataForLevelGenerator cellsDataForLevelprovider;
        private LevelGenerator levelGenerator;
        private CameraPositionProvider cameraPositionProvider;
        private IEntityVisualStateHandler<List<Cell>> showingCellsHandler;
        private IEntityVisualStateHandler<List<Cell>> hidingCellsHandler;
        private IEntityVisualStateHandler<TMP_Text> showingTaskTextsHandler;
        private CellPool cellPool;
        private TaskView taskView;

        public HideAndShowGameViewEntitiesBehaviour(IEntityVisualStateHandler<List<Cell>> showingCellsHandler, IEntityVisualStateHandler<List<Cell>> hidingCellsHandler
            , IEntityVisualStateHandler<TMP_Text> showingTaskTextsHandler
    , CellPool cellPool, TaskView taskView, CellForLeveViewlTuner cellForLevelTuner, CellsDataForLevelGenerator cellsDataForLevelprovider, LevelGenerator levelGenerator
            , CameraPositionProvider cameraPositionProvider)
        {
            this.showingCellsHandler = showingCellsHandler;
            this.showingTaskTextsHandler = showingTaskTextsHandler;
            this.hidingCellsHandler = hidingCellsHandler;
            this.cellPool = cellPool;
            this.taskView = taskView;
            this.cellForLevelTuner = cellForLevelTuner;
            this.cellsDataForLevelprovider = cellsDataForLevelprovider;
            this.levelGenerator = levelGenerator;
            this.cameraPositionProvider = cameraPositionProvider;
        }

        public override async UniTask ExecutBenaviour()
        {
            await hidingCellsHandler.SetVisualState(cellPool.CellsForPreviousLevel);
            cellForLevelTuner.TuneCellForLevel(cellPool.CellsForCurrentLevel, cellsDataForLevelprovider.AllCellsForLevel, levelGenerator.Grid.Cellpositions);
            taskView.SetTaskText(cellsDataForLevelprovider.CurrentWinningCell.Symbol);
            cameraPositionProvider.SetPosition();
            await UniTask.WhenAll(showingCellsHandler.SetVisualState(cellPool.CellsForCurrentLevel), showingTaskTextsHandler.SetVisualState(taskView.TaskText)); 
        }
    }
}