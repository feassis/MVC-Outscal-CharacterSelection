using UnityEngine;

public class BulletView : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private ParticleSystem explosionParticles;
    private BulletController controller;

    private Transform target;
    private float velocity;
    private const float turningSpeed = 0.01f;

    private bool shouldDestroyTarget = false;

    public void SetDestroyTarget(bool destroyTarget)
    {
        shouldDestroyTarget = destroyTarget;
    }

    private void OnDestroy()
    {
        if(shouldDestroyTarget)
        {
            Destroy(target.gameObject);
        }
    }

    public void SetController(BulletController controller)
    {
        this.controller = controller;
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
    }

    public void ToggleGravity(bool gravity)
    {
        rb.useGravity = gravity;
    }

    public void SetVelocity(float velocity)
    {
        this.velocity = velocity;
        rb.velocity = transform.forward * velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(explosionParticles, transform.position, Quaternion.identity);
        controller.CalculateBlastZone();
    }

    private void Update()
    {
        if(target != null)
        {
            var dir = (target.position - transform.position).normalized;

            rb.velocity = Vector3.Lerp(rb.velocity, dir * velocity, turningSpeed);

            Quaternion rotation = Quaternion.LookRotation(rb.velocity);
            rb.rotation = rotation;
        }


    }
}

