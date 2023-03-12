using UnityEngine;
using System.Collections.Generic;
using cakeslice;

public class ObjectHighlighter : MonoBehaviour
{
    public float outlineThreshold = 10f; // Vzd�lenost, ve kter� se bude objevovat outline
    public Collider triggerCollider; // Collider definuj�c� oblast, ve kter� se bude zobrazovat outline

    private List<Outline> outlines = new List<Outline>(); // Seznam objekt� s outline

    private void OnTriggerEnter(Collider other)
    {
        // Najdeme komponentu Outline na objektu, kter� vstoupil do triggerCollideru
        var objWithOutline = other.GetComponent<Outline>();

        // Pokud se v collideru nach�z� objekt s outline a zat�m nen� v seznamu, p�id�me ho
        if (objWithOutline != null && !outlines.Contains(objWithOutline))
        {
            outlines.Add(objWithOutline);
            objWithOutline.enabled = true; // Zobraz�me outline
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Najdeme komponentu Outline na objektu, kter� opustil triggerCollider
        var objWithOutline = other.GetComponent<Outline>();

        // Pokud se v collideru nach�z� objekt s outline a je v seznamu, odebereme ho
        if (objWithOutline != null && outlines.Contains(objWithOutline))
        {
            outlines.Remove(objWithOutline);
            objWithOutline.enabled = false; // Skryjeme outline
        }
    }
}
