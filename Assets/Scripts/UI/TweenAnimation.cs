using DG.Tweening;
using System.Collections;
using UnityEngine;

public class TweenAnimation : MonoBehaviour
{
    private bool _isPlaying;

    public IEnumerator PointAtoB(Transform objectToAnimate, Vector3 target, Ease easeType, float animationStartDelay, float animationDuration)
    {
        yield return new WaitForSeconds(animationStartDelay);

        objectToAnimate.DOMove(target, animationDuration).SetEase(easeType);
        yield return new WaitForSeconds(animationDuration);
        Destroy(objectToAnimate.gameObject);
    }

    public IEnumerator GraphicJump(Transform objectToAnimate, float animationStartDelay, float animationDuration, float jumpHeight)
    {
        if(_isPlaying)
        {
            yield break;
        }
        yield return new WaitForSeconds(animationStartDelay);

        _isPlaying = true;

        objectToAnimate.DOMove(objectToAnimate.transform.position + Vector3.up * jumpHeight, animationDuration);
        yield return new WaitForSeconds(animationDuration);
        objectToAnimate.DOMove(objectToAnimate.transform.position + Vector3.down * jumpHeight, animationDuration);
        yield return new WaitForSeconds(animationDuration);

        _isPlaying = false;
    }

    private void OnDisable()
    {
        transform.DOKill();
    }
}
