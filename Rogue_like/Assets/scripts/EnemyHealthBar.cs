using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public Transform target; // El enemigo al que está ligada la barra.
    public Image healthBar; // Referencia a la barra verde.
    public Vector3 offset; // Desplazamiento vertical.

    private void LateUpdate()
    {
        // Asegura que la barra siga al enemigo.
        if (target != null)
        {
            transform.position = Camera.main.WorldToScreenPoint(target.position + offset);
        }
    }

    public void UpdateHealth(float currentHealth, float maxHealth)
    {
        // Actualiza el tamaño de la barra de vida.
        healthBar.fillAmount = currentHealth / maxHealth;
    }
}
