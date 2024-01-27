using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableGun : InteractableObject
{
    [SerializeField] GameObject player;
    public override void Interaction()
    {
        // make player equip gun
        Weapon weapon = player.GetComponent<Weapon>();

        weapon.ActivateGun();

        Destroy(gameObject);
    }
}
