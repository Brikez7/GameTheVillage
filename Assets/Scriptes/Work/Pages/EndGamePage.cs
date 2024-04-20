using Assets.Scripts.Work.Interfaces;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Work.Pages
{
    public class EndGamePage : BasePage, IRestarter
    {
        private StatisticsCollector _statisticsCollector;
        [SerializeField] private TMP_Text _tStatistic;
        [SerializeField] private TMP_Text _tMessageEndGame;

        public void Initialize(StatisticsCollector statisticsCollector, BasePage pageGame) 
        {
            Initialize(pageGame);
            _statisticsCollector = statisticsCollector;

            var texts = GetComponentsInChildren<TMP_Text>();
            _tStatistic = texts[1];
            _tMessageEndGame = texts[0];
        }
        
        public void EndGame(bool isWin) 
        {
            _tStatistic.text = _statisticsCollector.GetStatistics();

            if (isWin)
                _tMessageEndGame.text = "You WIN!";
            else
                _tMessageEndGame.text = "Aw you lost...\nYou can repeat!";

            OtherPage.Exit();
            Show();
        }

        public void Restart()
        {
            ShowNext();
        }
    }
}
