using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateSelector : MonoBehaviour
{

    
    public GameObject menuState;
    public GameObject gameState;
    public Camera mainCamera;

    

    public void SelectMenuState()
    {
        mainCamera.transform.position = new Vector3(30, 1.35f, 0.2f);
        GameManager.gameManagerInstance.Restart();
    }

    public void SelectGameState()
    {
        mainCamera.transform.position = new Vector3(18, 1.35f, -0.25f);
        GameManager.gameManagerInstance.StartGame();

    }




}
