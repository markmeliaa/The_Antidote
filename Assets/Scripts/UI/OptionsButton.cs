using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsButton : MonoBehaviour
{
    [SerializeField] MenuButtonController menuButtonController;
    [SerializeField] Animator animator;
    [SerializeField] AnimatorFunctions animatorFunctions;
    [SerializeField] int thisIndex;
    [SerializeField] GameObject circleWipe;
    [SerializeField] GameObject currentcircleWipe;
    [SerializeField] Canvas currentCanvas;
    [SerializeField] Canvas nextCanvas;

    // Update is called once per frame
    void Update()
    {
        if (menuButtonController.index == thisIndex)
        {
            animator.SetBool("selected", true);
            // Pressed
            if (Input.GetAxis("Submit") == 1)
            {
                animator.SetBool("pressed", true);
                circleWipe.SetActive(true);
                circleWipe.GetComponent<Animator>().SetTrigger("Start");
                StartCoroutine("wait");
            }

            else if (animator.GetBool("pressed"))
            {
                animator.SetBool("pressed", false);
                animatorFunctions.disableOnce = true;
            }
        }

        else
            animator.SetBool("selected", false);
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1);
        circleWipe.SetActive(false);
        currentcircleWipe.SetActive(true);
        currentCanvas.gameObject.SetActive(false);
        nextCanvas.gameObject.SetActive(true);
    }
}
