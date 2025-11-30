using Unity.VisualScripting;
using UnityEngine;


public class WeaponSpawner : MonoBehaviour
{
    public Sprite spriteTest;
    public EconomyData economy;
    private void Awake()
    {
        RecipesHandler.Instance.broadcastResult.AddListener(CraftWeapon);
    }
    void CraftWeapon(RecipeData data, float percentageResult)
    {
        //Create crafted object.
        WeaponObject finishedWeapon = data.WeaponObject.WeaponData.WeaponPrefab;
        WeaponObject newObject = Instantiate(finishedWeapon);
        newObject.gameObject.AddComponent<BoxCollider2D>();
        newObject.gameObject.AddComponent<DragObject>();
        
        WeaponObject myWeapon = newObject.GetComponent<WeaponObject>();
        WeaponData spawnedWeaponData = myWeapon.weaponData;
        WeaponData recipeWeaponData = data.WeaponObject.WeaponData;
        //Add recipe info
        spawnedWeaponData.WeaponName = recipeWeaponData.WeaponName;
        spawnedWeaponData.weaponType = recipeWeaponData.weaponType;
        spawnedWeaponData.material = recipeWeaponData.material;

        float result = 0;
        switch (spawnedWeaponData.material)
        {
            case WeaponData.MATERIAL.copper:
                result = data.resourceCost.copper * economy.copperPrice * Mathf.Lerp(economy.penaltyMult, economy.copperMultiplier,percentageResult);
                break;
            case WeaponData.MATERIAL.silver:
                result = data.resourceCost.silver * economy.silverPrice * Mathf.Lerp(economy.penaltyMult, economy.silverMultiplier, percentageResult);
                break;
            case WeaponData.MATERIAL.gold:
                result = data.resourceCost.gold * economy.goldPrice * Mathf.Lerp(economy.penaltyMult, economy.silverMultiplier,percentageResult);
                break;
        }
        myWeapon.value = Mathf.CeilToInt(result);
        Debug.Log(result);
        Debug.Log(percentageResult);
        
    }
}
