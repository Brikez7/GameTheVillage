namespace Assets.Scripts.Work.Interfaces
{
    public interface IKeyStatistic<T> : IStatistic
    {
        public T Field { get; set; }
    }
    public interface IStatistic 
    {
        public string GetStatistic();
    }
}
