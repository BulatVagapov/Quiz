using System;
using UnityEngine;

namespace Quiz.Models
{
    [Serializable]
    public class CellDataCategory
    {
        [SerializeField] private CellDataModel[] category;
        public CellDataModel[] Category => category;
    }
}


