using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
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

    private void Start()
    {
        // Inicializar el pool de proyectiles (podr�as establecer un n�mero inicial de proyectiles)
        for (int i = 0; i < 10; i++) // 10 proyectiles por defecto
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
}
