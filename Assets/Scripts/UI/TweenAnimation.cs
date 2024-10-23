using DG.Tweening;
using System.Collections;
using UnityEngine;

public class TweenAnimation : MonoBehaviour
{
    private bool _isPlaying;

    public void StartPointAtoBAnimation(GameObject objectToAnimate, Vector3 target, Ease easeType, float animationStartDelay, float animationDuration)
    {
        StartCoroutine(PointAtoB(objectToAnimate, target, easeType, animationStartDelay, animationDuration));
    }

    private IEnumerator PointAtoB(GameObject objectToAnimate, Vector3 target, Ease easeType, float animationStartDelay, float animationDuration)
    {
        yield return new WaitForSeconds(animationStartDelay);

        objectToAnimate.transform.DOMove(target, animationDuration).SetEase(easeType);
        yield return new WaitForSeconds(animationDuration);
        Destroy(objectToAnimate);
    }

    public void StartGraphicJump(GameObject objectToAnimate, float animationStartDelay, float animationDuration, float jumpHeight)
    {
        if(!_isPlaying)
        {
            StartCoroutine(GraphicJump(objectToAnimate, animationStartDelay, animationDuration, jumpHeight));
        }       
    }

    private IEnumerator GraphicJump(GameObject objectToAnimate, float animationStartDelay, float animationDuration, float jumpHeight)
    {
        yield return new WaitForSeconds(animationStartDelay);

        _isPlaying = true;

        objectToAnimate.transform.DOMove(objectToAnimate.transform.position + Vector3.up * jumpHeight, animationDuration);
        yield return new WaitForSeconds(animationDuration);
        objectToAnimate.transform.DOMove(objectToAnimate.transform.position + Vector3.down * jumpHeight, animationDuration);
        yield return new WaitForSeconds(animationDuration);

        _isPlaying = false;
    }

    private void OnDisable()
    {
        transform.DOKill();
    }
}
