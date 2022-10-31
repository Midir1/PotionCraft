using System.Collections;
using UnityEngine;

public class ShakeScreen : MonoBehaviour
{
    [SerializeField] private AnimationCurve curve;
    [SerializeField] private float duration;

    private bool isShaking = false;

    private void Update()
    {
        if(!isShaking && (Input.GetMouseButtonDown(0) || Input.touchCount == 1))
        {
            StartCoroutine(ShakingEffect());
        }
    }

    private IEnumerator ShakingEffect()
    {
        isShaking = true;

        Vector3 startPosition = transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            var strength = curve.Evaluate(elapsedTime / duration);

            transform.position = startPosition + Random.insideUnitSphere * strength;
            yield return null;
        }

        transform.position = startPosition;
        isShaking = false;
    }
}