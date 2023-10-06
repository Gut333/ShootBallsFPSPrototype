using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif


public class MenuUiHandler : MonoBehaviour
{
    [SerializeField] private Button startGameButton;
    [SerializeField] private Button exitGameButton;
    

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        EditorApplication.ExitPlaymode();
        Application.Quit();
    }



}
