using TMPro;
using UnityEngine;
using Utilities;

namespace TimeInGame.View
{
    public class GameTime : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _timeInGameText;
        
        public float TimeInGame { get; private set; }

        private void Update()
        {
            TimeInGame += Time.deltaTime;
            TimeConversion.Time((int)TimeInGame, out string first, out string second);
            _timeInGameText.text = $"Time in the game {first} {second}";
        }

        public void SeTime(float timeInGame)
        {
            TimeInGame = timeInGame;
        }
    }
}