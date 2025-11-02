using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;



public class DragObject : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    Vector2 originalPos;
    bool holding;
    bool touchable = true;
    public bool goBack;
    public float lerpDuration = 0.25f;
    Coroutine currentDragged;
     
    public void OnPointerDown(PointerEventData eventData)
    {
        if (currentDragged != null)
        {
            StopCoroutine(currentDragged);
            touchable = true;

        }
        if (touchable)
        {
            Debug.Log("You found me");
            holding = true;
            currentDragged = StartCoroutine(Dragged());
        }
       
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("You dropped me");
        holding = false;
       
        
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TouchSimulation.Enable();
        originalPos = transform.position;
    }

    public IEnumerator Dragged()
    {
        while (holding)
        {
            if (Touch.activeTouches.Count > 0)
            {
                Touch touch = Touch.activeTouches[0];
                Vector3 pos = Camera.main.ScreenToWorldPoint(Touch.activeTouches[0].screenPosition);
                transform.position = new Vector3(pos.x, pos.y, 0);
            }
            yield return null;
        }

        if (goBack)
        {
            touchable = false;
            float timeLerp = 0;
            Vector3 iteratedPos = transform.position;
            while(timeLerp < lerpDuration)
            {
                
                float t = timeLerp / lerpDuration;
                transform.position = Vector2.Lerp(iteratedPos, originalPos, EasingFunc(t));
                timeLerp += Time.deltaTime;
                yield return null;
            }
            touchable = true;
        }
      
    }

    float EasingFunc(float x)
    {
        return x < 0.5 ? 2 * x * x : 1 - Mathf.Pow(-2 * x + 2, 2) / 2;
    }

   
    
}
