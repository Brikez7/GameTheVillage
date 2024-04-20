using UnityEngine;
using UnityEngine.UI;

public class MP3Player : MonoBehaviour
{
    private AudioSource _audioSource;

    [SerializeField] private AudioClip[] _music;
    [SerializeField] private Image _iMusic;

    public void Start()
    {
        _audioSource = _iMusic.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (_audioSource.isPlaying)
            _iMusic.fillAmount = 1 - _audioSource.time / _audioSource.clip.length;
    }

    public void Pause()
    {
        if (_audioSource.isPlaying)
            _audioSource.Stop();
        else
            _audioSource.Play();
    }

    public void ChangeMusic(int indexMusic)
    {
        if (indexMusic > -1 && indexMusic < _music.Length)
            _audioSource.clip = _music[indexMusic];
        else Debug.Log($"Error! The index music {indexMusic} is not exists");
    }
}
