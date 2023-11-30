using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int playerAmmo { get; set; }

    private float verticalInput;
    private float horizontalInput;
    private float rightLimit = 1.6f;
    private float leftLimit = -1.6f;
    private float speedMovement = 5f;
    private float gunRecoil = 2.0f;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject bulletPoint;
    
    private bool hasAmmo;

    private void Awake()
    {
        playerAmmo = 10;
    }

    private void Update()
    {
        if (GameManager.gameManagerInstance.GetGameStatus())
        {
            HorizontalMovement();
            VerticalRotation();
            HasAmmo();
            GameManager.gameManagerInstance.UpdatePlayerAmmo();
        }
        else
        {
            playerAmmo = 10;
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
            GameManager.gameManagerInstance.GameOver();
            return hasAmmo;
        }
    }
    

    private void Shoot()
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
        transform.position = new Vector3(transform.position.x + gunRecoil, transform.position.y, transform.position.z);
        yield return new WaitForSeconds(0.1f);
        transform.position = new Vector3(transform.position.x - gunRecoil, transform.position.y, transform.position.z);
    }

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
