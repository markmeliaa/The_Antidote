using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensors : MonoBehaviour
{
    public int type;
    public ObjectMovement car;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Exit")
        {
            car.EndPuzle();
            return;
        }

        if (collision.gameObject.tag == "Wall")
            car.wallCrash();

        switch (type)
        {
            case 0:
                car.blockedRight = true; break;
            case 1:
                car.blockedLeft = true; break;
            case 2:
                car.blockedUp = true; break;
            case 3:
                car.blockedDown = true; break;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        switch (type)
        {
            case 0:
                car.blockedRight = false; break;
            case 1:
                car.blockedLeft = false; break;
            case 2:
                car.blockedUp = false; break;
            case 3:
                car.blockedDown = false; break;
        }
    }
}
