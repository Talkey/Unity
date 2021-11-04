using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Player.Weapon
{
    class WeaponUI : AssualtRifle
    {
        public Text Current_Bullet_Num;
        public Text Total_Bullet;

        void Start()
        {
            Current_Bullet_Num.text = GetComponent<Firearms>().CurrentAmmo.ToString();
            Total_Bullet.text = GetComponent<Firearms>().AmmoInMag.ToString();
        }

        void UpDate()
        {

            Current_Bullet_Num.text = GetComponent<Firearms>().CurrentAmmo.ToString();
            Total_Bullet.text = GetComponent<Firearms>().AmmoInMag.ToString();
        }
    }
}