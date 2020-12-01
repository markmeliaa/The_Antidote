using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    [SerializeField]
    private GameObject selection, victory;

    public static Color fingerColor;
    public static Color[] properColors;

    public static bool redIsRed, orangeIsOrange, yellowIsYellow, greenIsGreen, blueIsBlue, purpleIsPurple;

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
    }

    private void CheckResults()
    {
        if (redIsRed && orangeIsOrange && yellowIsYellow && greenIsGreen && blueIsBlue && purpleIsPurple)
        {
            victory.SetActive(true);
        }
    }

    private void OnDestroy()
    {
        // Unsubscribe events that have been subscribed at the end of the program
        PaletteColor.colorPicked -= SetFingerColor;
        Glass.glassColorIsSet -= CheckResults;
    }
}
