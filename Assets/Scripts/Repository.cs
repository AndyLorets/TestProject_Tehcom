using UnityEngine;
public static class Repository
{
    #region Currency
    private const string _coinPrefs = "CoinsPrefs";
    public delegate void CurrencyEvent(int value);
    public static CurrencyEvent currencyChanged;
    public static int Coins
    {
        get => PlayerPrefs.GetInt(_coinPrefs, 0);
        set
        {
            PlayerPrefs.SetInt(_coinPrefs, value);
            currencyChanged?.Invoke(value);
        }
    }
    #endregion

    #region DailyRewards
    private const string _currentStreakPrefs = "CurrentStreak";
    public static int CurrentStreak
    {
        get => PlayerPrefs.GetInt(_currentStreakPrefs, 0);
        set => PlayerPrefs.SetInt(_currentStreakPrefs, value);
    }
    #endregion

    #region DateTime
    private const string _lastClaimEnergyTimePrefs = "LastClaimEnergyTime";
    private const string _lastClaimRewardTimePrefs = "LastClaimRewardTime";
    private const string _lastShowInterstitialTimePrefs = "LastShowInterstitialTime";
    public static string LastDateTimeEnergy
    {
        get => PlayerPrefs.GetString(_lastClaimEnergyTimePrefs, null);
        set => PlayerPrefs.SetString(_lastClaimEnergyTimePrefs, value);
    }
    public static string LastDateTimeReward
    {
        get => PlayerPrefs.GetString(_lastClaimRewardTimePrefs, null);
        set => PlayerPrefs.SetString(_lastClaimRewardTimePrefs, value);
    }
    public static string LastDateTimeShowInterstitial
    {
        get => PlayerPrefs.GetString(_lastShowInterstitialTimePrefs, null);
        set => PlayerPrefs.SetString(_lastShowInterstitialTimePrefs, value);
    }
    #endregion

    #region LvlManager
    private const string _lvlIndexPrefs = "LvlIndex";
    private const string _lvlAvablePrefs = "LvlAvablePrefs";
    private const string _lvlsCountPrefs = "LvlsCount";

    public delegate void UpdateLevelData();
    public static UpdateLevelData updateLevelData; 
    public static int LvlIndex
    {
        get => PlayerPrefs.GetInt(_lvlIndexPrefs, 0);
        set
        {
            PlayerPrefs.SetInt(_lvlIndexPrefs, value);
            updateLevelData?.Invoke(); 
        }
    }
    public static int LvlsCount
    {
        get => PlayerPrefs.GetInt(_lvlsCountPrefs, 0);
        set => PlayerPrefs.SetInt(_lvlsCountPrefs, value);
    }
    public static bool GetLevelAvable(int lvlIndex)
    {
        return PlayerPrefs.HasKey(_lvlAvablePrefs + lvlIndex); 
    }
    public static void SetLevelAvable(int lvlIndex)
    {
        PlayerPrefs.SetInt(_lvlAvablePrefs + lvlIndex, 1); 
    }
    #endregion

    #region ADSParameters
    private const string _adsPrefs = "AdsPrefs";
    public const string adBannerKey = "d7c98608b19523eb";
    public const string adInterstitialKey = "d4e20dedfb9ae00f";
    public const string adRewardKey = "fee6e17180cf60f9";
    public static bool AdsEnable => !PlayerPrefs.HasKey(_adsPrefs);
    public static void DisableAds() => PlayerPrefs.SetString(_adsPrefs, "Buyed");
    #endregion

    #region Sound
    private const string _soundEffect_mute_prefs = "SoundEffectsMute";
    private const string _soundMusic_mute_prefs = "SoundMusicsMute";
    private const int bool_true_value = 1;

    public delegate void SoundEvent(bool value);
    public static SoundEvent SoundMuteStateEvent;
    public static SoundEvent MusicMuteStateEvent;
    public static bool SoundMuteState
    {
        get
        {
            return PlayerPrefs.GetInt(_soundEffect_mute_prefs) == bool_true_value;
        }
        set
        {
            int state = value ? bool_true_value : -bool_true_value;
            PlayerPrefs.SetInt(_soundEffect_mute_prefs, state);
            SoundMuteStateEvent?.Invoke(value);   
        }
    }
    public static bool MusicMuteState
    {
        get
        {
            return PlayerPrefs.GetInt(_soundMusic_mute_prefs) == bool_true_value;
        }
        set
        {
            int state = value ? bool_true_value : -bool_true_value;
            PlayerPrefs.SetInt(_soundMusic_mute_prefs, state);
            MusicMuteStateEvent?.Invoke(value);
        }
    }
    #endregion
}
