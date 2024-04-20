using Assets.Scripts.Work.Interfaces;
using System;
using UnityEngine;

namespace Assets.Scripts.Work.Units
{
    public abstract class FriendUnit : BaseUnit, IKeyStatistic<int>
    {
        [SerializeField] private ProductionCharacteristics _productionCharacteristics;
        public ProductionCharacteristics ProductionCharacteristics { get => _productionCharacteristics; }
        public int Field { get; set; }
        [SerializeField] private AudioSource _audioSource;
        public virtual void Production(uint count)
        {
            _audioSource.Play();
            Count += count;
            Field += (int)count;
            TCount.text = Count.ToString();
        }

        public override void Restart()
        {
            base.Restart();
            Field = 0;
        }

        public abstract string GetStatistic();
    }
    [Serializable]
    public struct ProductionCharacteristics
    {
        [Range(0.1f, 5)] public float ProductionTime;
        [Range(1, 10)] public uint Cost;
        public TypeFriendUnit TypeUnit;
        public ProductionCharacteristics(float productionTime, uint cost, TypeFriendUnit typeUnit)
        {
            ProductionTime = productionTime;
            Cost = cost;
            TypeUnit = typeUnit;
        }
        [Serializable]
        public enum TypeFriendUnit
        {
            Warrior = 0,
            Worker = 1
        }
    }
}

