using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzleController : MonoBehaviour
{
    public GameObject winText;
    public desactivatePuzzle desactivate;

    Transform balls;
    bool[] colocadas;
    Vector3[] posIni;

    private void Start()
    {
        balls = GameObject.Find("Balls").transform;
        colocadas = new bool[balls.childCount];
        posIni = new Vector3[balls.childCount];

        for (int i = 0; i < balls.childCount; i++)
        {
            posIni[i] = balls.GetChild(i).position;
        }
    }

    void Update()
    {
        for(int i = 0; i < balls.childCount; i++)
        {
            GameObject curBall = balls.GetChild(i).gameObject;
            if (i < balls.childCount / 2 && curBall.transform.position.x > (curBall.GetComponent<ballsMovement>().objetivo.x - 0.5)
                && curBall.transform.position.x < (curBall.GetComponent<ballsMovement>().objetivo.x + 0.5)
                && curBall.transform.position.y > (curBall.GetComponent<ballsMovement>().objetivo.y - 0.5)
                && curBall.transform.position.y < (curBall.GetComponent<ballsMovement>().objetivo.y + 0.5))
            {
                colocadas[i] = true;
            }
            else if (colocadas[i])
                colocadas[i] = false;
        }

        int contador = 0;
        for(int i = 0; i < colocadas.Length; i++)
        {
            if (colocadas[i])
                contador++;
        }

        if (contador == 8)
            endPuzle();
    }

    private void endPuzle()
    {
        Debug.Log("Ending Puzle");
        winText.SetActive(true);

        for (int i = 0; i < balls.childCount; i++)
            balls.GetChild(i).GetComponent<ballsMovement>().active = false;

        desactivate.desactivate(false);
    }

    public void retryPuzle()
    {
        for (int i = 0; i < balls.childCount; i++)
        {
            balls.GetChild(i).position = posIni[i];
            colocadas[i] = false;
        }
    }
}
