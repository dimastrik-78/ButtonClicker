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
        
        public void ChangeState(Type gameState)
        {
            _activeState = _states[gameState];
            _activeState.Enter();
        }

        public void CreateStates(ISaveLoad saveLoad)
        {
            _states = new Dictionary<Type, IGameState>
            {
                [typeof(LunchGame)] = new LunchGame(saveLoad),
                [typeof(PlayGame)] = new PlayGame(),
                [typeof(CloseGame)] = new CloseGame(saveLoad)
            };
            
            ChangeState(typeof(LunchGame));
        }
    }
}