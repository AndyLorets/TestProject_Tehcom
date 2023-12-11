using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PurchasePrefab : MonoBehaviour
{
    [SerializeField] private PurchaseItem _purchaseItem;
    [SerializeField] private TextMeshProUGUI _title;
    [SerializeField] private Image _icon;
    [SerializeField] private TextMeshProUGUI _price;
    [SerializeField] private TextMeshProUGUI _count;

    private Button _buyButton;  
    private void OnEnable()
    {
        Construct();
    }
    private void Awake()
    {
        _buyButton = GetComponent<Button>();    
    }
    private void Construct()
    {
        bool meetsMinLevelRequirement = Repository.LvlIndex >= _purchaseItem.minLvlToSold;

        _title.text = _purchaseItem.title;
        _icon.sprite = _purchaseItem.icon;
        _price.text = meetsMinLevelRequirement ? $"{_purchaseItem.price}$" : $"Level {_purchaseItem.minLvlToSold}";
        _price.color = meetsMinLevelRequirement ? Color.white : Color.red;
        _count.text = _purchaseItem.count.ToString();

        _buyButton.interactable = meetsMinLevelRequirement; 
    }
    public void Sold() => _purchaseItem.Sold();
}
