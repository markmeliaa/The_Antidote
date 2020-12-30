using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountPoints : MonoBehaviour
{
    public desactivatePuzzle endPuzle;
    [SerializeField] GameObject casillasBlancas;
    [SerializeField] GameObject casillasNegras;
    private int totalPoints = 0;
    private int blancoPoints = 0;
    [SerializeField] GameObject winText;

    private void Start()
    {
        blancoPoints = casillasBlancas.transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        if (totalPoints == casillasNegras.transform.childCount && blancoPoints == casillasBlancas.transform.childCount - casillasNegras.transform.childCount)
        {
            for (int i = 0; i < casillasBlancas.transform.childCount; i++)
            {
                casillasBlancas.transform.GetChild(i).GetComponent<BoxCollider2D>().enabled = false;
            }
            winText.SetActive(true);
            endPuzle.desactivate(false);
            return;
        }

        for (int i = 0; i < casillasBlancas.transform.childCount; i++)
        {
            if (casillasBlancas.transform.GetChild(i).GetComponent<ChangeTile>().marcada && casillasBlancas.transform.GetChild(i).GetComponent<ChangeTile>().averiguada && !casillasBlancas.transform.GetChild(i).GetComponent<ChangeTile>().destapada)
            {
                totalPoints++;
                blancoPoints--;
                casillasBlancas.transform.GetChild(i).GetComponent<ChangeTile>().destapada = true;
            }

            else if (casillasBlancas.transform.GetChild(i).GetComponent<ChangeTile>().marcada && !casillasBlancas.transform.GetChild(i).GetComponent<ChangeTile>().averiguada && casillasBlancas.transform.GetChild(i).GetComponent<ChangeTile>().destapada)
            {
                totalPoints--;
                blancoPoints++;
                casillasBlancas.transform.GetChild(i).GetComponent<ChangeTile>().destapada = false;
            }

            else if (!casillasBlancas.transform.GetChild(i).GetComponent<ChangeTile>().marcada && casillasBlancas.transform.GetChild(i).GetComponent<ChangeTile>().averiguada && !casillasBlancas.transform.GetChild(i).GetComponent<ChangeTile>().destapada)
            {
                blancoPoints--;
                casillasBlancas.transform.GetChild(i).GetComponent<ChangeTile>().destapada = true;
            }

            else if (!casillasBlancas.transform.GetChild(i).GetComponent<ChangeTile>().marcada && !casillasBlancas.transform.GetChild(i).GetComponent<ChangeTile>().averiguada && casillasBlancas.transform.GetChild(i).GetComponent<ChangeTile>().destapada)
            {
                blancoPoints++;
                casillasBlancas.transform.GetChild(i).GetComponent<ChangeTile>().destapada = false;
            }
        }
    }

    public void resetGame()
    {
        for (int i = 0; i < casillasBlancas.transform.childCount; i++)
        {
            casillasBlancas.transform.GetChild(i).GetComponent<ChangeTile>().resetCasilla();
        }
    }
}
