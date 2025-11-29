using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class RecipeSlot : MonoBehaviour
{
    public Recipe recipeObject;
    public TMP_Text recipeName;
    public TMP_Text recipeMoneyCost;

    public TMP_Text recipeCoppertxt;
    public TMP_Text recipeSilvertxt;
    public TMP_Text recipeGoldtxt;

    private ResourceData resourceCost;
    private Button recipeButton;
    public UnityEvent closeUI;
    public Image costImage;
    int cost;

    public bool wasBought;


    private void Awake()
    {
        recipeName.text = recipeObject.recipeData.WeaponObject.name;
        resourceCost = recipeObject.recipeData.resourceCost;
        recipeButton = GetComponent<Button>();
        DefineMoneyCost();
        DefineResourceCost();

        if (!wasBought)
        {
            costImage.gameObject.SetActive(true);
        }
    }

    void DefineResourceCost()
    {
       
        recipeGoldtxt.text = resourceCost.gold.ToString();
        recipeCoppertxt.text = resourceCost.copper.ToString();
        recipeSilvertxt.text = resourceCost.silver.ToString();
    }

    void DefineMoneyCost()
    {
        cost = recipeObject.recipeData.recipeCost;
        recipeMoneyCost.text = cost.ToString();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartRecipe()
    {
        if (wasBought)
        {
            if (PlayerResourcesHandler.Instance.Craftable(resourceCost) == true)
            {
                RecipesHandler.Instance.LaunchRecipe(recipeObject);
                closeUI.Invoke();
            }
        }
        else
        {
            if (PlayerResourcesHandler.Instance.Buyable(cost) == true)
            {
                wasBought = true;
                costImage.gameObject.SetActive(false);   
            }
        }


    }
}
