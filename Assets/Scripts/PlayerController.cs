using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    private PlayerMotor playerMotor;

    private void Start()
    {
        playerMotor = GetComponent<PlayerMotor>();
    }
	
	private void Update()
    {
        // Get movement input
        Vector3 velHorizontal = transform.right * Input.GetAxis("Horizontal");
        Vector3 velApplicate = transform.forward * Input.GetAxis("Applicate");
        Vector3 velVertical = transform.up * Input.GetAxis("Vertical");
        Vector3 velocity = (velHorizontal + velApplicate + velVertical);
        playerMotor.velocity = velocity;

         // Get rotation input
         Vector3 rotation = Vector3.zero;
        if (Input.GetMouseButton(1))
        {
            rotation.y = Input.GetAxisRaw("Mouse X");
            rotation.x = Input.GetAxisRaw("Mouse Y");
        }
        playerMotor.rotation = rotation;

        // Get movementspeedfactor input
        float movementSpeedFactor = 1;
        if (Input.GetKey(KeyCode.LeftShift))
            movementSpeedFactor *= 10;
        playerMotor.movementSpeedFactor = movementSpeedFactor;
    }
}
