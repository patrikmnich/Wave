using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    float duration = 2f;
    float magnitude = 8.0f;

    public IEnumerator Shake()
    {
        Vector3 originalPosition = transform.localPosition;
        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-2f, 3f) * magnitude;
            float y = Random.Range(-2f, 3f) * magnitude;

            transform.localPosition = new Vector3(originalPosition.x + x, originalPosition.y + y, originalPosition.z);
            elapsed += Time.fixedDeltaTime;
            yield return null;
        }
        transform.localPosition = originalPosition;
    }
}
