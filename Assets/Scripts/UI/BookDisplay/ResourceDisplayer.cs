using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ResourceDisplayer : MonoBehaviour
{
    public enum MATTYPE
    {
        copper,
        iron,
        gold,
    }
    public MATTYPE type;
    public TMP_Text currentMaterials;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerResourcesHandler.Instance.updateMaterial += UpdateDisplay;
    }

    private void OnEnable()
    {
        UpdateDisplay();
    }

    void UpdateDisplay()
    {

        int amount = 0;
        switch (type)
        {
            case MATTYPE.copper:
                amount = PlayerResourcesHandler.Instance.playerResources.copper;
                break;

            case MATTYPE.iron:
                amount = PlayerResourcesHandler.Instance.playerResources.iron;
                break;

            case MATTYPE.gold:
                amount = PlayerResourcesHandler.Instance.playerResources.gold;
                break;
        }
        currentMaterials.text = amount.ToString();
    }
}
