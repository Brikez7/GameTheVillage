namespace Assets.Scripts.Work.Interfaces
{
    public interface IRulesVictory
    {
        public VerifierConditionsVictory WinChecker { get; set; }
        public void ComplianceVictoryRule();
    }
}
