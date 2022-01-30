using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firewall : MonoBehaviour
{
    private float[] yPositions = { -0.35f, -0.10f, 0.15f };
    public int currentPositionYIndex = 1;
    public float speed = 1f;

    public SpriteRenderer spriteRenderer;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyAfterXSeconds(5));
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3(transform.localPosition.x - Time.deltaTime * speed, yPositions[currentPositionYIndex], 0);
    }

    IEnumerator DestroyAfterXSeconds(int seconds)
    {
        yield return new WaitForSeconds(seconds);

        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        spriteRenderer.enabled = false;
        audioSource.Play();
    }
}
