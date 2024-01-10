using Core.GameState;
using ResourceSystem;
using SaveLoadSystem;
using TimeInGame.View;
using UnityEngine;
using Zenject;

namespace Core
{
    public class Installer : MonoInstaller
    {
        [SerializeField] private GameTime _time;
        
        public override void InstallBindings()
        {
            ResourceBindings();
            SaveLoadBindings();
            GameStateBindings();
            
            Container.Bind<GameTime>()
                .FromInstance(_time)
                .AsSingle()
                .NonLazy();
        }

        private void ResourceBindings()
        {
            Container.Bind<IResource>()
                .To<Currency>()
                .AsSingle()
                .NonLazy();
        }

        private void SaveLoadBindings()
        {
            Container.Bind<SaveData>()
                .AsSingle()
                .NonLazy();
        }

        private void GameStateBindings()
        {
            Container.Bind<IStateMachine>()
                .To<GameStateMachine>()
                .AsSingle()
                .NonLazy();
        }
    }
}