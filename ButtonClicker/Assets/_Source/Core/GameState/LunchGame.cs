using SaveLoadSystem;

namespace Core.GameState
{
    public class LunchGame : IGameState
    {
        private readonly ISaveLoad _saveLoad;

        public LunchGame(ISaveLoad saveLoad)
        {
            _saveLoad = saveLoad;
        }
        
        public void Enter()
        {
            if (_saveLoad.CheckFile())
            {
                _saveLoad.Load();
            }
        }
    }
}