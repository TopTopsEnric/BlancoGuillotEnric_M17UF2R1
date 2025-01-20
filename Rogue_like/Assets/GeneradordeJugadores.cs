using UnityEngine;
using UnityEngine.SceneManagement;

public class GeneradordeJugadores : MonoBehaviour
{
    public GameObject playerPrefab;
    public CameraManager cameraManager;
    // Prefab del jugador
    private GameObject playerInstance; // Instancia del jugador

    // Este booleano debería estar vinculado al estado de vida del jugador
    private bool isPlayerAlive = true; // Cambiar según el estado real del jugador

    private void OnEnable()
    {
        // Suscribirse al evento de carga de la escena
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        // Asegurarse de cancelar la suscripción al evento
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // Este método se llama cada vez que una escena es cargada
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Buscamos el GameObject "Respawn" en la escena
        GameObject respawnPoint = GameObject.Find("Respawn");

        // Verificamos si el GameObject "Respawn" existe
        if (respawnPoint != null)
        {
            // Si el jugador está vivo y el prefab está asignado
            if (playerPrefab != null && isPlayerAlive)
            {
                // Instanciamos el jugador en la posición del Respawn
                playerInstance = Instantiate(playerPrefab, respawnPoint.transform.position, Quaternion.identity);
                cameraManager.player= playerInstance;
                cameraManager.SetCamerasFollowPlayer();

                // Llenamos el inventario del jugador
                Inventory playerInventory = playerInstance.GetComponent<Inventory>();
                if (playerInventory != null)
                {
                    playerInventory.AddItems(GameManager.gameManager.inventory.prepararLista(),GameManager.gameManager.inventory.money);
                }
            }
            else
            {
                Debug.Log("El jugador no está vivo o el prefab no está asignado.");
            }
        }
        else
        {
            Debug.LogWarning("No se encontró el GameObject 'Respawn' en la escena.");
        }
    }

    
   
}