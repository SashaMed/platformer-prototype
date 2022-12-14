using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AggressiveWeapon : Weapon
{

    protected SO_AggressiveWeaponData aggressiveWeaponData;
    private List<IDamageable> detectedDamageables = new List<IDamageable> ();
    private List<IKnockbackable> detectedKnockbackables = new List<IKnockbackable> ();
    private List<IStunable> detectedStunables = new List<IStunable>();

    protected override void Awake()
    {
        base.Awake();

        if (weaponData.GetType() == typeof (SO_AggressiveWeaponData))
        {
            aggressiveWeaponData = (SO_AggressiveWeaponData)weaponData;
        }
        else
        {
            Debug.LogError("wrong data for the weapon");
        }
    }

    public override void AnimationHitTrigger()
    {
        base.AnimationHitTrigger();
        CheckMeleeAttack();
    }

    private void CheckMeleeAttack()
    {
        WeaponAttackDetails details = aggressiveWeaponData.AttackDetails[attackCounter];
        foreach (var detected in detectedDamageables.ToList())
        {
            detected.Damage(details.damageAmount);
           
        }

        foreach (var detected in detectedKnockbackables.ToList())
        {
            detected.Knockback(details.knockbackAngle, details.knockbackStrenght, core.Movement.FacingDirection);
        }

        foreach(var detected in detectedStunables.ToList())
        {
            detected.CheckIfShouldStun(details.damageAmount);
        }
    }

    public void AddToDetected(Collider2D collider)
    {
        IDamageable damageable = collider.GetComponent<IDamageable>();
        if (damageable != null)
        {
            detectedDamageables.Add(damageable);
        }
        IKnockbackable knockbackable = collider.GetComponent<IKnockbackable>();
        if (knockbackable != null)
        {
            detectedKnockbackables.Add(knockbackable);
        }
        var stunables = collider.GetComponent<IStunable>();
        if (stunables != null)
        {
            detectedStunables.Add(stunables);
        }
    }


    public void RemoveFromDetected(Collider2D collider)
    {
        IDamageable damageable = collider.GetComponent<IDamageable>();
        if (damageable != null)
        {
            detectedDamageables.Remove(damageable);
        }
        IKnockbackable knockbackable = collider.GetComponent<IKnockbackable>();
        if (knockbackable != null)
        {
            detectedKnockbackables.Remove(knockbackable);
        }
        var stunables = collider.GetComponent<IStunable>();
        if (stunables != null)
        {
            detectedStunables.Remove(stunables);
        }
    }
}
