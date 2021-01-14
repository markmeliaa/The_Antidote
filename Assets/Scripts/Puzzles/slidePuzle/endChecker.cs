using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endChecker : MonoBehaviour
{
    public Transform objects;
    public GameObject winText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Detectado");
        if (collision.gameObject.tag == "Player")
        {
            EndPuzle();
        }
    }

    public void EndPuzle()
    {
        for (int i = 0; i < objects.childCount; i++)
        {
            objects.GetChild(i).gameObject.GetComponent<ObjectMovement>().activated = false;
        }

        winText.SetActive(true);
        //puzzleEnding.desactivate(false);
    }
}
