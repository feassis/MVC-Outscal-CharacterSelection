using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankView : MonoBehaviour
{
    private TankController tankController;
    private float movement;
    private float rotation;
    [field: SerializeField] public Rigidbody Rb { get; private set; }

    private void Start()
    {
        GameObject cam = Camera.main.gameObject;
        cam.transform.parent = transform;  
        cam.transform.position = new Vector3 (0f, 3f, -4f);
    }

    public void SetTankController(TankController tankController)
    {
        this.tankController = tankController;
    }

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        movement = Input.GetAxis("Vertical");
        rotation = Input.GetAxis("Horizontal");

        if(movement != 0)
        {
            this.tankController.Move(movement, tankController.GetTankModel().movementSpeed);
        }

        if(rotation != 0)
        {
            this.tankController.Rotate(rotation, tankController.GetTankModel().rotationSpeed);
        }
    }
}
