using UnityEngine;

public class WeaponObject : MonoBehaviour
{
    public SpriteRenderer blade;
    [Header ("In Order, from top to bottom")]
    public GameObject[] weaponParts;

    [HideInInspector] public string weaponName;
    [HideInInspector] public ENUM_WEAPONTYPES weaponType;
}
