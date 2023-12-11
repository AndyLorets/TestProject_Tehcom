using UnityEngine;

[System.Serializable]
public class Reward
{
    public enum RewardType
    {
        Coin, Gem
    }
    [field: SerializeField] public RewardType rewardType { get; private set; }
    [field: SerializeField] public int value { get; private set; }
    [field: SerializeField] public string name { get; private set; }
    [field: SerializeField] public Sprite sprite { get; private set; }
}
