using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firewall : MonoBehaviour
{
    private float[] yPositions = { -3f, 0f, 3f };
    public int currentPositionYIndex = 1;
    public float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyAfterXSeconds(5));
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x - Time.deltaTime * speed, yPositions[currentPositionYIndex], 0);
    }

    IEnumerator DestroyAfterXSeconds(int seconds)
    {
        yield return new WaitForSeconds(seconds);

        Destroy(gameObject);
    }
}
