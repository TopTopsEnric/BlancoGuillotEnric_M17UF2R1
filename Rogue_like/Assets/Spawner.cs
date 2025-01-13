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
    [SerializeField] private Vector2 spawnRangeX; // Rango en X (m�nimo, m�ximo).
    [SerializeField] private Vector2 spawnRangeY; // Rango en Y (m�nimo, m�ximo).
    [SerializeField] private Vector2 spawnRangeZ; // Rango en Z (m�nimo, m�ximo).

    [Header("Opciones de Spawn")]
    [SerializeField] private int cantidadDeSpawns = 5; // N�mero de instancias a crear.
    [SerializeField] private bool spawnearAlInicio = true; // �Spawnear al iniciar?
    [SerializeField] private float distanciaMinimaEntreObjetos = 1.5f; // Distancia m�nima entre objetos.

    private List<Vector3> posicionesSpawneadas = new List<Vector3>(); // Almacena las posiciones ya usadas.

    private void Start()
    {
        if (spawnearAlInicio)
        {
            SpawnearPrefabs();
        }
    }

    /// <summary>
    /// M�todo para instanciar los prefabs en posiciones aleatorias dentro del rango definido,
    /// asegurando que no colisionen entre s�.
    /// </summary>
    public void SpawnearPrefabs()
    {
        for (int i = 0; i < cantidadDeSpawns; i++)
        {
            Vector3 spawnPosition;
            int maxIntentos = 100; // L�mite de intentos para encontrar una posici�n v�lida.
            int intentos = 0;

            // Encontrar una posici�n v�lida.
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
                Debug.LogWarning("No se encontr� una posici�n v�lida despu�s de muchos intentos.");
                continue;
            }

            // Seleccionar un prefab aleatorio del array.
            GameObject prefab = prefabs[Random.Range(0, prefabs.Length)];

            // Instanciar el prefab.
            Instantiate(prefab, spawnPosition, Quaternion.identity);

            // Almacenar la posici�n spawneada.
            posicionesSpawneadas.Add(spawnPosition);
        }
    }

    /// <summary>
    /// Verifica si la posici�n dada es v�lida (no demasiado cercana a otra).
    /// </summary>
    /// <param name="posicion">Posici�n a verificar.</param>
    /// <returns>True si es v�lida, False si no lo es.</returns>
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
