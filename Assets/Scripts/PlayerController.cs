using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int playerAmmo { get; set; }
    public GameState gameState;
    private float m_VerticalInput;
    private float m_HorizontalInput;
    private float m_RightLimit = 1.6f;
    private float m_LeftLimit = -1.6f;
    private float m_SpeedMovement = 5f;
    private float m_GunRecoil = 0.5f;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject bulletPoint;
    
    private bool hasAmmo;

    private void Awake()
    {
        playerAmmo = 10;
    }

    public void OnInit()
    {
        if (GameManager.gameManagerInstance.GetGameStatus())
        {
            _MovePlayer();
            HasAmmo();
            gameState.UpdatePlayerAmmo();
        }
        else
        {
            playerAmmo = 10;
        }
    }

    public void UpdateScore()
    {
        gameState.UpdateScore();
    }


    private void _MovePlayer()
    {
        m_VerticalInput = Input.GetAxis("Vertical");
        transform.Rotate(0, 0, m_VerticalInput);
        //rotation limiter ?

        m_HorizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward * m_SpeedMovement * m_HorizontalInput * Time.deltaTime);
        _ScreenLimiter();

    }


    public bool HasAmmo()
    {
        if (playerAmmo > 0)
        {
            _Shoot();GetAmmo();
            return hasAmmo;
        }
        else
        {
            gameState.GameOver();
            return hasAmmo;
        }
    }
    

    private void _Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bulletPrefab,bulletPoint.transform.position,bulletPoint.transform.rotation);
            playerAmmo = playerAmmo - 1;
            SetAmmo(playerAmmo);
            StartCoroutine(ShootAnim());
        }  
    }

    public void SetAmmo(int ammo){playerAmmo = ammo;}
    public int GetAmmo(){return playerAmmo;}

    IEnumerator ShootAnim()
    {
        transform.position = new Vector3(transform.position.x + m_GunRecoil, transform.position.y, transform.position.z);
        yield return new WaitForSeconds(0.1f);
        transform.position = new Vector3(transform.position.x - m_GunRecoil, transform.position.y, transform.position.z);
    }

    private void _ScreenLimiter()
    {
        if(transform.position.z > m_RightLimit)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, m_RightLimit);
        }
        else if(transform.position.z < m_LeftLimit)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, m_LeftLimit);
        }
    }
}
