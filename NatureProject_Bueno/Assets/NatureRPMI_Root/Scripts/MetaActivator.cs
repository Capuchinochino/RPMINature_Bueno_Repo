using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Activar el collider del padre
            Transform parent = transform.parent;
            if (parent != null)
            {
                BoxCollider2D parentCollider = parent.GetComponent<BoxCollider2D>();
                if (parentCollider != null)
                {
                    parentCollider.enabled = true;
                    Debug.Log("LvlFinish activado");
                }
            }

            // Opcional: desactivar el propio trigger para evitar reactivaciones
            gameObject.SetActive(false);
        }
    }
}
