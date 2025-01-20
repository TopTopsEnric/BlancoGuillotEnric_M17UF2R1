using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Prefabs a Instanciar")]
    [SerializeField] private GameObject[] prefabs; // Array de prefabs a spawnear.

    [Header("Zona de Spawn")]
    [SerializeField] private GameObject zonaSpawn; // Objeto con un Collider que define la zona de spawn.

    [Header("Opciones de Spawn")]
    [SerializeField] private int cantidadDeSpawns = 5; // Número de instancias a crear.
    [SerializeField] private bool spawnearAlInicio = true; // ¿Spawnear al iniciar?
    [SerializeField] private float distanciaMinimaEntreObjetos = 1.5f; // Distancia mínima entre objetos.

    private List<Vector3> posicionesSpawneadas = new List<Vector3>(); // Almacena las posiciones ya usadas.
    private Collider2D zonaCollider; // Referencia al collider de la zona de spawn.

    private void Start()
    {
        // Obtener el collider de la zona de spawn
        if (zonaSpawn != null)
        {
            zonaCollider = zonaSpawn.GetComponent<Collider2D>();
            if (!zonaCollider || !zonaCollider.isTrigger)
            {
                Debug.LogError("El objeto de zona de spawn necesita un Collider con 'Is Trigger' activado.");
                return;
            }
        }
        else
        {
            Debug.LogError("Zona de spawn no asignada.");
            return;
        }

        // Spawnear si está configurado para hacerlo al inicio
        if (spawnearAlInicio)
        {
            SpawnearPrefabs();
        }
    }

    public void SpawnearPrefabs()
    {
        for (int i = 0; i < cantidadDeSpawns; i++)
        {
            Vector3 spawnPosition;
            int maxIntentos = 100; // Límite de intentos para encontrar una posición válida.
            int intentos = 0;

            // Encontrar una posición válida dentro del área del collider
            do
            {
                spawnPosition = GenerarPosicionAleatoriaEnZona();
                intentos++;
            } while (!EsPosicionValida(spawnPosition) && intentos < maxIntentos);

            if (intentos >= maxIntentos)
            {
                Debug.LogWarning("No se encontró una posición válida después de muchos intentos.");
                continue;
            }

            // Seleccionar un prefab aleatorio
            GameObject prefab = prefabs[Random.Range(0, prefabs.Length)];

            // Instanciar el prefab
            Instantiate(prefab, spawnPosition, Quaternion.identity);

            // Almacenar la posición spawneada
            posicionesSpawneadas.Add(spawnPosition);
        }
    }

    private Vector3 GenerarPosicionAleatoriaEnZona()
    {
        // Calcular una posición aleatoria dentro del bounding box del collider
        Bounds bounds = zonaCollider.bounds;
        return new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y),
            Random.Range(bounds.min.z, bounds.max.z)
        );
    }

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