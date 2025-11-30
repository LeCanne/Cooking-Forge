using System.Collections;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using System;
using UnityEngine.Events;

public class HeatMinigame : ForgeMinigame
{
    public float lerpSpeed;
    public Transform ovenPos;
    public Transform basePos;
    public GameObject metalShard;
    Coroutine currentLerp;

    //HandleHeat
    [Range (0,1)]public float heat;
    public float heatSpeed;
  

    //HandleDesiredHeat
    [Range (0,1)]public float minHeat;
    [Range (0,1)]public float maxHeat;

    //Started
    bool minigameStarted;


    public UnityEvent ValueChanged = new UnityEvent(); 

    private void OnEnable()
    {
        
        PlayerControlsHandler.Instance.Touch += DoThat;
        PlayerControlsHandler.Instance.CancelTouch += Donot;
        
    }

    private void OnDisable()
    {
        if(PlayerControlsHandler.Instance != null)
        {
            PlayerControlsHandler.Instance.Touch -= DoThat;
            PlayerControlsHandler.Instance.CancelTouch -= Donot;
        }
    }

    void DoThat()
    {
        if(minigameStarted == false)
        {
            if (currentLerp != null)
            {
                StopCoroutine(currentLerp);
            }

            currentLerp = StartCoroutine(LerpToPos(ovenPos.transform.position));
        }
       
       
    }
    
    void Donot()
    {
        if (currentLerp != null)
        {
            StopCoroutine(currentLerp);
        }
     
        currentLerp = StartCoroutine(LerpToPos(basePos.transform.position));

        if(minigameStarted == true)
        {
            PlayerControlsHandler.Instance.Touch -= DoThat;
            PlayerControlsHandler.Instance.CancelTouch -= Donot;
            StartCoroutine(Done());
        }
       
    }

    private void Update()
    {
        if (Vector3.Distance(metalShard.transform.position, ovenPos.transform.position) < 1f)
        {
           heat += heatSpeed * Time.deltaTime;
           minigameStarted = true;

            if(heat >= 1)
            {
               
                Donot();
            }
        }  
    }

    

    IEnumerator LerpToPos(Vector3 lerp)
    {
        
        Vector3 originalPos = metalShard.transform.position;
        float speed = lerpSpeed;
        float distance = Vector3.Distance(originalPos, lerp);
        if(distance == 0)
        {
            distance = 1;
        }
        float finalTime = distance / speed;
        float elapsedTime = 0;
        while (elapsedTime < finalTime)
        {
            elapsedTime += Time.deltaTime;
            metalShard.transform.position = Vector3.Lerp(originalPos, lerp, LerpPos(elapsedTime / finalTime));
            yield return null;
            
        }

    }

    IEnumerator Done()
    {
       


        currentLerp = StartCoroutine(LerpToPos(basePos.transform.position));
        StopCoroutine(currentLerp);
        yield return new WaitForSeconds(1f);
        Debug.Log(heat);
        if (heat > maxHeat)
        {
            quality = 0;
        }
        else if (heat < minHeat)
        {
            quality = 0.5f;
        }
        else
        {
            quality = 1;
        }
        Success();
    }

    float LerpPos(float x)
    {
        
        return x < 0.5 ? 4 * x * x * x : 1 - Mathf.Pow(-2 * x + 2, 3) / 2;
    }
}
