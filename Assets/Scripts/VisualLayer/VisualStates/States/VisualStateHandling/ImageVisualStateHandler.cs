using Cysharp.Threading.Tasks;
using Quiz.VisualLayer.Effects;
using UnityEngine.UI;

namespace Quiz.VisualLayer
{
    public class ImageVisualStateHandler : IEntityVisualStateHandler<(Image, float, float)>
    {
        IEffect<(Image, float, float)> effect;

        public ImageVisualStateHandler(IEffect<(Image, float, float)> effect)
        {
            this.effect = effect;
        }

        public async UniTask SetVisualState((Image, float, float) target)
        {
            await effect.DoEffectAsync(target);
        }
    }
}