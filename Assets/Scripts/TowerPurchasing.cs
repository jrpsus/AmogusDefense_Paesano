using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerPurchasing : MonoBehaviour
{
    // Start is called before the first frame update
    public Spawner spawner;
    public int[] prices;
    public Text[] priceText;
    public int towerSelected = -1;
    void Start()
    {
        spawner = GameObject.Find("GameManager").GetComponent<Spawner>();
        for (int i = 0; i < prices.Length; i += 1)
        {
            priceText[i].text = "$" + prices[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PurchaseTower(int tower)
    {
        if (Time.timeScale >= 0.1f)
        {
            if (spawner.money >= prices[tower] && towerSelected != tower)
            {
                towerSelected = tower;
            }
            else if (towerSelected == tower)
            {
                towerSelected = -1;
            }
        }
    }
}
