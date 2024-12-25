using Cysharp.Threading.Tasks;

namespace Quiz.VisualLayer
{
    public abstract class AbstractVisualStateBehaviour
    {
        public virtual async UniTask ExecutBenaviour() { }
    }
}