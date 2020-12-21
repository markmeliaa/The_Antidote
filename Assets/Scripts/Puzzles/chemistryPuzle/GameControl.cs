#pragma warning disable CS0649

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    [SerializeField]
    private GameObject selection, victory;

    public static Color fingerColor;
    public static Color[] properColors;
    public desactivatePuzzle endPuzle;

    public static bool redIsRed, orangeIsOrange, yellowIsYellow, greenIsGreen, blueIsBlue, purpleIsPurple;
    public static bool resetSelection = false;

    private void Awake()
    {
        properColors = new Color[6];
    }

    // Start is called before the first frame update
    void Start()
    {
        PaletteColor.colorPicked += SetFingerColor;
        Glass.glassColorIsSet += CheckResults;

        //victory.SetActive(false);

        fingerColor = new Color(1f, 1f, 1f, 1f);
    }

    private void SetFingerColor(Color colorpicked, Vector3 colorPosition)
    {
        fingerColor = colorpicked;
        selection.transform.position = new Vector3(colorPosition.x, colorPosition.y, colorPosition.z);
        if (resetSelection)
        {
            selection.transform.position = new Vector3(-2, 7, 0);
            resetSelection = false;
        }
    }

    private void CheckResults()
    {
        if (redIsRed && orangeIsOrange && yellowIsYellow && greenIsGreen && blueIsBlue && purpleIsPurple)
        {
            //Seting the colors to false
            redIsRed = false;
            orangeIsOrange = false;
            yellowIsYellow = false;
            greenIsGreen = false;
            blueIsBlue = false;
            purpleIsPurple = false;

            victory.SetActive(true);
            endPuzle.desactivate(false);
        }
    }

    private void OnDestroy()
    {
        // Unsubscribe events that have been subscribed at the end of the program
        PaletteColor.colorPicked -= SetFingerColor;
        Glass.glassColorIsSet -= CheckResults;
    }
}
