using System.IO;
using ResourceSystem;
using SaveLoadSystem;
using TimeInGame.View;
using UnityEngine;

namespace Core.GameState
{
    public class SaveGame : IGameState
    {
        private readonly SaveData _data;
        private readonly IResource _resource;
        private readonly GameTime _gameTime;
        private readonly string _path;
        
        public SaveGame(SaveData data, IResource resource, GameTime gameTime, string path)
        {
            _data = data;
            _resource = resource;
            _gameTime = gameTime;
            _path = path;
        }

        public void Enter()
        {
            _data.Currency = _resource.ResourceValue;
            _data.Time = _gameTime.TimeInGame;

            File.WriteAllText(_path, JsonUtility.ToJson(_data));
        }
    }
}