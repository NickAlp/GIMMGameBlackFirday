using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticDoor : MonoBehaviour
{
    public Vector3 endPos;
    public float speed = 1.0f;

    private bool moving = false;
    private bool opening = true;
    private Vector3 startPos;
    private float delay = 0.0f;
    public bool battleStarted = false;

    private void Start()
    {
        startPos = transform.position;
        // Adjust endPos to move the door to the left by 5 units from the initial position
        endPos = new Vector3(startPos.x - 3.0f, startPos.y, startPos.z);
    }

    private void Update()
    {
        if (!battleStarted)
            if (moving)
            {
                MoveDoor(opening ? endPos : startPos);
            }
        if (GameObject.FindGameObjectsWithTag("Enemy").Length <= 0)
        {
            battleStarted = false;
        }
    }

    void MoveDoor(Vector3 goalPos)
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, goalPos, step);

        float dist = Vector3.Distance(transform.position, goalPos);
        if (dist <= 0.01f) // Checking if the door is close enough to the target position
        {
            if (opening)
            {
                delay += Time.deltaTime;
                if (delay > 1.5f)
                {
                    opening = false;
                    delay = 0f; // Reset delay
                }
            }
            else
            {
                moving = false;
                opening = true;
                delay = 0f; // Reset delay
            }
        }
    }

    public bool Moving
    {
        get { return moving; }
        set { moving = value; }
    }
}

