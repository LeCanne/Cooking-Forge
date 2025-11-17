using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
[RequireComponent (typeof(HammerMinigame))]
public class HammerBar : MonoBehaviour
{
    public RectTransform slider;
    public RectTransform container;
    public RectTransform validSpot;
    public HammerMinigame minigame;
    [Range (0,1)]public float value;
    [Range(0, 1)] float valid;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        minigame = GetComponent<HammerMinigame>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        value = minigame.power;
        valid = minigame.barPosition;
        validSpot.sizeDelta = new Vector2(minigame.barWidth, validSpot.rect.height);
        ChangeBarPosition();
        ChangeValidPosition();
    }

    void ChangeValidPosition()
    {
        Vector2 min = new Vector2(0, slider.anchoredPosition.y);
        Vector2 max = new Vector2(container.rect.width - validSpot.rect.width, slider.anchoredPosition.y);
        validSpot.anchoredPosition = Vector2.Lerp(min, max, valid);
    }

    void ChangeBarPosition()
    {
        Vector2 min = new Vector2(0, slider.anchoredPosition.y);
        Vector2 max = new Vector2(container.rect.width-slider.rect.width, slider.anchoredPosition.y);
        slider.anchoredPosition = Vector2.Lerp(min, max, value);
    }
}
