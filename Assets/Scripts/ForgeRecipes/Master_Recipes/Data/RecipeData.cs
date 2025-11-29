using UnityEngine;

[System.Serializable]
public class RecipeData 
{
    public Weapon WeaponObject;
    [SerializeField] public ResourceData resourceCost;
    [SerializeField] public int recipeCost;
    [SerializeField] public float difficulty;
    [SerializeField] public MinigameObject[] minigames;
    
}
