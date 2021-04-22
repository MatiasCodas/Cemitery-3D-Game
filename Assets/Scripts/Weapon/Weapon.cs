using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float damageValue = 10f;

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Character"))
        {
			Character character = other.GetComponent<Character>();
			character.life -= damageValue;
        }
    }

}
