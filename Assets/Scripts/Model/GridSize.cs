using System;
using UnityEngine;

namespace Quiz.Models
{
    [Serializable]
    public class GridSize
    {
        [SerializeField] private int columns;
        [SerializeField] private int rows;

        public int Columns => columns;
        public int Rows => rows;
        public int Size => columns * rows;
    }
}

