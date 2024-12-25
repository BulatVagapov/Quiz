using Quiz.Models;
using UnityEngine;

namespace Quiz.ScriptableObjects
{
    [CreateAssetMenu(fileName = "DataForCells", menuName = "ScriptableObject/DataForCells")]
    public class DataForCells : ScriptableObject
    {
        [SerializeField] private CellDataCategory[] data;
        public CellDataCategory[] Data => data;
    }
}


