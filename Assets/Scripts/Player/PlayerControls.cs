using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;

public class PlayerControls : MonoBehaviour, Actions_Player.IPlayerActions
{
    Actions_Player controls;
    

    public void OnEnable()
    {
        if (controls == null)
        {

            controls = new Actions_Player();
            controls.Player.SetCallbacks(this);
        }
        controls.Player.Enable();
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
          
        }
    }
}
