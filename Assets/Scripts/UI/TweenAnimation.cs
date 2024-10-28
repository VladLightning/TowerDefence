using DG.Tweening;
using System.Collections;
using UnityEngine;

public class TweenAnimation : MonoBehaviour
{
    public IEnumerator PointAtoB(Transform objectToAnimate, Vector3 target, Ease easeType, float animationStartDelay, float animationDuration)
    {
        yield return new WaitForSeconds(animationStartDelay);

        objectToAnimate.DOMove(target, animationDuration).SetEase(easeType);
        yield return new WaitForSeconds(animationDuration);
        Destroy(objectToAnimate.gameObject);
    }

    public IEnumerator PointAtoZCurve(Transform objectToAnimate, Vector3[] path, Ease easeType, PathType pathType, PathMode pathMode, float animationStartDelay, float animationDuration)
    {
        yield return new WaitForSeconds(animationStartDelay);

        objectToAnimate.DOPath(path, animationDuration, pathType, pathMode).SetEase(easeType);
        yield return new WaitForSeconds(animationDuration);
        Destroy(objectToAnimate.gameObject);
    }

    public IEnumerator GraphicJump(Transform objectToAnimate, float animationStartDelay, float animationDuration, float jumpHeight)
    {
        yield return new WaitForSeconds(animationStartDelay);

        objectToAnimate.DOMove(objectToAnimate.transform.position + Vector3.up * jumpHeight, animationDuration);
        yield return new WaitForSeconds(animationDuration);
        objectToAnimate.DOMove(objectToAnimate.transform.position + Vector3.down * jumpHeight, animationDuration);
        yield return new WaitForSeconds(animationDuration);
    }
}
