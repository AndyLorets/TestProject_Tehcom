using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class SoundBehaviour : MonoBehaviour
{
    private AudioSource _audioSource;
    bool _isMute; 
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _isMute = Repository.SoundMuteState; 
    }
    private void ChangeState(bool mute) => _isMute = mute;
    public void PlaySound()
    {
        if(_isMute) return;

        _audioSource.Play(); 
    }

    private void OnEnable()
    {
        Repository.SoundMuteStateEvent += ChangeState;
    }
    private void OnDisable()
    {
        Repository.SoundMuteStateEvent -= ChangeState;
    }
}
