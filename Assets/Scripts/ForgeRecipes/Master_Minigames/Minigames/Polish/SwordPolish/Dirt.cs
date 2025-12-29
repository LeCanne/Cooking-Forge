using UnityEngine;
using System;

public class Dirt : MonoBehaviour
{
    public float dirt = 1f;
    public GameObject dirtSprite;
    Vector3 initialScale;
    public float clean = 0f;

    bool inClean;
    public event Action SqueakyClean;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     
        initialScale = dirtSprite.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (inClean)
        {
            Clean();
        }
        
    }

    public void Clean()
    {
        clean += Time.deltaTime;
        float value = clean/dirt;
        dirtSprite.gameObject.transform.localScale = Vector3.Lerp(initialScale, Vector3.zero, value);

        if(clean >= 1f)
        {
            SqueakyClean?.Invoke();
            gameObject.SetActive(false);
            
        }
 
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            inClean = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other != null)
        {
            inClean = false;
        }
    }
}
