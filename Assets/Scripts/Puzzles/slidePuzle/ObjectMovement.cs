using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    Vector3 initialPosition, offset, startPosition;
    Sensors sensors;
    public bool horizontal;
    [SerializeField]
    bool movingRight, movingLeft, movingUp, movingDown;

    private void Awake()
    {
        startPosition = transform.position;
        sensors = GetComponentInChildren<Sensors>();
    }

    private void OnMouseDown()
    {
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        initialPosition = transform.position;
    }

    private void OnMouseDrag()
    {
        Vector3 posicion = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        Vector3 currentPos = Camera.main.ScreenToWorldPoint(posicion) + offset;

        if (horizontal && (!sensors.blockedLeft || !sensors.blockedRight))
        {
            currentPos = new Vector3(currentPos.x, transform.position.y, 0);
            if (currentPos.x > initialPosition.x)
                movingRight = true;
            else if (currentPos.x < initialPosition.x)
                movingLeft = true;
        }
        else if (!horizontal && (!sensors.blockedDown || !sensors.blockedUp))
        {
            currentPos = new Vector3(transform.position.x, currentPos.y, 0);
            if (currentPos.y > initialPosition.y)
                movingUp = true;
            else if (currentPos.y < initialPosition.y)
                movingDown = true;
        }
        else
            return;

        if (movingRight && sensors.blockedRight)
            return;
        else if (movingLeft && sensors.blockedLeft)
            return;
        else if (movingUp && sensors.blockedUp)
            return;
        else if (movingDown && sensors.blockedDown)
            return;

        transform.position = currentPos;
    }

    private void OnMouseUp()
    {
        transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), 0);
        movingRight = false;
        movingLeft = false;
        movingUp = false;
        movingDown = false;
    }

    public void resetObjects()
    {
        transform.position = startPosition;
        movingRight = false;
        movingLeft = false;
        movingUp = false;
        movingDown = false;
        offset = Vector3.zero;
        initialPosition = Vector3.zero;

        sensors.blockedDown = false;
        sensors.blockedLeft = false;
        sensors.blockedRight = false;
        sensors.blockedUp = false;
    }
}
