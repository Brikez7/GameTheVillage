using Assets.Scripts.Work.Buttons;
using Assets.Scripts.Work.Interfaces;
using Assets.Scripts.Work.Pages;
using Assets.Scripts.Work.Timers;
using Assets.Scripts.Work.Units;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Assets.Scripts.Work.Units.ProductionCharacteristics;

namespace Assets.Scripts.Work
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private Warriors _warriors;
        [SerializeField] private Workers _workers;
        [SerializeField] private Enemies _enemies;

        [SerializeField] private Millet _millet;

        [SerializeField] private Production _production;
        [SerializeField] private Sun _sun;
        [SerializeField] private EnemyWave _timerEnemyWave;

        [SerializeField] private EndGamePage _pageEndGame;
        [SerializeField] private BasePage _pageGame;
        [SerializeField] private WindowDescVictory _windowDescriptionVictory;

        [SerializeField] private StatisticsCollector _statisticsCollector;
        [SerializeField] private VerifierConditionsVictory _winChecker;
        [SerializeField] private GameState _gameState;

        [SerializeField] AudioPlayer _audioPlayer;

        [SerializeField] private ButtonsByUnit _buttonsByUnit;
        [SerializeField] private ButtonPauseGame _buttonPauseGame;

        [SerializeField] private Image _iTimerProductionWorkers;
        [SerializeField] private Image _iTimerProductionWarriors;

        public void Initialize()
        {
            InitializeUnits();

            InitializeTimers();

            InitializePages();

            InitializeGameState();

            InitializeButtons();
        }
        public void Start()
        {
            Initialize();
        }

        private void InitializeUnits()
        {
            _warriors.Initialize();
            _workers.Initialize(_winChecker);
            _enemies.Initialize();
        }
        private void InitializeTimers()
        {
            var timerWorkers = new TimerProduction(_workers, _iTimerProductionWorkers);
            var timerWarriors = new TimerProduction(_warriors, _iTimerProductionWarriors);
            _production.Initialize(_millet, new Dictionary<TypeFriendUnit, TimerProduction> 
            {
                [timerWorkers.Characteristics.TypeUnit] = timerWorkers,
                [timerWarriors.Characteristics.TypeUnit] = timerWarriors,
            });

            _millet.Initialize(_winChecker);
            _sun.Initialize(_millet, _warriors, _workers);
            _timerEnemyWave.Initialize(_enemies, _warriors, _gameState);
        }
        private void InitializePages()
        {
            _pageEndGame.Initialize(_statisticsCollector, _pageGame);
            _pageGame.Initialize(_pageEndGame);
            _windowDescriptionVictory.Initialize(_gameState);
        }
        private void InitializeGameState()
        {
            _winChecker.Initialize(_gameState);

            var elementsPause = new IPause[] { _production, _sun, _timerEnemyWave, _audioPlayer };
            var elementsRestarter = new IRestarter[] { _production, _sun, _timerEnemyWave, _millet, _winChecker, _pageEndGame, _warriors, _workers, _enemies, _audioPlayer };
            _gameState.Initialize(_pageEndGame, elementsPause, elementsRestarter);

            _statisticsCollector.Initialize(new IStatistic[] { _enemies, _warriors, _workers, _millet, _timerEnemyWave, _sun});
        }
        private void InitializeButtons()
        {
            _buttonsByUnit.Initialize();
            _buttonPauseGame.Initialize(_gameState);
        }
    }
}
