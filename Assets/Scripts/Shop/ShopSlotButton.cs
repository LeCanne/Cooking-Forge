using TMPro;
using UnityEngine;

public class ShopSlotButton : MonoBehaviour
{
    public ResourceData resourceGiven;
    public int price;

    public TMP_Text priceShown;
   

    public void Start()
    {
        priceShown.text = price.ToString();
    }

    public void BuyResource()
    {
        if (PlayerResourcesHandler.Instance.Buyable(price))
        {
            PlayerResourcesHandler.Instance.GiveResource(resourceGiven);
        }
    }


}
