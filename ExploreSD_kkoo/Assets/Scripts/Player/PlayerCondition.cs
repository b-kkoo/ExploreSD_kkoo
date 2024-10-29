using System;
using System.Collections;
using UnityEngine;

public interface IDamagable
{
    void TakePhysicalDamage(int damage);
}

public class PlayerCondition : MonoBehaviour, IDamagable
{
    public UICondition uiCondition;
    private Coroutine coroutine;


    Condition health { get { return uiCondition.health; } }
    Condition stamina { get { return uiCondition.stamina; } }

    public event Action onTakeDamage;

    private void Update()
    {
        stamina.Add(stamina.passiveValue * Time.deltaTime);

        if (health.curValue <= 0.0f)
        {
            Die();
        }
    }

    public void Heal(float amount)
    {
        health.Add(amount);
    }

    public void Boost()
    {
        StartCoroutine(BoostBuff());
    }

    public void Die()
    {
        Debug.Log("플레이어가 죽었다.");
    }

    public void TakePhysicalDamage(int damage)
    {
        health.Subtract(damage);
        onTakeDamage?.Invoke();
    }

    public bool UseStamina(float amount)
    {
        if (stamina.curValue - amount < 0)
        {
            return false;
        }
        stamina.Subtract(amount);
        return true;
    }

    private IEnumerator BoostBuff()
    {
        float boostBuff = 2.0f;
        float buffDuration = 10.0f;

        CharacterManager.Instance.Player.controller.moveSpeed *= boostBuff;
        yield return new WaitForSeconds(buffDuration);
        CharacterManager.Instance.Player.controller.moveSpeed /= boostBuff;
    }
}