using DG.Tweening;
using System.Collections;
using UnityEngine;

public class TweenAnimation : MonoBehaviour
{
    private bool _isPlaying;

    public void StartPointAtoBAnimation(Vector3 target, Ease easeType, float animationStartDelay, float animationDuration)
    {
        StartCoroutine(PointAtoB(target, easeType, animationStartDelay, animationDuration));
    }

    private IEnumerator PointAtoB(Vector3 target, Ease easeType, float animationStartDelay, float animationDuration)
    {
        yield return new WaitForSeconds(animationStartDelay);

        transform.DOMove(target, animationDuration).SetEase(easeType);
        yield return new WaitForSeconds(animationDuration);
        Destroy(gameObject);
    }

    public void StartGraphicJump(float animationStartDelay, float animationDuration, float jumpHeight)
    {
        if(!_isPlaying)
        {
            StartCoroutine(GraphicJump(animationStartDelay, animationDuration, jumpHeight));
        }       
    }

    private IEnumerator GraphicJump(float animationStartDelay, float animationDuration, float jumpHeight)
    {
        yield return new WaitForSeconds(animationStartDelay);

        _isPlaying = true;

        transform.DOMove(transform.position + Vector3.up * jumpHeight, animationDuration);
        yield return new WaitForSeconds(animationDuration);
        transform.DOMove(transform.position + Vector3.down * jumpHeight, animationDuration);
        yield return new WaitForSeconds(animationDuration);

        _isPlaying = false;
    }

    private void OnDisable()
    {
        transform.DOKill();
    }
}
