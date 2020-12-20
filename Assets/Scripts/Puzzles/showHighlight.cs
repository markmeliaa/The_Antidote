using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showHighlight : MonoBehaviour
{
    private SpriteRenderer highlight;
    private DialogueManager manager;

    private void Start()
    {
        highlight = GetComponent<SpriteRenderer>();
        manager = GameObject.Find("DialogueBox1").GetComponent<DialogueManager>();
        highlight.sortingOrder = -10;
    }

    private void OnBecameVisible()
    {
        highlight.sortingOrder = -10;
    }

    private void OnMouseEnter()
    {
        if (!manager.InConvo)
            highlight.sortingOrder = 10;
    }

    private void OnMouseExit()
    {
        highlight.sortingOrder = -10;
    }
}
