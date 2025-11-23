using UnityEngine;

[System.Serializable]
public class CommissionData
{
    [SerializeField]public string CommissionName;
    [SerializeField] public Weapon weapon;
    [TextArea (10,10)][SerializeField] public string[] dialogue;
    
    

}
