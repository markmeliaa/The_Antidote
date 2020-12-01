using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PaletteColor : MonoBehaviour
{
    public static event Action<Color, Vector3> colorPicked = delegate { };
    private Color color;
    private Vector3 colorPosition;


    // Start is called before the first frame update
    void Start()
    {
        color = GetComponent<SpriteRenderer>().color;
        colorPosition = transform.position;

        switch (name)
        {
            case "Red":
                GameControl.properColors[0] = color;
                break;
            case "Orange":
                GameControl.properColors[1] = color;
                break;
            case "Yellow":
                GameControl.properColors[2] = color;
                break;
            case "Green":
                GameControl.properColors[3] = color;
                break;
            case "Blue":
                GameControl.properColors[4] = color;
                break;
            case "Purple":
                GameControl.properColors[5] = color;
                break;
        }
    }

    private void OnMouseDown()
    {
        colorPicked(color, colorPosition);
    }
}
