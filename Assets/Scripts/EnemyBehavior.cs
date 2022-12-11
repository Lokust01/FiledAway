using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public float speed = 5f;

    public float distanceFromPlayer = 10f;

    public Vector3 playerPos;

    public AudioClip crashSound;

    private Rigidbody2D rb2D;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CameraPositioning.gameStarted == true)
        {

            GameObject player = GameObject.FindGameObjectWithTag("Player");

            Vector3 playerPos = player.transform.position;

            float distance = Vector3.Distance(transform.position, playerPos);

            if (distance <= distanceFromPlayer)
            { 


            Vector3 currentPosition = transform.position;

            Vector3 targetPosition = Vector3.MoveTowards(currentPosition, playerPos, speed * Time.deltaTime);



            transform.position = targetPosition;

            //transform.Rotate()

            //rb2D.AddForce(transform.forward * speed * Time.deltaTime);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.name == "LineDrawer")
        {
            // Destroy the enemy
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Player")
        {
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
            PlayerBehavior player = playerObject.GetComponent<PlayerBehavior>();
            Animator playerAnimation = playerObject.GetComponent<Animator>();

            playerAnimation.SetBool("isDead", true);

            AudioSource.PlayClipAtPoint(crashSound, Camera.main.transform.position);

            
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

            foreach (GameObject enemy in enemies)
            {
                GameObject.Destroy(enemy);
            }


            player.Invoke("Restart", 2f);

        }
    }

    
}
