using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollowingCamera : MonoBehaviour
{
    private List<Transform> targets = new List<Transform>();
    private Vector3 offset = new Vector3(0, 1.51f, -4.09f);
    private int targetindex;
    private void Start()
    {
        targets = RacingPlay.Instance.GetHorsesTransforms();
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            targetindex = 0;
        else if (Input.GetKeyDown(KeyCode.Alpha2))
            targetindex = 1;
        else if (Input.GetKeyDown(KeyCode.Alpha3))
            targetindex = 2;
        else if (Input.GetKeyDown(KeyCode.Alpha4))  
            targetindex = 3;
        else if (Input.GetKeyDown(KeyCode.Alpha5))
            targetindex = 4;
    }
    private void LateUpdate()
    {
        FollowTarget();
    }

    private void FollowTarget()
    {
        transform.position = targets[targetindex].position + offset;
    }
}
