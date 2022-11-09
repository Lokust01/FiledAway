using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPositioning : MonoBehaviour
{
    public Transform player;
   
    public static bool gameStarted;

    public int zOffset;
    public float xClampPos;
    public float yClampPos;
    public float xClampNeg;
    public float yClampNeg;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, zOffset);
       
    }

    // Update is called once per frame
    void Update()
    {
        

        if (gameStarted == true)
        {
            MoveWithPlayer();
        }
    }

    void MoveWithPlayer()
    {
        transform.position = new Vector3(player.position.x, player.position.y, zOffset);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, xClampNeg, xClampPos), Mathf.Clamp(transform.position.y, yClampNeg, yClampPos), zOffset);
    }

    
}
