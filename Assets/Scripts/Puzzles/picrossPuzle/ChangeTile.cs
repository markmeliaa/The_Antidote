using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTile : MonoBehaviour
{
    [SerializeField] Sprite Blanco;
    [SerializeField] Sprite X;
    [SerializeField] Sprite Negro;
    private bool blanco = true, x, negro;
    private SpriteRenderer sprite;
    public bool marcada = false;
    private bool averiguada = false;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void OnMouseDown()
    {
        if (blanco)
        {
            blanco = false;
            sprite.sprite = X;
            x = true;
        }


        else if (x)
        {
            x = false;
            sprite.sprite = Negro;
            negro = true;
            averiguada = true;
        }

        else if (negro)
        {
            negro = false;
            sprite.sprite = Blanco;
            blanco = true;
            averiguada = false;
        }
    }
}
