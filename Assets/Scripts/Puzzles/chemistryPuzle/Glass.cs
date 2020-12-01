using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Glass : MonoBehaviour
{
    public static event Action glassColorIsSet = delegate { };

    private Renderer rend;
    private Color colorToApply;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    private void OnMouseDown()
    {
        colorToApply = GameControl.fingerColor;
        rend.material.color = colorToApply;

        switch (name)
        {
            case "Red":
                if (colorToApply == GameControl.properColors[0])
                    GameControl.redIsRed = true;
                else
                    GameControl.redIsRed = false;
                break;
            case "Orange":
                if (colorToApply == GameControl.properColors[1])
                    GameControl.orangeIsOrange = true;
                else
                    GameControl.orangeIsOrange = false;
                break;
            case "Yellow":
                if (colorToApply == GameControl.properColors[2])
                    GameControl.yellowIsYellow = true;
                else
                    GameControl.yellowIsYellow = false;
                break;
            case "Green":
                if (colorToApply == GameControl.properColors[3])
                    GameControl.greenIsGreen = true;
                else
                    GameControl.greenIsGreen = false;
                break;
            case "Blue":
                if (colorToApply == GameControl.properColors[4])
                    GameControl.blueIsBlue = true;
                else
                    GameControl.blueIsBlue = false;
                break;
            case "Purple":
                if (colorToApply == GameControl.properColors[5])
                    GameControl.purpleIsPurple = true;
                else
                    GameControl.purpleIsPurple = false;
                break;
        }
        glassColorIsSet();
    }
}
