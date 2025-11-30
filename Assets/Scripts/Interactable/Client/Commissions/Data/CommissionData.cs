using UnityEngine;

[System.Serializable]
public class CommissionData
{
    [Header("Main Information")]
    [SerializeField]public string CommissionName;
    [SerializeField]public Weapon weapon;
    [Header("Intro Dialogues")]
    [TextArea (10,10)][SerializeField] public string[] dialogue;
    public enum COMMISSIONTYPE
    {
        Material,
        Equipment,
        Both
        
    }
    [SerializeField] public COMMISSIONTYPE type;
    
    

}
