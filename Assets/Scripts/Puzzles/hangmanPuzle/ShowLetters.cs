using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowLetters : MonoBehaviour
{
    public GameObject letters;
    public GameObject hangman;
    public GameObject w;
    public GameObject i;
    public GameObject n;
    public GameObject d;
    public GameObject o;
    public GameObject w2;
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
            if (Input.GetKeyDown(KeyCode.W) && !w.activeSelf)
            {
                w.SetActive(true);
                w2.SetActive(true);
                aciertos += 2;
            }

            if (Input.GetKeyDown(KeyCode.I) && !i.activeSelf)
            {
                i.SetActive(true);
                aciertos++;
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

            if (Input.GetKeyDown(KeyCode.O) && !o.activeSelf)
            {
                o.SetActive(true);
                aciertos++;
            }

            if (Input.GetKeyDown(KeyCode.S) && !s.activeSelf)
            {
                s.SetActive(true);
                aciertos++;
            }

            if (!Input.GetKeyDown(KeyCode.W) && !Input.GetKeyDown(KeyCode.I) && !Input.GetKeyDown(KeyCode.N) && 
                !Input.GetKeyDown(KeyCode.D) && !Input.GetKeyDown(KeyCode.O) && !Input.GetKeyDown(KeyCode.S) && 
                !Input.GetMouseButtonDown(0) && !Input.GetMouseButtonDown(1) && !Input.GetMouseButtonDown(2) && Input.anyKeyDown)
            {
                errores++;
                hangman.transform.GetChild(errores).gameObject.SetActive(true);
            }
        }
    }
}
