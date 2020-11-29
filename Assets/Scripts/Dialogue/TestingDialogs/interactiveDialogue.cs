using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactiveDialogue : MonoBehaviour
{
    public GameObject location;
    private void OnMouseDown()
    {
        location.GetComponentInParent<sceneManager>().setLocationTimes(location.name);
        location.GetComponent<Tester>().sceneWithInteraction = false;
    }
}
