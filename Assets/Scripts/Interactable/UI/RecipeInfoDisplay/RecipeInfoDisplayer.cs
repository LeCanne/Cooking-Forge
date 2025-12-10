using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RecipeInfoDisplayer : MonoBehaviour
{
    public TMP_Text priceInfo;
    public TMP_Text materialTypeInfo;
   
    public Button btnLaunchRecipe;
    public Recipe currentRecipe;
    public ResourceData visibleresourceData;
    
    private void Awake()
    {
        RecipesHandler.Instance.recipeSent += DisplayInfo;
    }

    private void DisplayInfo(Recipe recipe, ResourceData resourceData)
    {
        btnLaunchRecipe.onClick.RemoveAllListeners();
        WeaponData weapondata = recipe.recipeData.WeaponObject.WeaponData;

        if (weapondata != null)
        {
            if (weapondata.material == WeaponData.MATERIAL.copper)
            {
                priceInfo.text = recipe.recipeData.resourceCost.copper.ToString();
                materialTypeInfo.text = "Copper";
            }
            else if (weapondata.material == WeaponData.MATERIAL.iron)
            {
                priceInfo.text = recipe.recipeData.resourceCost.iron.ToString();
                materialTypeInfo.text = "Iron";
            }
            else
            {
                priceInfo.text = recipe.recipeData.resourceCost.gold.ToString();
                materialTypeInfo.text = "Gold";
            }

            
            btnLaunchRecipe.onClick.AddListener( delegate { LaunchRecipe(resourceData); } );
            visibleresourceData = resourceData;
            
        }

        currentRecipe = recipe;
    }

 

    private void LaunchRecipe(ResourceData resource)
    {
        if (PlayerResourcesHandler.Instance.Craftable(resource))
        {
            RecipesHandler.Instance.LaunchRecipe(currentRecipe);
            
        }
       
    }
}
