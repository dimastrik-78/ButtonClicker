using SaveLoadSystem;


namespace Core.GameState
{
    public class CloseGame : IGameState
    {
        private readonly ISaveLoad _saveLoad;

        public CloseGame(ISaveLoad saveLoad)
        {
            _saveLoad = saveLoad;
        }

        public void Enter()
        {
            _saveLoad.Save();
        }
    }
}