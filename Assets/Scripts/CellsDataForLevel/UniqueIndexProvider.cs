using System.Collections.Generic;
using UnityEngine;

namespace Quiz.GameLayer
{
    public class UniqueIndexProvider
    {
        private List<int> possibleIndices = new List<int>();
        private int possibleIndicesCount;
        private int randomPossibleIndicesIndex = -1;
        private int returningIndex = -1;
        private int excludedIndex = -1;

        public UniqueIndexProvider(int possibleIndicesCount)
        {
            this.possibleIndicesCount = possibleIndicesCount;
            FillPossibleIndices();
        }

        private void FillPossibleIndices()
        {
            for (int i = 0; i < possibleIndicesCount; i++)
            {
                if (i == excludedIndex) continue;
                possibleIndices.Add(i);
            }
        }

        public void SetExcludedIndex(int index)
        {
            excludedIndex = index;
            if (possibleIndices.Contains(excludedIndex)) possibleIndices.Remove(excludedIndex);
        }

        public int GetUniqueIndex()
        {
            if (possibleIndices.Count <= 0)
            {
                FillPossibleIndices();
            }

            randomPossibleIndicesIndex = Random.Range(0, possibleIndices.Count);
            returningIndex = possibleIndices[randomPossibleIndicesIndex];
            possibleIndices.RemoveAt(randomPossibleIndicesIndex);
            return returningIndex;
        }
    }
}