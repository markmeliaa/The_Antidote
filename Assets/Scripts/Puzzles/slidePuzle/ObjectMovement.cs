﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    Vector3 screenSpace, initialPosition, offset, startPosition;
    Sensors sensors;
    bool horizontal;
    bool movingRight, movingLeft, movingUp, movingDown;

    private void Awake()
    {
        startPosition = transform.position;
        sensors = GetComponentInChildren<Sensors>();
    }

    private void OnMouseDown()
    {
        screenSpace = Camera.main.WorldToScreenPoint(transform.position);
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        initialPosition = transform.position;
    }

    private void OnMouseDrag()
    {
        Vector3 posicion = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        Vector3 currentPos = Camera.main.ScreenToWorldPoint(posicion) + offset;

        if(horizontal && (!sensors.blockedLeft || !sensors.blockedRight))
        {
            currentPos = new Vector3(currentPos.x, transform.position.y, 0);
            if (currentPos.x > initialPosition.x)
                movingRight = true;
            else if(currentPos.x < initialPosition.x)
                movingLeft = true;
        }
        else if(!horizontal && (!sensors.blockedDown || !sensors.blockedUp))
        {
            currentPos = new Vector3(transform.position.x, currentPos.y, 0);
        }
    }
}