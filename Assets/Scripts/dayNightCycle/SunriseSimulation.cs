using UnityEngine;

public class SunriseSimulation : MonoBehaviour
{
    public static float CurrentOrbitAngle { get; private set; }
    public static bool IsDaytime { get; private set; }

    public Transform orbitCenter;
    public float orbitRadius = 150f;
    public float baseOrbitSpeed = 10f; // Base speed of the cycle
    public float dayLengthModifier = 1f; // Modify cycle speed (1 = normal, <1 = longer days, >1 = shorter days)
    public Light sunLight;
    public Transform sunSphere;

    public Material daySkybox;
    public Material nightSkybox;
    public Color dayFogColor = Color.cyan;
    public Color nightFogColor = Color.black;
    public float dayFogDensity = 0.002f;
    public float nightFogDensity = 0.01f;

    private float orbitAngle = -90f;

    void Update()
    {
        float modifiedOrbitSpeed = baseOrbitSpeed * (1f / dayLengthModifier);
        orbitAngle += modifiedOrbitSpeed * Time.deltaTime;
        if (orbitAngle > 360f) orbitAngle -= 360f;

        float x = orbitCenter.position.x + Mathf.Cos(Mathf.Deg2Rad * orbitAngle) * orbitRadius;
        float y = orbitCenter.position.y + Mathf.Sin(Mathf.Deg2Rad * orbitAngle) * orbitRadius;
        Vector3 sunPosition = new Vector3(x, y, orbitCenter.position.z);

        if (sunLight != null)
        {
            sunLight.transform.position = sunPosition;
            sunLight.transform.LookAt(orbitCenter);
            sunLight.intensity = Mathf.Lerp(sunLight.intensity, orbitAngle >= 0f ? 1f : 0f, 0.5f * Time.deltaTime);
        }

        if (sunSphere != null) sunSphere.position = sunPosition;

        IsDaytime = orbitAngle > 0f && orbitAngle < 180f;
        RenderSettings.skybox = IsDaytime ? daySkybox : nightSkybox;
        RenderSettings.fogColor = IsDaytime ? dayFogColor : nightFogColor;
        RenderSettings.fogDensity = Mathf.Lerp(RenderSettings.fogDensity, IsDaytime ? dayFogDensity : nightFogDensity, 0.5f * Time.deltaTime);
    }
}
