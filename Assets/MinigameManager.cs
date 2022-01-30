using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MinigameManager : MonoBehaviour
{
    public GameObject firewallPrefab;

    public float timeBetweenSpawns = 3;

    public GameObject gameArea;
    public Bat bat;

    public GameObject heartPrefab;
    public GameObject heartContainer;
    public Slider progressBar;
    public float gameTime = 1f;


    private float progress = 0;

    private List<GameObject> UIHearts;
    private GameObject[] hazardList;
    public UnityEvent gameOverEvent;

    private float spawnTimeCounter = 0f;
    // Start is called before the first frame update
    private void Awake()
    {
        if (gameOverEvent == null)
        {
            gameOverEvent = new UnityEvent();
        }
    }

    void initializeHearts()
    {
        UIHearts = new List<GameObject>();
        bat.gotHurtEvent.AddListener(gotHurt);
        for (int i = 0; i < bat.lives; i++)
        {
            GameObject UIHeart = Instantiate(heartPrefab);
            UIHearts.Add(UIHeart);
            UIHeart.transform.parent = heartContainer.transform;
        }
    }
    void Start()
    {
        initializeHearts();
    }
    void DestroyHazards()
    {
        hazardList = GameObject.FindGameObjectsWithTag("Hazard");
        foreach (GameObject hazardo in hazardList)
        {
            Destroy(hazardo);
        }
    }


    // Update is called once per frame
    void Update()
    {
        spawnTimeCounter += Time.deltaTime;

        if (spawnTimeCounter > timeBetweenSpawns)
        {
            spawnTimeCounter = 0;

            int positionYIndex = Random.Range(0, 3);

            GameObject firewall = Instantiate(firewallPrefab);

            firewall.transform.parent = gameArea.transform;

            firewall.GetComponent<Firewall>().currentPositionYIndex = positionYIndex;
        }

        progress += Time.deltaTime / gameTime;
        progressBar.value = progress;
    }

    public void gotHurt()
    {
        if (bat.lives == 0)
        {
            gameOverEvent.Invoke();
        }
        else
        {
            Destroy(UIHearts[bat.lives]);
        }
    }
    public void hideMinigame()
    {
        progressBar.value = 0f;
        progress = 0f;
        DestroyHazards();
        progressBar.gameObject.SetActive(false);
        heartContainer.gameObject.SetActive(false);
        gameArea.SetActive(false);
        gameObject.SetActive(false);

    }
    public void EnableMinigame()
    {
        progressBar.gameObject.SetActive(true);
        heartContainer.gameObject.SetActive(true);
        gameArea.SetActive(true);
        
    }
}
