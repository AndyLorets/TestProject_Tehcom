using System;

public static class DateTimer
{
    public static DateTime? LastClaimRewardTime
    {
        get
        {
            string date = Repository.LastDateTimeReward;

            if (!string.IsNullOrEmpty(date))
                return DateTime.Parse(date);
            return null;
        }
        set
        {
            if (value != null)
                Repository.LastDateTimeReward = value.ToString();
            else
                Repository.LastDateTimeReward = null;
        }
    }

    public static DateTime? LastClaimEnergyTime
    {
        get
        {
            string date = Repository.LastDateTimeEnergy;

            if (!string.IsNullOrEmpty(date))
                return DateTime.Parse(date);
            return null;
        }
        set
        {
            if (value != null)
                Repository.LastDateTimeEnergy = value.ToString();
            else
                Repository.LastDateTimeEnergy = null;
        }
    }
    public static DateTime? LastShowInterstitialTime
    {
        get
        {
            string date = Repository.LastDateTimeShowInterstitial;

            if (!string.IsNullOrEmpty(date))
                return DateTime.Parse(date);
            return null;
        }
        set
        {
            if (value != null)
                Repository.LastDateTimeShowInterstitial = value.ToString();
            else
                Repository.LastDateTimeShowInterstitial = null;
        }
    }
}