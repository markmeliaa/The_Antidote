using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetryPuzzle : MonoBehaviour
{
    public GameObject currentPuzle;

    private void OnMouseDown()
    {
        if (!currentPuzle.transform.Find("WinText").gameObject.activeSelf)
        {
            GameControl.fingerColor = new Color(1f, 1f, 1f, 1f);
            GameControl.redIsRed = false;
            GameControl.orangeIsOrange = false;
            GameControl.yellowIsYellow = false;
            GameControl.greenIsGreen = false;
            GameControl.blueIsBlue = false;
            GameControl.purpleIsPurple = false;

            GameControl.resetSelection = true;

            Transform squares = currentPuzle.transform.Find("Squares");
            for (int i = 0; i < squares.childCount; i++)
            {
                squares.GetChild(i).GetComponent<Renderer>().material.color = Color.white;
            }
        }
    }
}
