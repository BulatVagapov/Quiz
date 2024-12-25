using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace Quiz.VisualLayer.Effects
{
    public class BounceTransformEffect : IEffect<Transform>
    {
        private Vector3 baseScale;
        private Vector3 scaleSize = Vector3.zero;

        public async UniTask DoEffectAsync(Transform target)
        {
            if (!target.gameObject.activeSelf) target.gameObject.SetActive(true);
            
            baseScale = target.localScale;
            SetScaleSize(baseScale.x + (baseScale.x / 3), baseScale.y + (baseScale.y / 3));

            await target.DOScale(scaleSize, 0.15f).ToUniTask();
            SetScaleSize(baseScale.x - (baseScale.x / 3), baseScale.y - (baseScale.y / 3));
            await target.DOScale(scaleSize, 0.15f).ToUniTask();
            await target.DOScale(baseScale, 0.1f).ToUniTask();
        }

        private void SetScaleSize(float xValue, float yValue)
        {
            scaleSize.x = xValue;
            scaleSize.y = yValue;
        }
    }
}