using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Quiz.VisualLayer.Effects
{
    public class ShowTransformImmediatelyEffect : IEffect<Transform>
    {
        public async UniTask DoEffectAsync(Transform target)
        {
            target.gameObject.SetActive(true);
        }
    }
}
