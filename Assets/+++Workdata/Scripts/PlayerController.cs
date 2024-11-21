using System;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// irgendwas
/// </summary>
public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float jumpPower = 3f; 
    
    #region Private Variables

    public GameInput inputActions;
    /// <summary>
    /// reference to the moveaction from the inputmap (WASD)
    /// </summary>
    private InputAction moveAction;
    private InputAction jumpAction;
    
    private Vector2 moveInput;

    private Rigidbody2D rb;

    #endregion
    
    /// <summary>
    /// 
    /// </summary>
    private void Awake()
    {
        /*
         *
         *
         *
         * 
         */
        rb = gameObject.GetComponent<Rigidbody2D>();

        if (rb == null)
        {
            Debug.LogError("Rigidbody not available");
        }
        inputActions = new GameInput();
        moveAction = inputActions.Player.Move;
        jumpAction = inputActions.Player.Jump;
    }

    private void OnEnable()
    {
        inputActions.Enable();
        moveAction.performed += Move;
        moveAction.canceled += Move;

        jumpAction.performed += Jump;
    }


    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput.x * movementSpeed, rb.velocity.y);
    }

    private void OnDisable()
    {
        //
        inputActions.Disable();
        //
        moveAction.performed -= Move;
        
        //
        moveAction.canceled -= Move;
        
        jumpAction.performed -= Jump;
    }

    private void Move(InputAction.CallbackContext ctx)
    {
        moveInput = ctx.ReadValue<Vector2>();
    }
    
    private void Jump(InputAction.CallbackContext ctx)
    {
        rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
    }


    public void MAthe1()
    {
        int result = Addnumbers(4, 6);
    }

    public int Addnumbers(int a, int b)
    {
        int x = a * 2 + b * 2;
        return x;
    }

    public bool isDoorOpen;
    public void CheckIfDoorIsOpen()
    {
        if (isDoorOpen == false)
        {
           //.... 
        }
    }

    
}
