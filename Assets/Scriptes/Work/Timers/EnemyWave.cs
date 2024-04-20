using Assets.Scripts.Work.Interfaces;
using Assets.Scripts.Work.Units;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Assets.Scripts.Work.Units.BaseUnit;

namespace Assets.Scripts.Work.Timers
{
    public sealed class EnemyWave : BaseTimer, IKeyStatistic<int>
    {
        public int Field { get; set; }

        private float _timerWave = 0;
        [Range(1, 20)] [SerializeField] private float _startMaxTimeWave;
        private float _maxTimeWave;
        [SerializeField] private Image _iTimerWave;

        private uint _countEmptyCycle;
        [SerializeField] private uint _startCountEmptyCycle;
        private TMP_Text _tEmptyCycleWave;

        [SerializeField] private SettingsWave _settingsWave;

        [SerializeField] private AudioSource _audioSource;

        private Enemies _enemies;
        private Warriors _warriors;
        private GameState _gameState;
        public void Initialize(Enemies enemies, Warriors warriors, GameState gameState)
        {
            Initialize();

            _enemies = enemies;
            _warriors = warriors;
            _gameState = gameState;

            _tEmptyCycleWave = GetComponentInChildren<TMP_Text>();

            ReloadState();
        }
        private void ReloadState()
        {
            Field = 0;

            _timerWave = 0;
            _maxTimeWave = _startMaxTimeWave;
            _iTimerWave.fillAmount = 0;

            _countEmptyCycle = _startCountEmptyCycle;
            _tEmptyCycleWave.text = _startCountEmptyCycle.ToString();
            _tEmptyCycleWave.gameObject.SetActive(true);
        }

        public override void Restart()
        {
            base.Restart();
            ReloadState();
        }

        protected override void Tick()
        {
            _timerWave += Time.deltaTime;
            if (_timerWave >= _maxTimeWave)
            {
                _timerWave = 0;
                
                if (CheckWaveIsNotEmpty()) 
                {
                    if (Battle.Fight(_warriors, _enemies))
                    {
                        _audioSource.Play();
                        _enemies.NextWave(_settingsWave.MultiplierWaveCount);
                        _maxTimeWave *= _settingsWave.MultiplierWaveTime;
                    }
                    else
                    {
                        _gameState.EndGame(false);
                        return;
                    }
                }
                Field++;
            }
            _iTimerWave.fillAmount = _timerWave / _maxTimeWave;
        }
        private bool CheckWaveIsNotEmpty() 
        {
            if (_countEmptyCycle == 0)
                return true;

            if (--_countEmptyCycle == 0)
                _tEmptyCycleWave.gameObject.SetActive(false);
            else
                _tEmptyCycleWave.text = _countEmptyCycle.ToString();

            return false;
        }

        public string GetStatistic() => $"Number of rounds experienced is {Field}";
    }

    [Serializable]
    public struct SettingsWave
    {
        [Range(1, 2)] public float MultiplierWaveCount;
        [Range(1, 2)] public float MultiplierWaveTime;
        public SettingsWave(float multiplierWaveCount, float multiplierWaveTime)
        {
            MultiplierWaveCount = multiplierWaveCount;
            MultiplierWaveTime = multiplierWaveTime;
        }
    }
}
