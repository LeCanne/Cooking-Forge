using UnityEngine;

[CreateAssetMenu(fileName = "EconomyData", menuName = "Scriptable Objects/EconomyData")]
public class EconomyData : ScriptableObject
{
    [Header("Copper")]
    public int copperPrice;
    public float copperMultiplier;
    [Header("Silver")]
    public int silverPrice;
    public float silverMultiplier;
    [Header("Gold")]
    public int goldPrice;
    public float goldMultiplier;

    [Header("Penalties")]
    public float penaltyMult;
}
