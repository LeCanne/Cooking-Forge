using UnityEngine;
using UnityEngine.Events;

public class PNJ_Commissioner : MonoBehaviour
{
    
    public CommissionerObject commissioner;
    public int commissionNumber;
    SpriteRenderer spriteRenderer;
    CommissionData commissionData;
    public EconomyData economyData;
    int currentReward;

    [HideInInspector]public UnityEvent<int> commissionDone = new UnityEvent<int>();


    private void Awake()
    {
      
        spriteRenderer = GetComponent<SpriteRenderer>();
      
        
        

    }

    public void InitializeCommissioner()
    {
        commissionData = commissioner.CommissionerData.commision.data;
        
        //spriteRenderer.sprite = commissioner.CommissionerData.sprite;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Validates if colliding object is a finishedObject
        if (collision.TryGetComponent<WeaponObject>(out WeaponObject finishedObject)) 
        {
            //Checks the commission and does a behavior
            EvaluateCommission(finishedObject);
            

            //Clears the Commissioner and the Commission
            //WARN: May be bad practice, object pooling might be considered.
            Destroy(finishedObject.gameObject);
            Destroy(gameObject);

        }
    }


    //Compares data of the commission with the data of the finished object.
    void EvaluateCommission(WeaponObject weaponData)
    {
         
        if(commissionData.type == CommissionData.COMMISSIONTYPE.Equipment)
        {
            if (commissionData.weapon.WeaponData.weaponType == weaponData.weaponData.weaponType)
            {
                Debug.Log("GoodType");
                commissionDone.Invoke(commissionNumber + 1);
            }
        }
        else if(commissionData.type == CommissionData.COMMISSIONTYPE.Material)
        {
            if (commissionData.weapon.WeaponData.material == weaponData.weaponData.material)
            {
                Debug.Log("GoodMaterial");
                commissionDone.Invoke(commissionNumber + 1);
            }
        }
        else if(commissionData.type == CommissionData.COMMISSIONTYPE.Both) 
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

            if (goodToken == 2)
            {
                commissionDone.Invoke(commissionNumber + 1);
            }
        }  
       
    }
}
