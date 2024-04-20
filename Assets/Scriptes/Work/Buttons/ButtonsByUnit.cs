using Assets.Scripts.Work.Timers;
using UnityEngine;
using static Assets.Scripts.Work.Units.ProductionCharacteristics;

namespace Assets.Scripts.Work.Buttons
{
    public class ButtonsByUnit : MonoBehaviour
    {
        private Production _production;
        public void Initialize()
        {
            _production = GetComponent<Production>();
        }

        public void ByWorkers()
        {
            _production.By(TypeFriendUnit.Worker);
        }
        public void ByWarriors()
        {
            _production.By(TypeFriendUnit.Warrior);
        }
    }
}
