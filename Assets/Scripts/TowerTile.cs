using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTile : MonoBehaviour
{
    public TowerPurchasing towerPurchasing;
    public Spawner spawner;
    public Material material;
    public Renderer rd;
    //public Color tileColor;
    public GameObject[] towersAvailable;
    public bool hasTower = false;
    public int roundPlaced = -5;
    // Start is called before the first frame update
    void Start()
    {
        towerPurchasing = GameObject.Find("GameManager").GetComponent<TowerPurchasing>();
        spawner = GameObject.Find("GameManager").GetComponent<Spawner>();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawner.round >= roundPlaced + 5)
        {
            rd.material.color = new Color(1f, 144f / 255f, 144f / 255f, 1);
            hasTower = false;
        }
        else if (spawner.round >= roundPlaced + 4)
        {
            rd.material.color = new Color(1f, 1f, 144f / 255f, 1);
        }
        else if (spawner.round >= roundPlaced)
        {
            rd.material.color = new Color(144f / 255f, 1, 144f / 255f, 1);
        }
    }
    public void OnMouseDown()
    {
        if (towerPurchasing.towerSelected >= 0 && spawner.money >= towerPurchasing.prices[towerPurchasing.towerSelected] && hasTower == false && Time.timeScale >= 0.1f)
        {
            Instantiate(towersAvailable[towerPurchasing.towerSelected], transform.position + Vector3.up / 2, Quaternion.identity);
            spawner.money -= towerPurchasing.prices[towerPurchasing.towerSelected];
            spawner.UpdateAllText();
            roundPlaced = spawner.round;
            hasTower = true;
            if (towerPurchasing.towerSelected == 3)
            {
                spawner.income += 35;
            }
            towerPurchasing.towerSelected = -1;
        }
        
        //Debug.Log("YEP");
    }
}
