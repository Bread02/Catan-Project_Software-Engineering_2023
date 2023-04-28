using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

/**
 * This script controls the loading scene functionality and the loading bar. Other scripts can easily access this
 * to generate a loading bar to help the user know if the game has crashed or is loading.
 *
 * @author Altair Robinson
 * @version 26/04/2023
 */
public class LoadScene : MonoBehaviour
{

    public GameObject loadBar;
    public TextMeshProUGUI loadBarText;

    // Starts the loading scene coroutine to load up a new scene.
    public IEnumerator LoadSceneCoroutine(string sceneName)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);
        loadBar.SetActive(true);
        StartCoroutine(LoadingAnimation());

        while (!asyncOperation.isDone)
        {
             yield return null;
        }
    }

    // this sets the loading animation bar.
    public IEnumerator LoadingAnimation()
    {
        for (int i = 0; i < 1000; i++)
        {
            // if I is divisible by 2, do 
            loadBarText.text = "Loading.";
            yield return new WaitForSeconds(0.2f);
            loadBarText.text = "Loading..";
            yield return new WaitForSeconds(0.2f);
            loadBarText.text = "Loading...";
            yield return new WaitForSeconds(0.2f);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        loadBar.SetActive(false);
    }
}
