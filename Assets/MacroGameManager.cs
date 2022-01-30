using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MacroGameManager : MonoBehaviour
{
    public MinigameManager minigameManager;
    public HackerTyper hackertyperObj;

    private int hackLoops;
    private int batLoops;
    // Start is called before the first frame update
    void Start()
    {
        hackertyperObj.BeginHack();
        hackertyperObj.EndHack();
        hackLoops = 0;
        batLoops = 0;
        minigameManager.gameOverEvent.AddListener(GameOver);
        MailsManager.Instance.gameOverEvent.AddListener(GameOver);
    }

    // Update is called once per frame
    void Update()
    {
        if (minigameManager.progressBar.value == 1f)
        {
            minigameManager.hideMinigame();
            batLoops++;
            Debug.Log("Bat Loops: " + batLoops);
            hackertyperObj.gameObject.SetActive(true);
            hackertyperObj.BeginHack();
        }
        if (hackertyperObj.keyStrokeCount == hackertyperObj.chosenPasta.Length - hackertyperObj.chosenPasta.Length / 10)
        {
            hackertyperObj.keyStrokeCount = 0;
            hackertyperObj.EndHack();
            hackLoops++;
            Debug.Log("Hack Loops: " + hackLoops);
            minigameManager.gameObject.SetActive(true);
            minigameManager.EnableMinigame();
        }
    }

    void GameOver()
    {
        SceneManager.LoadScene(2);
    }


}
