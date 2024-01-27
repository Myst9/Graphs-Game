using System.Collections;
using UnityEngine;

public class hint2_dfs : MonoBehaviour
{
    public float displayTime = 5f;
    public GameObject hintObject;
    public GameObject scroll1;
    public GameObject scroll2;

    void Start()
    {
        HideHint();
        scroll1.SetActive(false);
        scroll2.SetActive(false);
    }

    public void ShowHint()
    {
        
        hintObject.SetActive(true);
        scroll1.SetActive(true);
        scroll2.SetActive(true);
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
