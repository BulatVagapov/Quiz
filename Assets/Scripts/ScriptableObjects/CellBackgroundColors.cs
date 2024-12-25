using UnityEngine;

namespace Quiz.ScriptableObjects
{
    [CreateAssetMenu(fileName = "CellBackgroundColors", menuName = "ScriptableObject/CellBackgroundColors")]
    public class CellBackgroundColors : ScriptableObject
    {
        [SerializeField] private Color[] colors;
        public Color[] Colors => colors;
    }
}