using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;
using UnityEngine.Animations.Rigging;
//using UnityEngine.Vector3;

[RequireComponent(typeof(PlayerInput))]

public class PlayerAimController : MonoBehaviour
{

    private StarterAssetsInputs _input;

    public GameObject mainCamera;
    public GameObject aimCamera;
    [SerializeField] GameObject crosshair;

    [SerializeField] private Rig aimRig;
    private float aimRigWeight;

    [SerializeField] Transform aimPos;
    [SerializeField] float aimSmoothSpeed = 20f;

    public float rotationSpeed = 5.0f; // Скорость вращения персонажа
    public LayerMask aimLayerMask; // Слой для Raycast при прицеливании

    public float shootingRange = 10f;
    
    

    


    void Start()
    {
        _input = GetComponent<StarterAssetsInputs>();
        
        
    }

    

    // Update is called once per frame
    void Update()
    {

        


        aimRig.weight = Mathf.Lerp(aimRig.weight, aimRigWeight, Time.deltaTime * 20f);

        if(_input.aimValue)
        {
            
            mainCamera.SetActive(false);

            crosshair.SetActive(true);
            aimCamera.gameObject.SetActive(true);

            RotatePlayerWithCamera();

            aimRigWeight = 1f;
       
        }
        else 
        {

            
            aimCamera.gameObject.SetActive(false);
            crosshair.SetActive(false);
            mainCamera.SetActive(true);
            aimRigWeight = 0f;
        }


        
        
    }

    void RotatePlayerWithCamera()
    {

        

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * shootingRange, Color.red);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, aimLayerMask))
        {
            aimPos.position = Vector3.Lerp(aimPos.position, hit.point, aimSmoothSpeed * Time.deltaTime);
            Vector3 targetDirection = hit.point - transform.position;
            targetDirection.y = 0; // Оставляем только горизонтальное направление
            Quaternion toRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        

            /*if (targetDirection != Vector3.zero)
        {
        }*/
        }

        /*if (_input.shoot)
        {
            
            //Vector3 aimDir = (mouseWorldPosition - spawnBulletPosition).normalized; 
            Instantiate(pfBulletProjectile, spawnBulletPosition.position, Quaternion.LookRotation(aimDir, Vector3.up));
            _input.shoot = false;
        }*/

        /*Ray aimRay;
    Vector3 targetDirection;

    if (_input.aimValue)
    {
        // Если прицеливаемся, используем направление от центра экрана
        aimRay = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
    }
    else
    {
        // Если не прицеливаемся, используем направление мыши
        aimRay = Camera.main.ScreenPointToRay(Input.mousePosition);
    }

    RaycastHit hit;

    if (Physics.Raycast(aimRay, out hit, Mathf.Infinity, aimLayerMask))
    {
        targetDirection = hit.point - transform.position;
        targetDirection.y = 0; // Оставляем только горизонтальное направление
    }
    else
    {
        // Если луч не попал ни в один объект, используем направление от центра экрана
        targetDirection = aimRay.direction;
    }

    Quaternion toRotation = Quaternion.LookRotation(targetDirection);
    transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);*/

    }

    /*IEnumerator ShowReticle()
    {
        yield return new WaitForSeconds(0.25f);
        aimReticle.SetActive(enabled);
    }*/
}
