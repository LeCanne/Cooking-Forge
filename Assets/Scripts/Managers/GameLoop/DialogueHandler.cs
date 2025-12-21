using System;
using UnityEngine;

public class DialogueHandler : MonoBehaviour
{
    private static DialogueHandler _instance;    
    public static DialogueHandler Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject gameObject = new GameObject("DialogueHandler");
                _instance = gameObject.AddComponent<DialogueHandler>();
            }

            return _instance;
        }
    }

    public event Action<string[]> dialogueSent;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);

        }
        else
        {
            _instance = this;
        }
    }

    public void SendDialogue(string[] array)
    {
        dialogueSent?.Invoke(array);
    }
}
