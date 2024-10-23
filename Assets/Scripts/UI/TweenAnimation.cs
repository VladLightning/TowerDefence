using DG.Tweening;
using System.Collections;
using UnityEngine;

public class TweenAnimation : MonoBehaviour
{
    public const float DEFAULT_ANIMATION_DURATION = 3;

    private bool _isPlaying;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartGraphicJump(0);
        }      
    }

    public void StartPointAtoBAnimation(Vector3 target, Ease easeType, float animationStartDelay)
    {
        StartCoroutine(PointAtoB(target, easeType, animationStartDelay));
    }

    private IEnumerator PointAtoB(Vector3 target, Ease easeType, float animationStartDelay)
    {
        yield return new WaitForSeconds(animationStartDelay);

        transform.DOMove(target, DEFAULT_ANIMATION_DURATION).SetEase(easeType);
        yield return new WaitForSeconds(DEFAULT_ANIMATION_DURATION);
        Destroy(gameObject);
    }

    public void StartGraphicJump(float animationStartDelay)
    {
        if(!_isPlaying)
        {
            StartCoroutine(GraphicJump(animationStartDelay));
        }       
    }

    private IEnumerator GraphicJump(float animationStartDelay)
    {
        yield return new WaitForSeconds(animationStartDelay);

        _isPlaying = true;

        float jumpDuration = 0.1f;

        transform.DOMove(transform.position + Vector3.up * 10, jumpDuration);
        yield return new WaitForSeconds(jumpDuration);
        transform.DOMove(transform.position + Vector3.down * 10, jumpDuration);
        yield return new WaitForSeconds(jumpDuration);

        _isPlaying = false;
    }

    private void OnDisable()
    {
        transform.DOKill();
    }
}
