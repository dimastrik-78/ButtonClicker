using System.IO;
using Event;
using ResourceSystem;
using SaveLoadSystem;
using TimeInGame.View;
using UnityEngine;

namespace Core.GameState
{
    public class LoadGame : IGameState
    {
        private SaveData _data;
        private readonly IResource _resource;
        private readonly GameTime _gameTime;
        private readonly string _path;
        private readonly Events _events;
        
        public LoadGame(SaveData data, IResource resource, GameTime gameTime, string path, Events events)
        {
            _data = data;
            _resource = resource;
            _gameTime = gameTime;
            _path = path;
            _events = events;
        }
        
        public void Enter()
        {
            if (!File.Exists(_path))
            {
                File.Create(_path);
            }
            else
            {
                _data = JsonUtility.FromJson<SaveData>(File.ReadAllText(_path));
                _resource.ResourceValue = _data.Currency;
                _gameTime.SeTime(_data.Time);
                _events.OnNewSession();
            }
        }
    }
}