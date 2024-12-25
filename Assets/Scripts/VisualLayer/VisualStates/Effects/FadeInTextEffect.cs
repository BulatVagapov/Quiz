using Cysharp.Threading.Tasks;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Quiz.VisualLayer.Effects
{
    public class FadeInTextEffect : IEffect<TMP_Text>
    {
        private Color color;

        public async UniTask DoEffectAsync(TMP_Text target)
        {
            color = target.color;
            color.a = 0;
            target.color = color;
            await target.DOFade(1f, 1.2f).ToUniTask();
        }
    }
}