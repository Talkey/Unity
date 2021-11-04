using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Player.Weapon
{
    public abstract class Firearms : MonoBehaviour, rweapon
    {
        [Header("��������ϵͳ")]
        public Transform MuzzlePoint;
        public Transform CashingPoint;

        public ParticleSystem MuzzleParticle;
        public ParticleSystem CashingParticle;


        [Header("�ӵ���Ϣ")]
        public float FireRate;
        protected float lastShoot;

        public int AmmoInMag = 30;
        public int MaxAmmoCarring = 120;
        public  int CurrentAmmo;
        public  int CurrentAmmoCarried;

        protected Animator GunAnimator;

        [Header("����UI")]
        public GameObject Weapon;
        public Text Current_Bullet_Num;
        public Text Total_Bullet;
        public  Text Weapon_Name;
        public Image Weapon_image;

        public UIcontroller UI;


        protected virtual void Start() 
        {
           // Weapon_Name.text = Weapon.tag;
        }


        protected abstract void BulletCalculate();

        protected abstract void shoot();
        protected  void ReLoad()
        {
            
            if (CurrentAmmoCarried >= AmmoInMag)
            {
                CurrentAmmo = AmmoInMag;
                CurrentAmmoCarried -= AmmoInMag;
                Debug.Log("��������");
            }
            /*
                
            if(CurrentAmmoCarried==AmmoInMag)
            {
                CurrentAmmo = AmmoInMag;
                CurrentAmmoCarried -=CurrentAmmo ;
            }
                */

            if (CurrentAmmoCarried < AmmoInMag&&CurrentAmmoCarried>0)
            {
                CurrentAmmo = AmmoInMag;
                CurrentAmmoCarried -=CurrentAmmoCarried;
                Debug.Log("����û�ӵ���");
            }
            
            if (CurrentAmmoCarried == 0 && Input.GetMouseButton(1)&&CurrentAmmo==0)
            {
                Debug.Log("û�ӵ���");
            }
            print("����");
        }



        protected abstract bool IsAllowShooting();
        protected abstract  void Generate_Bullet();

        void rweapon.Attack()
        {
            throw new System.NotImplementedException();
        }

        protected void BulletUp()
        {
            Current_Bullet_Num.text = GetComponent<Firearms>().CurrentAmmo.ToString();
            Total_Bullet.text = GetComponent<Firearms>().CurrentAmmoCarried.ToString();
        }
    }
}
