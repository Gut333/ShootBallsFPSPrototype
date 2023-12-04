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
    public GameManager gameManagerInstance;
    public Camera mainCamera;

    [SerializeField] private Text inputText;
    [SerializeField] private Text loadedText;
    private string playerName;
    private string saveName;
    
    private void Update()
    {
        playerName = PlayerPrefs.GetString("name", "none");
        loadedText.text = playerName;
    }

    public void SetPlayerName()
    {
        saveName = inputText.text;
        PlayerPrefs.SetString("name", saveName);
       // GameManager.gameManagerInstance.SetBestScorePlayerName(saveName);
    }


}
