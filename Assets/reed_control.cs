using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reed_control : MonoBehaviour
{
    // set how long will the reed platform exist
    public float lifetime = 1.0f;
    public Vector3 travelDis = new Vector3(1.0f, 0.0f, 0.0f);
    public Rigidbody rb;
    //private GameObject obj;
    private void Awake()
    {
        Destroy(gameObject, lifetime);
    }
}
