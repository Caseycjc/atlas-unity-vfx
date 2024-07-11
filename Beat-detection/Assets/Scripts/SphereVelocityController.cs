using UnityEngine;

public class SphereVelocityController : MonoBehaviour
{
    public Vector3 velocity; // Velocity vector to be set at launch

    void Update()
    {
        float intensity = CalculateCurrentIntensity();
        // Move the sphere in the direction of the initial velocity, scaled by intensity
        transform.position += velocity * intensity * Time.deltaTime;
    }

    float CalculateCurrentIntensity()
    {
        float total = 0;
        for (int i = 0; i < AudioPeer._freqBand.Length; i++)
        {
            total += AudioPeer._freqBand[i];
        }
        float averageIntensity = total / AudioPeer._freqBand.Length;
        return Mathf.InverseLerp(0, 10, averageIntensity); // Normalized intensity, affects speed
    }
}
