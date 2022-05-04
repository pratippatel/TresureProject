using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Powerups/JumpEffect")]
public class JumpEffect : PowerupEffect
{
     public int amount;
    public override void Apply(GameObject target){
        //amount can't be negative if player can only jump once.
        if (target.GetComponent<PlayerMovement>().maxJumps == 1 && amount < 0) return;

        else target.GetComponent<PlayerMovement>().maxJumps+=amount;

        
    }
}
