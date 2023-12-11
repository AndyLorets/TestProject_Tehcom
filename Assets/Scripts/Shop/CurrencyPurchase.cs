using UnityEngine;
[CreateAssetMenu(fileName = "NewPurchaseCurrency", menuName = "ScriptableObject/PurchaseCurrency")]
public class CurrencyPurchase : PurchaseItem
{
    public override void Sold()
    {
        Repository.Coins += count;
    }
}
