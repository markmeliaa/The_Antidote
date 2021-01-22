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

            Vector3 movimientoPos = curPosition - transform.position;
            if(moviendoRight || moviendoLeft)
            {
                if (movimientoPos.y != 0)
                    movimientoPos.y = 0;

                if (movimientoPos.x == 0)
                    movimientoPos.x = 0.000001f;

                transform.position = new Vector3(transform.position.x + (movimientoPos.x / Mathf.Abs(movimientoPos.x * 10)), transform.position.y, 0);
                movimientoPos.x -= Mathf.Abs(movimientoPos.x) / movimientoPos.x * 10;
            }
            else if(moviendoUp || moviendoDown)
            {
                if (movimientoPos.x != 0)
                    movimientoPos.x = 0;

                if (movimientoPos.y == 0)
                    movimientoPos.y = 0.000001f;

                transform.position = new Vector3(transform.position.x, transform.position.y + (movimientoPos.y / Mathf.Abs(movimientoPos.y * 10)), 0);
                movimientoPos.y -= Mathf.Abs(movimientoPos.y) / movimientoPos.y * 10;
            }
        }
    }

    private void OnMouseUp()
    {
        moviendoDown   = false;
        moviendoLeft   = false;
        moviendoRight  = false;
        moviendoUp     = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector3 correction = transform.position;

        if (collision.transform.position.x >= correction.x)
            correction.x -= 0.1f;
        if (collision.transform.position.x < correction.x)
            correction.x += 0.1f;
        if (collision.transform.position.y <= correction.x)
            correction.y += 0.1f;
        if (collision.transform.position.y > correction.x)
            correction.y -= 0.1f;

        transform.position = correction;
    }

}
