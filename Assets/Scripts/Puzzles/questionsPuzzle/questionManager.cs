using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class questionManager : MonoBehaviour
{
    public GameObject mercuryGameobject;
    public TextMesh mercuryText;
    public GameObject mercuryShadow;
    private bool venus = false;
    public GameObject venusGameobject;
    public TextMesh venusText;
    public GameObject venusShadow;
    private bool theEarth = false;
    public GameObject theEarthGameobject;
    public TextMesh theEarthText;
    public GameObject theEarthShadow;
    private bool saturn = false;
    public GameObject saturnGameobject;
    public TextMesh saturnText;
    public GameObject saturnShadow;
    private bool neptune = false;
    public GameObject neptuneGameobject;
    public TextMesh neptuneText;
    public GameObject neptuneShadow;

    public TextMesh bienHechoText;

    public void changeQuestion(GameObject current)
    {
        if (current == mercuryGameobject)
        {
            venus = true;
        }

        else if (current == venusGameobject)
        {
            venus = false;
            theEarth = true;
        }

        else if (current == theEarthGameobject)
        {
            theEarth = false;
            saturn = true;
        }

        else if (current == saturnGameobject)
        {
            saturn = false;
            neptune = true;
        }

        else
        {
            neptune = false;
        }

        
    }

    public void newQuestion()
    {
        StartCoroutine("showQuestion");
    }

    IEnumerator showQuestion()
    {
        if (venus)
        {
            mercuryText.gameObject.SetActive(false);
            mercuryShadow.SetActive(false);

            bienHechoText.gameObject.SetActive(true);
            yield return new WaitForSeconds(1);
            bienHechoText.gameObject.SetActive(false);

            venusText.gameObject.SetActive(true);
            venusShadow.SetActive(true);
        }

        else if (theEarth)
        {
            venusText.gameObject.SetActive(false);
            venusShadow.SetActive(false);

            bienHechoText.gameObject.SetActive(true);
            yield return new WaitForSeconds(1);
            bienHechoText.gameObject.SetActive(false);

            theEarthText.gameObject.SetActive(true);
            theEarthShadow.SetActive(true);
        }

        else if (saturn)
        {
            theEarthText.gameObject.SetActive(false);
            theEarthShadow.SetActive(false);

            bienHechoText.gameObject.SetActive(true);
            yield return new WaitForSeconds(1);
            bienHechoText.gameObject.SetActive(false);

            saturnText.gameObject.SetActive(true);
            saturnShadow.SetActive(true);
        }

        else if (neptune)
        {
            saturnText.gameObject.SetActive(false);
            saturnShadow.SetActive(false);

            bienHechoText.gameObject.SetActive(true);
            yield return new WaitForSeconds(1);
            bienHechoText.gameObject.SetActive(false);

            neptuneText.gameObject.SetActive(true);
            neptuneShadow.SetActive(true);
        }

        else
        {
            neptuneText.gameObject.SetActive(false);
            neptuneShadow.SetActive(false);
        }

        GameObject.Find("PuzzleHandler").GetComponent<WinScript>().AddPoints();
        yield return null;
    }

    public void Reset()
    {
        venus = false;
        neptune = false;
        saturn = false;
        theEarth = false;
    }
}
