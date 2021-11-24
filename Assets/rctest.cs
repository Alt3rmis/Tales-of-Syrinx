using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rctest : MonoBehaviour
{
    public GameObject player;

    private void Awake()
    {
        //player = transform.Find("Player").gameObject;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 pos = player.transform.position;
        RaycastHit hit;

        Ray ray = new Ray(pos, player.transform.forward);
        bool isHit = Physics.Raycast(ray, out hit, 5f, 1 << 0, QueryTriggerInteraction.Collide);
        Debug.DrawLine(pos, new Vector3(pos.x, pos.y, pos.z+5), Color.red);

        if(isHit)
        {
            print(hit.transform.name);
        }
    }
}
