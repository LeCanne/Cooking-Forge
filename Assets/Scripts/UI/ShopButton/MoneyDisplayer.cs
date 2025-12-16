using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MoneyDisplayer : MonoBehaviour
{
    public TMP_Text moneyText;
    

    private void Start()
    {
        PlayerResourcesHandler.Instance.moneyUpdate += DisplayMoney;
    }

    void DisplayMoney()
    {
        moneyText.text = PlayerResourcesHandler.Instance.money.ToString();
    }
}
