using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    public HelixPlatformGenerator generator;
    public Transform ballSpawn;
    public TowerRotator towerRotator;

    void Awake()
    {
        Instance = this;
    }

    public void LoadLevel(int level)
    {
        if (generator == null) return;
        if (level == 1) {
            generator.rings = 12;
            generator.segmentsPerRing = 10;
            towerRotator.rotationSpeed = 40f;
        } else if (level == 2) {
            generator.rings = 18;
            generator.segmentsPerRing = 12;
            towerRotator.rotationSpeed = 55f;
        } else {
            generator.rings = 25;
            generator.segmentsPerRing = 14;
            towerRotator.rotationSpeed = 75f;
        }
        generator.Generate();
        ResetBallPosition();
    }

    public void ResetBallPosition()
    {
        var ball = GameObject.FindWithTag("Player");
        if (ball != null)
            ball.GetComponent<BallController>().ResetBall(ballSpawn.position);
    }
}