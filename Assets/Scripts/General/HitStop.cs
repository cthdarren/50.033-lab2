using System.Collections;
using UnityEngine;

public class HitStop : MonoBehaviour
{
    private bool isWaiting;
    public void Stop(float duration_seconds)
    {
        if (isWaiting) return;
        StartCoroutine(WaitAsync(duration_seconds));
    }

    public IEnumerator WaitAsync(float duration_seconds)
    {
        isWaiting = true;
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(duration_seconds);
        Time.timeScale = 1f;
        isWaiting = false ;
    }
}
