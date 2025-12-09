using System.Collections;
using UnityEngine;
using UnityEngine.UI;


[ExecuteInEditMode]
[RequireComponent(typeof(RectTransform))]
public class DropdownMenu : MonoBehaviour
{

    //Measures
    public float childHeight = 20f;
    public float spacing;
    float minspacing;
    float originalHeight;
    float maximumHeight;

    //From upper part
    private float offsetRect;
    public float lerpDuration;
    public GameObject rects;

    //HandlePadding
    public VerticalLayoutGroup vLayout;
    public GameObject dropdownImg;
    bool closed = true;
    float maxTopPadding;

    //StockLerping
    Coroutine currentVerticalLerp;
    Coroutine currentSpacingLerp;
    Coroutine currentResizeHeight;


    private void Awake()
    {
        SizeContainers();
        originalHeight = gameObject.GetComponent<RectTransform>().sizeDelta.y;
        vLayout.spacing = minspacing;
        foreach (RectTransform rect in rects.GetComponentInChildren<RectTransform>())
        {
            maximumHeight += rect.sizeDelta.y + spacing;
            Debug.Log(rect.sizeDelta.y);
        }
        maximumHeight += gameObject.GetComponent<RectTransform>().sizeDelta.y + vLayout.padding.top + spacing;
       
    }


    private void Update()
    {
        SizeContainers();
    }



    void SizeContainers()
    {
        foreach (RectTransform rectTransform in rects.GetComponentInChildren<RectTransform>())
        {
            rectTransform.sizeDelta = new Vector2(rectTransform.rect.width, childHeight);
        }
        offsetRect = childHeight;
        minspacing = -childHeight;

        ResizeSpacing();
       
        maxTopPadding = dropdownImg.GetComponent<RectTransform>().rect.height + offsetRect;
    }


    void ResizeSpacing()
    {
        if (!Application.isPlaying)
        {
            vLayout.spacing = minspacing;
        }
      
    }



    public void Open()
    {
        currentVerticalLerp=StartCoroutine(LerpVerticalPadding(lerpDuration, 0, maxTopPadding));
        currentSpacingLerp=StartCoroutine(LerpSpacing(lerpDuration, -childHeight, spacing));
        currentResizeHeight = StartCoroutine(HeightResize(lerpDuration, originalHeight, maximumHeight  ));
        
    }

    public void Close()
    {
        currentVerticalLerp=StartCoroutine(LerpVerticalPadding(lerpDuration, maxTopPadding, 0));
        currentSpacingLerp=StartCoroutine(LerpSpacing(lerpDuration, spacing, -childHeight));
        currentResizeHeight = StartCoroutine(HeightResize(lerpDuration, maximumHeight, originalHeight));
    }

    public void TriggerBox()
    {
        if(currentVerticalLerp!=null && currentSpacingLerp != null)
        {
            StopCoroutine(currentSpacingLerp);
            StopCoroutine(currentVerticalLerp);
        }

        if (closed)
        {
            Open();
        }
        else
        {
            Close();
        }
        closed = !closed;
    }

    
        
    

    IEnumerator LerpVerticalPadding(float lerpDuration, float minimumValuePadding, float maximumValuePadding)
    {
        float duration = 0f;
        while(duration < lerpDuration)
        {
            duration += Time.deltaTime;
            vLayout.padding.top = (int)Mathf.Lerp(minimumValuePadding, maximumValuePadding, duration / lerpDuration);
            yield return null;
        }
    }

    IEnumerator LerpSpacing(float lerpDuration, float minimumValueSpacing, float maximumValueSpacing)
    {
        float duration = 0f;
        while (duration < lerpDuration)
        {
            duration += Time.deltaTime;
            vLayout.spacing = (int)Mathf.Lerp(minimumValueSpacing, maximumValueSpacing, duration / lerpDuration);
            yield return null;
        }
    }

    IEnumerator HeightResize(float lerpDuration, float minimumValue, float maximumValue)
    {
        float duration = 0f;
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        while(duration < lerpDuration)
        {
            duration += Time.deltaTime;
            rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, Mathf.Lerp(minimumValue, maximumValue, duration / lerpDuration));
            yield return null;
        }
    }
}
