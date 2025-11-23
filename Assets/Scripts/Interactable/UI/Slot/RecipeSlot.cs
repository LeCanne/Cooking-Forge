using TMPro;
using UnityEngine;

public class RecipeSlot : MonoBehaviour
{
    public Recipe recipeObject;
    public TMP_Text recipeName;

    private void Awake()
    {
        recipeName.text = recipeObject.recipeData.WeaponObject.name;
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
       RecipesHandler.Instance.LaunchRecipe(recipeObject);
    }
}
