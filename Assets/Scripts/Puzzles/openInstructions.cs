using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openInstructions : MonoBehaviour
{
    private Animator instructAnimator;
    [SerializeField] GameObject text;

    // Start is called before the first frame update
    void Start()
    {
        instructAnimator = GetComponent<Animator>();
    }

    private void OnMouseDown()
    {
        if (instructAnimator.GetBool("Show"))
        {
            instructAnimator.SetBool("Show", false);
            text.SetActive(false);
        }

        else if (!instructAnimator.GetBool("Show"))
        {
            instructAnimator.SetBool("Show", true);
            StartCoroutine("showText");
        }
    }

    IEnumerator showText()
    {
        yield return new WaitForSeconds(0.45f);
        text.SetActive(true);
    }
}
