using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseScene : MonoBehaviour
{
    [SerializeField] GameObject background;
    [SerializeField] GameObject miniMapIcon;
    [SerializeField] GameObject inventoryIcon;
    // Update is called once per frame
    void Update()
    {
        if(transform.childCount == 0)
        {
            background.SetActive(true);
            miniMapIcon.SetActive(true);
            inventoryIcon.SetActive(true);
            gameObject.SetActive(false);

        }
    }
}
