using System;
using SaveLoadSystem;

namespace Core.GameState
{
    public interface IStateMachine
    {
        void ChangeState(Type gameState);
        void CreateStates(ISaveLoad saveLoad);
    }
}