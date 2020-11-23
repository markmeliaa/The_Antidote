using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgoundChange : MonoBehaviour
{
    public Sprite newBackground;
    public GameObject miniMap;

    [SerializeField] bool change = false;
    float timer = 0.0f;
    float time = 2.0f;
    int type;

    private void Update()
    {
        if (change)
        {
            if(type == 0 && timer == 0.0f)
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
                change = false;

                for (int i = 0; i < transform.childCount; i++)
                {
                    transform.GetChild(i).gameObject.SetActive(true);
                }

                miniMap.SetActive(true);
                transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = newBackground;
            }

        }
    }

    public void changeBackground(int newType)
    {
        change = true;
        type = newType;
    }
}
