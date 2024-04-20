using Assets.Scripts.Work.Interfaces;
using Assets.Scripts.Work.Pages;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Work
{
    public class GameState : MonoBehaviour
    {
        private EndGamePage _endGamePage;
        private IEnumerable<IPause> _elementsPause;
        private IEnumerable<IRestarter> _elementsRestarter;
        private StateGame _state;

        [SerializeField] private AudioClip _audioVictory; 
        [SerializeField] private AudioClip _AudioDefeat; 
        [SerializeField] private AudioSource _sourceEndGame; 

        public void Initialize(EndGamePage endGamePage, IEnumerable<IPause> elementsPause, IEnumerable<IRestarter> elementsRestarter)
        {
            _endGamePage = endGamePage;
            _elementsPause = elementsPause;
            _elementsRestarter = elementsRestarter;
            _state = StateGame.ActiveGame;
        }

        public void RestartGame()
        {
            _elementsRestarter.Action(x => x.Restart());
            _state = StateGame.ActiveGame;
        }

        public void PauseGame()
        {
            if (_state == StateGame.ActiveGame)
            {
                _elementsPause.Action(x => x.StartPause());
                _state = StateGame.PausedGame;
            }
            else
                Debug.Log($"Game state is {_state} and not move to {StateGame.PausedGame}");
        }
        public void RemovePauseGame()
        {
            if (_state == StateGame.PausedGame)
            {
                _elementsPause.Action(x => x.StopPause());
                _state = StateGame.ActiveGame;
            }
            else
                Debug.Log($"Game state is {_state} and not move to {StateGame.ActiveGame}");
        }
        public void EndGame(bool isWin)
        {
            PauseGame();
            _state = StateGame.EndedGame;

            PlayClip(isWin);

            _endGamePage.EndGame(isWin);
        }
        private void PlayClip(bool isVictory) 
        {
            if (isVictory)
                _sourceEndGame.clip = _audioVictory;
            else
                _sourceEndGame.clip = _AudioDefeat;

            _sourceEndGame.Play();
        }
    }
    public enum StateGame
    {
        PausedGame = 0,
        ActiveGame = 1,
        EndedGame = 2
    }
}