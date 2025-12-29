using System;
using UnityEngine;
using UnityEngine.Events;

public class ForgeMinigame : MonoBehaviour
{
    
    [HideInInspector]public UnityEvent MinigameComplete;
   
    public WeaponObject weaponObject;
    [SerializeField]public int difficulty;
    [SerializeField][Range(0f,1f)]public float quality;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Success()
    {
       
        Debug.Log("Minigame Over! Quality : " + quality);
        MinigameComplete.Invoke();
    }
}
