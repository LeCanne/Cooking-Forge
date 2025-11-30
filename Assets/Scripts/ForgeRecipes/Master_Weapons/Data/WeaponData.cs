using UnityEngine;

[System.Serializable]
public class WeaponData
{
    public string WeaponName;
    public ENUM_WEAPONTYPES weaponType;
    public enum MATERIAL
    {
        copper,
        silver,
        gold
    }
    public MATERIAL material;
    [TextArea (10, 20)]public string description;
    public WeaponObject WeaponPrefab;
   
}
