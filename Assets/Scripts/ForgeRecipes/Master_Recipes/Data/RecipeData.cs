using UnityEngine;

[System.Serializable]
public class RecipeData 
{
    public Weapon WeaponObject;
    public ResourceData resourceCost;
    [SerializeField] public float difficulty;
    [SerializeField] public MinigameObject[] minigames;
    
}
