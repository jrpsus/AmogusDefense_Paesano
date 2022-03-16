using UnityEngine;
using UnityEngine.UI;

public class NextRound : MonoBehaviour
{
    public Text nextRoundText;
    public Spawner spawner;
    // Start is called before the first frame update
    void Start()
    {
        spawner = GameObject.Find("GameManager").GetComponent<Spawner>();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawner.spawnIndex >= 10 && spawner.enemyTimePassed >= 3)
        {
            nextRoundText.text = "Next Round";
        }
        else
        {
            nextRoundText.text = "Please Wait";
        }
    }
}
