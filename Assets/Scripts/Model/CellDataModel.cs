using System;
using UnityEngine;

namespace Quiz.Models
{
    [Serializable]
    public class CellDataModel
    {
        [SerializeField] private string symbol;
        [SerializeField] private Sprite symbolView;
        [SerializeField] private bool needRotate;
        [SerializeField] private Vector3 symbolRotation;

        public string Symbol => symbol;
        public Sprite SymbolView => symbolView;
        public bool NeedRotate => needRotate;
        public Vector3 SymbolRotation => symbolRotation;
    }
}