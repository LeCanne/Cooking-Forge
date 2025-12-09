using System;
using UnityEngine;
using UnityEngine.Events;

public class UIListener : MonoBehaviour
{
    public UnityEvent minigamesEnd;
    public UnityEvent minigameStart;
    private void Awake()
    {
        
        RecipesHandler.Instance.MinigamesOver.AddListener(OnMinigamesEnd);
        RecipesHandler.Instance.recipeStarted += OnMinigameStart;
    }

    void OnMinigameStart()
    {
        minigameStart.Invoke();
    }
    void OnMinigamesEnd()
    {
        minigamesEnd.Invoke();
    }

  
}
