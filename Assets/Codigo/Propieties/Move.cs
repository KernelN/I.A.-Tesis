using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed;
    public float rotateSpeed;
    float MoveTotal;
    float RotateTotal;
    Vector2 velocity;
    Rigidbody rb;



    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }


    public void StartLeftRotation()
    {
        rb.constraints = RigidbodyConstraints.None;
        rotateSpeed = 200;
    }

    public void StartRightRotation()
    {
        rb.constraints = RigidbodyConstraints.None;
        rotateSpeed = -200;
    }

    public void EndRotation()
    {
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        rotateSpeed = 0;
    }

    public void StartMove()
    {
        rb.constraints = RigidbodyConstraints.None;
        speed = 10;
    }

    public void EndMove()
    {
        rb.constraints = RigidbodyConstraints.FreezePosition;
        speed = 0;
    }

    public void FreezeExtras()
    {
        rb.constraints = RigidbodyConstraints.FreezeRotationY;
        rb.constraints = RigidbodyConstraints.FreezeRotationX;
        rb.constraints = RigidbodyConstraints.FreezePositionZ;
        if (transform.rotation.x < -2 || transform.rotation.x > 2)
        {
            float x = transform.rotation.x;
            float y = transform.rotation.y;
            float z = transform.rotation.z;
            transform.rotation = Quaternion.Euler(x - x, y, z);
        }
        else if (transform.rotation.y < -1 || transform.rotation.y > 1)
        {
            float x = transform.rotation.x;
            float y = transform.rotation.y;
            float z = transform.rotation.z;
            transform.rotation = Quaternion.Euler(x, y - y, z);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.name == "Top" || other.name == "Left Wall" || other.name == "Right Wall" || other.name == "Floor (trigger)")
        {
            EndMove();
            StartLeftRotation();
        }
    }

    void Update()
    {
        MoveTotal = Mathf.Abs(speed);

        RotateTotal = Mathf.Abs(rotateSpeed);

        transform.position += (transform.up * speed * Time.deltaTime);
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
        FreezeExtras();

     //   Energy.instance.energy -= (MoveTotal + (RotateTotal)) * gameObject.GetComponent<Energy>().size;
    }
}
