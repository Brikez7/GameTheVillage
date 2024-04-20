using Assets.Scripts.Work.Interfaces;

namespace Assets.Scripts.Work.Units
{
    public class Enemies : BaseUnit, IKeyStatistic<int>
    {
        public override void Restart()
        {
            base.Restart();
            Field = 0;
        }
        public int Field { get; set; }
        public void NextWave(float multiplierEnemy)
        {
            Field += (int)Count;
            Count = (uint)(Count * multiplierEnemy);
            TCount.text = Count.ToString();
        }

        public string GetStatistic() => $"The number of slain enemies player is {Field}";
    }
}