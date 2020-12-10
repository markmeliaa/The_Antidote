using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class desactivatePuzzle : MonoBehaviour
{
    [SerializeField] GameObject currentPuzzle;
    [SerializeField] GameObject background;

    private void OnMouseDown()
    {
        currentPuzzle.SetActive(false);
        background.SetActive(true);
    }
}
