using System.Collections.Generic;
using UnityEngine;

public class HelixPlatformGenerator : MonoBehaviour
{
    [Header("Platform Settings")]
    public int rings = 18;
    public int segmentsPerRing = 12;
    public float ringHeight = 0.5f;
    public float ringRadius = 2.5f;
    public GameObject segmentPrefab;
    public Material[] materials;

    List<GameObject> createdSegments = new List<GameObject>();

    void Start()
    {
        Generate();
    }

    public void Generate()
    {
        Clear();
        for (int r = 0; r < rings; r++)
        {
            float y = -r * ringHeight;
            float angleOffset = (r % 2 == 0) ? 0f : (360f / segmentsPerRing) / 2f;
            for (int s = 0; s < segmentsPerRing; s++)
            {
                float angle = s * (360f / segmentsPerRing) + angleOffset;
                float rad = Mathf.Deg2Rad * angle;
                Vector3 pos = new Vector3(Mathf.Cos(rad) * ringRadius, y, Mathf.Sin(rad) * ringRadius);
                GameObject seg = Instantiate(segmentPrefab, transform);
                seg.transform.localPosition = pos;
                seg.transform.localRotation = Quaternion.Euler(0f, -angle, 0f);
                seg.name = $"seg_r{r}_s{s}";
                var rend = seg.GetComponent<Renderer>();
                if (rend && materials != null && materials.Length > 0)
                    rend.material = materials[(r + s) % materials.Length];
                createdSegments.Add(seg);
            }
        }
    }

    public void Clear()
    {
        foreach (var go in createdSegments) if (go) Destroy(go);
        createdSegments.Clear();
    }
}