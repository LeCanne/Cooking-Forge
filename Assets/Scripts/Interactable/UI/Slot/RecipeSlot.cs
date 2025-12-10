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
       
        //DefineMoneyCost();
      
       
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
  

    //void DefineMoneyCost()
    //{
    //    cost = recipeObject.recipeData.recipeCost;
    //    recipeMoneyCost.text = cost.ToString();
    //}
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //public void StartRecipe()
    //{
    //    if (wasBought)
    //    {
    //        if (PlayerResourcesHandler.Instance.Craftable(resourceCost) == true)
    //        {
    //            RecipesHandler.Instance.LaunchRecipe(recipeObject);
    //            closeUI.Invoke();
    //        }
    //    }
    //    else
    //    {
    //        if (PlayerResourcesHandler.Instance.Buyable(cost) == true)
    //        {
    //            wasBought = true;
    //            costImage.gameObject.SetActive(false);   
    //        }
    //    }


    //}
}
