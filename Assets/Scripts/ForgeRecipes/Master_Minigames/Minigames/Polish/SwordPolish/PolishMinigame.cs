using UnityEngine;

public class PolishMinigame : ForgeMinigame
{
    public GameObject weapon;
    public SpriteRenderer spriteDirty;
    public GameObject dirt;
    public int minRange;
    public int maxRange;
    public float speed;
    public int dirtNumber;
    int wintoken;
    int totalwin;
    private void OnEnable()
    {
        PlayerControlsHandler.Instance.DragInfo += MoveSword;
    }
    private void OnDisable()
    {
        if(PlayerControlsHandler.Instance != null)
        {
            PlayerControlsHandler.Instance.DragInfo -= MoveSword;
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dirtNumber = Random.Range(1, 4);
        for (int i = 0; i < dirtNumber; i++)
        {
            wintoken += 1;
            SpawnDirt();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnDirt()
    {
        GameObject go = Instantiate(dirt, weapon.transform);
        float randomizedPosX = Random.Range(spriteDirty.bounds.min.x, spriteDirty.bounds.max.x);
        go.transform.position = new Vector3(randomizedPosX, spriteDirty.bounds.max.y, 0);
        go.GetComponent<Dirt>().SqueakyClean += DefineOver;
    }


    void DefineOver()
    {
       
        totalwin += 1;

        if(wintoken == totalwin)
        {
           
            Success();
        }
    }

    void MoveSword(Vector2 dragInfo)
    {
        //HandleMovementOfWeapon
        dragInfo *= 0.01f;
        dragInfo *= (speed * Time.deltaTime);
        weapon.transform.position += new Vector3(dragInfo.x, 0, 0);
        
        float xPos = weapon.transform.position.x;

        xPos = Mathf.Clamp(xPos, minRange, maxRange);

        weapon.transform.position = new Vector3(xPos, weapon.transform.position.y, 0);
    }


}
