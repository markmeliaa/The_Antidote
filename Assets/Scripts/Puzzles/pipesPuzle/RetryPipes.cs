using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetryPipes : MonoBehaviour
{
    public GameObject currentPuzle;

    private void OnMouseDown()
    {
        if (!currentPuzle.transform.Find("Text").Find("winnerText").gameObject.activeSelf)
        {
            currentPuzle.transform.Find("Puzle Manager").GetComponent<PuzleManager>().resetPuzle();
        }
    }
}
