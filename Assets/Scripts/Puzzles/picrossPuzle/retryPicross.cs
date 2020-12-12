using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class retryPicross : MonoBehaviour
{
    public GameObject currentPuzle;

    private void OnMouseDown()
    {
        if (!currentPuzle.transform.Find("youWin").gameObject.activeSelf)
        {
            currentPuzle.transform.Find("PicrossManager").GetComponent<CountPoints>().resetGame();
        }
    }
}
