using UnityEngine;

public class BulletView : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private ParticleSystem explosionParticles;
    private BulletController controller;

    public void SetController(BulletController controller)
    {
        this.controller = controller;
    }

    public void SetVelocity(float velocity)
    {
        rb.velocity = transform.forward * velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(explosionParticles, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
