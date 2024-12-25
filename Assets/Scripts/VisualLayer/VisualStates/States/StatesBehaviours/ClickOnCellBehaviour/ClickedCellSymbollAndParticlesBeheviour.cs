using Cysharp.Threading.Tasks;
using Quiz.GameLayer;
using Quiz.Models;
using UnityEngine;

namespace Quiz.VisualLayer
{
    public class ClickedCellSymbollAndParticlesBeheviour : ClickedCellSymbollBeheviour
    {
        private IEntityVisualStateHandler<(StarParticleSystemController, Vector3)>  particleHandler;
        private StarParticleSystemController starParticleSystemController;
        
        public ClickedCellSymbollAndParticlesBeheviour(IEntityVisualStateHandler<Transform> transformEffect, CellClickHandler cellClickHandler
            , IEntityVisualStateHandler<(StarParticleSystemController, Vector3)> particleHandler, StarParticleSystemController starParticleSystemController)
            : base(transformEffect, cellClickHandler)
        {
            this.particleHandler = particleHandler;
            this.starParticleSystemController = starParticleSystemController;
        }

        protected override async UniTask AwaitableBehaviourAsync(Cell clicckedCell)
        {
            await UniTask.WhenAll(base.AwaitableBehaviourAsync(clicckedCell)
                , particleHandler.SetVisualState((starParticleSystemController, clicckedCell.SymbolViewTransform.position)));
        }
    }
}