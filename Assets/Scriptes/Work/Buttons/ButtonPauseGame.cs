using UnityEngine;

namespace Assets.Scripts.Work.Buttons
{
    public class ButtonPauseGame : MonoBehaviour
    {
        private GameState _gameState;
        private bool _isPaused;
        public void Initialize(GameState gameState)
        {
            _gameState = gameState;
        }

        public void PauseGame()
        {
            if (_isPaused)
            {
                _gameState.RemovePauseGame();
                _isPaused = false;
            }
            else
            {
                _gameState.PauseGame();
                _isPaused = true;
            }
        }
    }
}
