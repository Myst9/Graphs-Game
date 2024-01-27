using System.Collections;
using UnityEngine;

public class hint3_dfs : MonoBehaviour
{
    public float displayTime = 5f;
    public GameObject hintObject;
    public GameObject scroll1;

    void Start()
    {
        HideHint();
        scroll1.SetActive(false);
    }

    public void ShowHint()
    {
        
        hintObject.SetActive(true);
        scroll1.SetActive(true);
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
