using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetryPipes : MonoBehaviour
{
    public GameObject currentPuzle;
    public TextMesh winText;

    private void OnMouseDown()
    {
        if (winText.gameObject.activeSelf)
        {
            currentPuzle.transform.Find("PuzleManager").GetComponent<PuzleManager>().resetPuzle();
        }
    }
}
