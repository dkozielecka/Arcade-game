using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScroll : MonoBehaviour
{
    public Transform cameraTransform;
    public float parallaxFactor;

    private Vector3 prevCameraPos;
    private Vector3 deltaCameraPos;

    void Start()
    {
        this.prevCameraPos = this.cameraTransform.position;
    }

    void Update()
    {
        this.deltaCameraPos = this.cameraTransform.position - this.prevCameraPos;

        float newX = transform.position.x + (this.deltaCameraPos.x * this.parallaxFactor);

        Vector3 newCameraPos = new Vector3(newX, transform.position.y, transform.position.z);
        transform.position = newCameraPos;

        this.prevCameraPos = this.cameraTransform.position;
    }
}
