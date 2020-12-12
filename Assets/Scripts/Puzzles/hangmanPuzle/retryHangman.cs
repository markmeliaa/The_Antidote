using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class retryHangman : MonoBehaviour
{
    public GameObject background;
    public GameObject currentPuzzle;

    private void OnMouseDown()
    {
        background.SetActive(true);
        for(int i= 0; i < currentPuzzle.transform.childCount; i++)
        {
            currentPuzzle.transform.GetChild(i).gameObject.SetActive(false);
        }
        currentPuzzle.SetActive(false);

        background.SetActive(false);
        currentPuzzle.SetActive(true);
        for(int i = 0; i < currentPuzzle.transform.childCount; i++)
        {
            if (currentPuzzle.transform.GetChild(i).name != "YouWin" && currentPuzzle.transform.GetChild(i).name != "YouLose")
                currentPuzzle.transform.GetChild(i).gameObject.SetActive(true);
        }

        currentPuzzle.transform.Find("HangmanManager").GetComponent<ShowLetters>().resetValues();
    }
}
