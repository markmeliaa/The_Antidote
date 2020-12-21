using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class desactivatePuzzle : MonoBehaviour
{
    [SerializeField] GameObject currentPuzzle;
    [SerializeField] GameObject background;
    public GameObject mapLoc;
    public GameObject puzzleLocation;
    public GameObject inventory;
    public Animator rectangleL;
    public Animator rectangleR;
    public Animator text;
    private AudioSource mainGameAudio;

    bool timesSet = false;
    private void Start()
    {
        mainGameAudio = GameObject.Find("MainCamera").GetComponent<AudioSource>();
    }

    private void OnMouseDown()
    {
        desactivate(false);
    }

    public void desactivate(bool compulsoryPuzzle)
    {
        if (compulsoryPuzzle && !timesSet)
        {
            mapLoc.GetComponent<sceneManager>().setLocationTimes(puzzleLocation.name);
            puzzleLocation.GetComponent<Tester>().sceneWithInteraction = false;
            Debug.Log("Times en " + puzzleLocation.name + ": " + mapLoc.GetComponent<sceneManager>().getLocationTimes(puzzleLocation.name));
            timesSet = true;
        }
        StartCoroutine("desactivatethis");
    }

    IEnumerator desactivatethis()
    {
        rectangleL.SetBool("startPuzzle", true);
        rectangleR.SetBool("startPuzzle", true);
        text.SetBool("endGame", true);
        yield return new WaitForSeconds(2);
        yield return new WaitForSeconds(1);
        currentPuzzle.SetActive(false);
        background.SetActive(true);
        inventory.SetActive(true);
        mapLoc.GetComponent<sceneManager>().changePuzleState();
        text.SetBool("endGame", false);
        rectangleL.SetBool("startPuzzle", false);
        rectangleR.SetBool("startPuzzle", false);
        mainGameAudio.mute = false;
    }
}
