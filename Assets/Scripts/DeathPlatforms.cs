using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlatforms : MonoBehaviour
{

    public AudioClip crashSound;
    public Animator dead;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
            PlayerBehavior player = playerObject.GetComponent<PlayerBehavior>();

            dead.SetBool("isDead", true);

            AudioSource.PlayClipAtPoint(crashSound, Camera.main.transform.position);

            player.Invoke("Restart", 2f);

        }
    }
}
