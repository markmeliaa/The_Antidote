using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class retryHangman : MonoBehaviour
{
    public GameObject currentPuzzle;

    private void OnMouseDown()
    {
        if( !currentPuzzle.transform.Find("YouWin").gameObject.activeSelf && currentPuzzle.transform.Find("HangmanManager").GetComponent<ShowLetters>() != null)
            currentPuzzle.transform.Find("HangmanManager").GetComponent<ShowLetters>().resetValues();

        if ( !currentPuzzle.transform.Find("YouWin").gameObject.activeSelf && currentPuzzle.transform.Find("HangmanManager").GetComponent<ShowLetters>() == null)
        {
            if ( !currentPuzzle.transform.Find("YouWin").gameObject.activeSelf && currentPuzzle.transform.Find("HangmanManager").GetComponent<ShowLetters2>() != null)
                currentPuzzle.transform.Find("HangmanManager").GetComponent<ShowLetters2>().resetValues();

            if (!currentPuzzle.transform.Find("YouWin").gameObject.activeSelf && currentPuzzle.transform.Find("HangmanManager").GetComponent<ShowLetters2>() == null)
            {
                if (!currentPuzzle.transform.Find("YouWin").gameObject.activeSelf && currentPuzzle.transform.Find("HangmanManager").GetComponent<ShowLetters3>() != null)
                    currentPuzzle.transform.Find("HangmanManager").GetComponent<ShowLetters3>().resetValues();

                if (!currentPuzzle.transform.Find("YouWin").gameObject.activeSelf && currentPuzzle.transform.Find("HangmanManager").GetComponent<ShowLetters3>() == null)
                {
                    if (!currentPuzzle.transform.Find("YouWin").gameObject.activeSelf && currentPuzzle.transform.Find("HangmanManager").GetComponent<ShowLetters4>() != null)
                        currentPuzzle.transform.Find("HangmanManager").GetComponent<ShowLetters4>().resetValues();

                    if (!currentPuzzle.transform.Find("YouWin").gameObject.activeSelf && currentPuzzle.transform.Find("HangmanManager").GetComponent<ShowLetters4>() == null)
                        currentPuzzle.transform.Find("HangmanManager").GetComponent<ShowLetters5>().resetValues();
                }
            }
        }

        if (currentPuzzle.transform.Find("YouLose").gameObject.activeSelf)
            currentPuzzle.transform.Find("YouLose").gameObject.SetActive(false);
    }
}
