using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    public Animator transition;

    public float transitionTime = 1f;

    public int nextScene;

    public DialogueManager manager;

    public Inventory inventory;

    private bool active;


    private void Update()
    {
        if (manager == null)
            return;

        if (manager.InConvo)
        {
            if (GetComponent<SpriteRenderer>() != null)
                GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<CursorObject>().active = false;
            active = false;
        }
        else
        {
            if (GetComponent<SpriteRenderer>() != null)
                GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<CursorObject>().active = true;
            active = true;
        }
    }

    private void OnMouseDown()
    {
        inventorySaver.itemSaver(inventory.items);

        if (active && SceneManager.GetActiveScene().buildIndex != nextScene)
        {
            LoadNextLevel();
        }
    }

    public void LoadNextLevel()
    {
       StartCoroutine(LoadLevel(nextScene));
    }

    IEnumerator LoadLevel(int nextScene)
    {
        //Play animation
        transition.SetTrigger("Start");

        //Wait
        yield return new WaitForSeconds(transitionTime);

        //Load scene
        SceneManager.LoadScene(nextScene);
    }
}
