using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmogusAI : MonoBehaviour
{
    public int state;
    public float speed;
    public float lifeSpan = 0f;
    public Rigidbody rb;
    public GameObject target1;
    public GameObject target2;
    public GameObject target3;
    public Material baseMaterial;
    public Material leadMaterial;
    public Material bossMaterial;
    public Renderer rd;
    public Color stateColor;
    public Vector3 mainTarget;
    public Spawner spawner;
    public int lookAtTarget = 1;
    // Start is called before the first frame update
    void Start()
    {
        ChangeColor();
        target1 = GameObject.Find("Cube (1)");
        target2 = GameObject.Find("Cube (2)");
        target3 = GameObject.Find("Cube (3)");
        spawner = GameObject.Find("GameManager").GetComponent<Spawner>();
    }

    // Update is called once per frame
    void Update()
    {
        lifeSpan += Time.deltaTime;
        if (lookAtTarget == 1)
        {
            mainTarget = target1.transform.position;
            rb.rotation = Quaternion.Euler(0, 180, 0);
            if (rb.velocity.z >= speed * -4)
            {
                rb.AddForce(this.transform.forward * speed * Time.deltaTime, ForceMode.Impulse);
            }
        }
        else if (lookAtTarget == 2)
        {
            mainTarget = target2.transform.position;
            rb.rotation = Quaternion.Euler(0, 90, 0);
            if (rb.velocity.x <= speed * 4)
            {
                rb.AddForce(this.transform.forward * speed * Time.deltaTime, ForceMode.Impulse);
            }
        }
        else if(lookAtTarget == 3)
        {
            mainTarget = target3.transform.position;
            rb.rotation = Quaternion.Euler(0, 180, 0);
            if (rb.velocity.z >= speed * -4)
            {
                rb.AddForce(this.transform.forward * speed * Time.deltaTime, ForceMode.Impulse);
            }
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Target1" && lookAtTarget == 1)
        {
            lookAtTarget = 2;
            rb.velocity = new Vector3(rb.velocity.z * -1, 0, 0);
        }
        if (other.gameObject.tag == "Target2" && lookAtTarget == 2)
        {
            lookAtTarget = 3;
            rb.velocity = new Vector3(0, 0, rb.velocity.x * -1);
        }
        if (other.gameObject.tag == "Target3" && lookAtTarget == 3)
        {
            spawner.health -= state;
            spawner.healthText.text = "LIVES: " + spawner.health;
            //spawner.remaining -= 1;
            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "OneDamage")
        {
            if (state <= 6)
            {
                state -= 1;
                spawner.money += 1;
                spawner.moneyText.text = "$ " + spawner.money;
                ChangeColor();
                SplitApart();
            }
            else if (state >= 11)
            {
                state -= 1;
                spawner.money += 1;
                spawner.moneyText.text = "$ " + spawner.money;
                ChangeColor();
                SplitApart();
            }
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "TwoDamage")
        {
            state -= 2;
            spawner.money += 2;
            if (state >= 11)
            {
                state -= 2;
                spawner.money += 2;
            }
            spawner.moneyText.text = "$ " + spawner.money;
            ChangeColor();
            SplitApart();
            Destroy(other.gameObject);
            rb.velocity /= 1.2f;
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.tag == "OneDamage")
        //{
        //    state -= 1;
        //    spawner.money += 1;
        //    spawner.moneyText.text = "$ " + spawner.money;
        //    ChangeColor();
        //    SplitApart();
        //    Destroy(collision.gameObject);
        //}
        //if (collision.gameObject.tag == "TwoDamage")
        //{
        //    state -= 2;
        //    spawner.money += 2;
        //    if (state >= 11)
        //    {
        //        state -= 2;
        //        spawner.money += 2;
        //    }
        //    spawner.moneyText.text = "$ " + spawner.money;
        //    ChangeColor();
        //    SplitApart();
        //    Destroy(collision.gameObject);
        //}
    }
    private void ChangeColor()
    {
        if (state <= 0)
        {
            //spawner.remaining -= 1;
            Destroy(gameObject);
        }
        if (state == 1)
        {
            stateColor = new Color(248f / 255f, 0, 0, 1);
            speed = 1f;
        }
        if (state == 2)
        {
            stateColor = new Color(0, 171f / 255f, 1, 1);
            speed = 1.2f;
        }
        if (state == 3)
        {
            stateColor = new Color(18f / 255f, 202f / 255f, 0, 1);
            speed = 1.4f;
        }
        if (state == 4)
        {
            stateColor = new Color(255f / 255f, 253f / 255f, 0, 1);
            speed = 1.6f;
        }
        if (state == 5)
        {
            stateColor = new Color(255f / 255f, 139f / 255f, 228f / 255f, 1);
            speed = 1.8f;
        }
        if (state == 6)
        {
            stateColor = new Color(0, 0, 0, 1);
            speed = 1.5f;
        }
        if (state <= 6)
        {
            rd.material = baseMaterial;
            rd.material.color = stateColor;
        }
        if (state >= 7 && state <= 10)
        {
            stateColor = new Color(152f / 255f, 152f / 255f, 152f / 255f, 1);
            speed = 1.3f;
            rd.material = leadMaterial;
        }
        if (state >= 11)
        {
            rd.material = bossMaterial;
            speed = 1f;
        }
    }
    private void SplitApart()
    {
        Vector3 smallOffset = new Vector3(Random.Range(-0.4f, 0.4f), 0, Random.Range(-0.4f, 0.4f));
        if (state >= 5 && state <= 6)
        {
            GameObject spawned = Instantiate(this.gameObject, transform.position + smallOffset, Quaternion.identity);
            if (spawned.TryGetComponent<Rigidbody>(out Rigidbody rb2))
            {
                rb2.velocity = rb.velocity;
            }
            if (spawned.TryGetComponent<AmogusAI>(out AmogusAI cmpt))
            {
                cmpt.state = this.state;
                cmpt.lifeSpan = this.lifeSpan;
            }
        }
        if (state == 10)
        {
            GameObject spawned = Instantiate(this.gameObject, transform.position + smallOffset, Quaternion.identity);
            if (spawned.TryGetComponent<Rigidbody>(out Rigidbody rb2))
            {
                rb2.velocity = rb.velocity;
            }
            if (spawned.TryGetComponent<AmogusAI>(out AmogusAI cmpt))
            {
                cmpt.state = this.state;
                cmpt.lifeSpan = this.lifeSpan;
            }
        }
    }
}
