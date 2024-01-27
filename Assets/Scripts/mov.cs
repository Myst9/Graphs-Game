using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody rb;
    private Road currentRoad;
    private bool hasEnteredRoad = false;

    private static Move currentlySelectedCar;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Move clickedCar = hit.collider.GetComponent<Move>();

                if (clickedCar != null)
                {
                    if (currentlySelectedCar != null && currentlySelectedCar != clickedCar)
                    {
                        currentlySelectedCar.Deselect();
                    }

                    clickedCar.Select();
                }
            }
        }

        if (currentlySelectedCar != null)
        {
            currentlySelectedCar.MoveSelectedCar();
        }
    }

    void Select()
    {
        currentlySelectedCar = this;
    }

    void Deselect()
    {
        currentlySelectedCar = null;
    }

    void MoveSelectedCar()
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
        if (!currentRoad)
        {
            Debug.Log("No road");
            hasEnteredRoad = false; // Reset the flag if the car is not on any road
        }

        if (currentRoad != null && currentRoad.CanCarMove())
        {
            rb.MovePosition(rb.position + movement * Time.deltaTime * moveSpeed);
            if (!hasEnteredRoad)
            {
                Debug.Log("Moving car");
                currentRoad.CarEntered();
                hasEnteredRoad = true; // Set the flag to true after entering the road
            }
        }
        else
        {
            if (hasEnteredRoad)
            {
                Debug.Log("Cannot move on this road");
                hasEnteredRoad = false; // Reset the flag when exiting the road
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Road road = other.GetComponent<Road>();
        if (road != null)
        {
            currentRoad = road;
        }
    }

    void OnTriggerExit(Collider other)
    {
        Road road = other.GetComponent<Road>();
        if (road != null)
        {
            currentRoad.CarExited();
            currentRoad = null;
        }
    }
}
