using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 5f;

    public Rigidbody rb;

    int coins = 0;
    public float dead_y = -50;
    Vector3 movem;


    // Update is called once per frame
    void Update()
    {
        movem.x = Input.GetAxisRaw("Horizontal");
        movem.z = Input.GetAxisRaw("Vertical");
        movem.y = 0;
        change(movem);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            coins++;
            Debug.Log("Coins: " + coins);
        }
    }

    void change(Vector3 movem)
    {
        rb.MovePosition(rb.position + movem * Time.deltaTime * moveSpeed);
    }
}
