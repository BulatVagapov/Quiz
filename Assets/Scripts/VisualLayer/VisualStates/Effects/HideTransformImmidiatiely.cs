using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Quiz.VisualLayer.Effects
{
    public class HideTransformImmediatelyEffect : IEffect<Transform>
    {
        public async UniTask DoEffectAsync(Transform target)
        {
            target.gameObject.SetActive(false);
            await UniTask.Delay(0);
        }
    }
}