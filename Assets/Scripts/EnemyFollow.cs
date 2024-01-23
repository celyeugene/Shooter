using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    
    public NavMeshAgent enemy;
    public Transform player;
    //[SerializeField] private float timer = 5;
    private float bulletTime;

    private Animator enemyAnimator;

    //public float enemyDamage = 50f;
    //public float shootingRange = 30f;

     //private float timer = 3f; // Изначальное значение таймера
    //private bool canShoot = true; // Флаг для разрешения стрельбы

    void Start()
    {
        enemyAnimator = GetComponent<Animator>();
    }

    void Update()
    {

        if (enemy.remainingDistance > enemy.stoppingDistance && !IsInAttackState())
        {
            // Если персонаж двигается, включаем анимацию ходьбы
            enemyAnimator.SetBool("isWalking", true);

            enemyAnimator.SetBool("isAttacking", false);

            enemyAnimator.SetLayerWeight(1, Mathf.Lerp(enemyAnimator.GetLayerWeight(1), 1f, Time.deltaTime * 10f));
        }
        else
        {
            enemyAnimator.SetBool("isWalking", false);

            // Проверяем, не находимся ли мы уже в состоянии атаки
            if (!IsInAttackState())
            {
                // Если не находимся, включаем анимацию атаки
                enemyAnimator.SetBool("isAttacking", true);

                enemyAnimator.SetLayerWeight(1, Mathf.Lerp(enemyAnimator.GetLayerWeight(1), 0f, Time.deltaTime * 10f));
                // Вызываем метод атаки
                //ttack();
            }
        
        }

        enemy.SetDestination(player.position);

    
        //ShootAtPlayer();
        // Обновление таймера
        /*if (canShoot)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                // Сброс таймера и разрешение стрельбы
                timer = 0.5f;
                canShoot = false;

                // Вызов метода стрельбы
                ShootAtPlayer();
            }
        }
        else
        {
            // Если стрельба разрешена, устанавливаем флаг обратно в true
            canShoot = true;
        }*/
    }

    bool IsInAttackState()
    {
        // Здесь вы можете добавить свою логику для определения, находится ли персонаж в состоянии атаки
        // Например, если у вас есть параметр анимации "IsAttacking", вы можете проверить его значение
        // или использовать другие критерии, подходящие для вашего проекта.
        return false;
    }

    

    /*void ShootAtPlayer()
    {
        //Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        Vector3 direction = transform.forward;
        Ray ray = new Ray(transform.position, direction);

        if (transform.position != 0)
        {
            enemyAnimator.SetBool("isWalking", true);
        }

        Debug.DrawRay(ray.origin, ray.direction * shootingRange, Color.red); // Отрисовка луча в сцене

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, shootingRange))
        {
            if (hit.collider.CompareTag("Player"))
            {
                Debug.Log("Hit player!");
                PlayerHealth playerHealth = hit.collider.GetComponent<PlayerHealth>();
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(enemyDamage);
                }
            }
        }
    }*/
    
    
    
    
    /*enemy.SetDestination(player.position);
    
    
    
    playerHealth.TakeDamage(enemyDamage);
    
    
    if (hit.collider.CompareTag("Player"))
            {
                // Нанести урон игроку
                PlayerHealth playerHealth = hit.collider.GetComponent<PlayerHealth>();
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(enemyDamage);
                }
            }*/
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    /*public NavMeshAgent enemy;
    public Transform player;
    [SerializeField] private float timer = 5;
    private float bulletTime;
    public GameObject enemyBullet;
    public Transform spawnPoint;

    public float enemyDamage = 50f;

    public float enemySpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemy.SetDestination(player.position);
        ShootAtPlayer();
    }

    void ShootAtPlayer()
    {
        

        Ray ray = new Ray(transform.position, player.position - transform.position);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            // Проверьте, что мы попали в игрока
            if (hit.collider.CompareTag("Player"))
            {
                // Нанести урон игроку
                PlayerHealth playerHealth = hit.collider.GetComponent<PlayerHealth>();
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(enemyDamage);
                }
            }
        }

        

    }*/

    /*void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Debug.Log("Collision with: " + hit.collider.gameObject.name);

    // Добавьте следующую строку
    Debug.DrawLine(transform.position, hit.point, Color.red, 2f);
        if (hit.collider.CompareTag("Player"))
        {
            PlayerHealth playerHealth = hit.collider.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(enemyDamage);
            }
        }
    }*/
}
