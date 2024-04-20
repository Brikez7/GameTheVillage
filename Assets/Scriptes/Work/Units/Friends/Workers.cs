using Assets.Scripts.Work.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Work.Units
{
    public class Workers : FriendUnit, IRulesVictory
    {
        [Range(0, 10)] [SerializeField] private uint EvenWheatProduction;
        public VerifierConditionsVictory WinChecker { get; set; }
        public virtual void Initialize(VerifierConditionsVictory winChecker)
        {
            Initialize();
            WinChecker = winChecker;
        }

        public uint GetWheatProduction() => EvenWheatProduction * Count;

        public override void Production(uint count)
        {
            base.Production(count);
            ComplianceVictoryRule();
        }
        public void ComplianceVictoryRule() => WinChecker.ComplianceWorkerIsWinCondition((int)Count);
        
        public override string GetStatistic() => $"The number of workers produced is {Field}";
    }
}