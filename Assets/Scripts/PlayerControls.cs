using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerControls : MonoBehaviour
{
    public float Mspeed;
    public float PJump;

    public static float move;
    private Rigidbody2D rb;
    bool FacingRight = true;
    
    


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(move * Mspeed, rb.velocity.y);

       

    }



    // Update is called once per frame
    void Update()
    {
        if(move <0 && FacingRight)
        {
            betterFlip();
        }

        else if (move > 0 && !FacingRight)
        {
            betterFlip();
        }

        

    }


    void betterFlip()
    {
        FacingRight = !FacingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    public void Move(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>().x;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if(Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            rb.AddForce(new Vector2(0, PJump), ForceMode2D.Impulse);
        }
    }
}
