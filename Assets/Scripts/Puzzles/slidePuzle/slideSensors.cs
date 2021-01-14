using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slideSensors : MonoBehaviour
{
    public GameObject sensorRight, sensorUp, sensorLeft, sensorDown;
    public float radioSensor = 0.1f;
    //[HideInInspector]
    public bool ocupadoRight, ocupadoUp, ocupadoLeft, ocupadoDown;

    private Transform parentCar;

    private void Start()
    {
        parentCar = GetComponentInParent<Transform>().gameObject.GetComponentInParent<Transform>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Comprobar();
    }

    void Comprobar()
    {
        if(parentCar.position.x < 5.2)
            ocupadoRight = Physics2D.OverlapCircle(sensorRight.transform.position, radioSensor);
        ocupadoUp = Physics2D.OverlapCircle(sensorUp.transform.position, radioSensor);
        ocupadoLeft = Physics2D.OverlapCircle(sensorLeft.transform.position, radioSensor);
        ocupadoDown = Physics2D.OverlapCircle(sensorDown.transform.position, radioSensor);
    }
}
