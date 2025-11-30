using UnityEngine;

public class WeaponObject : MonoBehaviour
{
    public SpriteRenderer blade;
    [Header ("In Order, from top to bottom")]
    public GameObject[] weaponParts;
    public int value;

    [HideInInspector] public WeaponData weaponData;

   

   
}
