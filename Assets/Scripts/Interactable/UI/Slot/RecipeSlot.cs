using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class RecipeSlot : MonoBehaviour
{
    public Recipe recipeObject;
    public TMP_Text recipeName;
    public ResourceData resourceCost = new ResourceData();
    public Button recipeButton;
    public bool wasBought;

    private void Awake()
    {
        InitalizeSlot();
    }

    public void InitalizeSlot()
    {
        recipeName.text = recipeObject.recipeData.WeaponObject.WeaponData.WeaponName;
        recipeButton.onClick.AddListener(SendInfo);
    }

    void SendInfo()
    {
        RecipesHandler.Instance.SendRecipeInfo(recipeObject, resourceCost);
    }
}
