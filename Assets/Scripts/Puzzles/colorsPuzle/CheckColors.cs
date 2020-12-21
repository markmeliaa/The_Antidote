using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckColors : MonoBehaviour
{
    public GameObject fichas;
    private Queue<GameObject> fichasQueue = new Queue<GameObject>();

    public TextMesh winText;
    public desactivatePuzzle desactivation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (DifferentColors())
        {
            winText.gameObject.SetActive(true);
            fichas.SetActive(false);
            desactivation.desactivate(true);
        }
    }

    public bool DifferentColors()
    {
        for (int i = 0; i < fichas.transform.childCount; i++)
        {
            fichasQueue.Enqueue(fichas.transform.GetChild(i).gameObject);
        }

        GameObject fichaActual = fichasQueue.Dequeue();

        while (fichasQueue.Count != 0)
        {
            Color colorActual = fichaActual.GetComponent<SpriteRenderer>().color;
            SpriteRenderer[] vecinosActuales = fichaActual.GetComponent<ChangeColor>().vecinos;

            foreach (SpriteRenderer vecino in vecinosActuales)
            {
                if (vecino.color == colorActual || vecino.color == Color.white || colorActual == Color.white)
                {
                    return false;
                }
            }

            fichaActual = fichasQueue.Dequeue();
        }

        return true;
    }
}
