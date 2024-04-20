using Assets.Scripts.Work.Interfaces;
using Assets.Scripts.Work.Units;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Work.Timers
{
    public sealed class Sun : BaseTimer, IKeyStatistic<uint>
    {
        private float _timer = 0;
        [Range(1, 10)] [SerializeField] private float _maxTimer;
        [SerializeField] private Image _iTimer;

        [SerializeField] private AudioSource _audioSource;

        public uint Field { get; set; }

        private Millet _millet;
        private Warriors _warriors;
        private Workers _workers;
        public void Initialize(Millet millet, Warriors warriors, Workers workers)
        {
            Initialize();

            _millet = millet;
            _warriors = warriors;
            _workers = workers;

            ReloadState();
        }
        private void ReloadState() 
        {
            Field = 0;
            _timer = 0;
        }
        public override void Restart()
        {
            base.Restart();
            ReloadState();
        }

        protected override void Tick()
        {
            _timer += Time.deltaTime;
            if (_timer >= _maxTimer)
            {
                _timer = 0;
                ++Field;

                _audioSource.Play();
                _millet.UpdateMilletMorning(_workers.GetWheatProduction(), _warriors.GetWheatConsumption());
            }
            _iTimer.fillAmount = 1 - _timer / _maxTimer;
        }

        public string GetStatistic() => $"The number of dawns that have come is {Field}";
    }
}
