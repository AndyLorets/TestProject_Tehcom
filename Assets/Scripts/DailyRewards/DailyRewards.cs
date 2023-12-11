using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class DailyRewards : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _statusText;
    [SerializeField] private Color _fallBtnTxtColor;
    [SerializeField] private Color _fallStatusColor;
    [SerializeField] private Button _claimBtn;
    //[SerializeField] private Animation _claimAnimation;
    [Space(5)]
    [SerializeField] private List<Reward> _rewardsList;
    [SerializeField] private List<RewardPrefab> _rewardPrefabsList;

    private bool _canClaimReward;
    private float _claimCoolDown = 24f;
    private float _claimDeadline = 48f;

    private const float tween_duration = .7f;
    private const float coroutine_duration = 1f;

    private void Start()
    {
        StartCoroutine(RewardStateUpdater());
        StartCoroutine(Visiblie(_canClaimReward));

        for (int i = 0; i < _rewardPrefabsList.Count; i++)
            _rewardPrefabsList[i].UpdateRewardDate(i, Repository.CurrentStreak, _rewardsList[i]);
    }
    public IEnumerator Visiblie(bool state, float t = 0)
    {
        yield return new WaitForSeconds(t); 
        transform.GetChild(0).gameObject.SetActive(state);
        _statusText.DOColor(Color.white, tween_duration);
    }
    private IEnumerator RewardStateUpdater()
    {
        while (true)
        {
            UpdateRewardState();
            //if (_canClaimReward) _claimAnimation.Play();
            //else _claimAnimation.Stop();
            yield return new WaitForSeconds(coroutine_duration);
        }
    }
    private void UpdateRewardState()
    {
        _canClaimReward = true;
        if (DateTimer.LastClaimRewardTime.HasValue)
        {
            var timeSpan = DateTime.UtcNow - DateTimer.LastClaimRewardTime.Value;

            if (timeSpan.TotalHours > _claimDeadline)
            {
                DateTimer.LastClaimRewardTime = null;
                Repository.CurrentStreak = 0;
            }
            else if (timeSpan.TotalHours < _claimCoolDown)
                _canClaimReward = false;
        }
        UpdateRewardsUI();
    }
    private void UpdateRewardsUI()
    {
        _claimBtn.onClick.RemoveAllListeners(); 
        _claimBtn.onClick.AddListener(delegate ()
        {
            if (_canClaimReward) StartCoroutine(ClaimReward());
            else StartCoroutine(Visiblie(false));
        });

        if (_canClaimReward)
            _statusText.text = "Claim You Reward";
        else
        {
            var nextClaimTime = DateTimer.LastClaimRewardTime.Value.AddHours(_claimCoolDown);
            var currentClaimCoolDown = nextClaimTime - DateTime.UtcNow;

            string cd = $"{currentClaimCoolDown.Hours:D2}:{currentClaimCoolDown.Minutes:D2}:{currentClaimCoolDown.Seconds:D2}";

            _statusText.text = $"Come back in {cd} for you next Reward!";
        }

        TextMeshProUGUI textBtn = _claimBtn.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        bool stateColor = textBtn.color == Color.white;
        Color colorTextBtn = !stateColor ? Color.white : _fallBtnTxtColor; 
        Color colorStatusText = !stateColor ? Color.white : _fallStatusColor;
        textBtn.text = _canClaimReward ? "Tap To Collect" : "Back";
        textBtn.DOColor(colorTextBtn, tween_duration);
        _statusText.DOColor(colorStatusText, tween_duration);
    }
    private IEnumerator ClaimReward()
    {
        if (!_canClaimReward) yield return null;

        var reward = _rewardsList[Repository.CurrentStreak]; 
        switch(reward.rewardType)
        {
            case Reward.RewardType.Coin:
                Repository.Coins += reward.value; 
                break;
        }

        DateTimer.LastClaimRewardTime = DateTime.UtcNow;
        Repository.CurrentStreak = (Repository.CurrentStreak + 1) % _rewardPrefabsList.Count;

        UpdateRewardState();

        yield return new WaitForSeconds(1);

        for (int i = 0; i < _rewardPrefabsList.Count; i++)
            _rewardPrefabsList[i].UpdateRewardDate(i, Repository.CurrentStreak, _rewardsList[i]);

        StartCoroutine(Visiblie(_canClaimReward, 5f));

    }
    public void OpenPanel()
    {
        StartCoroutine(Visiblie(true));
    }
    public void RemoveAll()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(0); 
    }
}
