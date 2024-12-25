using UnityEngine;
using UnityEngine.UI;

namespace Quiz
{
    public class EndOfGameCycleScreen : MonoBehaviour
    {
        [SerializeField] private Button restartButton;
        [SerializeField] private Image fadeImage;
        public Button RestartButton => restartButton;
        public Image FadeImage => fadeImage;
    }
}