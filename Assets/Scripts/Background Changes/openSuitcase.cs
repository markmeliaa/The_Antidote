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
        miniMapIcon.SetActive(false);
        inventoryIcon.SetActive(false);
    }
}
