using Event;
using ResourceSystem;
using SaveLoadSystem;
using TimeInGame.View;

namespace Core.GameState
{
    public interface IStateMachine
    {
        void ChangeState<T>() where T : IGameState;
        void CreateStates(SaveData data, IResource resource, GameTime gameTime, string path, Events events);
    }
}