using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TryAgain : MonoBehaviour
{
    [SerializeField] GameObject winText;
    [SerializeField] VyTController vytcontroller;
    public desactivatePuzzle endPuzle;

    private void OnMouseDown()
    {
        if (vytcontroller.checkTry())
        {
            winText.SetActive(true);

            for (int i = 0; i < vytcontroller.intento.transform.childCount; i++)
            {
                vytcontroller.intento.transform.GetChild(i).transform.GetComponent<BoxCollider2D>().enabled = false;
            }

            endPuzle.desactivate(false);
        }
    }
}
