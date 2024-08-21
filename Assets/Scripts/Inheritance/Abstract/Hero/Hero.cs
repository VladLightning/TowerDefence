using System.Collections;
using UnityEngine;
public abstract class Hero : Mob
{
    private const float DISTANCE_THRESHOLD = 0.1f;

    private IEnumerator _move;

    private float _skillCooldown;
    private float _respawnTime;
    private float _regenerationDelay;
    private float _regenerationInterval;
    private int _regenerationAmount;

    public void Initiate(HeroData heroData)
    {
        _damage = heroData.Damage;
        _attackSpeed = heroData.AttackSpeed;
        _damageType = heroData.DamageType;
        _health = heroData.Health;
        _movementSpeed = heroData.MovementSpeed;
        _skillCooldown = heroData.SkillCooldown;
        _respawnTime = heroData.RespawnTime;
        _regenerationDelay = heroData.RegenerationDelay;
        _regenerationInterval = heroData.RegenerationInterval;
        _regenerationAmount = heroData.RegenerationAmount;
    }

    private void LookAtMouse(Vector2 targetPosition)
    {
        transform.localScale =
         (targetPosition.x < transform.position.x)
         ? new Vector2(-Mathf.Abs(transform.localScale.x), transform.localScale.y)
         : new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);
    }

    private IEnumerator Move(Vector2 targetPosition)
    {
        while (Vector2.Distance(transform.position, targetPosition) > DISTANCE_THRESHOLD)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, _movementSpeed * Time.deltaTime);
            yield return new WaitForFixedUpdate();
        }
    }

    private void Skill()
    {
        throw new System.NotImplementedException();
    }

    private void RegenerateHealth()
    {
        throw new System.NotImplementedException();
    }

    protected override void Move()
    {
        throw new System.NotImplementedException();
    }

    public void StartMovement(Vector2 targetPosition)
    {
        if (_move != null)
        {
            StopCoroutine(_move);
        }

        LookAtMouse(targetPosition);
        _move = Move(targetPosition);
        StartCoroutine(_move);
    }
}