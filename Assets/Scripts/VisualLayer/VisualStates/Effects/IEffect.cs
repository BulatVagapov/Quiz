using Cysharp.Threading.Tasks;

namespace Quiz.VisualLayer.Effects
{
    public interface IEffect<T>
    {
        UniTask DoEffectAsync(T target);
    }
}