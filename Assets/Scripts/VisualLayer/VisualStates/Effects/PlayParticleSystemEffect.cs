using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Quiz.VisualLayer.Effects
{
    public class PlayParticleSystemEffect : IEffect<(StarParticleSystemController, Vector3)>
    {
        public async UniTask DoEffectAsync((StarParticleSystemController, Vector3) target)
        {
            target.Item1.SetParticleSystemPosition(target.Item2);
            target.Item1.PlayParticleSystem();
        }
    }
}