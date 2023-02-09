using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Mathematics;

public class WeaponRotation : MonoBehaviour
{
    //private float WeaponAngle;
    //public float RotationSpeed;
    //public float roMin, roMax;


    Vector3 rotateUD;
    public float rotateSpeed;

    PlayerInputs NewRototeaction;



    // Start is called before the first frame update
    void Start()
    {
       
    }


    private void Awake()
    {
        NewRototeaction = new PlayerInputs();

        //Note: += cntxt => above is acting as a pipe... taking the context
        //      value  and inserting it into moveLR varaible (lambda value)
        NewRototeaction.Player.Aim.performed += cntxt => rotateUD = cntxt.ReadValue<Vector2>();
        NewRototeaction.Player.Aim.canceled += cntxt => rotateUD = Vector2.zero;

    }
    // Update is called once per frame
    void Update()
    {
   

        Vector3 myRotateUD = new Vector3(0f, 0f, rotateUD.y * rotateSpeed);
        // x and y values zero'd as only want to rotate
        if (myRotateUD.z > 0f)
        {
            
            float rotAmount = Time.deltaTime * rotateSpeed;
            float clampedRotation = Mathf.Clamp(transform.localEulerAngles.z + rotAmount, 0.0f, 70.0f);
            transform.localEulerAngles = new Vector3(0f, 0f, clampedRotation);
        }
        else if (myRotateUD.z < 0f)
        {
            
            float rotAmount = Time.deltaTime * -rotateSpeed;
            float clampedRotation = Mathf.Clamp(transform.localEulerAngles.z + rotAmount, 0.0f, 70.0f);
            transform.localEulerAngles = new Vector3(0f, 0f, clampedRotation);
        }


    }


    private void FixedUpdate()
    {
        


        //transform.Rotate(0,0,WeaponAngle * RotationSpeed)
        
        //WeaponAngle += RotationSpeed * Input.GetAxis("Vertical");
        

        

        
        //WeaponAngle =  Mathf.Clamp(WeaponAngle, roMin, roMax);
        //transform.localEulerAngles = new Vector3(0, 0, WeaponAngle);

    }


  


    /*public void Aim(InputAction.CallbackContext context)
    {


        rotateUD = context.ReadValue<Vector2>();

       

    }*/

    private void OnEnable()
    {
        NewRototeaction.Player.Aim.Enable();
    }

    private void OnDisable()
    {
        NewRototeaction.Player.Aim.Disable();
    }



}
