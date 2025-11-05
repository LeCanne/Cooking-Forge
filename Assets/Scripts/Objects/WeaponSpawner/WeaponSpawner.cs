using UnityEngine;


public class WeaponSpawner : MonoBehaviour
{
    private void Awake()
    {
        RecipesHandler.Instance.broadcastResult.AddListener(CraftWeapon);
    }
    void CraftWeapon(RecipeData data, int result)
    {
        //Create crafted object.
        GameObject finishedWeapon = new GameObject("Weapon");
        finishedWeapon.AddComponent<BoxCollider2D>();
        finishedWeapon.AddComponent<FinishedObject>();
        finishedWeapon.AddComponent<SpriteRenderer>();

        //Get weapon data of created object.
        FinishedObject finished = finishedWeapon.GetComponent<FinishedObject>();
        finished.weaponData = new FinishedObject.WeaponData();

        //Set weapon data of created object.
        finished.weaponData.name = data.name;
        finished.weaponData.weaponType = data.weaponType;
        finished.weaponData.quality = result;
    }
}
