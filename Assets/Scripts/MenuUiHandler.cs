using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif


public class MenuUiHandler : MonoBehaviour
{
    [SerializeField] private Button startGameButton;
    [SerializeField] private Button exitGameButton;
    [SerializeField] private Text inputText;
    [SerializeField] private Text loadedText;
    private string playerName;
    private string saveName;
    public GameManager gameManagerInstance;
    

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        EditorApplication.ExitPlaymode();
        Application.Quit();
    }

    private void Update()
    {
        playerName = PlayerPrefs.GetString("name", "none");
        loadedText.text = playerName;
    }

    public void SetPlayerName()
    {
        saveName = inputText.text;
        PlayerPrefs.SetString("name", saveName);
        GameManager.gameManagerInstance.SetBestScorePlayerName(saveName);
    }







}
