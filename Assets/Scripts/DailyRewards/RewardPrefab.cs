using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RewardPrefab : MonoBehaviour
{
    [Header("BackGround")]
    [Space(5)]
    [SerializeField] private Image _backGroundImage;
    [SerializeField] private Sprite _defaultSprite;
    [SerializeField] private Sprite _currentStreakSprite;
    [Header("Reward Icon")]
    [Space(5)]
    [SerializeField] private Image _rewardIconImege;
    [Header("Text")]
    [Space(5)]
    [SerializeField] private TextMeshProUGUI _rewardValueText;
    [SerializeField] private TextMeshProUGUI _dayText;

    public void UpdateRewardDate(int day, int currentStreak, Reward reward)
    {
        bool isCurrentStreak = day == currentStreak;

        _dayText.text = $"Day {day + 1}";
        _rewardValueText.text = reward.value.ToString();
        _rewardIconImege.sprite = reward.sprite;
        _backGroundImage.sprite = isCurrentStreak ? _currentStreakSprite : _defaultSprite;
    }
}
