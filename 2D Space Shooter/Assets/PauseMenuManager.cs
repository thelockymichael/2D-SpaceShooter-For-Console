using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using InControl;
using UnityEngine.EventSystems;


public class PauseMenuManager : MonoBehaviour
{
    public GameObject PauseMenu;

    public GameObject GameOverMenu;

    public GameObject restartGameOverMenuButton;
    public GameObject resumePauseMenuButton;

    public bool openMenu = false;

    public bool gameOverOpen = false;

    private float gameOverWait = 1.5f;

    public EventSystem myEventSystem;

    public EventSystem gameOverEventSystem;

    // private GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        gameOverEventSystem.enabled = false;
        //anim = GetComponent<Animator>();
        // GameObject UIFaderControllerObject = GameObject.FindWithTag("GameOverMenu");
        //UIFaderController = UIFaderControllerObject.GetComponent<UIFader>();
        Time.timeScale = 1.0f;
        PauseMenu.SetActive(false);
        GameOverMenu.SetActive(false);

    }



    public void Restart()
    {

       // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
    }

    public void mainMenu()
    {
        //SceneManager.LoadScene("mainMenu");
        Time.timeScale = 1.0f;
    }

    public void Pause()
    {
      
        // PauseMenu.SetActive(true);
        // Time.timeScale = 0.0f;
        if (!openMenu && GameOverMenu)
        {

            openMenu = true;
            PauseMenu.SetActive(true);
            Time.timeScale = 0.0f;
            //Pause();
        }
        else if (openMenu /*&& GameOverMenu*/)
        {
            openMenu = false;
            PauseMenu.SetActive(false);
            Time.timeScale = 1.0f;
            //Resume();
        }
    }

    public void Resume()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1.0f;

    }

    public void GameOver()
    {
        StartCoroutine(gameOverDelay());
        //UIFaderController.FadeIn();
    }


    IEnumerator gameOverDelay()
    {
        myEventSystem.enabled = false;
        gameOverEventSystem.enabled = true;
        yield return new WaitForSeconds(gameOverWait);
        GameOverMenu.SetActive(true);
        StartCoroutine(highlightGameOverBtn());

       // Time.timeScale = 0.0f;
    }

    IEnumerator highlightGameOverBtn()
    {
        gameOverEventSystem.SetSelectedGameObject(null);
        yield return null;
        gameOverEventSystem.SetSelectedGameObject(gameOverEventSystem.firstSelectedGameObject);
    }

    IEnumerator highlightBtn()
    {
        myEventSystem.SetSelectedGameObject(null);
        yield return null;
        myEventSystem.SetSelectedGameObject(myEventSystem.firstSelectedGameObject);
    }
    // Update is called once per frame
    void Update()
    {
      

        var InputDevice = InputManager.ActiveDevice;

        if (InputDevice.Command.WasPressed && !openMenu)
        {
            openMenu = true;
            PauseMenu.SetActive(true);
            Time.timeScale = 0.0f;
            StartCoroutine(highlightBtn());
        }

        else if (InputDevice.Command.WasPressed && openMenu)
        {
            openMenu = false;
            PauseMenu.SetActive(false);
            Time.timeScale = 1.0f;
        }

    }
}
