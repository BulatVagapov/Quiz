using Cysharp.Threading.Tasks;
using Quiz.GameLayer;
using Quiz.Models;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

namespace Quiz.VisualLayer
{
    public class LoadingStateBehaviour : AbstractVisualStateBehaviour
    {
        private IEntityVisualStateHandler<List<Cell>> hidingCellsHandler;
        private IEntityVisualStateHandler<TMP_Text> hidingTaskTextsHandler;
        private IEntityVisualStateHandler<(Image, float, float)> faidInHandler;
        private IEntityVisualStateHandler<(Image, float, float)> faidOutHandler;
        private CellPool cellPool;
        private TaskView taskView;
        private LoadingScreen loadingScreen;
        private Loading loading;

        public LoadingStateBehaviour(IEntityVisualStateHandler<List<Cell>> hidingCellsHandler, IEntityVisualStateHandler<TMP_Text> hidingTaskTextsHandler
            , IEntityVisualStateHandler<(Image, float, float)> faidInHandler, IEntityVisualStateHandler<(Image, float, float)> faidOutHandler, CellPool cellPool, TaskView taskView
            , LoadingScreen loadingScreen, Loading loading)
        {
            this.hidingCellsHandler = hidingCellsHandler;
            this.hidingTaskTextsHandler = hidingTaskTextsHandler;
            this.faidInHandler = faidInHandler;
            this.faidOutHandler = faidOutHandler;
            this.cellPool = cellPool;
            this.taskView = taskView;
            this.loadingScreen = loadingScreen;
            this.loading = loading;
        }

        public override async UniTask ExecutBenaviour()
        {
            loadingScreen.ActivateScreen();
            await faidInHandler.SetVisualState((loadingScreen.BackgroundImage, 1f, loading.LoadingTimeInSeconds/2));
            await hidingCellsHandler.SetVisualState(cellPool.CellsForCurrentLevel);
            await hidingTaskTextsHandler.SetVisualState(taskView.TaskText);
            await faidOutHandler.SetVisualState((loadingScreen.BackgroundImage, 0f, loading.LoadingTimeInSeconds / 2));
            loadingScreen.DisactivateScreen();
        }
    }
}