using UnityEngine;

[System.Serializable]
public class WeaponData
{
    public string WeaponName;
    public ENUM_WEAPONTYPES weaponType;
    [TextArea (10, 20)]public string description;
    public WeaponObject WeaponPrefab;
}
