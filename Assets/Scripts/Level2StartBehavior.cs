using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2StartBehavior : MonoBehaviour
{
    public GameObject button;
    public GameObject mainMenuButton;

    public GameObject startText;

    

    // Start is called before the first frame update
    void Start()
    {

        Camera.main.orthographicSize = 27;
    }

    public void StartGame()
    {
        //figure out how to add a delay so it slowly adjusts the camera at the start of the level later

        for (int i = 0; i < 18; i++)
        {
            Camera.main.orthographicSize--;
            Camera.main.transform.position = new Vector3((Camera.main.transform.position.x - 1.6f), (Camera.main.transform.position.y - 0.75f), -10);
        }
        
        button.SetActive(false);
        mainMenuButton.SetActive(false);

        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        PlayerBehavior player = playerObject.GetComponent<PlayerBehavior>();
        player.playerResetCoords = new Vector3(-45, -18, -5);

        CameraPositioning.gameStarted = true;
        Destroy(this);
        
    }

    // Update is called once per frame
    void Update()
    {
        
           
        
    }
}
