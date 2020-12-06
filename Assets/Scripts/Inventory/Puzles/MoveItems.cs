using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveItems : MonoBehaviour
{
    public GameObject correctForm;
    public Sprite newSprite;
    public GameObject puzleLocation;

    private bool moving;
    private bool finish;

    private float startPosX;
    private float startPosY;

    private Vector3 resetPosition;
   
    void Start()
    {
        resetPosition = this.transform.position;
    }

    void Update()
    {
        if (!finish)
        {
            if (moving)
            {
                Vector3 mousePos;
                mousePos = Input.mousePosition;
                mousePos = Camera.main.ScreenToWorldPoint(mousePos);

                this.gameObject.transform.position = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, gameObject.transform.position.z);
            }
        }
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosY = mousePos.x - this.transform.position.x;
            startPosX = mousePos.y - this.transform.position.y;

            moving = true;
        }
    }

    private void OnMouseUp()
    {
        moving = false;

        if ((Mathf.Abs(this.transform.localPosition.x - correctForm.transform.localPosition.x) <= 1.5f) && (Mathf.Abs(this.transform.localPosition.y - correctForm.transform.localPosition.y) <= 1.5f) && correctForm.gameObject.activeSelf)
        {
            this.transform.localPosition = new Vector3(correctForm.transform.localPosition.x, correctForm.transform.localPosition.y, correctForm.transform.localPosition.z);
            finish = true; // Para que no se pueda mover más una vez está en el sitio correcto
            puzleLocation.transform.Find("InteractiveBackground").GetComponent<SpriteRenderer>().sprite = newSprite;
            puzleLocation.transform.Find("BackgroundMapGrey").GetComponent<SpriteRenderer>().sprite = newSprite;
            puzleLocation.transform.Find("InteractiveBackground").GetChild(0).gameObject.SetActive(false);
            Destroy(gameObject);
        }

        else
        {
            this.transform.localPosition = new Vector3(resetPosition.x, resetPosition.y, resetPosition.z);
        }
    }
}
