using System.Collections;
using TMPro;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using System;
using UnityEngine.UI;

public class DialogueDisplayer : MonoBehaviour
{
    public TMP_Text textBox;
    [TextArea(0,100)]public string[] texttoTest;
    //private AudioSource audioClip;
    Coroutine currentDialogue;
   

    

    private void Awake()
    {
        //audioClip = GetComponent<AudioSource>();
        DisplayDialogue(texttoTest);
    }

    public void DisplayDialogue(string[] dialogue)
    {
        if (currentDialogue != null)
        {
            StopCoroutine(currentDialogue);
        }
        currentDialogue = StartCoroutine(HandleDialogue(dialogue)); 
    }

    IEnumerator HandleDialogue(string[] dialogueList)
    {        
        textBox.text = "";
        //RollDialogue
        bool format = false;
        foreach (string dialogue in dialogueList)
        {
            
            textBox.maxVisibleCharacters = 0;
            textBox.text = dialogue;
            bool pass = false;

            //Each char plays a sound
            foreach (char c in dialogue)
            {
               
                
                if (c == '<')
                {
                    format = true;
                }

                if (format == false)
                {
                    textBox.maxVisibleCharacters++;
                    if(pass == false)
                    {
                        //audioClip.Play();
                        yield return new WaitForSeconds(0.045f);
                        //audioClip.Stop();
                    }
                    else
                    {
                        yield return new WaitForSeconds(0.01f);
                    }
                    
                }
               
                if(c == '>')
                {
                    format = false;
                }
                
            }        
        }
        yield return null;
    }
}
