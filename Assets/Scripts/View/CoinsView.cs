using DG.Tweening;
using TMPro;
using UnityEngine;

public class CoinsView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinText;
    [SerializeField] private Transform _coinImage;
    [SerializeField] private SoundBehaviour _coinSound; 

    private const float tween_duration = .5f; 
    private void Start()
    {
        RenderCoin(); 
    }
    private void RenderCoin(int value = 0)
    {
        _coinText.text = Repository.Coins.ToString();

        if (value == 0) return;

        _coinSound.PlaySound(); 
        _coinImage.DOPunchScale(Vector3.one * .15f, tween_duration);
        _coinText.DOColor(Color.yellow, tween_duration)
            .OnComplete(() => _coinText.DOColor(Color.white, tween_duration));
    }
    private void OnEnable()
    {
        Repository.currencyChanged += RenderCoin; 
    }
}
