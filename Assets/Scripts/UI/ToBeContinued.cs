using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToBeContinued : MonoBehaviour
{
    [SerializeField] GameObject circleWipe;
    [SerializeField] GameObject currentcircleWipe;
    [SerializeField] Canvas currentCanvas;
    [SerializeField] Canvas nextCanvas;

    private void Start()
    {
        StartCoroutine("changeScreen");
    }

    IEnumerator changeScreen()
    {
        yield return new WaitForSeconds(3);
        circleWipe.SetActive(true);
        circleWipe.GetComponent<Animator>().SetTrigger("Start");
        yield return new WaitForSeconds(1);
        circleWipe.SetActive(false);
        currentcircleWipe.SetActive(true);
        currentCanvas.gameObject.SetActive(false);
        nextCanvas.gameObject.SetActive(true);
    }
}
