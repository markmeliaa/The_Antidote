using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class dontDestroy : MonoBehaviour
{
    private static GameObject lastLocation;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void OnLevelWasLoaded(int level)
    {
        if (level == 2)
        {
            for (int i = 0; i < this.gameObject.transform.childCount; i++)
            {
                if (this.gameObject.transform.GetChild(i).gameObject.activeSelf)
                {
                    lastLocation = this.gameObject.transform.GetChild(i).gameObject;
                    Debug.Log(lastLocation.name);

                }
                this.gameObject.transform.GetChild(i).gameObject.SetActive(false);
            }
        }

        else if (level == 1)
        {
            for (int i = 0; i < this.gameObject.transform.childCount; i++)
            {
                if (this.gameObject.transform.GetChild(i).gameObject.name == lastLocation.name)
                {
                    this.gameObject.transform.GetChild(i).gameObject.SetActive(true);
                    Animator animation = this.gameObject.transform.GetChild(i).gameObject.transform.Find("CircleWipe").GetComponent<Animator>();
                    animation.SetTrigger("Start");
                }
                this.gameObject.transform.GetChild(i).gameObject.SetActive(false);
            }

        }
    }
}
