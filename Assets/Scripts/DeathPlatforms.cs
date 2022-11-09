using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlatforms : MonoBehaviour
{
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
            player.Invoke("Restart", 0f);

        }
    }
}
