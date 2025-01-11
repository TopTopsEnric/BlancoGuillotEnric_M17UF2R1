using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    private Stack<GameObject> projectilePool = new Stack<GameObject>(); // Pila para almacenar proyectiles
    public GameObject projectilePrefab; // Prefab del proyectil

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
        // Inicializar el pool de proyectiles (podrías establecer un número inicial de proyectiles)
        for (int i = 0; i < 10; i++) // 10 proyectiles por defecto
        {
            GameObject projectile = Instantiate(projectilePrefab);
            projectile.SetActive(false);
            projectilePool.Push(projectile);
        }
        Debug.Log(projectilePool);
    }

    // Método para sacar un proyectil del pool
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

    // Método para devolver un proyectil al pool
    public void Push(GameObject go)
    {
        go.SetActive(false);
        projectilePool.Push(go);
    }
}
