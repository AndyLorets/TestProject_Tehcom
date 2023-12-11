using UnityEngine;

public abstract class PurchaseItem : ScriptableObject
{
    [field: SerializeField] public string title { get; private set; }
    [field : SerializeField] public Sprite icon { get; private set; }
    [field : SerializeField] public int price { get; private set; }
    [field: SerializeField] public int count { get; private set; }
    [field: SerializeField] public int minLvlToSold { get; private set; }

    public abstract void Sold(); 

}
