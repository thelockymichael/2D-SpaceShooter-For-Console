using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class MenuManager02 : MonoBehaviour
{

    public GameObject storyPanel;
    public GameObject mainMenuPanel;
    public GameObject optionsPanel;
    public Text highScoreText;

    public EventSystem myEventSystem;
    public EventSystem myStorySystem;
    public EventSystem myOptionsSystem;


    public bool isPaused = false;

    private void Update()
    {
        Time.timeScale = 1.0f;

        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.JoystickButton7))
        {
            isPaused = !isPaused;
            StartCoroutine("highlightBtn");
        }
    }

    private void Start()
    {
        Time.timeScale = 1.0f;

        highScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        myStorySystem.enabled = false;
        myOptionsSystem.enabled = false;
        storyPanel.SetActive(false);
        optionsPanel.SetActive(false);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("game");
    }

    public void ResetHiScore()
    {
        PlayerPrefs.DeleteKey("HighScore");
        highScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();

    }

    public void Story()
    {
        myEventSystem.enabled = false;

        myOptionsSystem.enabled = false;
        myStorySystem.enabled = true;

        StartCoroutine("highlightBtnStory");

        mainMenuPanel.SetActive(false);
      

        storyPanel.SetActive(true);
    }

    public void Options()
    {
        myEventSystem.enabled = false;

        myStorySystem.enabled = false;
        myOptionsSystem.enabled = true;

        mainMenuPanel.SetActive(false);

        optionsPanel.SetActive(true);
    }

    public void Resume()
    {

        myEventSystem.enabled = true;

        myStorySystem.enabled = false;
        myOptionsSystem.enabled = false;

        StartCoroutine("highlightBtn");
        mainMenuPanel.SetActive(true);
        storyPanel.SetActive(false);
        optionsPanel.SetActive(false);
    }

    public void QuitToDesktop()
    {
        Application.Quit();
    }

    IEnumerator highlightBtn()
    {
        myEventSystem.SetSelectedGameObject(null);
        yield return null;
        myEventSystem.SetSelectedGameObject(myEventSystem.firstSelectedGameObject);
    }

    IEnumerator highlightBtnStory()
    {
        myStorySystem.SetSelectedGameObject(null);
        yield return null;
        myStorySystem.SetSelectedGameObject(myStorySystem.firstSelectedGameObject);
    }

    /*
    public void highlightBtn(GameObject highLightButton)
    {

        StartCoroutine(delay(highLightButton));
    //    myEventSystem.SetSelectedGameObject(highLightButton);
    }

    IEnumerator delay(GameObject highLightThisButton)
    {
        yield return new WaitForSeconds(0.5f);

        myEventSystem.SetSelectedGameObject(highLightThisButton);
     //   yield return null;
        //optionsEventSystem.SetSelectedGameObject(optionsEventSystem.firstSelectedGameObject);

      //  myEventSystem.SetSelectedGameObject(highLightThisButton, new BaseEventData(myEventSystem));

    }*/
}
