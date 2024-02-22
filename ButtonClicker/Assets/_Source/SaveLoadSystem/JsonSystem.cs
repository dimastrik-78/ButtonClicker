using System.IO;
using ResourceSystem;
using TimeInGame.View;
using UnityEngine;
using Zenject;

namespace SaveLoadSystem
{
    public class JsonSystem : ISaveLoad
    {
        private readonly IResource _resource;
        private readonly GameTime _gameTime;
        private readonly string _path;
        
        private SaveData _data;

        [Inject]
        private JsonSystem(IResource resource, SaveData data, GameTime gameTime)
        {
            _path = Application.dataPath + "GameData.json";
            _resource = resource;
            _data = data;
            _gameTime = gameTime;
        }

        public bool CheckFile()
        {
            if (!File.Exists(_path))
            {
                File.Create(_path);
                return false;
            }

            return true;
        }
        
        public void Save()
        {
            _data.Currency = _resource.ResourceValue;
            _data.Time = _gameTime.TimeInGame;

            File.WriteAllText(_path, JsonUtility.ToJson(_data));
        }

        public void Load()
        {
            _data = JsonUtility.FromJson<SaveData>(File.ReadAllText(_path));
            _resource.ResourceValue = _data.Currency;
            _gameTime.SetTime(_data.Time);
        }
    }
}