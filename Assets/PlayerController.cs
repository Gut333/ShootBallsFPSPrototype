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

    private void Awake()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        if (gameManagerScript.GetGameStatus()==true)
        {
            HorizontalMovement();
            VerticalRotation();
            Shoot();
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

    

    private void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab,bulletPoint.transform.position,bulletPoint.transform.rotation);
        }
        
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
