using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

//This Singleton handles all the recipes states, their minigame flow, ect...
public class RecipesHandler: MonoBehaviour
{
    public MinigameObject[] forgeMinigame;
    private List<ForgeMinigame> _minigames = new List<ForgeMinigame>();
    public UnityEvent NextMinigame = new UnityEvent();
    public UnityEvent MinigamesOver = new UnityEvent();
    [HideInInspector]public UnityEvent<RecipeData, int> broadcastResult = new UnityEvent<RecipeData,int>();
   

    private static RecipesHandler _instance;
    public static RecipesHandler Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject gameObject = new GameObject("Recipes Handler");
                _instance = gameObject.AddComponent<RecipesHandler>();
            }

            return _instance;
        }
    }

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

    void Start()
    {
       
    }

    public void LaunchRecipe(Recipe recipeObject)
    {
        StartCoroutine(MinigameProcess(recipeObject));
    }

    public void LaunchNext()
    {
        NextMinigame.Invoke();
    }

    IEnumerator MinigameProcess(Recipe recipeObject)
    {
        int quality = 0;
        forgeMinigame = recipeObject.recipeData.minigames;
        //Assign GameObjects associated to prefab scripts to list
        //Then, spawn clones of minigames via their GameObject.
        foreach(MinigameObject mgOb in forgeMinigame)
        {
            ForgeMinigame forgeMg = mgOb.minigameData.minigame;
            GameObject myforge = Instantiate(forgeMg.gameObject);
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
        RecipeResult(recipeObject.recipeData, quality);
        yield return null;
    }

    void RecipeResult(RecipeData recipe, int quality)
    {
        broadcastResult.Invoke(recipe, quality);
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
