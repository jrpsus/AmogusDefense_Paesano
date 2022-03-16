using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private float timer;
    public Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        //transform.LookAt(GameObject.FindWithTag("Amogus").transform.position, Vector3.up);
        timer += Time.deltaTime;
        if (timer >= 0.2)
        {
            //rb.velocity /= 1.2f;
        }
        if (timer >= 1)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Amogus")
        {
            Destroy(gameObject);
        }
    }
}
