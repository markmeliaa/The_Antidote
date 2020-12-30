using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowLetters4 : MonoBehaviour
{
    public GameObject letters;
    public GameObject hangman;
    public GameObject e;
    public GameObject n;
    public GameObject d;
    public GameObject e2;
    public GameObject s;
    public GameObject a;
    private int errores = 0;
    private int aciertos = 0;
    private int aciertosMax;
    public GameObject winText;
    public GameObject loseText;

    // Start is called before the first frame update
    void Start()
    {
        aciertosMax = letters.gameObject.transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        if (aciertos >= aciertosMax)
        {
            winText.SetActive(true);
        }

        else if (errores >= 6)
        {
            loseText.SetActive(true);
        }

        else
        {
            if (Input.GetKeyDown(KeyCode.E) && !e.activeSelf)
            {
                e.SetActive(true);
                e2.SetActive(true);
                aciertos += 2;
            }

            if (Input.GetKeyDown(KeyCode.N) && !n.activeSelf)
            {
                n.SetActive(true);
                aciertos++;
            }

            if (Input.GetKeyDown(KeyCode.D) && !d.activeSelf)
            {
                d.SetActive(true);
                aciertos++;
            }

            if (Input.GetKeyDown(KeyCode.S) && !s.activeSelf)
            {
                s.SetActive(true);
                aciertos++;
            }

            if (Input.GetKeyDown(KeyCode.A) && !a.activeSelf)
            {
                a.SetActive(true);
                aciertos++;
            }

            if (!Input.GetKeyDown(KeyCode.E) && !Input.GetKeyDown(KeyCode.N) && !Input.GetKeyDown(KeyCode.D) &&
                !Input.GetKeyDown(KeyCode.S) && !Input.GetKeyDown(KeyCode.A) &&
                !Input.GetMouseButtonDown(0) && !Input.GetMouseButtonDown(1) && !Input.GetMouseButtonDown(2) && Input.anyKeyDown)
            {
                errores++;
                hangman.transform.GetChild(errores).gameObject.SetActive(true);
            }
        }
    }

    public void resetValues()
    {
        aciertos = 0;
        errores = 0;
        e.SetActive(false);
        n.SetActive(false);
        d.SetActive(false);
        e2.SetActive(false);
        s.SetActive(false);
        a.SetActive(false);

        for (int i = 0; i < hangman.transform.childCount; i++)
        {
            if (hangman.transform.GetChild(i).name != "Hangman_0" && hangman.transform.GetChild(i).gameObject.activeSelf)
            {
                hangman.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
}
