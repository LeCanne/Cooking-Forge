using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using System;

public class PlayerControlsHandler : MonoBehaviour, Actions_Player.IPlayerActions
{
    Actions_Player controls;
    
    private static PlayerControlsHandler _instance;
 
    public static PlayerControlsHandler Instance
    {
        get 
        {
            if ((object)_instance == null)
            {
                GameObject go = new GameObject("InputHandler");
                _instance = go.AddComponent<PlayerControlsHandler>();
                DontDestroyOnLoad(go);
            }
            return _instance; 
        }
    } 
    
    void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public event Action Touch;
    public event Action CancelTouch;

    public event Action<Vector2> DragInfo;

    public void OnEnable()
    {
        if (controls == null)
        {

            controls = new Actions_Player();
            controls.Player.SetCallbacks(this);
        }
        controls.Player.Enable();
        controls.Player.Drag.performed += OnDrag;
    }

    public void OnDisable()
    {
        controls.Player.Disable();
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTouch(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed)
        {
            Touch?.Invoke();
        }
        if(context.phase == InputActionPhase.Canceled)
        {
            CancelTouch?.Invoke();
        }
    }

    public void OnDrag(InputAction.CallbackContext context)
    { 
       
            DragInfo?.Invoke(context.ReadValue<Vector2>());
            
        
    }
}
