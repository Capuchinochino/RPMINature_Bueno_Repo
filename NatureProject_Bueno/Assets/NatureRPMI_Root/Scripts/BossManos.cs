using UnityEngine;
using System.Collections;

public class BossManos : MonoBehaviour
{
    public Animator PataL; // Mano izquierda
    public Animator PataD; // Mano derecha

    void Start()
    {
        StartCoroutine(AnimarPataL());
        StartCoroutine(AnimarPataD());
    }

    IEnumerator AnimarPataL()
    {
        while (true)
        {
            yield return new WaitForSeconds(20f);
            PataL.SetBool("AnimarI", true);
            yield return new WaitForSeconds(0.5f); // Tiempo que dura el bool en true
            PataL.SetBool("AnimarI", false);
        }
    }

    IEnumerator AnimarPataD()
    {
        while (true)
        {
            yield return new WaitForSeconds(35f);
            PataD.SetBool("AnimarD", true);
            yield return new WaitForSeconds(0.5f); // Tiempo que dura el bool en true
            PataD.SetBool("AnimarD", false);
        }
    }
}
