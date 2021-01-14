using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballsMovement : MonoBehaviour
{
    public GameObject squareObjetivo;
    [HideInInspector] public Vector3 objetivo;
    public bool active = true;

    Vector3 screenSpace, offset, posInicial;
    Sensores sensores;
    [SerializeField]
    bool moviendoRight, moviendoLeft, moviendoUp, moviendoDown;
    

    private void Awake()
    {
        sensores = GetComponentInChildren<Sensores>();
        objetivo = squareObjetivo.transform.position;
    }

    private void OnMouseDown()
    {
        screenSpace = Camera.main.WorldToScreenPoint(transform.position);
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        posInicial = transform.position;
    }

    private void OnMouseDrag()
    {
        if(active)
        {
            Vector3 curScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenSpace) + offset;
            curPosition.x = Mathf.Clamp(curPosition.x, -3.75f, 4.5f);
            curPosition.y = Mathf.Clamp(curPosition.y, -2.75f, 1.75f);
            curPosition.z = 0;

            if(!sensores.ocupadoRight && !moviendoUp && !moviendoDown && !moviendoLeft)
            {
                if ((curPosition.x - 0.2) > posInicial.x)
                    moviendoRight = true;

                if(moviendoRight)
                    curPosition = new Vector3(curPosition.x, transform.position.y, 0);
            }

            if (!sensores.ocupadoLeft && !moviendoDown && !moviendoUp && !moviendoRight)
            {
                if ((curPosition.x + 0.2) < posInicial.x)
                    moviendoLeft = true;

                if (moviendoLeft)
                    curPosition = new Vector3(curPosition.x, transform.position.y, 0);
            }

            if(!sensores.ocupadoUp && !moviendoLeft && !moviendoRight && !moviendoDown)
            {
                if ((curPosition.y - 0.2) > posInicial.y)
                    moviendoUp = true;

                if (moviendoUp)
                    curPosition = new Vector3(transform.position.x, curPosition.y, 0);
            }

            if (!sensores.ocupadoDown && !moviendoLeft && !moviendoRight && !moviendoUp)
            {
                if ((curPosition.y + 0.2) < posInicial.y)
                    moviendoDown = true;

                if (moviendoDown)
                    curPosition = new Vector3(transform.position.x, curPosition.y, 0);
            }

            if (moviendoRight)
            {
                if (sensores.ocupadoRight || curPosition.x < posInicial.x)
                    return;
            }
            else if (curPosition.x > posInicial.x)
                return;

            if (moviendoLeft)
            {
                if (sensores.ocupadoLeft || curPosition.x > posInicial.x)
                    return;
            }
            else if (curPosition.x < posInicial.x)
                return;

            if (moviendoUp)
            {
                if (sensores.ocupadoUp || curPosition.y < posInicial.y)
                    return;
            }
            else if (curPosition.y > posInicial.y)
                return;

            if (moviendoDown)
            {
                if (sensores.ocupadoDown || curPosition.y > posInicial.y)
                    return;
            }
            else if (curPosition.y < posInicial.y)
                return;

            transform.position = curPosition;
        }
    }

    private void OnMouseUp()
    {
        if (Physics2D.OverlapCircle(transform.position, 0.5f))
        {
            Vector3 correction = transform.position;

            if (!sensores.ocupadoRight)
                correction.x += 0.5f;
            else if (!sensores.ocupadoLeft)
                correction.x -= 0.5f;
            else if (!sensores.ocupadoUp)
                correction.y += 0.5f;
            else if (!sensores.ocupadoDown)
                correction.y -= 0.5f;

            transform.position = correction;
        }

        moviendoDown   = false;
        moviendoLeft   = false;
        moviendoRight  = false;
        moviendoUp     = false;
    }

}
