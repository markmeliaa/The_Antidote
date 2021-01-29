using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowNames : MonoBehaviour
{
    [SerializeField] TextMesh currentName;

    private void OnMouseOver()
    {
        currentName.gameObject.SetActive(true);
    }

    private void OnMouseExit()
    {
        currentName.gameObject.SetActive(false);
    }
}
