using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class DayAndNight : MonoBehaviour
{
    [Header("Time Settings")]
    [Range(0f, 24f)]
    public float currentTime;
    public float timespeed = 1f;

    [Header("CurrentTime")]
    public string currentTimeString;

    [Header("Light Settings")]
    public Light sunLight;
    public float sunposition = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateTimeText();
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime * timespeed;
        if (currentTime >= 24)
        {
            currentTime = 0;
        }

        UpdateTimeText();
        UpdateLight();
    }

    private void OValidate()
    {
        UpdateLight();
    }

    void UpdateTimeText()
    {
        currentTimeString = Mathf.Floor(currentTime).ToString("00") + ((currentTime % 1) * 60).ToString("00");
    }

    void UpdateLight()
    {
        float sunRotation = currentTime / 24f * 360f;
        sunLight.transform.rotation = Quaternion.Euler(sunRotation - 90f, sunposition, 0f);
    }
}
