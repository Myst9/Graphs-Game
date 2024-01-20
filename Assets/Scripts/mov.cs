using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 5f;

    public Rigidbody rb;

    Vector3 movem;

    // Update is called once per frame
    void Update()
    {
        movem.x = Input.GetAxisRaw("Horizontal");
        movem.z = Input.GetAxisRaw("Vertical");
        movem.y = 0;
        change(movem);
    }

    void change(Vector3 movem)
    {
        rb.MovePosition(rb.position + movem * Time.deltaTime * moveSpeed);
    }
}
