using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RPGLevelLoader : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1f;

    public int nextScene;

    public DialogueManager manager;

    private bool active;

    private void Update()
    {
        if (manager == null)
            return;

        if (manager.InConvo)
        {
            active = false;
        }
        else
        {
            active = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "player" && active && SceneManager.GetActiveScene().buildIndex != nextScene)
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
