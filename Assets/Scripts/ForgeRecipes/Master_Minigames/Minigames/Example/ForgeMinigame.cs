using System;
using UnityEngine;
using UnityEngine.Events;

public class ForgeMinigame : MonoBehaviour
{
    
    [HideInInspector] public UnityEvent MinigameComplete;
    [SerializeField]public int difficulty;
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
        MinigameComplete.Invoke();
    }
}
