using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class retryPuzzle : MonoBehaviour
{
    public GameObject winText;
    public GameObject currentPuzle;
    public WinScript winScript;
    public questionManager manager;

    // Update is called once per frame
    private void OnMouseDown()
    {
        if (!winText.activeSelf)
        {
            manager.Reset();
            winScript.currentPoints = 0;

            //Desactivar pregunta
            Transform questions = currentPuzle.transform.Find("Questions").transform;

            for (int i = 0; i < questions.childCount; i++)
            {
                if (questions.GetChild(i).gameObject.activeSelf)
                    questions.GetChild(i).gameObject.SetActive(false);
            }
            questions.Find("Mercury").gameObject.SetActive(true);

            Transform shadowObjects = currentPuzle.transform.Find("ShadowObjects").transform;

            for (int i = 0; i < shadowObjects.childCount; i++)
            {
                if (shadowObjects.GetChild(i).name != "Background" && shadowObjects.GetChild(i).gameObject.activeSelf)
                    shadowObjects.GetChild(i).gameObject.SetActive(false);
            }
            shadowObjects.Find("Mercury").gameObject.SetActive(true);
        }
    }
}
