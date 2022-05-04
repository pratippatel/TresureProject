using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Powerups/SpeedBuff")]
public class SpeedBuff : PowerupEffect
{
    public float amount;
    public override void Apply(GameObject target){
        //Never add more than 3 speedDeBuffs in one level because
        //speed will become 0.
        target.GetComponent<PlayerMovement>().speed+=amount;
    }
}
