using Mono.Cecil;
using TMPro;
using UnityEngine;

public class ShopSlotButton : MonoBehaviour
{
    public ResourceData resourceGiven;
    public EconomyData economyData;
    public enum MATTYPE
    {
        copper,
        iron,
        gold,
    }
    public MATTYPE type;    
    private int price;

    public TMP_Text priceShown;
    public TMP_Text currentMaterials;

    private void Awake()
    {
        
    }
    public void Start()
    {
        switch (type)
        {
            case MATTYPE.copper:
                price = economyData.copperPrice;
                break;

            case MATTYPE.iron:
                price = economyData.ironPrice;
                break;

            case MATTYPE.gold:
                price = economyData.goldPrice;
                break;
        }
        priceShown.text = price.ToString();

        PlayerResourcesHandler.Instance.updateMaterial += UpdateMaterials;
    }

    void UpdateMaterials()
    {
        int amount = 0;
        switch (type)
        {
            case MATTYPE.copper:
                amount = PlayerResourcesHandler.Instance.playerResources.copper;
                break;

            case MATTYPE.iron:
                amount = PlayerResourcesHandler.Instance.playerResources.iron;
                break;

            case MATTYPE.gold:
                amount = PlayerResourcesHandler.Instance.playerResources.gold;
                break;
        }
        currentMaterials.text = amount.ToString();
    }

    public void BuyResource()
    {
        if (PlayerResourcesHandler.Instance.Buyable(price))
        {
            PlayerResourcesHandler.Instance.GiveResource(resourceGiven);
        }
    }


}
