using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public TMPro.TextMeshProUGUI title;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void consoleTest()
    {
        Debug.Log("ConsoleTest");
    }

    public void StartGame()
    {
        StartCoroutine(FindPlayer());

    }

    IEnumerator FindPlayer()
    {
        AsyncOperation asyncOp = SceneManager.LoadSceneAsync("DemoScene");
        while (!asyncOp.isDone)
        {
            yield return null;
        }
        GameObject playerObj = GameObject.Find("Player");
        playerObj = GameObject.Find("Player");
        
    }
}
