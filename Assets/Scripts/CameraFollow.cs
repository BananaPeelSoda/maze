using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float transitionSpeed = 10;

    private Vector3 offset;


    // Start is called before the first frame update
    void Start()
    {
        //calculate how far the camera is from the target
        offset = target.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //check if the player exists 
        if (target == null)
        {
            enabled = false;
            return;

        }

        Vector3 targetPosition = target.position - offset;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, transitionSpeed * Time.deltaTime);
    }
}
