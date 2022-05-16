using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public AudioSource audioSource;

    public Animator animator;

    public ParticleSystem[] particles;

    public float attackInterval = 0.5f;
    float currentInterval;

    public float damage = 2f;
    public float range = 20f;

    public Transform enemyCamera;

    GameObject player;

    public EnemyController enemyController;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Start is called before the first frame update
    void Start()
    {
        currentInterval = attackInterval;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyController.attackPlayer)
        {
            currentInterval -= Time.deltaTime;
            if (currentInterval <= 0)
            {
                Vector3 targetPostition = new Vector3(randomFloat(player.transform.position.x), randomFloat(player.transform.position.y), randomFloat(player.transform.position.z));
                enemyCamera.LookAt(targetPostition);

                RaycastHit hit;

                if (Physics.Raycast(enemyCamera.position, enemyCamera.forward, out hit, range))
                {
                    PlayerHealth playerHealth = hit.transform.GetComponent<PlayerHealth>();

                    if (playerHealth != null)
                    {
                        playerHealth.TakeDamage(damage);
                    }
                }

                for (int i = 0; i < particles.Length; i++)
                {
                    particles[i].Play();
                    PlayGunSound();
                    animator.SetTrigger("WeaponRecoil");
                }

                currentInterval = attackInterval;
            }
        }
    }

    float randomFloat(float input)
    {
        return Random.Range(input - 0.5f, input + 0.5f);
    }

    void PlayGunSound()
    {
        if (!MuteAudio.isAudioMuted)
        {
            audioSource.Play();
        }
    }
}
