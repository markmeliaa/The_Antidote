using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowLetters : MonoBehaviour
{
    public GameObject letters;
    public GameObject hangman;
    public GameObject c;
    public GameObject e1;
    public GameObject r;
    public GameObject e2;
    public GameObject a;
    public GameObject l;
    public GameObject e3;
    public GameObject s;
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
            if (Input.GetKeyDown(KeyCode.C) && !c.activeSelf)
            {
                c.SetActive(true);
                aciertos++;
            }

            if (Input.GetKeyDown(KeyCode.E) && !e1.activeSelf)
            {
                e1.SetActive(true);
                e2.SetActive(true);
                e3.SetActive(true);
                aciertos += 3;
            }

            if (Input.GetKeyDown(KeyCode.R) && !r.activeSelf)
            {
                r.SetActive(true);
                aciertos++;
            }

            if (Input.GetKeyDown(KeyCode.A) && !a.activeSelf)
            {
                a.SetActive(true);
                aciertos++;
            }

            if (Input.GetKeyDown(KeyCode.L) && !l.activeSelf)
            {
                l.SetActive(true);
                aciertos++;
            }

            if (Input.GetKeyDown(KeyCode.S) && !s.activeSelf)
            {
                s.SetActive(true);
                aciertos++;
            }

            if (!Input.GetKeyDown(KeyCode.C) && !Input.GetKeyDown(KeyCode.E) && !Input.GetKeyDown(KeyCode.R) && 
                !Input.GetKeyDown(KeyCode.A) && !Input.GetKeyDown(KeyCode.L) && !Input.GetKeyDown(KeyCode.S) && Input.anyKeyDown == true)
            {
                errores++;
                hangman.transform.GetChild(errores).gameObject.SetActive(true);
            }
        }
    }
}
