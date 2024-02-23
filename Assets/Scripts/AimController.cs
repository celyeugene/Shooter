using UnityEngine;
using StarterAssets;
using Cinemachine;

public class AimController : MonoBehaviour
{
    private StarterAssetsInputs _input;
    public Transform playerBody;
    public CinemachineVirtualCamera playerCamera;
    public float mouseSensitivity = 100f;
    public LayerMask aimLayer;
    private float rotationX = 0f;

    private bool isAiming = false;
    void Start()
    {
        _input = GetComponent<StarterAssetsInputs>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Обработка прицеливания
        if (_input.aimValue)
        {
            isAiming = true;
            playerCamera.m_Lens.FieldOfView = 30f; // Здесь установи желаемое поле зрения при прицеливании
        }
        else if (!_input.aimValue)
        {
            isAiming = false;
            playerCamera.m_Lens.FieldOfView = 60f; // Здесь установи поле зрения в обычном режиме
        }

        // Вращение камеры и персонажа
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -80f, 80f);

        playerBody.Rotate(Vector3.up * mouseX);
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);


        // RayCast для прицеливания
        if (isAiming)
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, aimLayer))
            {
                // Обработка попадания прицела
                Debug.Log("Попал в: " + hit.collider.name);
            }
        }
    }
}
