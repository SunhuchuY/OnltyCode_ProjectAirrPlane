using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class PlaneControllor : MonoBehaviour
{

    private float _forwardSpeed = 10f;


    public float forwardSpeed 
    {
        get 
        {
            return _forwardSpeed;
        }

        set 
        {
            EventBus.Publish(EventType.Hud);

            if (value <= maxForwardSpeed && value > 0)
                _forwardSpeed = value;

        }

    }


    public float rotationSpeed = 3f;
    public float horizontalSpeed = 2f;


    private const float maxHorizontal = 30f;
    private const float maxRotation = 20f;
    private const float maxForwardSpeed = 300f;




    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // 전진/후진 이동
        float verticalInput = Input.GetAxis("Vertical");
        forwardSpeed += verticalInput;
        Debug.Log(forwardSpeed);
        Vector3 forwardForce = transform.rotation * Vector3.right * forwardSpeed;
        rb.AddForce(forwardForce);

        // horizontal
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(new Vector3(0, horizontalInput * horizontalSpeed, 0), Space.Self);

        // rotation and run
        float axisInput = Input.GetAxis("Axis");
        transform.Rotate(Vector3.right * axisInput * rotationSpeed, Space.Self);

        float rawInput = Input.GetAxis("Raw");
        transform.Rotate(Vector3.forward * rawInput * rotationSpeed, Space.Self);

        // Limit
        //LimitVelocity();
        //LimitHorizontal();
    }

    void LimitVelocity()
    {
        // 전진 속도 제한
        if (rb.velocity.magnitude > forwardSpeed)
        {
            rb.velocity = rb.velocity.normalized * forwardSpeed;
        }

        // 회전 속도 제한
        if (rb.angularVelocity.magnitude > rotationSpeed)
        {
            rb.angularVelocity = rb.angularVelocity.normalized * rotationSpeed;
        }
    }

    void LimitHorizontal()
    {
        float currentRotationY = transform.rotation.eulerAngles.y;
        
        if (currentRotationY > 180)
        {
            currentRotationY -= 360;
        }


        if (currentRotationY > maxHorizontal)
        {
            currentRotationY = maxHorizontal;
        }
        else if (currentRotationY < -maxHorizontal)
        {
            currentRotationY = -maxHorizontal;
        }

        transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x, currentRotationY, transform.rotation.eulerAngles.z));
    }

    void LimitRotation()
    {
        float currentRotationX = transform.rotation.eulerAngles.x;

        if (currentRotationX > 180)
        {
            currentRotationX -= 360;
        }

        if (currentRotationX > maxRotation)
        {
            currentRotationX = maxRotation;
        }
        else if (currentRotationX < -maxRotation)
        {
            currentRotationX = -maxRotation;
        }

        transform.rotation = Quaternion.Euler(new Vector3(currentRotationX, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z));

        float currentRotationZ = transform.rotation.eulerAngles.z;

        if (currentRotationZ > 180)
        {
            currentRotationZ -= 360;
        }

        if (currentRotationZ > maxRotation)
        {
            currentRotationZ = maxRotation;
        }
        else if (currentRotationZ < -maxRotation)
        {
            currentRotationZ = -maxRotation;
        }

        transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, currentRotationZ));
    }

    public int GetSpeed()
    {
        return (int)forwardSpeed;
    }
}
