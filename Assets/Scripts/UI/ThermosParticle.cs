using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThermosParticle : MonoBehaviour
{
    public Vector3 initialVelocity;
    public Vector3 velocityJitter;
    public float gravity;
    
    private Vector3 currentVelocity;
    private float currentRotationSpeed;

    public float rotationSpeed;
    public float rotationJitter;

    public float killPos;

    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        ApplyGravity();

        if (transform.position.y < killPos)
            KillParticle();
    }

    public void SetupMovement()
    {
        currentVelocity = initialVelocity + Vector3.right * velocityJitter.x * (Random.value * 2 - 1) + Vector3.up * velocityJitter.y * Random.value;
        currentRotationSpeed = rotationSpeed + rotationJitter * (Random.value * 2 - 1);
    }

    void Move()
    {
        transform.position += currentVelocity * Time.deltaTime;
        transform.Rotate(Vector3.forward * currentRotationSpeed * Time.deltaTime);
    }

    void ApplyGravity()
    {
        currentVelocity += Vector3.down * gravity * Time.deltaTime;
    }

    void KillParticle()
    {
        gameObject.SetActive(false);
    }
}
