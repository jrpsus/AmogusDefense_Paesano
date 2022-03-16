using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour
{
    public float shootTime;
    public float shootSpeed;
    private float shootTimePassed = 0f;
    public int towerType;
    public int roundPlaced;
    public GameObject shootType;
    public GameObject[] availableTargets;
    public float[] lifeSpans;
    public int theLongest;
    public float lifeScan;
    //public Vector3[] availablePositions;
    public Spawner spawner;
    public Transform shoot;
    //public Animation shootAnim;
    // Start is called before the first frame update
    void Start()
    {
        spawner = GameObject.Find("GameManager").GetComponent<Spawner>();
        roundPlaced = spawner.round;
    }

    // Update is called once per frame
    void Update()
    {
        shootTimePassed += Time.deltaTime * Random.Range(0.99f, 1.01f);
        if (shootTimePassed >= shootTime && towerType <= 2)
        {
            lifeScan = 0;
            availableTargets = GameObject.FindGameObjectsWithTag("Amogus");
            for (int i = 0; i < availableTargets.Length; i += 1)
            {
                lifeSpans[i] = availableTargets[i].GetComponent<AmogusAI>().lifeSpan;
            }
            for (int i = 0; i < availableTargets.Length; i += 1)
            {
                if (lifeSpans[i] >= lifeScan)
                {
                    theLongest = i;
                    lifeScan = lifeSpans[i];
                }
            }
            shootTimePassed = 0;
            //shoot.LookAt(GameObject.FindWithTag("Amogus").transform.position, Vector3.up);
            //shoot.LookAt(availableTargets[(Mathf.FloorToInt(Random.Range(0, availableTargets.Length - 1)))].transform.position);
            shoot.LookAt(availableTargets[theLongest].transform.position);
            GameObject bullet = Instantiate(shootType, shoot.position, shoot.rotation);
            Rigidbody rb2 = bullet.GetComponent<Rigidbody>();
            rb2.AddForce(shoot.forward * shootSpeed);
            rb2.transform.LookAt(GameObject.FindWithTag("Amogus").transform.position, Vector3.up);
        }
        if (spawner.round - 5 >= roundPlaced)
        {
            if (towerType == 3)
            {
                spawner.income -= 35;
            }
            Destroy(gameObject);
        }
    }
}
