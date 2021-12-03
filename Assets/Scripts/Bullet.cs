using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Awake()
    {
        rb.velocity = new Vector3(speed, 0.0f, 0.0f);
        // Destroy(gameObject, 1f);
    }

    // Update is called once per frame
    // void Update()
    // {
    //     // GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward * 50);
    //     transform.position = transform.position + new Vector3(Speed * Time.deltaTime, 0f, 0f);
    // }

    void OnTriggerEnter(Collider hitInfo)
    {
        if (hitInfo.CompareTag("Enemy"))
        {
            Destroy(hitInfo.gameObject);
            Destroy(gameObject);
            return;
        }
        if (hitInfo.CompareTag("Boss"))
        {
            Boss.BossInstance.Improve();
            return;
        }
        if (!hitInfo.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
