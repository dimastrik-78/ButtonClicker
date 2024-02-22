using Core.GameState;
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
        private ISaveLoad _saveLoad;

        [Inject]
        private void Construct(IStateMachine stateMachine, ISaveLoad saveLoad)
        {
            _stateMachine = stateMachine;
            _saveLoad = saveLoad;
        }
        
        private void Start()
        {
            _mining.SetParameters(_givePoint);

            _stateMachine.CreateStates(_saveLoad);
            _stateMachine.ChangeState(typeof(PlayGame));
        }

        private void OnApplicationQuit()
        {
            _stateMachine.ChangeState(typeof(CloseGame));
        }
    }
}