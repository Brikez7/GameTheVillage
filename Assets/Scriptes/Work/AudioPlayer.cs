using Assets.Scripts.Work.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Work
{
    public class AudioPlayer : MonoBehaviour, IPause, IRestarter
    {
        private const float _pauseMultiplier = 0.3f;
        private bool _isPlaying = true;
        [SerializeField] private AudioSource[] _audioSources;

        public void ChangeState()
        {
            if (_isPlaying)
                Off();
            else
                On();
        }
        private void On()
        {
            _audioSources.Action(x => x.Play());
            _isPlaying = true;
        }
        private void Off()
        {
            _audioSources.Action(x => x.Stop());
            _isPlaying = false;
        }

        public void StartPause() => _audioSources.Action(x => x.volume *= _pauseMultiplier);
        public void StopPause() => _audioSources.Action(x => x.volume /= _pauseMultiplier);
        
        public void Restart() => StopPause();
        
    }
}
