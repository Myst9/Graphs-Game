using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CapacityText : MonoBehaviour
{
    // Start is called before the first frame update
    public Road r;
    public TextMeshProUGUI UpdateCapacity;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCapacity.text = r.capacity.ToString();
    }
}
