using Cinemachine;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject player;  // El jugador al que las c�maras deben seguir

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
        // Buscar la c�mara principal (f�sica) por nombre
        Camera mainCamera = GameObject.Find("Main Camera")?.GetComponent<Camera>();
        if (mainCamera != null)
        {
            Debug.Log("Main Camera encontrada");
            // Aqu� puedes realizar cualquier configuraci�n adicional que necesites con la c�mara principal
        }
        else
        {
            Debug.LogError("Main Camera no encontrada en la escena");
        }

        // Buscar la c�mara virtual por nombre
        CinemachineVirtualCamera virtualCamera = GameObject.Find("Virtual Camera")?.GetComponent<CinemachineVirtualCamera>();
        if (virtualCamera != null)
        {
            Debug.Log("Virtual Camera encontrada");
            // Asignar el jugador como objetivo de seguimiento en la c�mara virtual
            virtualCamera.Follow = player.transform;
            virtualCamera.LookAt = player.transform;  // Opcional, para que mire al jugador
        }
        else
        {
            Debug.LogError("Virtual Camera no encontrada en la escena");
        }
    }
}
