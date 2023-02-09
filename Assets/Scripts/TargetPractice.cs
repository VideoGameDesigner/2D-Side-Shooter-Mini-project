using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPractice : MonoBehaviour
{
    public static bool isactive;
    
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
        isactive = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Bullet"))
        {

            gameObject.SetActive(false);
            isactive = false;
        }
    }

    

}
