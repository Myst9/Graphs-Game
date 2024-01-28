using System.Collections;
using UnityEngine;
using UnityEngine.UI; 
using TMPro; 

public class ChangeHint_dfs : MonoBehaviour
{
    public float displayTime = 5f;
    public GameObject hintObject;
    public TextMeshProUGUI scrollText;

    void Start()
    {
        HideHint();
    }

    public void ChangeHint()
    {
        if (scrollText!= null)
        {
            scrollText.text = "Go back"; 
        }
        hintObject.SetActive(true);
        StartCoroutine(HideAfterDelay());
    }

    private void HideHint()
    {
        hintObject.SetActive(false);
    }

    private IEnumerator HideAfterDelay()
    {
        yield return new WaitForSeconds(displayTime);
        HideHint();
    }
}
