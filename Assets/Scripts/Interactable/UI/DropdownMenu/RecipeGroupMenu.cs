using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class RecipeGroupMenu : MonoBehaviour
{

    public RecipeSlot recipeSlot;
    public GameObject recipeContainer;

    public DropdownMenu dropDown;
    public RecipeGroup recipeGroup;
    private int resourceCost;
    private int recipeGroupCost;
    public bool bought;
    
    public Image costImage;

    public TMP_Text recipeGroupName;
    public TMP_Text recipeRessourceCost;
    public TMP_Text recipeMoneyCost;


    private void Awake()
    {
        resourceCost = recipeGroup.data.resourceCost;
        recipeGroupCost = recipeGroup.data.recipeCost;

        DefineMoneyCost();
        InstantiateRecipes();
    }
       

    void DefineMoneyCost()
    {
         recipeGroupName.text = recipeGroup.data.recipeGroupName;
         recipeRessourceCost.text = resourceCost.ToString();
         recipeMoneyCost.text = recipeGroupCost.ToString();
    }


    RecipeSlot NewSlot() 
    {
        GameObject newSlot = Instantiate(recipeSlot.gameObject, recipeContainer.transform);
        RecipeSlot slot = newSlot.GetComponent<RecipeSlot>();
        
        return slot;
    }

    void InstantiateRecipes()
    {
        Copper();
        Iron();
        Gold();
    }

    void Copper()
    {
        RecipeSlot slot = NewSlot();
        slot.recipeObject = recipeGroup.data.copperRecipe;
        slot.resourceCost.copper = recipeGroup.data.resourceCost;
        slot.InitalizeSlot();

    }

    void Iron()
    {
        RecipeSlot slot = NewSlot();
        slot.recipeObject = recipeGroup.data.ironRecipe;
        slot.resourceCost.iron = recipeGroup.data.resourceCost;
        slot.InitalizeSlot();

    }

    void Gold()
    {
        RecipeSlot slot = NewSlot();
        slot.recipeObject = recipeGroup.data.goldRecipe;
        slot.resourceCost.gold = recipeGroup.data.resourceCost;
        slot.InitalizeSlot();

    }

   
    public void TriggerRecipeGroup()
    {
        if(bought == false)
        {
            if (PlayerResourcesHandler.Instance.Buyable(recipeGroupCost))
            {
                bought = true;
                costImage.gameObject.SetActive(false);
            }
        }
        else
        {
            dropDown.TriggerBox();
        }
       
    }

    
}
