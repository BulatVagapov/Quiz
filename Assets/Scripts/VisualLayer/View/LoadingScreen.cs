using UnityEngine;
using UnityEngine.UI;

namespace Quiz
{
    public class LoadingScreen : MonoBehaviour
    {
        [SerializeField] private Image backgroundImage;
        [SerializeField] private GameObject loadingTextGameObject;
        public Image BackgroundImage => backgroundImage;
        public GameObject LoadingTextGameObject => loadingTextGameObject;

        private void Awake()
        {
            DisactivateScreen();
        }

        public void ActivateScreen()
        {
            loadingTextGameObject.SetActive(true);
            gameObject.SetActive(true);
        }

        public void DisactivateScreen()
        {
            loadingTextGameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}