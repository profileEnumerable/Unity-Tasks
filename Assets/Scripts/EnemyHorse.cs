using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHorse : Unit
{
    protected virtual void OnTriggerEnter2D(Collider2D collider)
    {
        Bullet bullet = collider.GetComponent<Bullet>();

        if (bullet)
        {
            ReceiveDamage();
        }

        //Character character = collider.GetComponent<Character>();

        //if (character)
        //{
        //    character.ReceiveDamage();
        //}
    }
}
