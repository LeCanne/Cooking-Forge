using UnityEngine;

[System.Serializable]
public class RecipeGroupData
{
    [SerializeField] public string recipeGroupName;
   [SerializeField]  public int resourceCost;
   [SerializeField]  public int recipeCost;
    [SerializeField] public Recipe copperRecipe;
    [SerializeField] public Recipe ironRecipe;
    [SerializeField] public Recipe goldRecipe;
}
