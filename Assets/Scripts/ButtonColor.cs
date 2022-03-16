using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonColor : MonoBehaviour
{
    public int towerType;
    public TowerPurchasing towerPurchasing;
    public Color buttonColor;
    // Start is called before the first frame update
    void Start()
    {
        towerPurchasing = GameObject.Find("GameManager").GetComponent<TowerPurchasing>();
    }

    // Update is called once per frame
    void Update()
    {
        if (towerPurchasing.towerSelected != towerType)
        {
            buttonColor = new Color(189f / 255f, 209f / 255f, 191f / 255f, 1);
        }
        else
        {
            buttonColor = new Color(90f / 255f, 154f / 255f, 96f / 255f, 1);
        }
        this.gameObject.GetComponent<Image>().color = buttonColor;
    }
}
