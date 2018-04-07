using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{


    // Transform of the camera to shake. Grabs the gameObject's transform
    // if null.
    public Transform camTransform;

    // How long the object should shake for.
    public float shakeDuration = 0f;

    // Amplitude of the shake. A larger value shakes the camera harder.
    public float shakeAmount = 0.7f;
    public float decreaseFactor = 1.0f;
    public bool shake1 = false;
    public bool shake2 = false;
    public bool shake3 = false;

    Vector3 originalPos;

    void Awake()
    {
        if (camTransform == null)
        {
            camTransform = GetComponent(typeof(Transform)) as Transform;
        }
    }

    void OnEnable()
    {
        originalPos = camTransform.localPosition;
    }

    void Update()
    {
        //boss shake
        if (shake1 == true)
        {
            shakeDuration = 1;
            shake1 = false;
        }

        if (shake2 == true)
        {
            shakeDuration = 1;
            shake2 = false;
        }

        if (shake3 == true)
        {
            shakeDuration = 1;
            shake3 = false;
        }


        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            shakeDuration = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            shakeDuration = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            shakeDuration = 3;
        }


        if (shakeDuration > 0)
        {
            camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

            shakeDuration -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shakeDuration = 0f;
            camTransform.localPosition = originalPos;
        }
    }


}