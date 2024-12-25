using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine.UI;

namespace Quiz.VisualLayer.Effects
{
    public class FadeOutImageEffect : IEffect<(Image, float, float)>
    {
        public async UniTask DoEffectAsync((Image, float, float) target)
        {
            await target.Item1.DOFade(target.Item2, target.Item3).ToUniTask();
        }
    }
}