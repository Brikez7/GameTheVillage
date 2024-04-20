using Assets.Scripts.Work.Interfaces;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Work
{
    public class StatisticsCollector : MonoBehaviour
    {
        private IEnumerable<IStatistic> _statistics;
        public void Initialize(IEnumerable<IStatistic> statistics)
            => _statistics = statistics;
        
        public string GetStatistics() => _statistics.FuncToString(x => x.GetStatistic());
    }
}
