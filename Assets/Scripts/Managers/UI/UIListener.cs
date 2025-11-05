using System;
using UnityEngine;
using UnityEngine.Events;

public class UIListener : MonoBehaviour
{
    public UnityEvent minigamesEnd;
    private void Awake()
    {
        Debug.Log(RecipesHandler.Instance.name);
        RecipesHandler.Instance.MinigamesOver.AddListener(OnMinigamesEnd);
    }

    void OnMinigamesEnd()
    {
        minigamesEnd.Invoke();
    }

    private void OnDestroy()
    {
        
    }
}
