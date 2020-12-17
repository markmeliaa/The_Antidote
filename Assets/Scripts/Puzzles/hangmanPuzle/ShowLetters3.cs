using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowLetters3 : MonoBehaviour
{
    public GameObject letters;
    public GameObject hangman;
    public GameObject g;
    public GameObject o;
    public GameObject t;
    public GameObject e;
    public GameObject r;
    public GameObject o2;
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
            if (Input.GetKeyDown(KeyCode.G) && !g.activeSelf)
            {
                g.SetActive(true);
                aciertos++;
            }

            if (Input.GetKeyDown(KeyCode.O) && !o.activeSelf)
            {
                o.SetActive(true);
                o2.SetActive(true);
                aciertos += 2;
            }

            if (Input.GetKeyDown(KeyCode.T) && !t.activeSelf)
            {
                t.SetActive(true);
                aciertos++;
            }

            if (Input.GetKeyDown(KeyCode.E) && !e.activeSelf)
            {
                e.SetActive(true);
                aciertos++;
            }

            if (Input.GetKeyDown(KeyCode.R) && !r.activeSelf)
            {
                r.SetActive(true);
                aciertos++;
            }

            if (!Input.GetKeyDown(KeyCode.G) && !Input.GetKeyDown(KeyCode.O) && !Input.GetKeyDown(KeyCode.T) &&
                !Input.GetKeyDown(KeyCode.E) && !Input.GetKeyDown(KeyCode.R) &&
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
        g.SetActive(false);
        o.SetActive(false);
        t.SetActive(false);
        e.SetActive(false);
        r.SetActive(false);
        o2.SetActive(false);

        for (int i = 0; i < hangman.transform.childCount; i++)
        {
            if (hangman.transform.GetChild(i).name != "Hangman_0" && hangman.transform.GetChild(i).gameObject.activeSelf)
            {
                hangman.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
}
