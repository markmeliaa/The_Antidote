using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowLetters2 : MonoBehaviour
{
    public GameObject letters;
    public GameObject hangman;
    public GameObject c;
    public GameObject r;
    public GameObject u;
    public GameObject z;
    public GameObject r2;
    public GameObject o;
    public GameObject j;
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
            if (Input.GetKeyDown(KeyCode.C) && !c.activeSelf)
            {
                c.SetActive(true);
                aciertos ++;
            }

            if (Input.GetKeyDown(KeyCode.R) && !r.activeSelf)
            {
                r.SetActive(true);
                r2.SetActive(true);
                aciertos += 2;
            }

            if (Input.GetKeyDown(KeyCode.U) && !u.activeSelf)
            {
                u.SetActive(true);
                aciertos++;
            }

            if (Input.GetKeyDown(KeyCode.Z) && !z.activeSelf)
            {
                z.SetActive(true);
                aciertos++;
            }

            if (Input.GetKeyDown(KeyCode.O) && !o.activeSelf)
            {
                o.SetActive(true);
                aciertos++;
            }

            if (Input.GetKeyDown(KeyCode.J) && !j.activeSelf)
            {
                j.SetActive(true);
                aciertos++;
            }

            if (Input.GetKeyDown(KeyCode.A) && !a.activeSelf)
            {
                a.SetActive(true);
                aciertos++;
            }

            if (!Input.GetKeyDown(KeyCode.C) && !Input.GetKeyDown(KeyCode.R) && !Input.GetKeyDown(KeyCode.U) &&
                !Input.GetKeyDown(KeyCode.Z) && !Input.GetKeyDown(KeyCode.O) && !Input.GetKeyDown(KeyCode.J) && !Input.GetKeyDown(KeyCode.A) &&
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
        c.SetActive(false);
        r.SetActive(false);
        u.SetActive(false);
        z.SetActive(false);
        r2.SetActive(false);
        o.SetActive(false);
        j.SetActive(false);
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
