#pragma warning disable 0649

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public float speed;

    [SerializeField] private GameObject background;
    [SerializeField] private GameObject dialogueCanvas;
    [SerializeField] private GameObject startConvoButton;
    private Animator mapAnimator;

    private void Start()
    {
        mapAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.M) && mapAnimator.GetBool("isShowing") == false)
        {
            mapAnimator.SetBool("isShowing", true);
            background.SetActive(false);
            startConvoButton.SetActive(false);
            dialogueCanvas.SetActive(false);
        }

        if (Input.GetKey(KeyCode.N) && mapAnimator.GetBool("isShowing") == true)
        {
            mapAnimator.SetBool("isShowing", false);
            background.SetActive(true);
            startConvoButton.SetActive(true);
            dialogueCanvas.SetActive(true);
        }
    }
}
