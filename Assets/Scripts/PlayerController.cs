using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Power = 5;
    public enum ControlTypes
    {
        velocity,
        force,
        acceleration
    }
    public ControlTypes ControlType;
    private Rigidbody rb;
    private Vector3 movement;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        handlePlayerInput();
    }

    private void FixedUpdate()
    {
        if(ControlType == ControlTypes.velocity)
        {
            rb.velocity = movement;
        }else if (ControlType == ControlTypes.force)
        {
            rb.AddForce(movement);
        }
        else if (ControlType == ControlTypes.acceleration)
        {

        }
    }

    void handlePlayerInput()
    {
        float h = Input.GetAxis("Horizontal") * Power;
        float v = Input.GetAxis("Vertical") * Power;
        float n = 0;
        if (ControlType == ControlTypes.velocity) n = rb.velocity.y;

        movement = new Vector3(h, n, v);
    }
}
