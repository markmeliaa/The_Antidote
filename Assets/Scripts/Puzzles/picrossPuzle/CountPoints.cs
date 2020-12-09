using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountPoints : MonoBehaviour
{
    [SerializeField] GameObject casillasBlancas;
    [SerializeField] GameObject casillasNegras;
    private int totalPoints = 0;
    [SerializeField] GameObject winText;

    // Update is called once per frame
    void Update()
    {

        if (totalPoints >= casillasNegras.transform.childCount)
        {
            for (int i = 0; i < casillasBlancas.transform.childCount; i++)
            {
                casillasBlancas.transform.GetChild(i).GetComponent<BoxCollider2D>().enabled = false;
            }
            winText.SetActive(true);
            return;
        }

        for (int i = 0; i < casillasBlancas.transform.childCount; i++)
        {
            if (casillasBlancas.transform.GetChild(i).GetComponent<ChangeTile>().marcada && casillasBlancas.transform.GetChild(i).GetComponent<ChangeTile>().averiguada && !casillasBlancas.transform.GetChild(i).GetComponent<ChangeTile>().destapada)
            {
                totalPoints++;
                casillasBlancas.transform.GetChild(i).GetComponent<ChangeTile>().destapada = true;
            }

            else if (casillasBlancas.transform.GetChild(i).GetComponent<ChangeTile>().marcada && !casillasBlancas.transform.GetChild(i).GetComponent<ChangeTile>().averiguada && casillasBlancas.transform.GetChild(i).GetComponent<ChangeTile>().destapada)
            {
                totalPoints--;
                casillasBlancas.transform.GetChild(i).GetComponent<ChangeTile>().destapada = false;
            }
        }
    }
}
