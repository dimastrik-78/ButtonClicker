using TimeInGame.View;
using Zenject;

namespace Event
{
    public class Events
    {
        private GameTime _timeInGame;

        private bool _firstSession = true;
        private bool _firstEvent;
        private bool _secondEvent;
        private bool _thirdEvent;
        private bool _fourthEvent;
        private bool _fifthEvent;

        [Inject]
        public Events(GameTime timeInGame)
        {
            _timeInGame = timeInGame;
        }

        public void OnNewSession()
        {
            _firstSession = false;
        }

        public void OnClick(string text)
        {
            AppMetrica.Instance.ReportEvent(text);
        }

        public void OnClickWithParameters(string holdTime, int count)
        {
            string eventParameters = $"\\{{\"Time in game\":\"{_timeInGame.TimeInGame}\", \"Hold time\":\"{holdTime}\", \"Click\":\"{count}\"\\}}";
            
            AppMetrica.Instance.ReportEvent("Json", eventParameters);
        }

        public void OnCrossingCertainTime()
        {
            if (!_firstSession)
            {
                return;
            }
            
            switch (_timeInGame.TimeInGame)
            {
                case >= 10 and < 20 
                    when !_firstEvent:
                    AppMetrica.Instance.ReportEvent("Time in game: 10+ second");
                    _firstEvent = true;
                    return;
                case >= 20 and < 30 
                    when !_secondEvent:
                    AppMetrica.Instance.ReportEvent("Time in game: 20+ second");
                    _secondEvent = true;
                    return;
                case >= 30 and < 40 
                    when !_thirdEvent:
                    AppMetrica.Instance.ReportEvent("Time in game: 30+ second");
                    _thirdEvent = true;
                    return;
                case >= 40 and < 50
                    when !_fourthEvent:
                    AppMetrica.Instance.ReportEvent("Time in game: 40+ second");
                    _fourthEvent = true;
                    return;
                case >= 50 and < 60 
                    when !_fifthEvent:
                    AppMetrica.Instance.ReportEvent("Time in game: 50+ second");
                    _fifthEvent = true;
                    return;
            }
        }
    }
}