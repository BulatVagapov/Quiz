using Cysharp.Threading.Tasks;
using Quiz.VisualLayer.Effects;
using UnityEngine;

namespace Quiz.VisualLayer
{
    public class StarParticleSystemHandler : IEntityVisualStateHandler<(StarParticleSystemController, Vector3)>
    {
        private IEffect<(StarParticleSystemController, Vector3)> effect;

        public StarParticleSystemHandler(IEffect<(StarParticleSystemController, Vector3)> effect)
        {
            this.effect = effect;
        }

        public async UniTask SetVisualState((StarParticleSystemController, Vector3) target)
        {
            await effect.DoEffectAsync(target);
        }
    }
}