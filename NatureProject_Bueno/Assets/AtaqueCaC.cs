using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueCaC : MonoBehaviour
{

    [SerializeField] private Transform controladorGolpe;
    [SerializeField] private float radioGolpe;
    [SerializeField] private float dañoGolpe;


    public void Golpe() 
    {
        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorGolpe.position, radioGolpe);


        foreach (Collider2D colisionador in objetos)
        {
            if (colisionador.CompareTag("Enemy"))
            {
                NPCController npc = colisionador.GetComponent<NPCController>();
                if (npc != null && npc.gameObject.activeInHierarchy)
                {
                    npc.TakeDamage(Mathf.RoundToInt(dañoGolpe));
                }
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controladorGolpe.position, radioGolpe);
    }

}
