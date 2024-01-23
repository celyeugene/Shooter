using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    //private StarterAssetsInputs _input;
    public float range = 100f;
    public float playerDamage = 10f;
    public float fireRate = 15f;

    private int maxBullets = 30;

    public int allBullets = 120;
    
    public int totalBullets;
    //[SerializeField] Transform barrelPos;
    [SerializeField] GameObject bullet;
    //public Rigidbody bulletT;
    //public float bulletSpeed = 10f;
    public LayerMask shootableLayer;
    private float nextTimeToFire = 0f;

    public ParticleSystem muzzleFlash;
    void Start()
    {
        totalBullets = maxBullets;
        allBullets = 120;
    }

    void Update()
    {
        if (totalBullets > 0 && Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
        else if (totalBullets >= 0 && Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());
        }
    }

    void Shoot()
    {
        muzzleFlash.Play();
        totalBullets--;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, range, shootableLayer))
        {
            Debug.Log(hit.transform.name);
            Instantiate(bullet, hit.point, Quaternion.LookRotation(hit.normal));

            Health health = hit.transform.GetComponent<Health>();

            if (health != null)
            {
                health.TakeDamage(playerDamage);
            }
        }
    }

    IEnumerator Reload()
    {
        float reloadTime = 3f;

    if (totalBullets < maxBullets && allBullets > 0)
    {
        // Определение количества патронов для перезарядки
        int bulletsToReload = Mathf.Min(maxBullets - totalBullets, allBullets);

        // Ждем указанное время
        yield return new WaitForSeconds(reloadTime);

        // Вычитаем из общего количества патронов
        allBullets -= bulletsToReload;

        // Добавляем патроны к локальному магазину
        totalBullets = Mathf.Min(maxBullets, totalBullets + bulletsToReload);
    }
    }
}
