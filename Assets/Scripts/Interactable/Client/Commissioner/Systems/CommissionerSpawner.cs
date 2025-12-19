using System;
using UnityEngine;
using UnityEngine.Events;

public class CommissionerSpawner : MonoBehaviour
{
    public PNJ_Commissioner currentCommissioner;

    private void Awake()
    {
        DayHandler.Instance.callCommissioner.AddListener(SpawnCommission);
    }


    void SpawnCommission(int currentCommission, CommissionerObject commissionerObject)
    {
        //First create a Commissioner Recipient
        PNJ_Commissioner thisCommission = Instantiate(currentCommissioner, transform);
        

        //Then add every commissioner states, and a callback to DayHandler.
        thisCommission.commissioner = commissionerObject;
        thisCommission.commissionNumber = currentCommission;
        thisCommission.commissionDone.AddListener(DayHandler.Instance.DoCommissioner);
        thisCommission.InitializeCommissioner();
    }
    
}
