using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerResourcesHandler : MonoBehaviour
{
    private static PlayerResourcesHandler _instance;
    public static PlayerResourcesHandler Instance
    {
        get 
        { 
            if(_instance == null)
            {
                GameObject go = new GameObject("ResourcesHandler");
                _instance = go.AddComponent<PlayerResourcesHandler>();

            }    
            
            return _instance; 
        }
    }

    public ResourceData playerResources;
    public event Action moneyUpdate;
    public event Action updateMaterial;
    public int money;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy( gameObject );
        }
        else
        {
            _instance = this;
        }

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MoneyUpdated();
        MaterialUpdated();
    }

    public bool Craftable(ResourceData resourceTaken)
    {
        int pCopper = playerResources.copper;
        int pSilver = playerResources.iron;
        int pGold = playerResources.gold;
        int[] playerResourcesIntegers = new int[] {pGold, pSilver, pCopper };

        int rCopper = resourceTaken.copper;
        int rSilver = resourceTaken.iron; 
        int rGold = resourceTaken.gold;
        int[] resourceTakenIntegers = new int[] {rGold, rSilver, rCopper};

        for(int i = 0; i < playerResourcesIntegers.Length; i++)
        {
            if(playerResourcesIntegers[i] - resourceTakenIntegers[i] < 0)
            {
                return false;
            }
        }

        int newCopper = pCopper - rCopper;
        int newSilver = pSilver - rSilver;
        int newGold = pGold - rGold;
       
        playerResources.copper = newCopper;
        playerResources.iron = newSilver; 
        playerResources.gold = newGold;
        MaterialUpdated();
        return true;
    }

    public void GiveResource(ResourceData resourceGiven)
    {
        playerResources.copper += resourceGiven.copper;
        playerResources.iron += resourceGiven.iron;
        playerResources.gold += resourceGiven.gold;
        MaterialUpdated();
    }

    public bool Buyable(int price)
    {
        if(money - price < 0)
        {
            return false;
        }
        money -= price;
        MoneyUpdated();
        return true;
    }

    public void GiveMoney(int moneyGiven)
    {
      
        money += moneyGiven;
        MoneyUpdated();
    }

    public void MoneyUpdated()
    {
        moneyUpdate?.Invoke();
    }

    public void MaterialUpdated()
    {
        updateMaterial?.Invoke();
    }



    
}
