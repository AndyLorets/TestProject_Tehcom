using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class UILvlPrefab : MonoBehaviour
{
    [SerializeField] protected Image _image;
    [SerializeField] protected Image _lockImage;
    [SerializeField] protected TextMeshProUGUI _lvlText;
    private Button _playLevelBtn; 
    protected int _lvlIndex;
    protected int _targetStars;
    protected bool _avable;
    protected bool _specialLvl;
    public virtual void UpdateLvlData(int lvlIndex, bool avable)
    {
        _playLevelBtn = GetComponent<Button>();
        _lvlIndex = lvlIndex;
        _avable = avable;

        RenderUI();
        InitMainButton();
    }
    protected virtual void RenderUI()
    {
        _lvlText.text = _avable == true ? (_lvlIndex + 1).ToString() : "";
        _lockImage.gameObject.SetActive(!_avable);
    }

    protected virtual void InitMainButton()
    {
        if (_playLevelBtn == null) return;

        _playLevelBtn.onClick.RemoveAllListeners();
        _playLevelBtn.onClick.AddListener(delegate ()
        {
            if (_avable)
            {
                int nextLvl = _lvlIndex + 1; 
                Repository.SetLevelAvable(nextLvl);
                Repository.LvlIndex = nextLvl;
            }
            else
            {
                _lockImage.transform.DORestart();
                _lockImage.transform.DOScale(Vector3.one * 1.3f, 0.2f)
                     .OnComplete(() => _lockImage.transform.DOScale(Vector3.one, 0.2f));
            }
        });
    }
}
