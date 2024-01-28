using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class gameender : MonoBehaviour
{
    public static gameender instance;  // Static reference to the gameender
    public TextMeshProUGUI carCountText;
    //public Road destinationRoad;

    private void Awake()
{
    instance = this;
    carCountText = GameObject.Find("gameOver").GetComponent<TextMeshProUGUI>();
}


    // This method is called when the "Done" button is pressed
    public void OnDoneButtonPressed()
    {
        int carsOnDestinationRoad = CountCarsOnDestinationRoad();

        Debug.Log("Number of cars on destination road: " + carsOnDestinationRoad);

        carCountText.text = "You took " + carsOnDestinationRoad.ToString() + "/6 cars back to the museum";

        EndGame();  // Call the EndGame method
    }

    // This method counts the number of cars on the destination road
    private int CountCarsOnDestinationRoad()
    {
        int count = 0;

        // Iterate through all the cars in the scene
        moveford[] allCars = FindObjectsOfType<moveford>();

        foreach (moveford car in allCars)
        {
            // Check if the car is on the destination road
            Debug.Log(car);
            if (car.IsOnDestinationRoad("long_road_one_pavement (6)"))
            {
                count++;
            }
        }

        return count;
    }

    // Method to handle game over logic
    private void EndGame()
    {
        Debug.Log("Game Over!");
    }
}
