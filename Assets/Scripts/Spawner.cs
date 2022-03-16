using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    public int money = 20;
    public int health = 10;
    public int round = 0;
    public int income = 0;
    //public int remaining = 0;
    public int spawnIndex;
    public Text moneyText;
    public Text healthText;
    public Text roundText;
    public Transform spawnPos;
    public GameObject spawnObject;
    public AmogusAI ai;
    public float timeBetweenEnemies;
    public float enemyTimePassed;
    public int[] spawnProcedure;
    //private EnemyOptions[] enemyPrefabs = new EnemyOptions[0];
    // Start is called before the first frame update

    //1: 5 red
    //2: 4 red, 2 blue
    //3: 6 red, 4 blue
    //4: 6 blue, 2 green
    //5: 10 blue
    //6: 5 blue, 5 green
    //7: 10 green
    //8: 5 green, 5 yellow
    //9: 10 yellow
    //10: 5 yellow, 5 pink
    //11: 10 pink
    //12: 5 pink, 5 black
    //13: 10 black
    //14: 2 green, 2 yellow, 2 pink, 2 black, 2 lead
    //15: 1 boss
    //16: 5 black, 5 lead
    //17: 10 lead
    //18: 1 boss, 5 lead
    //19: 2 boss, 8 lead
    //20: 4 boss
    void Start()
    {
        GetRounds();
    }

    // Update is called once per frame
    void Update()
    {
        enemyTimePassed += Time.deltaTime;
        if (enemyTimePassed >= timeBetweenEnemies && spawnIndex <= 10)
        {
            if (spawnProcedure[spawnIndex] >= 1)
            {
                Spawn(spawnProcedure[spawnIndex]);
            }
            enemyTimePassed = 0f;
            spawnIndex += 1;
        }
    }
    void Spawn(int setState)
    {
        GameObject spawned = Instantiate(spawnObject, spawnPos.position, Quaternion.identity);
        //remaining += 1;
        if (spawned.TryGetComponent<AmogusAI>(out AmogusAI cmpt))
        {
            cmpt.state = setState;
        }
    }
    void GetRounds()
    {
        for (int i = 0; i < spawnProcedure.Length; i += 1)
        {
            spawnProcedure[i] = 0;
        }
        if (round == 1)
        {
            for (int i = 0; i < spawnProcedure.Length; i += 2)
            {
                spawnProcedure[i] = 1;
            }
        }
        if (round == 2)
        {
            spawnProcedure[0] = 1;
            spawnProcedure[1] = 1;
            spawnProcedure[2] = 1;
            spawnProcedure[3] = 1;
            spawnProcedure[5] = 2;
            spawnProcedure[7] = 2;
        }
        if (round == 3)
        {
            for (int i = 0; i < spawnProcedure.Length; i += 2)
            {
                spawnProcedure[i] = 1;
                spawnProcedure[i + 1] = 2;
            }
            spawnProcedure[1] = 1;
        }
        if (round == 4)
        {
            for (int i = 0; i < spawnProcedure.Length; i += 5)
            {
                spawnProcedure[i] = 3;
                spawnProcedure[i + 1] = 0;
                spawnProcedure[i + 2] = 2;
                spawnProcedure[i + 3] = 2;
                spawnProcedure[i + 4] = 2;
            }
        }
        if (round == 5)
        {
            for (int i = 0; i < spawnProcedure.Length; i += 1)
            {
                spawnProcedure[i] = 2;
            }
        }
        if (round == 6)
        {
            for (int i = 0; i < spawnProcedure.Length; i += 2)
            {
                spawnProcedure[i] = 2;
                spawnProcedure[i + 1] = 3;
            }
        }
        if (round == 7)
        {
            for (int i = 0; i < spawnProcedure.Length; i += 1)
            {
                spawnProcedure[i] = 3;
            }
        }
        if (round == 8)
        {
            for (int i = 0; i < spawnProcedure.Length; i += 2)
            {
                spawnProcedure[i] = 3;
                spawnProcedure[i + 1] = 4;
            }
        }
        if (round == 9)
        {
            for (int i = 0; i < spawnProcedure.Length; i += 1)
            {
                spawnProcedure[i] = 4;
            }
        }
        if (round == 10)
        {
            for (int i = 0; i < spawnProcedure.Length; i += 2)
            {
                spawnProcedure[i] = 4;
                spawnProcedure[i + 1] = 5;
            }
        }
        if (round == 11)
        {
            for (int i = 0; i < spawnProcedure.Length; i += 1)
            {
                spawnProcedure[i] = 5;
            }
        }
        if (round == 12)
        {
            for (int i = 0; i < spawnProcedure.Length; i += 2)
            {
                spawnProcedure[i] = 5;
                spawnProcedure[i + 1] = 6;
            }
        }
        if (round == 13)
        {
            for (int i = 0; i < spawnProcedure.Length; i += 1)
            {
                spawnProcedure[i] = 6;
            }
        }
        if (round == 14)
        {
            for (int i = 0; i < spawnProcedure.Length; i += 5)
            {
                spawnProcedure[i] = 3;
                spawnProcedure[i + 1] = 4;
                spawnProcedure[i + 2] = 5;
                spawnProcedure[i + 3] = 6;
                spawnProcedure[i + 4] = 10;
            }
        }
        if (round == 15)
        {
            spawnProcedure[0] = 50;
        }
        if (round == 16)
        {
            for (int i = 0; i < spawnProcedure.Length; i += 2)
            {
                spawnProcedure[i] = 6;
                spawnProcedure[i + 1] = 10;
            }
        }
        if (round == 17)
        {
            for (int i = 0; i < spawnProcedure.Length; i += 1)
            {
                spawnProcedure[i] = 10;
            }
        }
        if (round == 18)
        {
            for (int i = 0; i < spawnProcedure.Length; i += 2)
            {
                spawnProcedure[i + 1] = 10;
            }
            spawnProcedure[0] = 50;
        }
        if (round == 19)
        {
            for (int i = 0; i < spawnProcedure.Length; i += 1)
            {
                spawnProcedure[i] = 10;
            }
            spawnProcedure[0] = 50;
            spawnProcedure[5] = 50;
        }
        if (round == 20)
        {
            spawnProcedure[0] = 50;
            spawnProcedure[3] = 50;
            spawnProcedure[6] = 50;
            spawnProcedure[9] = 50;
        }
        roundText.text = "ROUND: " + round;
    }
    public void NextRound()
    {
        if (spawnIndex >= 10 && enemyTimePassed >= 3 && Time.timeScale >= 0.1f)
        {
            round += 1;
            money += income + round + 9;
            health += income / 7;
            spawnIndex = 0;
            UpdateAllText();
            GetRounds();
        }
        
    }
    public void UpdateAllText()
    {
        moneyText.text = "$ " + money;
        healthText.text = "LIVES: " + health;
        roundText.text = "ROUND: " + round;
    }
}
