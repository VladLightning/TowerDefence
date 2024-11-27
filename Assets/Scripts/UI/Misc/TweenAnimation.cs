using DG.Tweening;
using System.Collections;
using UnityEngine;

public class TweenAnimation : MonoBehaviour
{
    public IEnumerator PointAtoB(Transform objectToAnimate, Vector3 target, Ease easeType, float animationDuration)
    {
        objectToAnimate.DOMove(target, animationDuration).SetEase(easeType);
        yield return new WaitForSeconds(animationDuration);
    }

    public IEnumerator PointAtoZCurve(Transform objectToAnimate, Vector3[] path, Ease easeType, PathType pathType, float animationDuration)
    {
        objectToAnimate.DOPath(path, animationDuration, pathType, PathMode.TopDown2D).SetEase(easeType);
        yield return new WaitForSeconds(animationDuration);
    }

    public IEnumerator GraphicJump(Transform objectToAnimate, float animationDuration, float jumpHeight)
    {
        objectToAnimate.DOMove(objectToAnimate.transform.position + Vector3.up * jumpHeight, animationDuration);
        yield return new WaitForSeconds(animationDuration);
        objectToAnimate.DOMove(objectToAnimate.transform.position + Vector3.down * jumpHeight, animationDuration);
        yield return new WaitForSeconds(animationDuration);
    }
}
