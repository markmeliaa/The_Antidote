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

    [SerializeField] Animator tvAnimator;

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
        if (tvAnimator == null)
            StartCoroutine(LoadLevel(nextScene));

        else
        {
            tvAnimator.SetBool("tvOn", false);
            StartCoroutine(LoadLevel2(nextScene));
        }
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

    IEnumerator LoadLevel2(int nextScene)
    {
        yield return new WaitForSeconds(0.5f);

        //Play animation
        transition.SetTrigger("Start");

        //Wait
        yield return new WaitForSeconds(transitionTime);

        //Load scene
        SceneManager.LoadScene(nextScene);
    }
}
