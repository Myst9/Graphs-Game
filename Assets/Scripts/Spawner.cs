using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject hide1;
    public GameObject hide2;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            //GameObject j = Instantiate(other.gameObject, new Vector3(transform.position.x + 1, transform.position.y,transform.position.z + 1),transform.rotation);
            //Instantiate(other.gameObject);
            //other.gameObject.FindGameObjectWithTag("Player").GetComponent<mov>().dead_time+= 40;
            hide1.SetActive(true); hide2.SetActive(true);
            Debug.Log("Successfully Generated ");
        }
    }
}
