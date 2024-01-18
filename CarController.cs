using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{

    // Settings
    public float MoveSpeed = 50;
    public float MaxSpeed = 15;
    public float Drag = 0.98f;
    public float SteerAngle = 20;
    public float Traction = 1;
    public GameObject[] WheelMesh = new GameObject[4];
    public WheelCollider[] wheelCollider = new WheelCollider[4];


    private Vector3 MoveForce;

    // Update is called once per frame
    private void FixedUpdate()
    {
        AnimateWheels();

        // Moving
        MoveForce += transform.forward * MoveSpeed * Time.deltaTime;
        transform.position += MoveForce * Time.deltaTime;

        // Steering
        float steerInput = Input.GetKey(KeyCode.Space) ? 1.0f : 0.0f;
        if (steerInput != 0.0f)
        {
            transform.Rotate(Vector3.up * steerInput * MoveForce.magnitude * SteerAngle * Time.deltaTime);
        }
        else
        {
            // Reset rotation when the space key is not pressed
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, Time.deltaTime);
        }

       
        MoveForce *= Drag;
        MoveForce = Vector3.ClampMagnitude(MoveForce, MaxSpeed);

        // Traction
        Debug.DrawRay(transform.position, MoveForce.normalized * 3);
        Debug.DrawRay(transform.position, transform.forward * 3, Color.blue);
        MoveForce = Vector3.Lerp(MoveForce.normalized, transform.forward, Traction * Time.deltaTime) * MoveForce.magnitude;
    }



    void AnimateWheels()
    {
        for (int i = 0; i < 4; i++)
        {
            Vector3 wheelPosition;
            Quaternion wheelRotation;
            wheelCollider[i].GetWorldPose(out wheelPosition, out wheelRotation);
            WheelMesh[i].transform.position = wheelPosition;
            WheelMesh[i].transform.rotation = wheelRotation * Quaternion.Euler(0, 0, 90); 
        }
    }
}