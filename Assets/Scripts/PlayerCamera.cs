using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public GameObject player;
    public float cameraSpeedTime = 500;

    private Vector3 currentVelocity;

    void Start()
    {
        
    }

    void Update()
    {
        Vector3 playerPosition = this.player.transform.position;
        Vector3 cameraPosition = new Vector3(playerPosition.x, transform.position.y, transform.position.z);

        transform.position = Vector3.SmoothDamp(transform.position, cameraPosition, ref this.currentVelocity, this.cameraSpeedTime);
    }
}
