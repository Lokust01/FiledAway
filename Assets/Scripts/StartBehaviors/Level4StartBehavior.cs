using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level4StartBehavior : MonoBehaviour
{
    public GameObject button;
    public GameObject mainMenuButton;

    public GameObject startText;

    public GameObject pinkVirus;

    /*public int minEnemiesArea1 = 3;
    public int maxEnemiesArea1 = 6;
    public Transform spawnArea1;


    public int minEnemiesArea2 = 1;
    public int maxEnemiesArea2 = 3;
    public Transform spawnArea2;*/

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
        player.playerResetCoords = new Vector3(-45, -16, -5);

        CameraPositioning.gameStarted = true;


        GameObject sa1Object = GameObject.FindGameObjectWithTag("SA1");
        SpawnAreaBehavior sa1 = sa1Object.GetComponent<SpawnAreaBehavior>();
        sa1.SpawnEnemies();

        GameObject sa2Object = GameObject.FindGameObjectWithTag("SA2");
        SpawnAreaBehavior sa2 = sa2Object.GetComponent<SpawnAreaBehavior>();
        sa2.SpawnEnemies();

        Destroy(this);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.L))
        {
            StartGame();
        }


    }

   /* public void SpawnEnemies()
    {
        //Spawn Area 1
        GameObject spawnArea1Object = GameObject.Find("Spawn Area1");
        BoxCollider2D sa1 = spawnArea1Object.GetComponent<BoxCollider2D>();

        int numEnemies = Random.Range(minEnemiesArea1, maxEnemiesArea1);

        for (int i = 0; i < numEnemies; i++)
        {
            Vector2 randomPosition = Random.insideUnitCircle * sa1.bounds.size.x / 2;
            Debug.Log(randomPosition);
            GameObject enemy = Instantiate(pinkVirus, randomPosition, Quaternion.identity);
        }

        //Spawn Area 2
        GameObject spawnArea2Object = GameObject.Find("Spawn Area2");
        BoxCollider2D sa2 = spawnArea2Object.GetComponent<BoxCollider2D>();

        int numEnemies2 = Random.Range(minEnemiesArea1, maxEnemiesArea1);

        for (int i = 0; i < numEnemies2; i++)
        {
            Vector2 randomPosition2 = Random.insideUnitCircle * sa2.bounds.size.x / 2;
            Debug.Log(randomPosition2);
            GameObject enemy = Instantiate(pinkVirus, randomPosition2, Quaternion.identity);
        }



    }*/
}
