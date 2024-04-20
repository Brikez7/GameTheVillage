using Assets.Scripts.Work.Interfaces;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Work
{
    public class VerifierConditionsVictory : MonoBehaviour, IRestarter
    {
        [Range(1, 100)] [SerializeField] private int _countWorkersNeedForWin;
        private TMP_Text _tCountWorkersNeedForWin;
        private bool _isWinWorker;

        [Range(1, 100)] [SerializeField] private int _countMilletNeedForWin;
        private TMP_Text _tCountMilletNeedForWin;
        private bool _isWinMillet;

        private GameState _gameState;
        public void Initialize(GameState gameState)
        {
            _gameState = gameState;

            var texts = GetComponentsInChildren<TMP_Text>();
            _tCountMilletNeedForWin = texts[0];
            _tCountWorkersNeedForWin = texts[1];
            _tCountWorkersNeedForWin.text = $"1) The workers needed to win - {_countWorkersNeedForWin}";
            _tCountMilletNeedForWin.text = $"2) The millet needed to win - {_countMilletNeedForWin}";
        }

        public void ComplianceWorkerIsWinCondition(int countWorkers)
        {
            _isWinWorker = countWorkers >= _countWorkersNeedForWin;
            CheckWinConditions();
        }
        public void ComplianceMilletIsWinCondition(int countMillet)
        {
            _isWinMillet = countMillet >= _countMilletNeedForWin;
            CheckWinConditions();
        }
        private void CheckWinConditions()
        {
            if (_isWinWorker && _isWinMillet)
                _gameState.EndGame(true);
        }

        public void Restart()
        {
            _isWinWorker = false;
            _isWinMillet = false;
        }
    }
}
