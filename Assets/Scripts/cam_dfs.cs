using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam_dfs : MonoBehaviour
{
    public GameObject player;
    public float defaultFOV = 200f;
    public float tiltAngle = 0f;
    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.Find("download"); // The player
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 5, player.transform.position.z - 10);
         Camera.main.fieldOfView = defaultFOV / (Mathf.Sqrt(Vector3.Distance(transform.position, player.transform.position) + 1));
         transform.rotation = Quaternion.Euler(tiltAngle, 0f, 0f);
    }

}
