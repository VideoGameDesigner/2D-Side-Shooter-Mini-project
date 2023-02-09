using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponFire : MonoBehaviour
{
    public Transform FirePoint1;
    public Transform FirePoint2;
    public Transform FirePoint3;
    public Transform FirePoint3a;
    public Transform FirePoint3b;
    public GameObject BulletPrefab1;
    public GameObject BulletPrefab2;
    public GameObject BulletPrefab3;
    public GameObject BulletPrefab3a;
    public GameObject BulletPrefab3b;
   

    int totalWeapons = 1;
    public int currentWeaponIndex;
    
    public GameObject[] guns;
    public GameObject WeaponHolder;
    public GameObject CurrentGun;


    private float firerate1 = 0.4f;
    private float firerate2 = 0.4f;
    private float firerate3 = 0.1f;
    private float nextfire1 = 0f;
    private float nextfire2 = 0f;
    private float nextfire3 = 0f;
    

    // Start is called before the first frame update
    void Start()
    {
        totalWeapons = WeaponHolder.transform.childCount;
        guns = new GameObject[totalWeapons];

        for (int i = 0; i < totalWeapons; i++)
        {
            guns[i] = WeaponHolder.transform.GetChild(i).gameObject;
            guns[i].SetActive(false);

        }

        guns[0].SetActive(true);
        currentWeaponIndex = 0;
       
    }

    // Update is called once per frame
    void Update()
    {
         /*if(Input.GetKeyDown(KeyCode.T))
        {
            if(currentWeaponIndex < totalWeapons-1)

            {
                guns[currentWeaponIndex].SetActive(false);
                currentWeaponIndex += 1;
                guns[currentWeaponIndex].SetActive(true);
                CurrentGun = guns[currentWeaponIndex];
            }


        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            if (currentWeaponIndex > 0)

            {
                guns[currentWeaponIndex].SetActive(false);
                currentWeaponIndex -= 1;
                guns[currentWeaponIndex].SetActive(true);
                CurrentGun = guns[currentWeaponIndex];
            }


        }

        */

       


    }


    void Shoot1()
    {
        if(currentWeaponIndex == 0)

        {
            Instantiate(BulletPrefab1, FirePoint1.position, FirePoint1.rotation);
        }
        
    }

    void Shoot2()
    {
        if(currentWeaponIndex ==1)

        {
            Instantiate(BulletPrefab2, FirePoint2.position, FirePoint2.rotation);
        }
       
    }

    void Shoot3()
    {
        if(currentWeaponIndex ==2)
        {
            Instantiate(BulletPrefab3, FirePoint3.position, FirePoint3.rotation);
            Instantiate(BulletPrefab3a, FirePoint3a.position, FirePoint3a.rotation);
            Instantiate(BulletPrefab3b, FirePoint3b.position, FirePoint3b.rotation);
        }
        
    }


    public void Fire(InputAction.CallbackContext context)
    {


        if (Time.time > nextfire1)
        {
            nextfire1 = Time.time + firerate1;
            Shoot1();
        }

        if (Time.time > nextfire2)
        {
            nextfire2 = Time.time + firerate2;
            Shoot2();
        }


        if ( Time.time > nextfire3 )
        {
            nextfire3 = Time.time + firerate3;
            Shoot3();
        }
    

    }

    public void WeaponSwtich1(InputAction.CallbackContext context)
    {
        if (currentWeaponIndex ==0 && currentWeaponIndex !=1 && currentWeaponIndex != 2)

        {
            guns[currentWeaponIndex].SetActive(false);
            currentWeaponIndex = 1;
            guns[currentWeaponIndex].SetActive(true);
            CurrentGun = guns[currentWeaponIndex];
        }

        if (currentWeaponIndex == 2 && currentWeaponIndex != 1 && currentWeaponIndex != 0)

        {
            guns[currentWeaponIndex].SetActive(false);
            currentWeaponIndex = 1;
            guns[currentWeaponIndex].SetActive(true);
            CurrentGun = guns[currentWeaponIndex];
        }


    }

    public void WeaponSwtich2(InputAction.CallbackContext context)
    {
        if (currentWeaponIndex == 1 && currentWeaponIndex !=0 && currentWeaponIndex != 2)

        {
            guns[currentWeaponIndex].SetActive(false);
            currentWeaponIndex = 2;
            guns[currentWeaponIndex].SetActive(true);
            CurrentGun = guns[currentWeaponIndex];
        }

        if (currentWeaponIndex == 0 && currentWeaponIndex != 1 && currentWeaponIndex != 2)

        {
            guns[currentWeaponIndex].SetActive(false);
            currentWeaponIndex = 2;
            guns[currentWeaponIndex].SetActive(true);
            CurrentGun = guns[currentWeaponIndex];
        }

    }

    public void WeaponSwtich3(InputAction.CallbackContext context)
    {
        if (currentWeaponIndex == 2 && currentWeaponIndex != 0 && currentWeaponIndex != 1)

        {
            guns[currentWeaponIndex].SetActive(false);
            currentWeaponIndex = 0;
            guns[currentWeaponIndex].SetActive(true);
            CurrentGun = guns[currentWeaponIndex];
        }


        if (currentWeaponIndex == 1 && currentWeaponIndex != 0 && currentWeaponIndex != 2)

        {
            guns[currentWeaponIndex].SetActive(false);
            currentWeaponIndex = 0;
            guns[currentWeaponIndex].SetActive(true);
            CurrentGun = guns[currentWeaponIndex];
        }


    }




}
