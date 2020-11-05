#pragma warning disable 0649

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.IO;

public class Puzzle : MonoBehaviour
{
    public Sprite fichaEscondidaImg;
    public List<Sprite> fichaImg = new List<Sprite>();
    public GameObject fichaPrefab;
    public GameObject bordePrefab;
    public GameObject textoGanador;
    public GameObject puzleBackground;
    public GameObject puzle;

    GameObject fichaEscondida;
    int numCostado;
    GameObject padreFichas;
    GameObject padreBordes;
    List<Vector3> posicionesIniciales = new List<Vector3>();
    GameObject[] fichas;

    void Awake()
    {
        padreFichas = GameObject.Find("Fichas");
        padreBordes = GameObject.Find("Bordes");
    }

    public void CrearPuzle()
    {
        if (Mathf.Sqrt(fichaImg.Count) == Mathf.Round(Mathf.Sqrt(fichaImg.Count)))
        {
            puzleBackground.gameObject.SetActive(true);
            CrearFichas();
        }
        else
        {
            print("Imposible Crear Puzle");
        }
    }

    private void OnMouseDown()
    {
        CrearPuzle();
        puzleBackground.SetActive(false);
    }

    void CrearFichas()
    {
        int contador = 0;
        numCostado = (int)Mathf.Sqrt(fichaImg.Count);

        for (int alto = numCostado + 2; alto > 0; alto--)
        {
            for (int ancho = 0; ancho < numCostado + 2; ancho++)
            {
                Vector3 posicion = new Vector3(ancho - (numCostado / 1.5f), alto - (numCostado / 1.5f), 0);

                if (alto == 1 || alto == numCostado + 2 || ancho == 0 || ancho == numCostado + 1)
                {
                    GameObject borde = Instantiate(bordePrefab, posicion, Quaternion.identity);
                    borde.transform.parent = padreBordes.transform;
                }
                else
                {
                    GameObject ficha = Instantiate(fichaPrefab, posicion, Quaternion.identity);
                    ficha.GetComponent<SpriteRenderer>().sprite = fichaImg[contador];
                    ficha.transform.parent = padreFichas.transform;
                    ficha.name = fichaImg[contador].name;
                    if (ficha.name == fichaEscondidaImg.name)
                        fichaEscondida = ficha;

                    contador++;
                }

            }
        }

        fichaEscondida.SetActive(false);
        fichas = GameObject.FindGameObjectsWithTag("Ficha");
        for (int i = 0; i < fichas.Length; i++)
        {
            posicionesIniciales.Add(fichas[i].transform.position);
        }

        Barajar();
    }

    void Barajar()
    {
        int aleatorio;
        for (int i = 0; i < fichas.Length; i++)
        {
            aleatorio = Random.Range(i, fichas.Length);

            Vector3 posTemp = fichas[i].transform.position;
            fichas[i].transform.position = fichas[aleatorio].transform.position;
            fichas[aleatorio].transform.position = posTemp;
        }
    }

    public void ComprobarGanador()
    {
        for (int i = 0; i < fichas.Length; i++)
        {
            if (posicionesIniciales[i] != fichas[i].transform.position)
            {
                return;
            }
        }

        fichaEscondida.gameObject.SetActive(true);
        print("Puzle Resuelto");
        textoGanador.gameObject.SetActive(true);

        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3);

        puzleBackground.SetActive(true);
        puzle.SetActive(false);
    }
}
