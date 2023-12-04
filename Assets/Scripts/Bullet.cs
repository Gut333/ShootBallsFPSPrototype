using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //public GameState gameState;

    private float bulletSpeed = 40f;
    private float outOfLimit = -1f;
    private ParticleSystem explosion;
    private ParticleSystem targetExplosion;
    private PlayerController playerScript;
    //[SerializeField] PlayerController playerScript;

    


    private void Awake()
    {
        explosion = GameObject.Find("Explosion").GetComponent<ParticleSystem>();
        targetExplosion = GameObject.Find("Target Explosion").GetComponent<ParticleSystem>();
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
            explosion.gameObject.transform.position = transform.position;
            explosion.Play();
            Destroy(gameObject);

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
            playerScript.UpdateScore();

            explosion.gameObject.transform.position = transform.position;
            targetExplosion.gameObject.transform.position = transform.position;
            targetExplosion.Play();
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
