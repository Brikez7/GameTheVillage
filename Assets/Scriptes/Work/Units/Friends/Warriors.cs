using UnityEngine;

namespace Assets.Scripts.Work.Units
{
    public class Warriors : FriendUnit
    {
        [Range(0, 10)] [SerializeField] private uint EvenWheatConsumption;
        public uint GetWheatConsumption() => EvenWheatConsumption * Count;

        public override string GetStatistic() => $"The number of warriors produced is {Field}";
    }
}