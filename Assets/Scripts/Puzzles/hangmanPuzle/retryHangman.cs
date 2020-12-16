using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class retryHangman : MonoBehaviour
{
    public GameObject currentPuzzle;

    private void OnMouseDown()
    {
        if(!currentPuzzle.transform.Find("YouLose").gameObject.activeSelf && !currentPuzzle.transform.Find("YouWin").gameObject.activeSelf && currentPuzzle.transform.Find("HangmanManager").GetComponent<ShowLetters>() != null)
            currentPuzzle.transform.Find("HangmanManager").GetComponent<ShowLetters>().resetValues();

        if (!currentPuzzle.transform.Find("YouLose").gameObject.activeSelf && !currentPuzzle.transform.Find("YouWin").gameObject.activeSelf && currentPuzzle.transform.Find("HangmanManager").GetComponent<ShowLetters>() == null)
            currentPuzzle.transform.Find("HangmanManager").GetComponent<ShowLetters2>().resetValues();
    }
}
