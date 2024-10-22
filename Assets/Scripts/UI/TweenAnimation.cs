using DG.Tweening;
using System.Collections;
using UnityEngine;

public class TweenAnimation : MonoBehaviour
{
    private const float ANIMATION_DURATION = 3;

    public void StartPointAtoBAnimation(Vector3 target, Ease easeType)
    {
        StartCoroutine(PointAtoB(target, easeType));
    }

    private IEnumerator PointAtoB(Vector3 target, Ease easeType)
    {
        transform.DOMove(target, ANIMATION_DURATION).SetEase(easeType);
        yield return new WaitForSeconds(ANIMATION_DURATION);
        Destroy(gameObject);
    }

    private void OnDisable()
    {
        transform.DOKill();
    }
}
