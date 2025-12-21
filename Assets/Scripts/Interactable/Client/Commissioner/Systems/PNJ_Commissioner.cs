using UnityEngine;
using UnityEngine.Events;

public class PNJ_Commissioner : MonoBehaviour
{
    
    public CommissionerObject commissioner;
    public int commissionNumber;
    public SpriteRenderer spriteRenderer;
    CommissionData commissionData;
    public EconomyData economyData;
    int currentReward;
    [HideInInspector]public UnityEvent<int> commissionDone = new UnityEvent<int>();


    private void Awake()
    {
      
    }

    public void InitializeCommissioner()
    {
        commissionData = commissioner.CommissionerData.commision.data;
        spriteRenderer.sprite = commissioner.CommissionerData.sprite;
        DialogueHandler.Instance.SendDialogue(commissionData.dialogue);
        //spriteRenderer.sprite = commissioner.CommissionerData.sprite;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Validates if colliding object is a finishedObject
        if (collision.TryGetComponent<WeaponObject>(out WeaponObject finishedObject)) 
        {
            //Checks the commission and does a behavior
            EvaluateCommission(finishedObject);
           

            



        }
    }


    //Compares data of the commission with the data of the finished object.
    public void EvaluateCommission(WeaponObject weaponData)
    {

        if (commissionData.type == CommissionData.COMMISSIONTYPE.Equipment)
        {
            if (commissionData.weapon.WeaponData.weaponType == weaponData.weaponData.weaponType)
            {
                Debug.Log("GoodType");
                GiveMoney(weaponData.value);
            }
            else
            {
                GiveMoney(Mathf.RoundToInt(weaponData.value * 0.5f));
            }
            
        }
        else if (commissionData.type == CommissionData.COMMISSIONTYPE.Material)
        {
            if (commissionData.weapon.WeaponData.material == weaponData.weaponData.material)
            {
                Debug.Log("GoodMaterial");
                GiveMoney(weaponData.value);
            }
            else
            {
                GiveMoney(Mathf.RoundToInt(weaponData.value * 0.5f));
            }
            
        }
        else if (commissionData.type == CommissionData.COMMISSIONTYPE.Both)
        {
            int goodToken = 0;

            if (commissionData.weapon.WeaponData.weaponType == weaponData.weaponData.weaponType)
            {

                Debug.Log("GoodType");
                goodToken += 1;

            }
            if (commissionData.weapon.WeaponData.material == weaponData.weaponData.material)
            {
                Debug.Log("GoodMaterial");
                goodToken += 1;

            }

            switch (goodToken)
            {
                case 0:
                    GiveMoney(Mathf.RoundToInt(weaponData.value * 0.25f));
                    break;

                case 1:
                    GiveMoney(Mathf.RoundToInt(weaponData.value * 0.5f));
                    break;
                case 2:
                    GiveMoney(weaponData.value);
                    break;
            }
         
        }
        Destroy(weaponData.gameObject);
        EndCommission();
       
       
        


    }

    void EndCommission()
    {
        Debug.Log("ended");
        commissionDone.Invoke(commissionNumber + 1);
        Destroy(gameObject);
        
    }

    void GiveMoney(int money)
    {
        PlayerResourcesHandler.Instance.GiveMoney(money);
    }
}
