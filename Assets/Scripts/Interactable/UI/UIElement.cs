using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class UIElement : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public UnityEvent OnAct;
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Bonsoir");
        OnAct.Invoke();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
