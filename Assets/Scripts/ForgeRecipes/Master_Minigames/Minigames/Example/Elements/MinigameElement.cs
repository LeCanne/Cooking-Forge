using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class MinigameElement : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public UnityEvent UsedObject;
    public bool interactable;

    public void OnPointerDown(PointerEventData eventData)
    {
        if(interactable == true)
        {
            UsedObject.Invoke();
        }
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
