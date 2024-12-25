using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace Quiz.VisualLayer.Effects
{
    public class EaseInBounceTransformEffect : IEffect<Transform>
    {
        private float baseXPosition;
        private float newXPosition;

        public async UniTask DoEffectAsync(Transform target)
        {
            baseXPosition = target.position.x;
            newXPosition = baseXPosition + 0.2f;

            await target.DOMoveX(newXPosition, 0.1f).ToUniTask();
            newXPosition = baseXPosition - 0.4f;
            await target.DOMoveX(newXPosition, 0.05f).ToUniTask();
            await target.DOMoveX(baseXPosition, 0.1f).ToUniTask();
        }
    }
}