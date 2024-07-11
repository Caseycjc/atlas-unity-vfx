using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereLauncher : MonoBehaviour
{
    public GameObject spherePrefab;
    public Transform playerTransform;
    public float maxInterval = 2.0f; // Maximum time between launches
    public float minInterval = 0.5f; // Minimum time between launches
    public float baseSpeed = 5.0f; // Base speed for launching spheres
    public float initialDelay = 5.0f; // Initial delay before first launch
    private float timeSinceLastLaunch = 0;
    private float launchInterval;
    private bool firstLaunch = true; // Flag to check if it's the first launch

    void Start()
    {
        // Initialize with max interval at start
        launchInterval = maxInterval;
    }

    void Update()
    {
        float intensity = CalculateIntensity();
        // Adjust launch interval based on intensity, scale intensity impact
        launchInterval = Mathf.Clamp(maxInterval - (intensity * 3), minInterval, maxInterval);

        if (firstLaunch)
        {
            // If it's the first launch, wait for the initial delay
            if (timeSinceLastLaunch >= initialDelay)
            {
                LaunchSphere();
                timeSinceLastLaunch = 0;
                firstLaunch = false; // Set first launch to false after the first sphere is launched
            }
        }
        else
        {
            // Regular interval checking after the first launch
            if (timeSinceLastLaunch >= launchInterval)
            {
                LaunchSphere();
                timeSinceLastLaunch = 0;
            }
        }
        
        // Always increment the time counter
        timeSinceLastLaunch += Time.deltaTime;
    }

    void LaunchSphere()
    {
        GameObject sphere = Instantiate(spherePrefab, transform.position, Quaternion.identity);
        
        // Calculate initial direction towards the player
        Vector3 direction = (playerTransform.position - transform.position).normalized;
        float intensity = CalculateIntensity();
        float initialSpeed = baseSpeed + (intensity * 10);

        // Attach and initialize the SphereVelocityController
        SphereVelocityController controller = sphere.AddComponent<SphereVelocityController>();
        controller.velocity = direction * initialSpeed; // Set initial velocity that will be maintained
    }





    float CalculateIntensity()
    {
        float total = 0;
        for (int i = 0; i < AudioPeer._freqBand.Length; i++)
        {
            total += AudioPeer._freqBand[i];
        }
        float averageIntensity = total / AudioPeer._freqBand.Length;
        // Normalize the intensity value to ensure it's within a usable range
        float normalizedIntensity = Mathf.InverseLerp(0, 10, averageIntensity); // Adjust the max value based on observed intensities
        Debug.Log("Normalized Intensity: " + normalizedIntensity);
        return normalizedIntensity;
    }
}
