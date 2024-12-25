using Cysharp.Threading.Tasks;

namespace Quiz.VisualLayer
{
    public interface IEntityVisualStateHandler<T>
    {
        UniTask SetVisualState(T target);
    }
}