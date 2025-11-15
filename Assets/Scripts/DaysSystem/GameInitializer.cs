using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    public DayList dayList;
    public int dayIndex;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        Screen.orientation = ScreenOrientation.LandscapeRight;
        DayHandler.Instance.StartGame(dayIndex, dayList);
    }
}
