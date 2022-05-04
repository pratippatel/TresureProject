using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Powerups/AttackEffect")]
public class AttackEffect : PowerupEffect
{
   public float amount;
   public int attack;
   public override void Apply(GameObject target){
        //Never add more than 3 attackDeBuffs in one level because
        //speed will become 0.
        target.GetComponent<PlayerMovement>().speed+=amount;
        target.GetComponent<PlayerAttack>().attackCooldown=attack;
    }
}
