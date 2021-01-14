using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    public Transform objects;
    public GameObject winText;
    public desactivatePuzzle puzzleEnding;

    public bool activated = true;
    public bool horizontal;

    Vector3 initialPosition, offset, startPosition, screenSpace;
    slideSensors sensores;
    [SerializeField]
    bool movingRight, movingLeft, movingUp, movingDown;

    private void Awake()
    {
        startPosition = transform.position;
        sensores = GetComponentInChildren<slideSensors>();
    }

    private void OnMouseDown()
    {
        screenSpace = Camera.main.WorldToScreenPoint(transform.position);
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
            currentPos.z = 0;

            if (horizontal)
            {
                
                if (!sensores.ocupadoRight && !movingLeft)
                {
                    if(currentPos.x > initialPosition.x)
                        movingRight = true;

                    if(movingRight)
                        currentPos = new Vector3(currentPos.x, transform.position.y, 0);
                }
                
                if (!sensores.ocupadoLeft && !movingRight)
                {
                    if(currentPos.x < initialPosition.x)
                        movingLeft = true;
                    
                    if(movingLeft)
                        currentPos = new Vector3(currentPos.x, transform.position.y, 0);
                }
            }
            else if (!horizontal)
            {
                
                if (!sensores.ocupadoUp && !movingDown)
                {
                    if(currentPos.y > initialPosition.y)
                        movingUp = true;

                    if(movingUp)
                        currentPos = new Vector3(transform.position.x, currentPos.y, 0);
                }

                if (!sensores.ocupadoDown && !movingUp)
                {
                    if(currentPos.y < initialPosition.y)
                        movingDown = true;

                    if(movingDown)
                        currentPos = new Vector3(transform.position.x, currentPos.y, 0);
                }  
            }

            if (movingRight)
            {
                if (sensores.ocupadoRight || currentPos.x < initialPosition.x)
                    return;
            }
            else if (currentPos.x > initialPosition.x)
                return;

            if (movingLeft)
            {
                if (sensores.ocupadoLeft || currentPos.x > initialPosition.x)
                    return;
            }
            else if (currentPos.x < initialPosition.x)
                return;

            if (movingUp)
            {
                if (sensores.ocupadoUp || currentPos.y < initialPosition.y)
                    return;
            }
            else if (currentPos.y > initialPosition.y)
                return;

            if (movingDown)
            {
                if (sensores.ocupadoDown || currentPos.y > initialPosition.y)
                    return;
            }
            else if (currentPos.y < initialPosition.y)
                return;

            transform.position = currentPos;
        }
    }

    private void OnMouseUp()
    {
        /*if( Physics2D.OverlapArea(new Vector2(transform.position.x - 2, transform.position.y - 0.75f), new Vector2(transform.position.x + 2, transform.position.y + 0.75f)))
        {
            Vector3 correction = transform.position;

            if (horizontal)
            {
                if (!sensores.ocupadoLeft)
                    correction.x -= 0.3f;
                else if (!sensores.ocupadoRight)
                    correction.x += 0.3f;
            }
            else
            {
                if (!sensores.ocupadoUp)
                    correction.y += 0.3f;
                else if (!sensores.ocupadoDown)
                    correction.y -= 0.3f;
            }

            transform.position = correction;
        }*/

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
    }
}
