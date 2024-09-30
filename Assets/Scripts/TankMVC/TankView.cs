using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankView : MonoBehaviour
{
    private TankController tankController;
    private float movement;
    private float rotation;
    [field: SerializeField] public Rigidbody Rb { get; private set; }
    [field: SerializeField] public MeshRenderer[] childs {  get; private set; }
    [SerializeField] private Slider aimSlider;
    [field: SerializeField] public Transform projectileSpawnPosition;
    [SerializeField] private BulletView bulletView;
    [SerializeField] private AudioSource shootingSound;
    [SerializeField] private AudioSource shootingChargeSound;
    [SerializeField] private float cameraShakeDuration = 0.4f;
    [SerializeField] private float cameraShakeMagnitude = 10f;

    private float aimValue;
    private float aimMaxChargeTime;

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

    public void SetAimMaxCharge(float aimMaxCharge)
    {
        aimMaxChargeTime = aimMaxCharge;
    }

    private void Update()
    {
        Movement();
        Shooting();
    }

    private void Movement()
    {
        movement = Input.GetAxis("Vertical");
        rotation = Input.GetAxis("Horizontal");

        if(movement != 0)
        {
            this.tankController.Move(movement, tankController.GetTankModel().MovementSpeed);
        }

        if(rotation != 0)
        {
            this.tankController.Rotate(rotation, tankController.GetTankModel().RotationSpeed);
        }
    }
    private float GetAimValuePecentage()
    {
        return Mathf.Clamp(aimValue / aimMaxChargeTime, 0, 1);
    }

    public void ChangeColor(Material color)
    {
        for (int i = 0; i < childs.Length; i++)
        {
            childs[i].material = color;
        }
    }

    private void Shooting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            shootingChargeSound.Play();
        }

        if (Input.GetMouseButton(0))
        {
            aimValue += Time.deltaTime;
            aimSlider.normalizedValue = GetAimValuePecentage();
        }

        if(Input.GetMouseButtonUp(0))
        {
            this.tankController.Shoot(GetAimValuePecentage(), bulletView, projectileSpawnPosition);
            shootingSound.Play();
            shootingChargeSound.Stop();
            aimSlider.normalizedValue = 0;
            aimValue = 0;
            if(Camera.main.TryGetComponent<CameraShake>(out CameraShake shake))
            {
                StartCoroutine(shake.Shake(cameraShakeDuration, cameraShakeMagnitude));
            }
        }
    }
}
