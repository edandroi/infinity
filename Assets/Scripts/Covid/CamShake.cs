using UnityEngine;
using System.Collections;

public class CamShake : MonoBehaviour
{
    // Transform of the camera to shake. Grabs the gameObject's transform
    // if null.
    public Transform camTransform;
	
    // How long the object should shake for.
    float shakeDuration;
    public float shakeDurationTotal = 0f;
	
    // Amplitude of the shake. A larger value shakes the camera harder.
    public float shakeAmount = 0.7f;
    public float decreaseFactor = 1.0f;
	
    Vector3 originalPos;
    public static bool shakingNow = false;

	
    void Awake()
    {
        if (camTransform == null)
        {
            camTransform = Camera.main.GetComponent(typeof(Transform)) as Transform;
        }
        
        originalPos = camTransform.position;
        shakeDuration = shakeDurationTotal;
    }

    void Update()
    {
        
        if (shakingNow)
            CamShaking();
    }

    void CamShaking()
    {
        if (shakeDuration > 0)
        {
            camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
			
            shakeDuration -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shakeDuration = shakeDurationTotal;
            camTransform.localPosition = originalPos;
            shakingNow = false;
        }
    }
}