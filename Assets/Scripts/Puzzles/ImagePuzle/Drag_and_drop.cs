#pragma warning disable 0649

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag_and_drop : MonoBehaviour
{
    Vector3 screenSpace, offset, posInicial;
    Sensores sensores;
    Puzzle puzzle;
    bool moviendoLeft, moviendoRight, moviendoUp, moviendoDown;

    private void Awake()
    {
        sensores = GetComponentInChildren(typeof(Sensores)) as Sensores;
        puzzle = GameObject.Find("ComputerPuzzleManager").GetComponent(typeof(Puzzle)) as Puzzle;
    }

    private void OnMouseDown()
    {
        screenSpace = Camera.main.WorldToScreenPoint(transform.position);
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        posInicial = transform.position;
    }

    private void OnMouseDrag()
    {
        Vector3 posicion = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        Vector3 curScreenSpace = posicion;
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenSpace) + offset;

        if (!sensores.ocupadoLeft || !sensores.ocupadoRight)
        {
            curPosition = new Vector3(curPosition.x, transform.position.y, 0);
            if (!sensores.ocupadoLeft && !moviendoLeft && !moviendoRight)
            {
                moviendoLeft = true;
            }
            if (!sensores.ocupadoRight && !moviendoLeft && !moviendoRight)
            {
                moviendoRight = true;
            }
        }
        else if (!sensores.ocupadoUp || !sensores.ocupadoDown)
        {
            curPosition = new Vector3(transform.position.x, curPosition.y, 0);
            if (!sensores.ocupadoUp && !moviendoUp && !moviendoDown)
            {
                moviendoUp = true;
            }
            if (!sensores.ocupadoDown && !moviendoUp && !moviendoDown)
            {
                moviendoDown = true;
            }
        }
        else
            return;

        if (moviendoLeft)
        {
            if(curPosition.x > posInicial.x){
                return;
            }
        }
        if (moviendoRight)
        {
            if(curPosition.x < posInicial.x)
            {
                return;
            }
        }
        if(moviendoUp)
        {
            if (curPosition.y < posInicial.y)
            {
                return;
            }
        }
        if (moviendoDown)
        {
            if (curPosition.y > posInicial.y)
            {
                return;
            }
        }

        if (Vector3.Distance(curPosition, posInicial) > 1)
            return;

        transform.position = curPosition;
    }

    private void OnMouseUp()
    {
        transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), 0);
        moviendoLeft = false;
        moviendoRight = false;
        moviendoUp = false;
        moviendoDown = false;

        puzzle.ComprobarGanador();
    }
}
