using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed;
    public ParticleSystem bulletImpactPS;
    public GameObject healthPack;

    private Rigidbody2D rb;
    private PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.up * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Enemy")
        {
            Instantiate(bulletImpactPS, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);

            int randomChance;
            randomChance = Random.Range(0, 2);

            if(randomChance == 0)
            {
                Instantiate(healthPack, transform.position, Quaternion.identity);
            }

            player.score++;
            Destroy(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
    }
}
