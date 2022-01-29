using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinigameManager : MonoBehaviour
{
    public GameObject firewallPrefab;

    public float timeBetweenSpawns = 3;

    public Bat bat;

    public GameObject heartPrefab;
    public GameObject heartContainer;
    public Slider progressBar;
    public float gameTime = 1f;

    private float progress = 0;

    private List<GameObject> UIHearts;

    private float spawnTimeCounter = 0f;
    // Start is called before the first frame update
    void Start()
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

    // Update is called once per frame
    void Update()
    {
        spawnTimeCounter += Time.deltaTime;

        if (spawnTimeCounter > timeBetweenSpawns)
        {
            spawnTimeCounter = 0;

            int positionYIndex = Random.Range(0, 3);

            GameObject firewall = Instantiate(firewallPrefab);

            firewall.GetComponent<Firewall>().currentPositionYIndex = positionYIndex;
        }

        progress += Time.deltaTime / gameTime;
        progressBar.value = progress;
    }

    public void gotHurt()
    {
        Destroy(UIHearts[bat.lives]);
    }

}
