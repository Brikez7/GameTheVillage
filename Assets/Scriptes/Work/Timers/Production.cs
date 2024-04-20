using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Work.Units;
using static Assets.Scripts.Work.Units.ProductionCharacteristics;

namespace Assets.Scripts.Work.Timers
{
    public sealed class Production : BaseTimer
    {
        private Millet _heroMillet;

        private Dictionary<TypeFriendUnit, TimerProduction> _dictionaryTimerProductions;
        public void Initialize(Millet heroMillet, Dictionary<TypeFriendUnit, TimerProduction> dictionaryTimerProductions)
        {
            Initialize();
            _dictionaryTimerProductions = dictionaryTimerProductions;
            _heroMillet = heroMillet;

            ReloadState();
        }
        private void ReloadState() => _dictionaryTimerProductions.Action(x => x.CancelProduction());
        public override void Restart()
        {
            base.Restart();
            ReloadState();
        }

        public void By(TypeFriendUnit typeUnit)
        {
            var timerProduction = _dictionaryTimerProductions[typeUnit];
            if (_heroMillet.ByUnit(timerProduction.Characteristics.Cost) && IsNotStop)
                timerProduction.StartProduction();
        }

        protected override void Tick()
        {
            _dictionaryTimerProductions.Action(x =>
            {
                if (x.IsProduction)
                    x.UpdateTimerProduction();
            });
        }
    }
    public class TimerProduction
    {
        public bool IsProduction { get; private set; } = false;
        public float Timer = 0;
        private uint _countProductions = 1;
        public ProductionCharacteristics Characteristics => FriendUnit.ProductionCharacteristics;
        public FriendUnit FriendUnit { get; private set; }
        private readonly Image _iTimerProduction;
        public TimerProduction(FriendUnit friendUnit, Image iTimerProduction)
        {
            FriendUnit = friendUnit;
            _iTimerProduction = iTimerProduction;
        }

        public void StartProduction()
        {
            IsProduction = true;
            _iTimerProduction.gameObject.SetActive(true);
        }

        public bool UpdateTimerProduction()
        {
            Timer += Time.deltaTime;
            if (Timer >= FriendUnit.ProductionCharacteristics.ProductionTime)
            {
                FriendUnit.Production(_countProductions);
                CancelProduction();

                return true;
            }
            _iTimerProduction.fillAmount = Timer / FriendUnit.ProductionCharacteristics.ProductionTime;
            return false;
        }
        public void CancelProduction()
        {
            _iTimerProduction.fillAmount = 0;
            _iTimerProduction.gameObject.SetActive(false);

            IsProduction = false;
            Timer = 0;
        }
    }
}
