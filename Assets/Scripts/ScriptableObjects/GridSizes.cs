using Quiz.Models;
using UnityEngine;

namespace Quiz.ScriptableObjects
{
    [CreateAssetMenu(fileName = "GridSizes", menuName = "ScriptableObject/GridSizes")]
    public class GridSizes : ScriptableObject
    {
        [SerializeField] private GridSize[] sizes;
        public GridSize[] Sizes => sizes;
    }
}

