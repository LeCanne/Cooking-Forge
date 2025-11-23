using UnityEngine;

[System.Serializable]
public class RecipeData 
{
    public Weapon WeaponObject;
    [SerializeField] public float cost;
    [SerializeField] public float reward;
    [SerializeField] public float difficulty;
    [SerializeField] public MinigameObject[] minigames;
    
}
