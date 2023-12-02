using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameState : MonoBehaviour
{
    public GameManager gameManager;
    public MenuState menuState;

    public Button restartButton;
    public GameObject gameOverText;

    public List<GameObject> blankPoints;

    private float m_RandomZ;
    private float m_RandomY;
    private float m_RandomX;
    private Vector3 m_blankRandomPos;



    private void OnEnable()
    {
        StartCoroutine(BlankPointsSpawner());
    }

    public void OnRestartButtonPressed()
    {
        gameManager.SetGameStatus(true);
        gameManager.SetMainMenuCameraPos();
        restartButton.gameObject.SetActive(false);
        menuState.gameObject.SetActive(true);
        gameOverText.SetActive(false);
    }


    private void _BlankPointsGenerator()
    {
        m_RandomZ = Random.Range(-2, 2);
        m_RandomY = Random.Range(0, 5);
        m_RandomX = Random.Range(1, 8);
        m_blankRandomPos = new Vector3(m_RandomX, m_RandomY, m_RandomZ);
        Instantiate(blankPoints[0], m_blankRandomPos, blankPoints[0].transform.rotation);
    }

    IEnumerator BlankPointsSpawner()
    {
        gameManager.SetGameStatus(true);
        while (gameManager.GetGameStatus())
        {
            yield return new WaitForSeconds(3);
            _BlankPointsGenerator();
        }
    }


}
