using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnableCanvasOnClick : MonoBehaviour
{
    public Canvas canvas;
    public float transitionDuration = 1f;
    public AnimationCurve transitionCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);

    private bool canvasEnabled = false;
    private Coroutine transitionCoroutine;

    private void Awake()
    {
        if (canvas != null)
        {
            canvas.enabled = false;
        }
    }

    private void OnMouseDown()
    {
        if (canvas != null)
        {
            if (canvasEnabled)
            {
                DisableCanvas();
            }
            else
            {
                EnableCanvas();
            }
        }
    }

    private void EnableCanvas()
    {
        if (transitionCoroutine != null)
        {
            StopCoroutine(transitionCoroutine);
        }
        transitionCoroutine = StartCoroutine(TransitionCanvas(true));
    }

    private void DisableCanvas()
    {
        if (transitionCoroutine != null)
        {
            StopCoroutine(transitionCoroutine);
        }
        transitionCoroutine = StartCoroutine(TransitionCanvas(false));
    }

    private IEnumerator TransitionCanvas(bool enable)
    {
        canvasEnabled = enable;
        float startAlpha = enable ? 0 : 1;
        float endAlpha = enable ? 1 : 0;
        float startTime = Time.time;
        while (Time.time - startTime < transitionDuration)
        {
            float t = (Time.time - startTime) / transitionDuration;
            float alpha = Mathf.Lerp(startAlpha, endAlpha, transitionCurve.Evaluate(t));
            canvas.GetComponent<CanvasGroup>().alpha = alpha;
            yield return null;
        }
        canvas.enabled = enable;
    }
}