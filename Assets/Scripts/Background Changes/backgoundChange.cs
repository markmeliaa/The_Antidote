using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgoundChange : MonoBehaviour
{
    public Sprite newBackground;
    public GameObject miniMap;
    public GameObject[] changeConditions;
    public int[] changeTimes;
    public float time = 2.0f;

    float timer = 0.0f;
    int index = 0;
    sceneManager manager;

    private void Start()
    {
        manager = GetComponentInParent<sceneManager>();
    }

    private void Update()
    {
        if (index < changeConditions.Length && manager.getLocationBool(changeConditions[index].name) 
            && manager.getLocationTimes(changeConditions[index].name) == changeTimes[index])
        {
            if(gameObject.name == "KieransRoom" && timer == 0.0f)
            {
                for(int i = 0; i < transform.childCount; i++)
                {
                    transform.GetChild(i).gameObject.SetActive(false);
                }

                miniMap.SetActive(false);
            }

            timer += Time.deltaTime;

            if(timer >= time)
            {
                timer = 0;
                index++;

                for (int i = 0; i < transform.childCount; i++)
                {
                    transform.GetChild(i).gameObject.SetActive(true);
                }

                miniMap.SetActive(true);
                transform.Find("InteractiveBackground").GetComponent<SpriteRenderer>().sprite = newBackground;
                transform.Find("BackgroundMapGrey").GetComponent<SpriteRenderer>().sprite = newBackground;
            }
        }
    }
}
