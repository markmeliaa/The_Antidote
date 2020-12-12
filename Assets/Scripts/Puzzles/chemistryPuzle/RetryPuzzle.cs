using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetryPuzzle : MonoBehaviour
{
    public GameObject currentPuzle;
    public GameObject background;

    private void OnMouseDown()
    {
        background.SetActive(true);

        for(int i = 0; i < currentPuzle.transform.childCount; i++)
        {
            currentPuzle.transform.GetChild(i).gameObject.SetActive(false);
        }
        currentPuzle.SetActive(false);

        background.SetActive(false);
        currentPuzle.SetActive(true);

        for (int i = 0; i < currentPuzle.transform.childCount; i++)
        {
            if(currentPuzle.transform.GetChild(i).name != "WinText")
                currentPuzle.transform.GetChild(i).gameObject.SetActive(true);
        }

        GameControl.fingerColor = new Color(1f, 1f, 1f, 1f);
        GameControl.redIsRed = false;
        GameControl.orangeIsOrange = false;
        GameControl.yellowIsYellow = false;
        GameControl.greenIsGreen = false;
        GameControl.blueIsBlue = false;
        GameControl.purpleIsPurple = false;

        GameControl.resetSelection = true;

        Transform squares = currentPuzle.transform.Find("Squares");
        for(int i = 0; i < squares.childCount; i++)
        {
            squares.GetChild(i).GetComponent<Renderer>().material.color = Color.white;
        }
    }
}
