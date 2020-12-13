using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensors : MonoBehaviour
{
    public GameObject winText;
    public desactivatePuzzle puzzleEnding;
    public GameObject sensorRight, sensorUp, sensorLeft, sensorDown;
    public float radioSensor = 0.1f;

    //[HideInInspector] 
    public bool blockedRight, blockedUp, blockedLeft, blockedDown;

    // Update is called once per frame
    void FixedUpdate()
    {
        Comprobar();
    }

    void Comprobar()
    {
        if(Physics2D.OverlapCircle(sensorRight.transform.position, radioSensor) != null 
            && Physics2D.OverlapCircle(sensorRight.transform.position, radioSensor).tag == "Exit")
        {
            winText.SetActive(true);
            puzzleEnding.desactivate();
            return;
        }
        blockedRight = Physics2D.OverlapCircle(sensorRight.transform.position, radioSensor);
        blockedUp = Physics2D.OverlapCircle(sensorUp.transform.position, radioSensor);
        blockedLeft = Physics2D.OverlapCircle(sensorLeft.transform.position, radioSensor);
        blockedDown = Physics2D.OverlapCircle(sensorDown.transform.position, radioSensor);
    }
}
