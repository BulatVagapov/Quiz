using Quiz.GameLayer;
using Quiz.Models;
using Quiz.ScriptableObjects;
using Quiz.VisualLayer;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Quiz.DI
{
    public class GameLifetimeScope : LifetimeScope
    {
        [SerializeField] private DataForCells CellsData;
        [SerializeField] private GridSizes gridSizrs;
        [SerializeField] private CellBackgroundColors backgroundColors;

        [SerializeField] private Cell cellPrefab;
        [SerializeField] private int startCellQuantity;
        [SerializeField] private GameObject clickProtectionPanel;
        [SerializeField] private EndOfGameCycleScreen endGameCycleScreen;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponent(gridSizrs);
            builder.RegisterComponent(CellsData);
            builder.RegisterComponent(backgroundColors);
            builder.RegisterComponent(cellPrefab);
            builder.RegisterComponent(clickProtectionPanel);
            builder.RegisterComponent(endGameCycleScreen);

            builder.Register<GameCycleRestarter>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
            builder.Register<ClickProtectionController>(Lifetime.Singleton).As<IInitializable>().AsSelf();
            builder.Register<CellsDataForLevelGenerator>(Lifetime.Singleton);
            builder.Register<CellSpawner>(Lifetime.Singleton);
            builder.Register<GridGenerator>(Lifetime.Singleton);
            builder.Register<CellClickObserver>(Lifetime.Singleton);
            builder.Register<CellPool>(Lifetime.Singleton).WithParameter(startCellQuantity).AsImplementedInterfaces().AsSelf();
            builder.Register<CellForLeveViewlTuner>(Lifetime.Singleton);
            builder.Register<LevelGenerator>(Lifetime.Singleton);
            builder.Register<GameCyclePresenter>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
            builder.Register<CellClickHandler>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
            builder.Register<EntryPoint>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
            builder.Register<Loading>(Lifetime.Singleton).WithParameter(2f);
        }
    }
}