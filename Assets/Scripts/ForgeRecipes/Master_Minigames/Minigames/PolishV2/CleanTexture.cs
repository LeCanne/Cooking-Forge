using UnityEngine;
using UnityEngine.Rendering;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class CleanTexture : MonoBehaviour
{
    SpriteRenderer sprite;
    Material mat;
    int cool;

    public void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
       
    }

    private void Start()
    {
        mat = GetComponent<SpriteRenderer>().material;
    }
    public void Update()
    {
        //Texture2D tex = new Texture2D(mat.GetTexture("_Ugly"));



        //RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        //if(hit.collider != null)
        //{
           
        //    Vector2 localPos = (Vector2)sprite.gameObject.transform.position - hit.point;

        //    Vector2 Uv = new Vector2(localPos.y / sprite.gameObject.transform.localScale.y*tex.height, localPos.x / sprite.gameObject.transform.localScale.x*tex.width);
          

        //    Debug.Log(tex.GetPixel((int)Uv.x,(int)Uv.y));
        //    tex.SetPixel((int)Uv.x, (int)Uv.y, new Color(0,0,0,0));
        //    tex.Apply();
        //}

        //Vector2 coordinates =  transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //tex.SetPixel((int)coordinates.x, (int)coordinates.y, new Color(0,0,0,0));
        //mat.SetTexture("_Ugly", tex);
        //tex.Apply();
    }

    
}
