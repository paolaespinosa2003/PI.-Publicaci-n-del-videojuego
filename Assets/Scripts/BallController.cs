using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(AudioSource))]
public class BallController : MonoBehaviour
{
    public float bounceForce = 6f;
    public float maxFallSpeed = 25f;
    Rigidbody rb;
    public ParticleSystem hitParticles;
    public AudioClip bounceSfx;
    AudioSource audioSource;
    bool isDead = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (rb.velocity.y < -maxFallSpeed)
            rb.velocity = new Vector3(rb.velocity.x, -maxFallSpeed, rb.velocity.z);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (isDead) return;

        if (collision.gameObject.CompareTag("Platform"))
        {
            ContactPoint cp = collision.contacts[0];
            if (Vector3.Dot(cp.normal, Vector3.up) > 0.5f)
            {
                rb.velocity = new Vector3(rb.velocity.x, bounceForce, rb.velocity.z);
                if (hitParticles) hitParticles.Play();
                if (bounceSfx && audioSource) audioSource.PlayOneShot(bounceSfx);
                if (GameManager.Instance != null) GameManager.Instance.AddScore(10);
            }
        }

        if (collision.gameObject.CompareTag("DeadZone"))
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;
        rb.isKinematic = true;
        if (GameManager.Instance != null) GameManager.Instance.OnPlayerDeath();
    }

    public void ResetBall(Vector3 pos)
    {
        isDead = false;
        transform.position = pos;
        rb.isKinematic = false;
        rb.velocity = Vector3.zero;
    }
}