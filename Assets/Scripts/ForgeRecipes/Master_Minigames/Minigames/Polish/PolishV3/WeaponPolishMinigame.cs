using UnityEngine;

public class WeaponPolishMinigame : ForgeMinigame
{
    [Range(0, 1)] public float cleanliness;
    public Material uncleanMaterial;
    private Material objectMaterial;

    public float sensitivity;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        PlayerControlsHandler.Instance.DragInfo += EvaluateDrag;
        MinigameStart();
    }

    private void MinigameStart()
    {
        GameObject go = new GameObject("blade");
        SpriteRenderer spr = go.AddComponent<SpriteRenderer>();
        spr.sprite = weaponObject.blade.sprite;
        spr.material = uncleanMaterial;

        go.transform.localScale = new Vector3(3f, 3f);
        go.transform.position = transform.position;
        objectMaterial = spr.material;
    }

    // Update is called once per frame
    void Update()
    {
        objectMaterial.SetFloat("_Dirt", 1-cleanliness);
    }

    void EvaluateDrag(Vector2 drag)
    {
        Debug.Log(drag);
        cleanliness += drag.magnitude * sensitivity;
        cleanliness = Mathf.Clamp(cleanliness, 0, 1);

        if (cleanliness == 0)
        {
            quality = 1;
            Success();
        }
    }
}
