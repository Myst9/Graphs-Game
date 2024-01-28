using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitch_dfs : MonoBehaviour
{

    public GameObject cam1;

     void Start()
     {
            cam1.SetActive(false);
     }

    void Update()
    {
        
        if (Input.GetButtonDown("1Key"))
        {
            Debug.Log("1 pressed");
            cam1.SetActive(true);
        }
        if (Input.GetButtonDown("2Key"))
        {
            Debug.Log("2 pressed");
            cam1.SetActive(false);
        }
    }

}
