using Cysharp.Threading.Tasks;
using UnityEngine.UI;

namespace Quiz.VisualLayer
{
    public class ShowEndOfCycleScreenEntitiesBehaviour : AbstractVisualStateBehaviour
    {
        private EndOfGameCycleScreen endOfGameCycleScreen;
        private IEntityVisualStateHandler<(Image, float, float)> fadingOutImageHandler;

        public ShowEndOfCycleScreenEntitiesBehaviour(EndOfGameCycleScreen endOfGameCycleScreen, IEntityVisualStateHandler<(Image, float, float)> fadingOutImageHandler)
        {
            this.endOfGameCycleScreen = endOfGameCycleScreen;
            this.fadingOutImageHandler = fadingOutImageHandler;
            this.endOfGameCycleScreen.RestartButton.onClick.AddListener(OnRestartButtonClick);
        }

        public override async UniTask ExecutBenaviour()
        {
            endOfGameCycleScreen.gameObject.SetActive(true);
            await fadingOutImageHandler.SetVisualState((endOfGameCycleScreen.FadeImage, 0.5f, 0.5f));

            await UniTask.WaitUntil(() => !endOfGameCycleScreen.gameObject.activeSelf);
        }

        private void OnRestartButtonClick()
        {
            endOfGameCycleScreen.gameObject.SetActive(false);
        }
    }
}