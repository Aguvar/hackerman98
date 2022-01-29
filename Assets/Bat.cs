using UnityEngine;
using UnityEngine.Events;

public class Bat : MonoBehaviour
{
    private float[] yPositions = { -3f, 0f, 3f };
    private int currentPositionYIndex = 1;
    private float currentPositionX;
    private float interpolationDistance = 0;

    public int lives = 3;

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
        currentPositionX = transform.position.x;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(currentPositionX, Mathf.Lerp(transform.position.y, yPositions[currentPositionYIndex], interpolationDistance), 0);

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
            interpolationDistance += Time.deltaTime * 0.1f;
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
