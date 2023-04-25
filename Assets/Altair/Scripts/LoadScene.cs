using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class LoadScene : MonoBehaviour
{

    public GameObject loadBar;

    // make an animated load bar
    public TextMeshProUGUI loadBarText;

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
