using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    public DayList dayList;
    public int dayIndex;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        DayHandler.Instance.StartGame(dayIndex, dayList);
        Screen.orientation = ScreenOrientation.LandscapeRight;
        
    }

    private void Start()
    {
        
    }
}
