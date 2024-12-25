using Cysharp.Threading.Tasks;
using Quiz.Models;
using Quiz.VisualLayer.Effects;
using System.Collections.Generic;
using UnityEngine;


namespace Quiz.VisualLayer
{
    public class CellsVisualStateHandler : IEntityVisualStateHandler<List<Cell>>
    {
        private IEffect<Transform> effect;

        public CellsVisualStateHandler(IEffect<Transform> effect)
        {
            this.effect = effect;
        }

        public async UniTask SetVisualState(List<Cell> target)
        {
            for (int i = 0; i < target.Count; i++)
            {
                target[i].gameObject.SetActive(true);
                await effect.DoEffectAsync(target[i].transform);
            }
        }
    }
}