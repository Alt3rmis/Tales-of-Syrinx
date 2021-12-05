using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reedController : MonoBehaviour
{
    // how long will the reed platform exist
    public float lifetime = 1.0f;
    public float allowedDifference = 5.0f; // how far will the reed platform travel
    public float speed = 20f; // reed platform speed
    public Rigidbody rb;
    private Vector3 rawPos; // stor raw position
    private bool moveFlag = false; // if the reed platform is moving

    public PlayerController MyPlayer;
    //private GameObject obj;
    void Awake()
    {
        Destroy(gameObject, lifetime);
        rawPos = rb.position;
        rb.velocity = new Vector3(speed, 0.0f, 0.0f);
        moveFlag = true;
    }
    
    void FixedUpdate()
    {
        if(moveFlag && rb.position.x - rawPos.x >= allowedDifference)
        {
            // Debug.Log("Distance stop");
            rb.constraints=RigidbodyConstraints.FreezeAll;
            moveFlag = false;
        } else if(rb.velocity.x < 0.01f){
            // Debug.Log("Collide stop");
            rb.constraints=RigidbodyConstraints.FreezeAll;
            moveFlag = false;
        }
    }


    void OnDisable()
    {
        Debug.Log("Disabled!");
        addReedCount();
    }
    
    void addReedCount()
    {
        MyPlayer.reed_count += 1;
    }
}