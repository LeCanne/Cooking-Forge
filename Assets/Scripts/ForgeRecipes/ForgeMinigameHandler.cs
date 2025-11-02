using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class ForgeMinigameRecipe : MonoBehaviour
{
    public ForgeMinigame[] forgeMinigame;
    private List<ForgeMinigame> _minigames = new List<ForgeMinigame>();
    public UnityEvent NextMinigame;
    public UnityEvent MinigamesOver;
    
   
    void Start()
    {
        StartCoroutine(MinigameProcess());
    }

    void LaunchNext()
    {
        NextMinigame.Invoke();
    }

    IEnumerator MinigameProcess()
    {
        //Assign GameObjects associated to prefab scripts to list
        //Then, spawn clones of minigames via their GameObject.
        foreach(ForgeMinigame mg in forgeMinigame)
        {   
            GameObject myforge = Instantiate(mg.gameObject);
            myforge.SetActive(false);
            ForgeMinigame myMg = myforge.GetComponent<ForgeMinigame>();
            myMg.MinigameComplete.AddListener(LaunchNext);
            _minigames.Add(myMg);
        }

        //Assign completion conditions to each object.
        foreach (ForgeMinigame mg in _minigames)
        {
            mg.gameObject.SetActive(true);
            yield return StartCoroutine(WaitUntilEvent(NextMinigame));
            mg.gameObject.SetActive(false);
            Debug.Log("completed");
        }

        //Remove Listener and destroy each object in list.
        for (int i = _minigames.Count - 1; i >= 0;  i--)
        {
            _minigames[i].MinigameComplete.RemoveListener(LaunchNext);
            Destroy(_minigames[i].gameObject);
        }
        _minigames.Clear();

        Debug.Log("AllMinigamesDone");
        MinigamesOver.Invoke();
        yield return null;
    }

    private IEnumerator WaitUntilEvent(UnityEvent unityEvent)
    {
        var trigger = false;
        Action action = () => trigger = true;
        unityEvent.AddListener(action.Invoke);
        yield return new WaitUntil(() => trigger);
        unityEvent.RemoveListener(action.Invoke);
    }
}
