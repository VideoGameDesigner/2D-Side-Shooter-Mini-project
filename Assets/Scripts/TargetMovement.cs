using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TargetMovement : MonoBehaviour
{
    public GameObject Respawnbox;
    public float delay = 2f;
    public float timer;

    public float distanceTocover;
    public float targetspeed;

    private Vector3 startingposition;




    // Start is called before the first frame update
    void Start()
    {
        startingposition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(TargetPractice.isactive == false)
        {
            timer += Time.deltaTime;
            if(timer > delay)
            {
                Respawnbox.SetActive(true);
                timer = 0;             
            }
                   
        }

        if( timer == 0)
        {
            timer += Time.deltaTime;
            
        }

        Vector3 axis = startingposition;

        axis.x += distanceTocover * Mathf.Sin(Time.time * targetspeed);
        transform.position = axis;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }



    }

}
