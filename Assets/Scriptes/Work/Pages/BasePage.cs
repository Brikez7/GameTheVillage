namespace Assets.Scripts.Work.Pages
{
    public class BasePage : BaseWindow
    {
        protected BasePage OtherPage;
        public virtual void Initialize(BasePage nextPage)
        {
            Initialize();
            OtherPage = nextPage;
        }
        public virtual void ShowNext()
        {
            Exit();
            OtherPage.Show();
        }
    }
}
