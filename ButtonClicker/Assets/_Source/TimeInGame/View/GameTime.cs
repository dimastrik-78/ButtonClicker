using Event;
using TMPro;
using UnityEngine;
using Utilities;
using Zenject;

namespace TimeInGame.View
{
    public class GameTime : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _timeInGameText;
        
        public float TimeInGame { get; private set; }

        private Events _events;

        [Inject]
        public void Construct(Events events)
        {
            _events = events;
        }

        private void Update()
        {
            TimeInGame += Time.deltaTime;
            TimeConversion.Time((int)TimeInGame, out string first, out string second);
            _timeInGameText.text = $"Time in the game {first} {second}";
            
            _events.OnCrossingCertainTime();
        }

        public void SeTime(float timeInGame)
        {
            TimeInGame = timeInGame;
        }
    }
}