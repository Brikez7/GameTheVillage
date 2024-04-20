namespace Assets.Scripts.Work.Pages
{
    public class WindowDescVictory : BaseWindow
    {
        private GameState _gameState;
        public void Initialize(GameState gameState)
        {
            Initialize();
            _gameState = gameState;
        }

        public override void Show()
        {
            base.Show();
            _gameState.PauseGame();
        }
        public override void Exit()
        {
            base.Exit();
            _gameState.RemovePauseGame();
        }
    }
}
