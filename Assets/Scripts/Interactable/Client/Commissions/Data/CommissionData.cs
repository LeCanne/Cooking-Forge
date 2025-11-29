using UnityEngine;

[System.Serializable]
public class CommissionData
{
    [Header("Main Information")]
    [SerializeField]public string CommissionName;
    [SerializeField]public Weapon weapon;
    [Header ("Rewards")]
    [SerializeField]public int moneyBonus;
    [SerializeField]public int penalty;
    [Header("Intro Dialogues")]
    [TextArea (10,10)][SerializeField] public string[] dialogue;
    
    

}
