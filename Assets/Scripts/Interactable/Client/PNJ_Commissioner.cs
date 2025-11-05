using UnityEngine;

public class PNJ_Commissioner : MonoBehaviour
{
    public Commission commission;
    SpriteRenderer spriteRenderer;
    CommissionData commissionData;


    private void Awake()
    {
        commissionData = commission.data;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Validates if colliding object is a finishedObject.
        if (collision.TryGetComponent<FinishedObject>(out FinishedObject finishedObject)) 
        {
            ValidateCommission(finishedObject.weaponData);

        }
    }


    //Compares data of the commission with the data of the finished object.
    void ValidateCommission(FinishedObject.WeaponData weaponData)
    {
        if( commissionData.type == weaponData.weaponType)
        {
            Debug.Log("GoodType");
        }

        if (commissionData.name == weaponData.name)
        {
            Debug.Log("GoodName");
        }

        Debug.Log("EndCommission");
    }
}
