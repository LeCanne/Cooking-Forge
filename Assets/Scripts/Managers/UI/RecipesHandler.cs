using UnityEditorInternal;
using UnityEngine;
public class RecipesHandler : MonoBehaviour
{
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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
