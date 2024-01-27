using UnityEngine;

public class Road : MonoBehaviour
{
    public int capacity = 10; // Initial capacity of the road

    // Function to check if the road has enough capacity for a car to travel
    public bool CanCarMove()
    {
        Debug.Log(capacity);
        return capacity > 0;
    }

    // Function to decrease the road capacity when a car enters
    public void CarEntered()
{
    if (capacity > 0)
    {
        capacity--;
        Debug.Log("Car entered. Remaining capacity: " + capacity);
    }
    else
    {
        Debug.LogError("Capacity is already zero.");
    }
}


    // Function to increase the road capacity when a car exits (reverse direction)
    public void CarExited()
    {
        if (!IsCarOnRoad())
    {
        capacity++;
        Debug.Log("Car exited. Remaining capacity: " + capacity);
    }
    }

    private bool IsCarOnRoad()
{
    // Implement your logic to check if the car is still on the road
    // Return true if the car is on the road, false otherwise

    Collider roadCollider = GetComponent<Collider>();

    if (roadCollider == null)
    {
        Debug.LogError("Road collider not found.");
        return false;
    }

    // Example condition (replace with your own)
    float carX = transform.position.x;
    float carZ = transform.position.z;
    float roadX = this.transform.position.x;
    float roadZ = this.transform.position.z;
    float roadWidth = roadCollider.bounds.size.x;

    return Mathf.Abs(carX - roadX) < roadWidth / 2f && Mathf.Abs(carZ - roadZ) < roadWidth / 2f;
}



}