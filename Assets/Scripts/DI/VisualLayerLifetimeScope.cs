using Quiz.GameLayer;
using Quiz.VisualLayer;
using Quiz.VisualLayer.Effects;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Quiz.DI
{
    public class VisualLayerLifetimeScope : LifetimeScope
    {
        [SerializeField] private TaskView taskView;
        [SerializeField] private LoadingScreen loadingScreen;
        [SerializeField] private ParticleSystem ParticleSystem;
        [SerializeField] private Camera cam;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponent(taskView);
            builder.RegisterComponent(loadingScreen);
            builder.RegisterComponent(ParticleSystem);
            builder.RegisterComponent(cam);

            builder.Register<BounceTransformEffect>(Lifetime.Transient).As<IEffect<Transform>>().AsSelf();
            builder.Register<CellForLeveViewlTuner>(Lifetime.Singleton);
            builder.Register<HideTransformImmediatelyEffect>(Lifetime.Transient).As<IEffect<Transform>>().AsSelf();
            builder.Register<StarParticleSystemController>(Lifetime.Singleton);
            builder.Register<CameraPositionProvider>(Lifetime.Singleton);

            ConfigureStartGameCycleVisualState(builder);
            ConfigureTransitionBetweenLevelsVisualState(builder);
            ConfigureOnCorrectCellClickVisualState(builder);
            ConfigureOnRegularCellClickVisualState(builder);
            ConfigureEndOfGameCycleVisualState(builder);
            ConfigureLoadingVisualState(builder);
        }

        private void ConfigureStartGameCycleVisualState(IContainerBuilder builder)
        {
            builder.Register<FadeInTextEffect>(Lifetime.Transient);

            builder.Register<StartGameCycleVisualState>(container =>
            {
                BounceTransformEffect cellsEffect = container.Resolve<BounceTransformEffect>();
                CellsVisualStateHandler cellsHandler = new CellsVisualStateHandler(cellsEffect);

                FadeInTextEffect tectEffect = container.Resolve<FadeInTextEffect>();
                TaskVisualStateHandler taskHandler = new TaskVisualStateHandler(tectEffect);

                HideTransformImmediatelyEffect hideCellEffect = container.Resolve<HideTransformImmediatelyEffect>();
                CellsVisualStateHandler hideCellHandler = new CellsVisualStateHandler(hideCellEffect);

                HideAndShowGameViewEntitiesBehaviour behaviour = new HideAndShowGameViewEntitiesBehaviour(cellsHandler, hideCellHandler, taskHandler
                    , container.Resolve<CellPool>(), container.Resolve<TaskView>(), container.Resolve<CellForLeveViewlTuner>()
                    , container.Resolve<CellsDataForLevelGenerator>(), container.Resolve<LevelGenerator>(), container.Resolve<CameraPositionProvider>());

                StartGameCycleVisualState state = new StartGameCycleVisualState(container.Resolve<GameCyclePresenter>(), behaviour
                    , container.Resolve<ClickProtectionController>());
                return state;
            }, Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
        }

        private void ConfigureTransitionBetweenLevelsVisualState(IContainerBuilder builder)
        {
            builder.Register<ShowTransformImmediatelyEffect>(Lifetime.Transient);
            builder.Register<ShowTextImmediatelyEffect>(Lifetime.Transient);

            builder.Register<TransitionBetweenLevelsVisualState>(container =>
            {
                ShowTransformImmediatelyEffect showCellsEffect = container.Resolve<ShowTransformImmediatelyEffect>();
                CellsVisualStateHandler cellsHandler = new CellsVisualStateHandler(showCellsEffect);
                HideTransformImmediatelyEffect hideCellEffect = container.Resolve<HideTransformImmediatelyEffect>();
                CellsVisualStateHandler hideCellHandler = new CellsVisualStateHandler(hideCellEffect);

                ShowTextImmediatelyEffect tectEffect = container.Resolve<ShowTextImmediatelyEffect>();
                TaskVisualStateHandler taskHandler = new TaskVisualStateHandler(tectEffect);

                HideAndShowGameViewEntitiesBehaviour behaviour = new HideAndShowGameViewEntitiesBehaviour(cellsHandler, hideCellHandler, taskHandler
                    , container.Resolve<CellPool>(), container.Resolve<TaskView>(), container.Resolve<CellForLeveViewlTuner>()
                    , container.Resolve<CellsDataForLevelGenerator>(), container.Resolve<LevelGenerator>(), container.Resolve<CameraPositionProvider>());

                TransitionBetweenLevelsVisualState state = new TransitionBetweenLevelsVisualState(container.Resolve<GameCyclePresenter>()
                    , container.Resolve<OnCorrectCellClickVisualState>(), behaviour, container.Resolve<ClickProtectionController>());
                return state;
            }, Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
        }

        private void ConfigureOnCorrectCellClickVisualState (IContainerBuilder builder)
        {
            builder.Register<PlayParticleSystemEffect>(Lifetime.Transient);
            
            builder.Register<OnCorrectCellClickVisualState>(container =>
            {
                BounceTransformEffect effect = container.Resolve<BounceTransformEffect>();
                CellSymbolVisualStateHandler cellsHandler = new CellSymbolVisualStateHandler(effect);

                PlayParticleSystemEffect particleEffect = container.Resolve<PlayParticleSystemEffect>();
                StarParticleSystemHandler particleHandler = new StarParticleSystemHandler(particleEffect);

                ClickedCellSymbollAndParticlesBeheviour behaviour = new ClickedCellSymbollAndParticlesBeheviour(cellsHandler, container.Resolve<CellClickHandler>()
                    , particleHandler, container.Resolve<StarParticleSystemController>());

                OnCorrectCellClickVisualState state = new OnCorrectCellClickVisualState(container.Resolve<CellClickHandler>(), behaviour);
                return state;
            }, Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
        }

        private void ConfigureOnRegularCellClickVisualState(IContainerBuilder builder)
        {
            builder.Register<EaseInBounceTransformEffect>(Lifetime.Transient);
            
            builder.Register<OnRegularCellClickVisualState>(container =>
            {
                EaseInBounceTransformEffect cellsEffect = container.Resolve<EaseInBounceTransformEffect>();
                CellSymbolVisualStateHandler cellsHandler = new CellSymbolVisualStateHandler(cellsEffect);
                ClickedCellSymbollBeheviour behaviour = new ClickedCellSymbollBeheviour(cellsHandler, container.Resolve<CellClickHandler>());

                OnRegularCellClickVisualState state = new OnRegularCellClickVisualState(container.Resolve<CellClickHandler>(), behaviour);
                return state;
            }, Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
        }

        private void ConfigureEndOfGameCycleVisualState(IContainerBuilder builder)
        {
            builder.Register<FadeInImageEffect>(Lifetime.Transient);
            
            builder.Register<EndOfGameCycleVisualState>(container =>
            {
                FadeInImageEffect imageffect = container.Resolve<FadeInImageEffect>();
                ImageVisualStateHandler cellsHandler = new ImageVisualStateHandler(imageffect);
                ShowEndOfCycleScreenEntitiesBehaviour behaviour = new ShowEndOfCycleScreenEntitiesBehaviour(container.Resolve<EndOfGameCycleScreen>(), cellsHandler);

                EndOfGameCycleVisualState state = new EndOfGameCycleVisualState(container.Resolve<GameCyclePresenter>(), container.Resolve<OnCorrectCellClickVisualState>()
                    ,behaviour);
                return state;
            }, Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
        }

        private void ConfigureLoadingVisualState(IContainerBuilder builder)
        {
            builder.Register<FadeInImageEffect>(Lifetime.Transient);
            builder.Register<FadeOutImageEffect>(Lifetime.Transient);
            builder.Register<HideTextImmediatelyEffect>(Lifetime.Transient);

            builder.Register<LoadingVisualState>(container =>
            {
                FadeInImageEffect fadeInImage = container.Resolve<FadeInImageEffect>();
                ImageVisualStateHandler fadeInImageHandler = new ImageVisualStateHandler(fadeInImage);

                HideTransformImmediatelyEffect hideCellsEffect = container.Resolve<HideTransformImmediatelyEffect>();
                CellsVisualStateHandler cellsHandler = new CellsVisualStateHandler(hideCellsEffect);


                HideTextImmediatelyEffect hideTaskTextEffect = container.Resolve<HideTextImmediatelyEffect>();
                TaskVisualStateHandler taskHandler = new TaskVisualStateHandler(hideTaskTextEffect);

                FadeOutImageEffect fadeOutImage = container.Resolve<FadeOutImageEffect>();
                ImageVisualStateHandler fadeOutImageHandler = new ImageVisualStateHandler(fadeOutImage);



                LoadingStateBehaviour behaviour = new LoadingStateBehaviour(cellsHandler, taskHandler, fadeInImageHandler, fadeOutImageHandler
                    , container.Resolve<CellPool>(), container.Resolve<TaskView>(), container.Resolve<LoadingScreen>(), container.Resolve<Loading>());

                LoadingVisualState state = new LoadingVisualState(container.Resolve<GameCycleRestarter>(), behaviour);
                return state;
            }, Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
        }
    }
}