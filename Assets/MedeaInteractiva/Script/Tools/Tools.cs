using System;
using System.Collections;
using UnityEngine;

public static class Tools
{
    public static IEnumerator Fade(int _start, int _target, float _duration, CanvasGroup _canvasGroup, Action onComplete = null)
    {
        float currentTime = 0f;
        while (currentTime < _duration)
        {
            currentTime += Time.deltaTime;
            float alpha = Mathf.Lerp(_start, _target, currentTime / _duration);
            _canvasGroup.alpha = alpha;
            yield return null;
        }

        onComplete?.Invoke();
    }

    public static IEnumerator Delay(float _delay, Action _action)
    {
        yield return new WaitForSeconds(_delay);
        _action?.Invoke();
    }
}