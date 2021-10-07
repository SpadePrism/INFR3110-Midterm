using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform target; //Set Player here
    public float distance; //Offset for camera to not be inside player

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Sets camera position to players position at an offset (distance) so that it follows
        //Distance subtracted from z position so camera is positioned on the players side while they move along the x axis
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y + 2, target.transform.position.z - distance);
    }
}
