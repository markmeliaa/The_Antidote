using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundActivation : MonoBehaviour
{
    public GameObject[] backgroundLocations;

    backgoundChange nextBackground;

    private void OnMouseDown()
    {
        for (int i = 0; i < backgroundLocations.Length; i++)
        {
            nextBackground = backgroundLocations[i].GetComponent<backgoundChange>();

            if(nextBackground != null)
            {
                nextBackground.changeBackground();
            }
        }
    }
}
