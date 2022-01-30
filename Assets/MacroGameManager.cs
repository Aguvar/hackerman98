using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MacroGameManager : MonoBehaviour
{
    public MinigameManager minigameManager;

    // Start is called before the first frame update
    void Start()
    {
        minigameManager.gameOverEvent.AddListener(GameOver);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GameOver()
    {
        SceneManager.LoadScene(2);
    }


}
