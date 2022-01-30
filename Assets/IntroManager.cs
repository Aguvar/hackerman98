using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroManager : MonoBehaviour
{

    public GameObject creditPanel;
    public AudioSource trackSource;
    public int secondsForMusic = 2;
    public GameObject instructionsPanel;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlayTrackAfterSeconds(secondsForMusic));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        print("Starting Game");
        instructionsPanel.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ShowCredits()
    {
        creditPanel.SetActive(true);
    }

    IEnumerator PlayTrackAfterSeconds(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        trackSource.Play();

        float currentTime = 0;
        float start = trackSource.volume;

        while (currentTime < 5)
        {
            currentTime += Time.deltaTime;
            trackSource.volume = Mathf.Lerp(start, 0.2f, currentTime / 5);
            yield return null;
        }
        yield break;
    }
}
