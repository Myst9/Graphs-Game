using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitch : MonoBehaviour
{

    public GameObject cam1;
    public GameObject cam2;
    public GameObject cam3;
    public GameObject cam4;
    public GameObject cam5;
    public GameObject cam6;
    public GameObject cam7;
    public GameObject cam8;
    public GameObject cam9;
    public GameObject cam10;

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetButtonDown("1Key"))
        {
            Debug.Log("1 pressed");
            setFalse();
            cam1.SetActive(true);
        }
        if (Input.GetButtonDown("2Key"))
        {
            Debug.Log("2 pressed");
            setFalse();
            cam2.SetActive(true);
        }
        if (Input.GetButtonDown("3Key"))
        {
            setFalse();
            cam3.SetActive(true);
        }
        if (Input.GetButtonDown("4Key"))
        {
            setFalse();
            cam4.SetActive(true);
        }
        if (Input.GetButtonDown("5Key"))
        {
            setFalse();
            cam5.SetActive(true);
        }
        if (Input.GetButtonDown("6Key"))
        {
            setFalse();
            cam6.SetActive(true);
        }
        if (Input.GetButtonDown("7Key"))
        {
            setFalse();
            cam7.SetActive(true);
        }
        if (Input.GetButtonDown("8Key"))
        {
            setFalse();
            cam8.SetActive(true);
        }
        if (Input.GetButtonDown("9Key"))
        {
            setFalse();
            cam9.SetActive(true);
        }
        if (Input.GetButtonDown("0Key"))
        {
            setFalse();
            cam10.SetActive(true);
        }
    }

    void setFalse()
    {
        cam1.SetActive(false);
        cam2.SetActive(false);
        /*cam3.SetActive(false);
        cam4.SetActive(false);
        cam5.SetActive(false);
        cam6.SetActive(false);
        cam7.SetActive(false);
        cam8.SetActive(false);
        cam9.SetActive(false);*/
        cam10.SetActive(false);
    }
}
