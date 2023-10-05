using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float bulletSpeed = 40f;
    private GameManager gameManagerScript;
    private float outOfLimit = -1f;
    private ParticleSystem explosion;
    private PlayerController playerScript;
    

    private void Awake()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
        explosion = GameObject.Find("Explosion").GetComponent<ParticleSystem>();
        playerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.left * bulletSpeed * Time.deltaTime);
        DestroyBulletOutOfLimits();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
            explosion.gameObject.transform.position = transform.position;
            explosion.Play();
        }

        if (other.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
            explosion.gameObject.transform.position = transform.position;
            explosion.Play();
        }


        if (other.gameObject.CompareTag("Target"))
        {
            playerScript.SetAmmo(playerScript.GetAmmo()+1);
            gameManagerScript.UpdateScore();
            explosion.gameObject.transform.position = transform.position;
            explosion.Play();
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    private void DestroyBulletOutOfLimits()
    {
        if(transform.position.y < outOfLimit)
        {
            Destroy(gameObject);
        }
    }
}
