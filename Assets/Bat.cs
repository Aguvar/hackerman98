using UnityEngine;

public class Bat : MonoBehaviour
{
    private float[] yPositions = { -3f, 0f, 3f };
    private int currentPositionYIndex = 1;
    private float currentPositionX;
    private float interpolationDistance = 0;

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
}
