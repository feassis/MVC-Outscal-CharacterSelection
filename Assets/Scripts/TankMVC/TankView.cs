using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankView : MonoBehaviour, IDamageble
{
    private TankController tankController;
    private float movement;
    private float rotation;
    [field: SerializeField] public Rigidbody Rb { get; private set; }
    [field: SerializeField] public MeshRenderer[] childs {  get; private set; }
    [SerializeField] private Slider aimSlider;
    [field: SerializeField] public Transform projectileSpawnPosition;
    [field: SerializeField] public Transform hommingSpawnPosition;
    [field: SerializeField] public Transform piercingSpawnPosition;
    [SerializeField] private BulletView bulletView;
    [SerializeField] private AudioSource shootingSound;
    [SerializeField] private AudioSource shootingChargeSound;
    [SerializeField] private float cameraShakeDuration = 0.4f;
    [SerializeField] private float cameraShakeMagnitude = 10f;
    [field: SerializeField] public GameObject Mesh;

    private float aimValue;
    private float aimMaxChargeTime;
    private bool isGuided;

    public EnemyView Target {  get; private set; }

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

    public void SetIsGuided(bool isGuided)
    {
        this.isGuided = isGuided;
    }

    public void TakeDamage(int damage, int piercing)
    {
        this.tankController.TakeDamage(damage, piercing);
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
            this.tankController.Rotate(rotation);
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
            Target = null;

        }

        if (Input.GetMouseButton(0))
        {
            aimValue += Time.deltaTime;
            aimSlider.normalizedValue = GetAimValuePecentage();
            Targeting();
        }

        if(Input.GetMouseButtonUp(0))
        {
            if(Target != null)
            {
                Target.IsBeingTarget(false);
            }
            this.tankController.Shoot(GetAimValuePecentage(), bulletView);
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

    private void Targeting()
    {
        if(!isGuided)
        {
            return;
        }

        var enemies = tankController.GetEnemies();

        float closestDistance = float.MaxValue;

        Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);

        foreach(var enemy in enemies)
        {
            if(IsObjectVisible(Camera.main, enemy))
            {
                Vector3 screenPosition = Camera.main.WorldToScreenPoint(enemy.transform.position);

                // Calcular a distância até o centro da tela
                float distance = Vector2.Distance(screenPosition, screenCenter);

                // Verificar se essa distância é a menor encontrada até agora
                if (distance < closestDistance)
                {
                    if(Target != null)
                    {
                        Target.IsBeingTarget(false);
                    }

                    closestDistance = distance;
                    Target = enemy;
                }
            }
        }
        
        if(Target != null)
        {
            Target.IsBeingTarget(true);
        }
    }

    private bool IsObjectVisible(Camera camera, EnemyView enemy)
    {
        Vector3 viewportPosition = camera.WorldToViewportPoint(enemy.transform.position);

        bool isVisible = viewportPosition.x >= 0 && viewportPosition.x <= 1 &&
                         viewportPosition.y >= 0 && viewportPosition.y <= 1 &&
                         viewportPosition.z > 0;

        return isVisible;
    }
}
