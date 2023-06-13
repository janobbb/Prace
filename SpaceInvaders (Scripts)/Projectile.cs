using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float moveSpeed;
    public GameObject wybuchPrefab;

    private GameManager manager;
    public AudioSource audioSource;
    void Start()
    {
        manager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Niszczenie")
        {
            
            Destroy(gameObject);
            manager.bulletExist = false;
            manager.UpdateScore(manager.minus);
        }
        
        if (collision.gameObject.tag == "Enemy")
        {
            Instantiate(wybuchPrefab, transform.position, Quaternion.identity);
            FindObjectOfType<AudioManager>().Play("Explosion");
            Destroy(collision.gameObject);
            manager.enemiesCount--;
            manager.UpdateScore(manager.plus);
            Destroy(gameObject);
            manager.bulletExist = false;
        }

    }

}
