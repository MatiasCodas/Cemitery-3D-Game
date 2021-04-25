using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    public float life = 100f;
    public float maxLife = 10f;
    public HUD hud;

    public void GainLife(float value)
    {
        life += value;

        if(life >100){life = 100;}
        
        if (hud != null) { hud.UpdateLife(); }
    }

    public void TakeDamage(float _damage)
    {
        life -= _damage;

        if (hud != null) { hud.UpdateLife(); }
    }
}
