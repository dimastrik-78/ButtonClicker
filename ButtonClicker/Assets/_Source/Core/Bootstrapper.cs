using Core.GameState;
using Event;
using ResourceSystem;
using SaveLoadSystem;
using TimeInGame.View;
using UnityEngine;
using Zenject;

namespace Core
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private MiningButton _mining;
        [SerializeField] private float _givePoint;

        private IStateMachine _stateMachine;
        private SaveData _saveData;
        private IResource _resource;
        private GameTime _gameTime;
        private Events _events;

        [Inject]
        private void Construct(IStateMachine stateMachine, SaveData data, IResource resource, GameTime gameTime, Events events)
        {
            _stateMachine = stateMachine;
            _saveData = data;
            _resource = resource;
            _gameTime = gameTime;
            _events = events;
        }
        
        private void Start()
        {
            _mining.SetParameters(_givePoint);

            string path = Application.dataPath + "GameData.json";
            
            _stateMachine.CreateStates(_saveData, _resource, _gameTime, path, _events);
            _stateMachine.ChangeState<PlayGame>();
        }

        private void OnApplicationQuit()
        {
            _stateMachine.ChangeState<SaveGame>();
        }
    }
}