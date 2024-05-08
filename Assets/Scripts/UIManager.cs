using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Text time_Text;
    public bool is_GameManager_use = false;

    private GameManager gameManager;
    private int time = 0;

    private void Start()
    {
        if(is_GameManager_use == true)
        {
            gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        }

        if(time_Text != null)
        {
            StartCoroutine(TimeFlow());
        }
    }

    IEnumerator TimeFlow()
    {
        while(gameManager.is_activate)
        {
            time_Text.text = "Time: " + time;
            yield return new WaitForSeconds(1f);
            time += 1;
        }
    }

    public void GameStart()
    {
        SceneManager.LoadScene("Avoid It And Feed It");
    }

    public void GameExit()
    {
        Application.Quit();
    }

    public void GameRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ToMainmenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
