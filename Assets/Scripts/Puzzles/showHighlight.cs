using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showHighlight : MonoBehaviour
{
    public GameObject sourceSprite;

    private SpriteRenderer highlight;
    private DialogueManager manager;

    private void Awake()
    {
        highlight = GetComponent<SpriteRenderer>();
        manager = GameObject.Find("DialogueBox1").GetComponent<DialogueManager>();
        highlight.sortingOrder = -10;
    }

    private void Update()
    {
        //Desaparece cuando desaparece el interactuable en los puzles de objetos
        if (sourceSprite != null && !sourceSprite.activeSelf)
        {
            gameObject.SetActive(false);
            CursorManager.Instance.SetActiveCursorType(CursorManager.CursorType.Arrow);
        }

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
