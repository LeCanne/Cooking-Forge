using System.Collections;
using System;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

public class DayHandler : MonoBehaviour
{
    private static DayHandler _instance;
    private DayList Scenario;
    private int dayNum = 0;
    private int comNum;

    DayData currentDay;

    [HideInInspector]public UnityEvent<int, CommissionerObject> callCommissioner = new UnityEvent<int, CommissionerObject>();
    
    
    public static DayHandler Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject gameObject = new GameObject("DayHandler");
                _instance = gameObject.AddComponent<DayHandler>();
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

    public void StartGame(int dayIndex, DayList scenario)
    {
        //Initialize Scenario
        Scenario = scenario;
        dayNum = dayIndex;
       

        StartDay();
       
    }
    private void StartDay()
    {
        currentDay = Scenario.dayObjects[dayNum].dayData;
        DoCommissioner(0);
    }

    public void DoCommissioner(int comNumber)
    {
        if (currentDay.commissioners.Length > comNumber)
        {
            callCommissioner.Invoke(comNumber, currentDay.commissioners[comNumber]);
        }
        else
        {
            EndDay();
        }
    }

    private void EndDay()
    {
        dayNum += 1;
        if (dayNum >= Scenario.dayObjects.Length)
        {
            Debug.Log("EndScenario");
        }
        else
        {
            Debug.Log("DayOver");
            StartDay();
        }
    }

}
