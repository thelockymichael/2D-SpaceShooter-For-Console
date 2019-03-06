using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public GameObject loadingScreen;

    public Slider slider;

    public Text progressText;

    public GameObject loadPanel;

    AsyncOperation async;

    private float speed = 1.0f;
    public Color loadToColor = Color.black;

    public void LoadLevel(int sceneIndex)
    {
        Debug.Log("DO SOMETHING");

        StartCoroutine(delayLoading(sceneIndex));

    }

    IEnumerator delayLoading(int sceneIndex)
    {
        Debug.Log("DO SOMETHING02");

        //  Initiate.Fade(scene, loadToColor, speed);
        yield return new WaitForSeconds(speed);
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    private void Start()
    {
        loadingScreen.SetActive(false);
        loadPanel.SetActive(false);
    }
    
    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        Debug.Log("DO SOMETHING03");

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        loadingScreen.SetActive(true);
        loadPanel.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            progressText.text = progress * 100 + "%";
            Debug.Log(operation.progress);

            yield return null;
        }
    }
}
     /*
     IEnumerator LoadAsynchronously(int sceneIndex)
     {
         loadingScreen.SetActive(true);
         loadPanel.SetActive(true);
         async = SceneManager.LoadSceneAsync(sceneIndex);
         async.allowSceneActivation = false;

         while (async.isDone == false)
         {
             slider.value = async.progress;
             if (async.progress == 0.9f)
             {
                 slider.value = 1f;
                 async.allowSceneActivation = true;
             }
             yield return null;
         }
     }
 }*/


