using Cinemachine;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject player;  // El jugador al que las cámaras deben seguir

    private void Awake()
    {
        // Asegurarse de que este objeto no se destruya al cambiar de escena
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        SetCamerasFollowPlayer();
    }

    public void SetCamerasFollowPlayer()
    {
        // Buscar la cámara principal (física) por nombre
        Camera mainCamera = GameObject.Find("Main Camera")?.GetComponent<Camera>();
        if (mainCamera != null)
        {
            Debug.Log("Main Camera encontrada");
            // Aquí puedes realizar cualquier configuración adicional que necesites con la cámara principal
        }
        else
        {
            Debug.LogError("Main Camera no encontrada en la escena");
        }

        // Buscar la cámara virtual por nombre
        CinemachineVirtualCamera virtualCamera = GameObject.Find("Virtual Camera")?.GetComponent<CinemachineVirtualCamera>();
        if (virtualCamera != null)
        {
            Debug.Log("Virtual Camera encontrada");
            // Asignar el jugador como objetivo de seguimiento en la cámara virtual
            virtualCamera.Follow = player.transform;
            virtualCamera.LookAt = player.transform;  // Opcional, para que mire al jugador
        }
        else
        {
            Debug.LogError("Virtual Camera no encontrada en la escena");
        }
    }
}
