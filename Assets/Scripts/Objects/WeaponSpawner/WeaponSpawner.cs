using Unity.VisualScripting;
using UnityEngine;


public class WeaponSpawner : MonoBehaviour
{
    public Sprite spriteTest;
    private void Awake()
    {
        RecipesHandler.Instance.broadcastResult.AddListener(CraftWeapon);
    }
    void CraftWeapon(RecipeData data, int result)
    {
        //Create crafted object.
        WeaponObject finishedWeapon = data.WeaponObject.WeaponData.WeaponPrefab;
        WeaponObject newObject = Instantiate(finishedWeapon);
        newObject.gameObject.AddComponent<BoxCollider2D>();
        newObject.gameObject.AddComponent<DragObject>();
        
        //Add recipe info
        newObject.GetComponent<WeaponObject>().weaponName = data.WeaponObject.WeaponData.WeaponName;
        newObject.GetComponent<WeaponObject>().weaponType = data.WeaponObject.WeaponData.weaponType;
        
    }
}
