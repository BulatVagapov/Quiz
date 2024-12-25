using System.Collections.Generic;
using UnityEngine;

namespace Quiz.Models
{
    public class GridModel
    {
        public List<Vector3> Cellpositions { get; private set; }
        public Vector3 GridCenter { get; private set; }

        public GridModel(List<Vector3> cellpositions, Vector3 gridCenter)
        {
            Cellpositions = cellpositions;
            GridCenter = gridCenter;
        }
    }
}

