using TMPro;
using UnityEngine;

namespace Quiz.VisualLayer
{
    public class TaskView : MonoBehaviour
    {
        [SerializeField] private TMP_Text taskText;
        private string findString = "Find ";
        public TMP_Text TaskText => taskText;

        private void Awake()
        {
            taskText.gameObject.SetActive(false);
        }

        public void SetTaskText(string taskSymbol)
        {
            taskText.text = findString + taskSymbol;
        }
    }
}