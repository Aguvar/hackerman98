using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameManager : MonoBehaviour
{
    public GameObject firewallPrefab;

    public float timeBetweenSpawns = 3;

    private float spawnTimeCounter = 0f;
    // Start is called before the first frame update
    void Start()
    {
           
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
    }
}
