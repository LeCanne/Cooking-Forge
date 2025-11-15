using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
[RequireComponent (typeof(HeatMinigame))]
public class HeatBar : MonoBehaviour
{
    public RectTransform Container;
    public Image hotImage;
    public Image coldImage;
    public HeatMinigame heatMinigame;

    public RectTransform bar;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void Update()
    {
       ChangeVisuals(); 
       ChangeBarPosition();
    }

    void ChangeVisuals()
    {
        heatMinigame.maxHeat = Mathf.Clamp(heatMinigame.maxHeat, heatMinigame.minHeat, 1);
        float fillHeat = 1 - heatMinigame.maxHeat;
        float fillCold = heatMinigame.minHeat;


        hotImage.fillAmount = fillHeat;
        coldImage.fillAmount = fillCold;
    }

    void ChangeBarPosition()
    {
        Vector2 min = new Vector2(bar.anchoredPosition.x, Container.offsetMin.y);
        Vector2 max = new Vector2(bar.anchoredPosition.x, Container.rect.height);
        bar.anchoredPosition = Vector2.Lerp(min, max, heatMinigame.heat);
    }

    // Update is called once per frame

}
