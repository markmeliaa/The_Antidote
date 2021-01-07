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
            curPosition.z = 0;


            if ((!sensores.ocupadoLeft || !sensores.ocupadoRight) && (!moviendoDown && !moviendoUp))
            {
                if ((curPosition.x + 0.5) < posInicial.x && !moviendoRight)
                    moviendoLeft = true;
                if ((curPosition.x - 0.5) > posInicial.x && !moviendoLeft)
                    moviendoRight = true;

                if (moviendoRight || moviendoLeft)
                    curPosition = new Vector3(curPosition.x, transform.position.y, 0);
            }

            if ((!sensores.ocupadoUp || !sensores.ocupadoDown) && (!moviendoLeft && !moviendoRight))
            {


                if ((curPosition.y - 0.5) > posInicial.y && !moviendoDown)
                    moviendoUp = true;

                if ((curPosition.y + 0.5) < posInicial.y && !moviendoUp)
                    moviendoDown = true;

                if (moviendoUp || moviendoDown)
                    curPosition = new Vector3(transform.position.x, curPosition.y, 0);
            }

            if (moviendoRight)
            {
                if (sensores.ocupadoRight || curPosition.x < posInicial.x)
                    return;
            }

            if (moviendoLeft)
            {
                if (sensores.ocupadoLeft || curPosition.x > posInicial.x)
                    return;
            }

            if (moviendoUp)
            {
                if (sensores.ocupadoUp || curPosition.y < posInicial.y)
                    return;
            }

            if (moviendoDown)
            {
                if (sensores.ocupadoDown || curPosition.y > posInicial.y)
                    return;
            }
            transform.position = curPosition;
        }
    }

    private void OnMouseUp()
    {
        moviendoDown   = false;
        moviendoLeft   = false;
        moviendoRight  = false;
        moviendoUp     = false;
    }
}
