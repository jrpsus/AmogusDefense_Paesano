using UnityEngine.UI;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public GameObject pauseUI;
    public Spawner spawner;
    public Text resultText;
    // Start is called before the first frame update
    void Start()
    {
        spawner = GameObject.Find("GameManager").GetComponent<Spawner>();
        pauseUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (spawner.round >= 21)
        {
            pauseUI.SetActive(true);
            resultText.text = "YOU WIN";
            Time.timeScale = 0.01f;
        }
        if (spawner.health <= 0)
        {
            pauseUI.SetActive(true);
            resultText.text = "YOU DIED";
            Time.timeScale = 0.01f;
        }
    }
}
