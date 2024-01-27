using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mov_dijkstra : MonoBehaviour
{
    // Start is called before the first frame update
    
    public float moveSpeed = 10f;
    public Rigidbody rb;

    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput).normalized;

        if (movement != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, Time.deltaTime * 360f);
        }

        MoveCar(movement);
    }

    void MoveCar(Vector3 movement)
    {

        rb.MovePosition(rb.position + movement * Time.deltaTime * moveSpeed);
    }

}
