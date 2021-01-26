using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openInstructions : MonoBehaviour
{
    private Animator instructAnimator;

    // Start is called before the first frame update
    void Start()
    {
        instructAnimator = GetComponent<Animator>();
    }

    private void OnMouseDown()
    {
        if (instructAnimator.GetBool("ShowQuestions"))
        {
            instructAnimator.SetBool("ShowQuestions", false);
        }

        else if (!instructAnimator.GetBool("ShowQuestions"))
        {
            instructAnimator.SetBool("ShowQuestions", true);
        }
    }
}
