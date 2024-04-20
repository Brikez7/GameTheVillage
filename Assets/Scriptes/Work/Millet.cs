using Assets.Scripts.Work.Interfaces;
using System;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Work
{
    public class Millet : MonoBehaviour, IRestarter, IRulesVictory, IKeyStatistic<(uint ProducedMillet, uint SpentMillet)>
    {
        [Range(0, 30)] [SerializeField] private int _startMilletCount;
        private int _milletCount;
        private TMP_Text _tMilletCount;

        private (uint ProducedMillet, uint SpentMillet) _field;
        public (uint ProducedMillet, uint SpentMillet) Field
        {
            get { return _field; }
            set { _field = value; }
        }

        public VerifierConditionsVictory WinChecker { get; set; }
        public void Initialize(VerifierConditionsVictory game)
        {
            WinChecker = game;
            _tMilletCount = GetComponentInChildren<TMP_Text>();

            Restart();
            ReloadState();
        }

        public bool ByUnit(uint milletCount)
        {
            bool canBy = _milletCount >= milletCount;
            if (canBy)
            {
                _field.SpentMillet += milletCount;

                _milletCount -= (int)milletCount;
                ComplianceVictoryRule();

                _tMilletCount.text = _milletCount.ToString();
            }
            return canBy;
        }

        public void UpdateMilletMorning(uint producedMillet, uint spentMillet)
        {
            _field.ProducedMillet += producedMillet;
            _field.SpentMillet += spentMillet;

            _milletCount = _milletCount - (int)spentMillet + (int)producedMillet;
            ComplianceVictoryRule();

            _tMilletCount.text = _milletCount.ToString();
        }

        public void ComplianceVictoryRule()
        {
            WinChecker.ComplianceMilletIsWinCondition(_milletCount);
        }

        public void Restart()
        {
            ReloadState();

            _milletCount = _startMilletCount;
            _tMilletCount.text = _milletCount.ToString();
        }
        private void ReloadState()
        {
            _field.ProducedMillet = 0;
            _field.SpentMillet = 0;
        }

        public string GetStatistic() 
            => $"The amount of millet produced is {Field.ProducedMillet}\n" +
               $"The amount of millet spent is {Field.SpentMillet}";
    }
}
