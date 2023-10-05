using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float verticalInput;
    private float horizontalInput;
    private float rightLimit = 1.6f;
    private float leftLimit = -1.6f;
    private float speedMovement = 5f;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject bulletPoint;
    private GameManager gameManagerScript;
    public int playerAmmo;
    private bool hasAmmo;

    private void Awake()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerAmmo = 10;
    }

    private void Update()
    {
        
        if (gameManagerScript.GetGameStatus()==true)
        {
            HorizontalMovement();
            VerticalRotation();
            HasAmmo();
            gameManagerScript.UpdatePlayerAmmo();
        }
    }

    private void VerticalRotation()
    {
        verticalInput = Input.GetAxis("Vertical");
        transform.Rotate(0, 0, verticalInput);
    }
    private void HorizontalMovement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward * speedMovement * horizontalInput * Time.deltaTime);
        ScreenLimiter();
    }

    public bool HasAmmo()
    {
        if (playerAmmo > 0)
        {
            Shoot();GetAmmo();
            return hasAmmo;
        }
        else
        {
            gameManagerScript.GameOver();
            return hasAmmo;
        }
    }
    

    private void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            Instantiate(bulletPrefab,bulletPoint.transform.position,bulletPoint.transform.rotation);
            playerAmmo = playerAmmo - 1;
            SetAmmo(playerAmmo);
        }  
    }

    public void SetAmmo(int ammo){playerAmmo = ammo;}
    public int GetAmmo(){return playerAmmo;}



    private void ScreenLimiter()
    {
        if(transform.position.z > rightLimit)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, rightLimit);
        }
        else if(transform.position.z < leftLimit)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, leftLimit);
        }
    }

}
