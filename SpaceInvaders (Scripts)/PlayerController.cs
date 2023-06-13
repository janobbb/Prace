using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float hInput;
    public GameObject bulletPrefab;
    public GameManager manager;
    private AudioSource shot;
    void Start()
    {
        manager = FindObjectOfType<GameManager>();
        shot = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        hInput = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector2.down * hInput * moveSpeed * Time.deltaTime);

        if(Input.GetButtonDown("Fire1") && manager.bulletExist == false)
        {
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            FindObjectOfType<AudioManager>().Play("Shot");
            manager.bulletExist = true;

        }
    }
}
