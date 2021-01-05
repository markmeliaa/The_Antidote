using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    public Transform objects;
    public GameObject winText;
    public desactivatePuzzle puzzleEnding;

    public bool activated = true;
    public bool blockedRight, blockedLeft, blockedUp, blockedDown;
    public bool horizontal;

    Vector3 initialPosition, offset, startPosition;
    [SerializeField]
    bool movingRight, movingLeft, movingUp, movingDown;

    private void Awake()
    {
        startPosition = transform.position;
    }

    private void OnMouseDown()
    {
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        initialPosition = transform.position;
    }

    private void OnMouseDrag()
    {
        if (activated)
        {
            Vector3 posicion = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
            Vector3 currentPos = Camera.main.ScreenToWorldPoint(posicion) + offset;
            currentPos.x = Mathf.Clamp(currentPos.x, -6.5f, 7f);
            currentPos.y = Mathf.Clamp(currentPos.y, -5.0f, 5.0f);

            if (horizontal)
            {
                currentPos = new Vector3(currentPos.x, transform.position.y, 0);
                if (!blockedRight && currentPos.x > initialPosition.x)
                {
                    movingRight = true;
                    movingLeft = false;
                }
                else if (!blockedLeft && currentPos.x < initialPosition.x)
                {
                    movingLeft = true;
                    movingRight = false;
                }

                else
                    return;

            }
            else if (!horizontal)
            {
                currentPos = new Vector3(transform.position.x, currentPos.y, 0);
                if (!blockedUp && currentPos.y > initialPosition.y)
                {
                    movingUp = true;
                    movingDown = false;
                }

                else if (!blockedDown && currentPos.y < initialPosition.y)
                {
                    movingDown = true;
                    movingUp = false;
                }
                else
                    return;

            }

            if (movingRight && blockedRight)
                return;
            else if (movingLeft && blockedLeft)
                return;
            else if (movingUp && blockedUp)
                return;
            else if (movingDown && blockedDown)
                return;

            transform.position = currentPos;
        }
    }

    private void OnMouseUp()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
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

        blockedDown = false;
        blockedLeft = false;
        blockedRight = false;
        blockedUp = false;
    }

    public void EndPuzle()
    {
        for (int i = 0; i < objects.childCount; i++)
        {
            objects.GetChild(i).gameObject.GetComponent<ObjectMovement>().activated = false;
        }

        winText.SetActive(true);
        //puzzleEnding.desactivate(false);
    }
}
