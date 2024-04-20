using UnityEngine;

namespace Assets.Scripts.Work.Pages
{
    public class BaseWindow : MonoBehaviour
    {
        protected GameObject Page;
        protected void Initialize()
        {
            Page = gameObject;
        }

        public virtual void Exit() => Page.SetActive(false);
        public virtual void Show() => Page.SetActive(true);
    }
}
