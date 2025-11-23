using UnityEngine;
using UnityEngine.Events;

public class PNJ_Commissioner : MonoBehaviour
{
    
    public CommissionerObject commissioner;
    public int commissionNumber;
    SpriteRenderer spriteRenderer;
    CommissionData commissionData;

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
            ValidateCommission(finishedObject);
            

            //Clears the Commissioner and the Commission
            //WARN: May be bad practice, object pooling might be considered.
            Destroy(finishedObject.gameObject);
            Destroy(gameObject);

        }
    }


    //Compares data of the commission with the data of the finished object.
    void ValidateCommission(WeaponObject weaponData)
    {
        if( commissionData.weapon.WeaponData.weaponType == weaponData.weaponType)
        {
            Debug.Log("GoodType");
        }

        if (commissionData.weapon.WeaponData.WeaponName == weaponData.weaponName)
        {
            Debug.Log("GoodName");
        }

        commissionDone.Invoke(commissionNumber+1);
        Debug.Log("EndCommission");
        
       
    }
}
