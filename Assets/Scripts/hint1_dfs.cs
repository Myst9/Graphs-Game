using System.Collections;
using UnityEngine;

public class hint1_dfs : MonoBehaviour
{
    public float displayTime = 5f;
    public GameObject hintObject;

    void Start()
    {
        HideHint();
    }

    public void ShowHint()
    {
        
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
