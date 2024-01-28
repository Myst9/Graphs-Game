using System.Collections;
using UnityEngine;

public class move_dfs : MonoBehaviour
{
    public float moveSpeed = 10f;
    public Rigidbody rb;
    int coins = 0;
    public Logic_dfs l;
    private int coinsCollected = 0;


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
            l.addScore(1);
            coinsCollected++;

            if (coinsCollected == 8)
            {
                Debug.Log("Gameover! You collected 8 items.");
            }
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("hint1"))
        {
            hint1_dfs hintController = other.GetComponentInChildren<hint1_dfs>();
            hintController?.ShowHint();
        }
        else if (other.gameObject.CompareTag("hint2"))
        {
            hint2_dfs hintController = other.GetComponentInChildren<hint2_dfs>();
            hintController?.ShowHint();
        }
        else if (other.gameObject.CompareTag("hint3"))
        {
            hint2_dfs hintController = other.GetComponentInChildren<hint2_dfs>();
            hintController?.ShowHint();
        }
        else if (other.gameObject.CompareTag("hint4"))
        {
            hint1_dfs hintController = other.GetComponentInChildren<hint1_dfs>();
            hintController?.ShowHint();
        }
        else if (other.gameObject.CompareTag("hint5"))
        {
            hint1_dfs hintController = other.GetComponentInChildren<hint1_dfs>();
            hintController?.ShowHint();
        }
        else if (other.gameObject.CompareTag("hint6"))
        {
            hint3_dfs hintController = other.GetComponentInChildren<hint3_dfs>();
            hintController?.ShowHint();
        }
        else if (other.gameObject.CompareTag("hint7"))
        {
            hint1_dfs hintController = other.GetComponentInChildren<hint1_dfs>();
            hintController?.ShowHint();
        }
        else if (other.gameObject.CompareTag("hint8"))
        {
            hint1_dfs hintController = other.GetComponentInChildren<hint1_dfs>();
            hintController?.ShowHint();
        }
    }

}
