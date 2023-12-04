using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager gameManagerInstance;
    public Camera mainCamera;
    public string playerName;
    public GameObject menuState;
    public GameObject gameState;
    private bool m_IsGameActive;

    private void Awake()
    {
        GameManagerInstance();
        SetMainMenuCameraPos();
        SetGameStatus(false);
    }


    private void GameManagerInstance()
    {
        if (gameManagerInstance != null)
        {
            Destroy(gameObject);
            return;
        }
        gameManagerInstance = this;
        DontDestroyOnLoad(gameObject);
    }


    public void SetMainMenuCameraPos()
    {
        mainCamera.transform.position = new Vector3(28, 1.25f, 0f);
        SetGameStatus(false);
    }

    public void SetGameCameraPos()
    {
        mainCamera.transform.position = new Vector3(18f, -1f, 0f);
        //just for test
        gameState.SetActive(true);
        SetGameStatus(true);

    }

    public void ExitGame(){Application.Quit();}

    public bool GetGameStatus(){return m_IsGameActive;}

    public void SetGameStatus(bool isActive){m_IsGameActive = isActive;}

}
