using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;
using System.Collections.Generic;

public class Spawner : MonoBehaviour
{
    [Header("Prefabs a Instanciar")]
    [SerializeField] private GameObject[] prefabs; // Array de prefabs a spawnear.

    [Header("Rango de Spawn")]
    [SerializeField] private Vector2 spawnRangeX; // Rango en X (mínimo, máximo).
    [SerializeField] private Vector2 spawnRangeY; // Rango en Y (mínimo, máximo).
    [SerializeField] private Vector2 spawnRangeZ; // Rango en Z (mínimo, máximo).

    [Header("Opciones de Spawn")]
    [SerializeField] private int cantidadDeSpawns = 5; // Número de instancias a crear.
    [SerializeField] private bool spawnearAlInicio = true; // ¿Spawnear al iniciar?
    [SerializeField] private float distanciaMinimaEntreObjetos = 1.5f; // Distancia mínima entre objetos.

    private List<Vector3> posicionesSpawneadas = new List<Vector3>(); // Almacena las posiciones ya usadas.

    private void Start()
    {
        if (spawnearAlInicio)
        {
            SpawnearPrefabs();
        }
    }

    /// <summary>
    /// Método para instanciar los prefabs en posiciones aleatorias dentro del rango definido,
    /// asegurando que no colisionen entre sí.
    /// </summary>
    public void SpawnearPrefabs()
    {
        for (int i = 0; i < cantidadDeSpawns; i++)
        {
            Vector3 spawnPosition;
            int maxIntentos = 100; // Límite de intentos para encontrar una posición válida.
            int intentos = 0;

            // Encontrar una posición válida.
            do
            {
                spawnPosition = new Vector3(
                    Random.Range(spawnRangeX.x, spawnRangeX.y),
                    Random.Range(spawnRangeY.x, spawnRangeY.y),
                    Random.Range(spawnRangeZ.x, spawnRangeZ.y)
                );
                intentos++;
            } while (!EsPosicionValida(spawnPosition) && intentos < maxIntentos);

            if (intentos >= maxIntentos)
            {
                Debug.LogWarning("No se encontró una posición válida después de muchos intentos.");
                continue;
            }

            // Seleccionar un prefab aleatorio del array.
            GameObject prefab = prefabs[Random.Range(0, prefabs.Length)];

            // Instanciar el prefab.
            Instantiate(prefab, spawnPosition, Quaternion.identity);

            // Almacenar la posición spawneada.
            posicionesSpawneadas.Add(spawnPosition);
        }
    }

    /// <summary>
    /// Verifica si la posición dada es válida (no demasiado cercana a otra).
    /// </summary>
    /// <param name="posicion">Posición a verificar.</param>
    /// <returns>True si es válida, False si no lo es.</returns>
    private bool EsPosicionValida(Vector3 posicion)
    {
        foreach (Vector3 posSpawneada in posicionesSpawneadas)
        {
            if (Vector3.Distance(posicion, posSpawneada) < distanciaMinimaEntreObjetos)
            {
                return false;
            }
        }
        return true;
    }
}
