using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : RangeWeapon
{
    public GameObject arrow;
    private void Update()
    {
        if (GameManager.isPaused) return;

        if (currentAmmo.value == 0) return;

        if (Input.GetButton("Fire1"))
        {
            arrow.SetActive(true);
            animController.SetBool("Aim", true);
        }

        if (Input.GetButtonUp("Fire1"))
        {
            arrow.SetActive(false);
            animController.SetBool("Aim", false);
            Shoot();
        }
    }
}
