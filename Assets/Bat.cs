using UnityEngine;
using UnityEngine.Events;

public class Bat : MonoBehaviour
{
    private float[] yPositions = { -0.35f, -0.10f, 0.15f };
    private int currentPositionYIndex = 1;
    private float currentPositionX;
    private float interpolationDistance = 0;

    public int lives = 3;
    public float speed = 1;

    public UnityEvent gotHurtEvent;


    private void Awake()
    {
        if (gotHurtEvent == null)
        {
            gotHurtEvent = new UnityEvent();
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        currentPositionX = transform.localPosition.x;

    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3(currentPositionX, Mathf.Lerp(transform.localPosition.y, yPositions[currentPositionYIndex], interpolationDistance), 0);

        if (Input.GetKeyDown(KeyCode.W) && currentPositionYIndex < 2)
        {
            currentPositionYIndex++;
            interpolationDistance = 0;
        }
        else if (Input.GetKeyDown(KeyCode.S) && currentPositionYIndex > 0)
        {
            currentPositionYIndex--;
            interpolationDistance = 0;
        }

        if (interpolationDistance < 1)
        {
            interpolationDistance += Time.deltaTime * (speed / 10);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Contains("Hazard"))
        {
            lives--;
            gotHurtEvent.Invoke();
        }
    }
}
