using UnityEngine;

public class Road : MonoBehaviour
{
    public int capacity = 10; // Initial capacity of the road
    public Transform beginningPoint; // The beginning point of the road
    public Transform endingPoint; // The ending point of the road

    // Function to check if the road has enough capacity for a car to travel
    public bool CanCarMove()
    {
        Debug.Log(capacity);
        return capacity > 0;
    }

    // Function to decrease the road capacity when a car enters
    public void CarEntered(bool movingTowardsEnding)
    {
        if (movingTowardsEnding)
        {
            capacity--;
            Debug.Log("Car entered. Capacity decreases. Remaining capacity: " + capacity);
        }
        else
        {
            capacity++;
             Debug.Log("Car entered. Capacity increases. Remaining capacity: " + capacity);
        }
    }

    // Function to increase the road capacity when a car exits (reverse direction)
    public void CarExited()
    {
        Debug.Log("Car exited. Remaining capacity: " + capacity);
    }

    // private bool IsCarOnRoad()
    // {
    //     // Return true if the car is on the road, false otherwise

    //     Collider roadCollider = GetComponent<Collider>();

    //     if (roadCollider == null)
    //     {
    //         Debug.LogError("Road collider not found.");
    //         return false;
    //     }

    //     // Example condition (replace with your own)
    //     float carX = transform.position.x;
    //     float carZ = transform.position.z;
    //     float roadX = this.transform.position.x;
    //     float roadZ = this.transform.position.z;
    //     float roadWidth = roadCollider.bounds.size.x;

    //     return Mathf.Abs(carX - roadX) < roadWidth / 2f && Mathf.Abs(carZ - roadZ) < roadWidth / 2f;
    // }

    // Function to determine the direction of car movement on the road
    public bool IsCarMovingTowardsEnding(Transform carTransform)
    {
        Vector3 roadDirection = endingPoint.position - beginningPoint.position;
        Vector3 carDirection = carTransform.forward;

        float dotProduct = Vector3.Dot(roadDirection.normalized, carDirection.normalized);

        // If dot product is positive, car is moving towards the ending point
        //Debug.Log(dotProduct);
        return dotProduct >= 0f;
    }
}
