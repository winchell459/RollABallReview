using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform Target;
    
    public enum FollowTypes
    {
        Offset,
        Smooth,
        Rotation,
        SmoothRotation
    }

    public FollowTypes FollowType;
    public float Smoothing = 1;

    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - Target.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(FollowType == FollowTypes.Offset)
        {
            transform.position = Target.position + offset;
        }else if (FollowType == FollowTypes.Smooth)
        {
            transform.position = Vector3.MoveTowards(transform.position, Target.position + offset, Smoothing * Time.fixedTime);
        }
        else if (FollowType == FollowTypes.Rotation)
        {
            transform.position = Target.position + offset;
            Vector3 direction = Target.GetComponent<Rigidbody>().velocity;
            direction = new Vector3(direction.x, 0, direction.z);
            if(direction.magnitude > 0)
            {

            }
        }
        else if (FollowType == FollowTypes.SmoothRotation)
        {
            transform.position = Vector3.MoveTowards(transform.position, Target.position + offset, Smoothing * Time.fixedTime);
        }
    }
}
