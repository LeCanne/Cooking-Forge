using UnityEngine;

[System.Serializable]
public class MinigameData 
{
   [SerializeField] [Range(0,3)]public int difficulty;
    public ForgeMinigame minigame;

}
