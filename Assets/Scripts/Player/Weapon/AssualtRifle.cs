using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Player.Weapon
{
    public class AssualtRifle : Firearms
    {
        [Header("武器特效")]
        public ParticleSystem MuzzleParticles;
        public ParticleSystem BulletParticles;

        public GameObject FireParticle;
        public AKBullet tempbullet;
        public Transform GunShootPosition;
        public Animator anim;
        public static bool continuous_shooting;
        public Sprite Gun;


        void Start()
        {
            Weapon_Name.text = Weapon.tag;
            CurrentAmmo = AmmoInMag;
            CurrentAmmoCarried = MaxAmmoCarring;
            lastShoot = Time.deltaTime;
            BulletUp();
            Weapon_image.sprite = Gun;
        }

        // Update is called once per frame
        void Update()
        {
            BulletUp();
            Weapon_image.sprite = Gun;
            continuous_shooting = UI.con_shoot;
            if (anim.GetFloat("Velocity")<=4.81f)
            { shoot();
            }
            if(Input.GetMouseButtonDown(1)&&!Input.GetMouseButtonDown(0)&& CurrentAmmoCarried > 0)
            {
                ReLoad();
                anim.Play("reload",0,0);
            }
        }

        //设计连射和狙击模式切换
        protected override void shoot()
        {

            if (Input.GetKeyDown(KeyCode.E))
            {
                continuous_shooting = UI.con_shoot;
            }
            if (Input.GetKeyDown(KeyCode.Mouse0) && !continuous_shooting&& CurrentAmmo>0&& anim.GetBool("Reload")==false)
            {
                Generate_Bullet();

                print("狙击");
                anim.Play("fire");
                MuzzleParticles.Play();
                BulletParticles.Play();

                BulletCalculate();
                Invoke("ParticleSys_off", 0.3f);
            }

            if (Input.GetKey(KeyCode.Mouse0) && continuous_shooting && CurrentAmmo > 0)
            {
                anim.SetBool("Con_Shooting",true);
                Generate_Bullet();

                print("连射");
                BulletParticles.Play();
                FireParticle.SetActive(true);

                BulletCalculate();
            }


            if(Input.GetMouseButtonUp(0)||CurrentAmmo<=0)
            {
                FireParticle.SetActive(false);
                anim.SetBool("Con_Shooting", false);
            }
        }

        //子弹充足允许射击
        protected  override bool  IsAllowShooting()
        {
            return Time.deltaTime - lastShoot > 1 / FireRate;
        }

        protected override void BulletCalculate()
        {
            CurrentAmmo = CurrentAmmo - 1;
        }


        public  void ParticleSys_off()
        {
            FireParticle.SetActive(false);
        }


        protected override void Generate_Bullet()
        {
            AKBullet bullet = Instantiate(tempbullet, GunShootPosition.position, Quaternion.Euler(transform.eulerAngles));
            GunShootPosition.DetachChildren();
        }


    }
}
