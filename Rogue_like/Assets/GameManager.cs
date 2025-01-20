using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    
    public Inventory inventory;
    private Stack<GameObject> projectilePool = new Stack<GameObject>(); // Pila para almacenar proyectiles
    public GameObject projectilePrefab; // Prefab del proyectil
    public bool playa { get; set; } = false;
    public bool bosque { get; set; } = false;
    public bool cueva { get; set; } = false;
    

    private void Awake()
    {
        // Asegura que solo haya una instancia del GameManager
        if (gameManager == null)
        {
            gameManager = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        // Suscribir el evento para cargar la escena
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        // Desuscribir el evento para evitar errores
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // Este m�todo se llama cuando se carga una escena
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Inicializar el inventario y el pool de proyectiles
        inventory = GetComponent<Inventory>();

        // Inicializar el pool de proyectiles (30 proyectiles por defecto)
        for (int i = 0; i < 30; i++)
        {
            GameObject projectile = Instantiate(projectilePrefab);
            projectile.SetActive(false);
            projectilePool.Push(projectile);
        }

        Debug.Log(projectilePool);
    }

    // M�todo para sacar un proyectil del pool
    public GameObject Pop()
    {
        if (projectilePool.Count > 0)
        {
            GameObject projectile = projectilePool.Pop();
            projectile.SetActive(true);
            return projectile;
        }
        else
        {
            // Si no hay proyectiles disponibles, puedes decidir si crear uno nuevo o retornar null
            Debug.LogWarning("No more projectiles in pool. Creating a new one.");
            GameObject newProjectile = Instantiate(projectilePrefab);
            return newProjectile;
        }
    }

    // M�todo para devolver un proyectil al pool
    public void Push(GameObject go)
    {
        go.SetActive(false);
        projectilePool.Push(go);
    }

    public void ChangeScene(int sceneIndex)
    {
        if (sceneIndex >= 0 && sceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(sceneIndex);
        }
        else
        {
            Debug.LogError("El �ndice de escena no es v�lido: " + sceneIndex);
        }
    }

    public void Finish()
    {
        // Mensaje de depuraci�n en la consola
        Debug.Log("Cerrando el juego...");

        // Si est� en el Editor, se detiene la ejecuci�n
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // Cerrar la aplicaci�n
#endif
    }
}
