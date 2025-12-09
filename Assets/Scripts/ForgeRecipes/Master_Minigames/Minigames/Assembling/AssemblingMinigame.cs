using System.Collections;
using UnityEngine;

public class AssemblingMinigame : ForgeMinigame
{
    int token;
    int maxToken;
    private void Awake()
    {
        
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnSword();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnSword()
    {
        GameObject blueprint = weaponObject.gameObject;
        WeaponObject wo = blueprint.GetComponent<WeaponObject>();

        int id = 0;
        foreach (GameObject go in wo.weaponParts)
        {
            GameObject firstGo = Instantiate(go, transform);
            WeaponPartIdentifier ident = firstGo.AddComponent<WeaponPartIdentifier>();
            ident.assemblingMinigame = this;
            ident.id = id;
            Rigidbody2D rb = firstGo.AddComponent<Rigidbody2D>();
            Collider2D collido = firstGo.AddComponent<PolygonCollider2D>();
            collido.isTrigger = true;
            rb.bodyType = RigidbodyType2D.Kinematic;

            if(ident.TryGetComponent(out SpriteRenderer spr))
            {
                
                spr.color = Color.black;
                spr.sortingOrder = 7;
                maxToken += 1;
            }

            GameObject part = Instantiate(go, transform);
            if(part.TryGetComponent(out SpriteRenderer sprother))
            {
                sprother.sortingOrder = 8;
            }
            part.transform.position = transform.position + new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f), 0);
            WeaponPart wp = part.AddComponent<WeaponPart>();
            wp.id = id;
            Collider2D collid = part.AddComponent<PolygonCollider2D>();
            collid.isTrigger = true;
            DragObject Do = part.AddComponent<DragObject>();
           

            id += 1;
            

            
        }
    }

    public void ValidateWeaponPart()
    {
        token += 1;
        if (token == maxToken)
        {
            quality = 1;
            StartCoroutine(Lapse());
        }
        
    }


    IEnumerator Lapse()
    {
        yield return new WaitForSeconds(1f);
        Success();
        yield return null;
    }
}
