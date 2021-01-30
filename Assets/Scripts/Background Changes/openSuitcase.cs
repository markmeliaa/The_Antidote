using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openSuitcase : MonoBehaviour
{
    [SerializeField] GameObject background;
    [SerializeField] GameObject maletinabierto;
    [SerializeField] GameObject miniMapIcon;
    [SerializeField] GameObject inventoryIcon;

    private void OnMouseDown()
    {
        background.SetActive(false);
        maletinabierto.SetActive(true);

        if(maletinabierto.GetComponent<SpriteRenderer>() != null)
            maletinabierto.GetComponent<SpriteRenderer>().sortingOrder= 2;

        maletinabierto.transform.GetChild(0).gameObject.SetActive(true);
        maletinabierto.transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder = 3;
        miniMapIcon.SetActive(false);
        inventoryIcon.SetActive(false);
    }
}
