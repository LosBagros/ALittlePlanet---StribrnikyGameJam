using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planeta : MonoBehaviour
{
    public float attractForce = 10f; // S�la p�itahov�n�
    public float attractRange = 999f; // Vzd�lenost, na kter� se za�ne hr�� p�itahovat

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                float distance = Vector3.Distance(transform.position, other.transform.position);
                if (distance <= attractRange)
                {
                    float force = attractForce * (attractRange - distance) / attractRange;
                    rb.AddForce((transform.position - other.transform.position).normalized * force);
                }
            }
        }
    }
}
