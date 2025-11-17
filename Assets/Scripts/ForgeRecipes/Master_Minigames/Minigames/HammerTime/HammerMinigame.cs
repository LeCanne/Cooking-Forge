using UnityEngine;

public class HammerMinigame : ForgeMinigame
{
    [Range(0, 1)] public float power;
    public float time;
    public float speed;
    int slamNumber;

    [Range(0,1)]public float barPosition;
    public float barWidth;
    
    private void OnEnable()
    {
        PlayerControlsHandler.Instance.Touch += HammerSlam;
       ChangeBarLocation();
    }

    private void Start()
    {
        
    }
    private void Update()
    {
        BarUpdate();
    }
    void BarUpdate()
    {
        time += Time.deltaTime;
        power = Mathf.Pow(Mathf.Sin(speed * time),2);
    }

    void ChangeBarLocation()
    {
        barPosition = Random.Range(0f, 1f);
    }


    void HammerSlam()
    {
        Debug.Log("clicked");
        if (power > barPosition && power < barPosition+barWidth*0.1f)
        {
            Debug.Log("SLAM");

        }
        slamNumber += 1;
        ChangeBarLocation();

        if (slamNumber >= 3)
        {
            PlayerControlsHandler.Instance.Touch -= HammerSlam;
            Success();
        }
    }


}
