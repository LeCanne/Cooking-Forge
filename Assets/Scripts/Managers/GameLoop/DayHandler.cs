using UnityEngine;

public class DayHandler : MonoBehaviour
{
    private static DayHandler _instance;
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
   
}
