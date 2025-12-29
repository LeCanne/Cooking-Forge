using UnityEngine;

public class HammerMinigame : ForgeMinigame
{
    [Range(0, 1)] public float power;
    public float time;
    public float speed;
    [Range(0.0f,0.2f)]public float offsetResolution;
    int slamNumber;
    public int maxSlamNumber;

    [Range(0,1)]public float barPosition;
    public float barWidth;
    
    private void OnEnable()
    {
        quality = 1;
        PlayerControlsHandler.Instance.Touch += HammerSlam;
        ChangeBarLocation();
    }
    private void OnDisable()
    {
        if (PlayerControlsHandler.Instance != null)
        {
            PlayerControlsHandler.Instance.Touch -= HammerSlam;
        
        }
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
        float minpos = barPosition - offsetResolution;
        float maxpos = (barPosition + barWidth * 0.1f) + offsetResolution;
        if (power > minpos && power < maxpos)
        {
            Debug.Log("SLAM");
        }
        else
        {
            quality -= 1 / maxSlamNumber;
        }
            slamNumber += 1;
        ChangeBarLocation();

        if (slamNumber >= maxSlamNumber)
        {
            PlayerControlsHandler.Instance.Touch -= HammerSlam;
            Success();
        }
    }


}
