using UnityEngine;

[System.Serializable]
public class CommissionData
{
    [SerializeField] public string name;
    [TextArea (10,10)][SerializeField] public string[] dialogue;
    [SerializeField] public ENUM_WEAPONTYPES type;
    

}
