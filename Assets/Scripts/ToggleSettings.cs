using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ToggleSettings : MonoBehaviour
{
    [SerializeField] private SettingsType _toggling;
    [SerializeField] private Image _image;
    [SerializeField] private Sprite _activeStateSprite, _deactiveStateSprite; 
    private bool _isMute; 
    private Button _button;

    private enum SettingsType
    {
        Sounds, Music
    }
    private void Start()
    {
        Construct();
        ChangeSprite();
    }
    private void Construct()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(() => ChangeState());

        switch (_toggling)
        {
            case SettingsType.Sounds:
                _isMute = Repository.SoundMuteState;
                break;
            case SettingsType.Music:
                _isMute = Repository.MusicMuteState;
                break;
        }
    }

    public void ChangeState()
    {
        _isMute = !_isMute;

        ChangeSprite();
        SaveState(); 
    }

    private void ChangeSprite()
    {
        _image.sprite = _isMute ? _deactiveStateSprite : _activeStateSprite;
    }

    private void SaveState()
    {
        switch (_toggling)
        {
            case SettingsType.Sounds:
                Repository.SoundMuteState = _isMute;
                break;
            case SettingsType.Music:
                Repository.MusicMuteState = _isMute;
                break;
        }
    }
}
