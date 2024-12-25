using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Quiz.VisualLayer.Effects
{
    public class FadeInImageEffect : IEffect<(Image, float, float)>
    {
        private Color color;

        public async UniTask DoEffectAsync((Image, float, float) target)
        {
            color = target.Item1.color;
            color.a = 0;
            target.Item1.color = color;
            await target.Item1.DOFade(target.Item2, target.Item3).ToUniTask();
        }
    }
}