using Cysharp.Threading.Tasks;
using Quiz.VisualLayer.Effects;
using TMPro;

namespace Quiz.VisualLayer
{
    public class TaskVisualStateHandler : IEntityVisualStateHandler<TMP_Text>
    {
        private IEffect<TMP_Text> effect;

        public TaskVisualStateHandler(IEffect<TMP_Text> fadeInTextEffect)
        {
            this.effect = fadeInTextEffect;
        }

        public async UniTask SetVisualState(TMP_Text target)
        {
            target.gameObject.SetActive(true);
            await effect.DoEffectAsync(target);
        }
    }
}