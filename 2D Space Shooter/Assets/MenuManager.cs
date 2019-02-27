using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class MenuManager : MonoBehaviour
{
    public GameObject storyImage;
    private bool openMenu = false;

    public GameObject settingsMenu;

    public GameObject mainMenu;

    public EventSystem myEventSystem;

    public EventSystem optionsEventSystem;

    public EventSystem storyEventSystem;

    IEnumerator optionsDelay()
    {
        myEventSystem.enabled = false;
        optionsEventSystem.enabled = true;

        yield return new WaitForSeconds(0.2f);
        settingsMenu.SetActive(true);
        mainMenu.SetActive(false);
        StartCoroutine(highlightGameOverBtn());

       // Time.timeScale = 0.0f;
    }

    IEnumerator mainMenuDelay()
    {
        myEventSystem.enabled = true;
        optionsEventSystem.enabled = false;
        storyEventSystem.enabled = false;

        yield return new WaitForSeconds(0.2f);
        settingsMenu.SetActive(false);
        storyImage.SetActive(false);
        mainMenu.SetActive(true);
        StartCoroutine(highlightBtn());

        // Time.timeScale = 0.0f;
    }

    IEnumerator storyDelay()
    {
        myEventSystem.enabled = false;
        optionsEventSystem.enabled = false;
        storyEventSystem.enabled = true;
        yield return new WaitForSeconds(0.2f);
        storyImage.SetActive(true);
        mainMenu.SetActive(false);
        StartCoroutine(highlightStoryBtn());

        // Time.timeScale = 0.0f;
    }

    IEnumerator highlightGameOverBtn()
    {
        optionsEventSystem.SetSelectedGameObject(null);
        yield return null;
        optionsEventSystem.SetSelectedGameObject(optionsEventSystem.firstSelectedGameObject);
    }

    IEnumerator highlightBtn()
    {
        myEventSystem.SetSelectedGameObject(null);
        yield return null;
        myEventSystem.SetSelectedGameObject(myEventSystem.firstSelectedGameObject);
    }

    IEnumerator highlightStoryBtn()
    {
        storyEventSystem.SetSelectedGameObject(null);
        yield return null;
        storyEventSystem.SetSelectedGameObject(storyEventSystem.firstSelectedGameObject);
    }

    void Start()
    {
        storyImage.SetActive(false);
        settingsMenu.SetActive(false);
        optionsEventSystem.enabled = false;
        storyEventSystem.enabled = false;

        //anim = GetComponent<Animator>();
        storyImage.SetActive(false);
       // UIFaderController = GetComponent<UIFader>();
       // GameObject UIFaderControllerObject = GameObject.FindWithTag("GameOverMenu");
        //UIFaderController = UIFaderControllerObject.GetComponent<UIFader>();
    }

    public void Play()
    {
        //SceneManager.LoadScene("game");
    }
    public void Story()
    {
        StartCoroutine(storyDelay());
       //storyImage.SetActive(false);
        //settingsMenu.SetActive(false);

        //SceneManager.LoadScene("game");
    }

    public void Options()
    {
        StartCoroutine(optionsDelay());
       // settingsMenu.SetActive(true);
      //  mainMenu.SetActive(false);

    }

    public void QuitToDesktop()
    {
        Application.Quit();
        //SceneManager.LoadScene("game");
    }

    public void ResetHiScore()
    {
        PlayerPrefs.DeleteKey("HighScore");

    }

    public void ReturnToMainMenu()
    {
        StartCoroutine(mainMenuDelay());

        //  mainMenu.SetActive(true);
        //  settingsMenu.SetActive(false);
        // storyImage.SetActive(false);
    }

    public void Pause()
    {
        // PauseMenu.SetActive(true);
        // Time.timeScale = 0.0f;
        if (!openMenu /*&& !GameOverMenu*/)
        {

            openMenu = true;
            storyImage.SetActive(true);
            Time.timeScale = 0.0f;
            Debug.Log("Menu open");
            //Pause();
        }
        else if (openMenu /*&& GameOverMenu*/)
        {
            openMenu = false;
            storyImage.SetActive(false);
            Time.timeScale = 1.0f;
            Debug.Log("Menu close");
            //Resume();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
