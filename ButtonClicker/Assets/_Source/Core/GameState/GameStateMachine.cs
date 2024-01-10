using System;
using System.Collections.Generic;
using ResourceSystem;
using SaveLoadSystem;
using TimeInGame.View;

namespace Core.GameState
{
    public class GameStateMachine : IStateMachine
    {
        private Dictionary<Type, IGameState> _states;
        private IGameState _activeState;
        
        public void ChangeState<T>() where T : IGameState
        {
            _activeState = _states[typeof(T)];
            _activeState.Enter();
        }

        public void CreateStates(SaveData data, IResource resource, GameTime gameTime, string path)
        {
            _states = new Dictionary<Type, IGameState>
            {
                [typeof(LoadGame)] = new LoadGame(data, resource, gameTime, path),
                [typeof(PlayGame)] = new PlayGame(),
                [typeof(SaveGame)] = new SaveGame(data, resource, gameTime, path)
            };
            
            ChangeState<LoadGame>();
        }
    }
}