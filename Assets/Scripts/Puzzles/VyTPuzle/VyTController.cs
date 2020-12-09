#pragma warning disable CS0649

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VyTController : MonoBehaviour
{
    public GameObject intento;
    [SerializeField] GameObject resultado;
    [SerializeField] GameObject taparResultado;
    [SerializeField] TextMesh vYt;
    private int vacas = 0;
    private int toros = 0;
    private GameObject[] coloresResultado = new GameObject[4];
    private Color[] coloresDisponibles = { Color.red, Color.yellow, Color.blue, Color.green };

    private void Awake()
    {
        for (int i = 0; i < resultado.transform.childCount; i++)
        {
            resultado.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().color = coloresDisponibles[Random.Range(0, coloresDisponibles.Length)];
            coloresResultado[i] = resultado.transform.GetChild(i).gameObject;
        }
    }

    public bool checkTry()
    {
        vacas = 0;
        toros = 0;
        for (int i = 0; i < intento.transform.childCount; i++)
        {
            for (int j = 0; j < coloresResultado.Length; j++)
            {
                if (coloresResultado[i].GetComponent<SpriteRenderer>().color == intento.transform.GetChild(j).gameObject.GetComponent<SpriteRenderer>().color)
                {
                    vacas++;
                    break;
                }
            }
            
            if (intento.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().color == coloresResultado[i].GetComponent<SpriteRenderer>().color)
            {
                vacas--;
                toros++;
            }
        }

        vYt.text = "VACAS: " + vacas + "\nTOROS: " + toros;

        if (toros == 4)
        {
            taparResultado.SetActive(false);
            return true;
        }

        return false;
    }
}
