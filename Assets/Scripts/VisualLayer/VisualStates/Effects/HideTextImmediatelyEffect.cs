using Cysharp.Threading.Tasks;
using TMPro;

namespace Quiz.VisualLayer.Effects
{
    public class HideTextImmediatelyEffect : IEffect<TMP_Text>
    {
        public async UniTask DoEffectAsync(TMP_Text target)
        {
            target.gameObject.SetActive(false);
        }
    }
}