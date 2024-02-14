using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed;
    public GameObject bullet;
    public Transform bulletSpawnPoint;
    public TextMeshProUGUI healthText;
    public int health = 3;
    public ParticleSystem explosionPS;
    public int score;
    public TextMeshProUGUI scoreText;
    public MenuController menuController;

    private Rigidbody2D rb;
    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);   

        Vector2 rotation = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);

        transform.up = rotation;

        if (Input.GetKey(KeyCode.Space))
        {
            rb.velocity = transform.up * movementSpeed;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(bullet, bulletSpawnPoint.transform.position, transform.rotation);
            source.Play();
        }

        healthText.text = ("Health: " + health.ToString());
        scoreText.text = ("Score: " + score.ToString());
    }

    public void DamagePlayer()
    {
        health--;

        if(health == 0)
        {
            Instantiate(explosionPS, transform.position, Quaternion.identity);
            Destroy(healthText);
            Destroy(scoreText);
            menuController.ShowMenu();
            Destroy(gameObject);
        }
    }
}
