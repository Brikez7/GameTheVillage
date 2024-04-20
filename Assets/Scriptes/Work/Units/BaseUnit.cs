using Assets.Scripts.Work.Interfaces;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Work.Units
{
    public abstract class BaseUnit : MonoBehaviour, IRestarter
    {
        protected uint Count;
        protected uint StartCount { get => _startCount; }

        [Range(0, 10)][SerializeField] private uint _startCount;
        protected TMP_Text TCount;
        public virtual void Initialize()
        {
            TCount = GetComponentInChildren<TMP_Text>();
            ReloadState();
        }
        public virtual void Restart() => ReloadState();
        
        private void ReloadState()
        {
            Count = StartCount;
            TCount.text = Count.ToString();
        }

        public class Battle
        {
            public static bool Fight(Warriors friendUnit, Enemies enemy)
            {
                bool isNotDefeat = friendUnit.Count > enemy.Count;

                if (isNotDefeat)
                {
                    friendUnit.Count -= enemy.Count;
                    friendUnit.TCount.text = friendUnit.Count.ToString();
                }
                return isNotDefeat;
            }
        }
    }
}