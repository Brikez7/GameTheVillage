using Assets.Scripts.Work.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Work.Timers
{
    public abstract class BaseTimer : MonoBehaviour, IPause, IRestarter
    {
        protected bool IsNotStop;
        protected virtual void Initialize() => IsNotStop = true;


        protected void Update()
        {
            if (IsNotStop)
                Tick();
        }
        protected abstract void Tick();

        public virtual void Restart() => IsNotStop = true;

        public void StartPause()
            => IsNotStop = false;
        public void StopPause()
            => IsNotStop = true;
    }
}