using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveford : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody rb;
    private Road currentRoad;
    private bool OnRoad = false;
    private bool entered = false;

    private static moveford currentlySelectedCar;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                moveford clickedCar = hit.collider.GetComponent<moveford>();

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
            currentlySelectedCar.movefordSelectedCar();
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

    void movefordSelectedCar()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput).normalized;

        if (movement != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, Time.deltaTime * 360f);
        }

        movefordCar(movement);
    }

    void movefordCar(Vector3 movement)
    {
        if (!currentRoad)
        {
            Debug.Log("No road");
            OnRoad = false; // Reset the flag if the car is not on any road
        }

        else if (currentRoad != null && currentRoad.CanCarMove())
        {
            bool movingTowardsEnding = currentRoad.IsCarMovingTowardsEnding(transform);
            rb.MovePosition(rb.position + movement * Time.deltaTime * moveSpeed);
            if(!OnRoad && !entered){
                Debug.Log("entered just now");
                currentRoad.CarEntered(movingTowardsEnding);
                OnRoad = true;
                entered = true;
            }
            // if (!hasEnteredRoad)
            // {
            //     Debug.Log("Moving car");
            //     currentRoad.CarEntered(movingTowardsEnding);
            //     hasEnteredRoad = true; // Set the flag to true after entering the road
            // }
        }
        else
        {
            Debug.Log("Cannot move on this road");
            OnRoad = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Road road = other.GetComponent<Road>();
        if (road != null)
        {
            currentRoad = road;
            Debug.Log(road);
        }
    }

    void OnTriggerExit(Collider other)
    {
        Road road = other.GetComponent<Road>();
        if (road != null)
        {
            currentRoad.CarExited();
            //currentRoad = null;
            OnRoad = false;
            entered = false;
        }
    }
}
