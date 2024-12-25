using Cysharp.Threading.Tasks;
using Quiz.VisualLayer.Effects;
using UnityEngine;

namespace Quiz.VisualLayer
{
    public class CellSymbolVisualStateHandler : IEntityVisualStateHandler<Transform>
    {
        private IEffect<Transform> effect;

        public CellSymbolVisualStateHandler(IEffect<Transform> effect)
        {
            this.effect = effect;
        }

        public async UniTask SetVisualState(Transform target)
        {
            await effect.DoEffectAsync(target.transform);
        }
    }
}