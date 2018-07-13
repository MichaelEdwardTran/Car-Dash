using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCamera : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    private Vector3 originalPosition;

    public float speed = 6.0f; //when speed * Time.deltaTime == 1, the position will be the target position


    private bool interpolateLocked = false;
    private float interpolation = 1;
    private int interpolateLockCount;
    private Vector3 floatingOriginOffset;
    // Use this for initialization
    void Start()
    {
        offset = transform.position - player.transform.position;
        originalPosition = transform.position;
    }



    void Update()
    {
        interpolation = speed * Time.deltaTime;

        if (interpolation > 0.99)
        {
            interpolation = 1;
        }
        Vector3 position = new Vector3(
            Mathf.Lerp(this.transform.position.x, player.transform.position.x + offset.x, interpolation),
            originalPosition.y,
            originalPosition.z);
        this.transform.position = position;

        if (interpolateLocked) //if we decided to freeze the camera's relative position to the player
        {
            if(interpolateLockCount <= 0)
            {
                interpolateLocked = false;
            }
            else
            {
                interpolateLockCount--;
                this.transform.position = player.transform.position + floatingOriginOffset;
            }
        }
    }

    public void interpolateLock() //freezes camera's relative position to player for interpolateLockCount frames
    {
        interpolateLocked = true;
        interpolateLockCount = 1;
        floatingOriginOffset = transform.position - player.transform.position;
    }
}


