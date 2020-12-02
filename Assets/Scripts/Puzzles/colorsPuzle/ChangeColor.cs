using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public SpriteRenderer sprite;
    private bool red, green, blue, yellow;

    public bool visitado = false;
    public SpriteRenderer[] vecinos;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void OnMouseDown()
    {
        if (yellow)
        {
            yellow = false;
            sprite.color = Color.red;
            red = true;
        }


        else if (red)
        {
            red = false;
            sprite.color = Color.green;
            green = true;
        }

        else if (green)
        {
            green = false;
            sprite.color = Color.blue;
            blue = true;
        }

        else if (blue)
        {
            blue = false;
            sprite.color = Color.yellow;
            yellow = true;
        }

        else
        {
            sprite.color = Color.red;
            red = true;
        }
    }
}
