using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class retryBlueRed : MonoBehaviour
{
    public GameObject gameArea;
    public GameObject winText;
    private void OnMouseDown()
    {
        if(!winText.activeSelf)
            gameArea.GetComponent<puzleController>().retryPuzle();
    }
}
