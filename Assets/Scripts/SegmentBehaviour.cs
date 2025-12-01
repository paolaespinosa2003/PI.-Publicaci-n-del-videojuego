using UnityEngine;

public class SegmentBehaviour : MonoBehaviour
{
    public bool isSafe = true;
    public GameObject breakParticlesPrefab;

    void Start()
    {
        gameObject.tag = "Platform";
        if (!GetComponent<Collider>())
        {
            var col = gameObject.AddComponent<BoxCollider>();
            col.size = new Vector3(1.2f, 0.3f, 0.6f);
        }
    }

    public void Break()
    {
        if (breakParticlesPrefab)
            Instantiate(breakParticlesPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}