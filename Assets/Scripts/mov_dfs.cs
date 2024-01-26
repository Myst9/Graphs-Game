using System.Collections;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float moveSpeed = 10f;
    public Rigidbody rb;
    int coins = 0;

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            coins++;
            Debug.Log("Coins: " + coins);
        }
        else if (other.gameObject.CompareTag("hint1") ||
                 other.gameObject.CompareTag("hint2") ||
                 other.gameObject.CompareTag("hint3") ||
                 other.gameObject.CompareTag("hint4") ||
                 other.gameObject.CompareTag("hint5") ||
                 other.gameObject.CompareTag("hint6") ||
                 other.gameObject.CompareTag("hint7") ||
                 other.gameObject.CompareTag("hint8"))
        {
            hint1_dfs hintController = other.GetComponentInChildren<hint1_dfs>();
            hintController?.ShowHint();
        }
    }
}
