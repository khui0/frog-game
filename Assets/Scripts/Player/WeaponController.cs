using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public AudioSource audioSource;

    public Animator animator;

    public ParticleSystem[] particles;

    float shootInterval = 0.2f;
    float currentInterval;

    public float damage = 4f;
    public float range = 100f;

    public Camera playerCamera;

    private void Start()
    {
        range += Upgrades.upgradeLevel[1] * 20;

        shootInterval = 1f / (5 + (Upgrades.upgradeLevel[2] * 2));
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.isGamePaused)
        {
            if (currentInterval > 0)
            {
                currentInterval -= Time.deltaTime;
            }

            if (Upgrades.upgradeLevel[0] == 0)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    ShootGun();
                }
            }
            else
            {
                if (Input.GetMouseButton(0))
                {
                    ShootGun();
                }
            }
        }
    }

    void ShootGun()
    {
        if (currentInterval <= 0)
        {
            RaycastHit hit;

            if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, range))
            {
                EnemyHealth enemyHealth = hit.transform.GetComponent<EnemyHealth>();

                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(damage);
                }
            }

            for (int i = 0; i < particles.Length; i++)
            {
                particles[i].Play();
                PlayGunSound();
                animator.SetTrigger("WeaponRecoil");
            }

            currentInterval = shootInterval;
        }
    }

    void PlayGunSound()
    {
        if (!MuteAudio.isAudioMuted)
        {
            audioSource.Play();
        }
    }
}
