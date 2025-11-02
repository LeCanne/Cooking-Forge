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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMinigamesEnd()
    {
        minigamesEnd.Invoke();
    }

    private void OnDestroy()
    {
        
    }
}
