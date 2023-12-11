using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class MusicBehaviour : MonoBehaviour
{
    [SerializeField] private AudioClip[] _clips;

    private int _currentClipIndex; 
    private AudioSource _audioSource;
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>(); 
    }
    private void Start()
    {
        if (!Repository.MusicMuteState)
            ChangeClip(); 
    }
    private void ChangeClip()
    {
        _currentClipIndex = Random.Range(0, _clips.Length);
        _audioSource.clip = _clips[_currentClipIndex];
        _audioSource.Play(); 
    }
    private void ChangeState(bool mute)
    {
        if (mute)
        {
            _audioSource.Stop();
            return; 
        }

        ChangeClip();
    }

    private void OnEnable()
    {
        Repository.MusicMuteStateEvent += ChangeState; 
    }
    private void OnDisable()
    {
        Repository.MusicMuteStateEvent -= ChangeState;
    }
}
