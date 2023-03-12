using UnityEngine;
using System.Collections.Generic;
using cakeslice;

public class ObjectHighlighter : MonoBehaviour
{
    public List<Outline> outlinedObjects = new List<Outline>();
    public Transform player;
    public float distanceToShowOutlines = 50f;
    public float distanceToRemoveObject = 4f;

    void Start()
    {
        // p�id� v�echny objekty v sc�n� s komponentou Outline do seznamu outlinedObjects
        var outlinedObjectsInScene = FindObjectsOfType<Outline>();
        foreach (var obj in outlinedObjectsInScene)
        {
            outlinedObjects.Add(obj);
        }

        // vypne obrysy na za��tku
        ToggleOutlines(false);
    }

    void Update()
    {
        // zapne / vypne obrysy, kdy� je hr�� dostate�n� bl�zko objektu
        foreach (var obj in outlinedObjects)
        {
            if (obj == null)
            {
                outlinedObjects.Remove(obj);
                continue;
            }
            float distanceToPlayer = Vector3.Distance(player.position, obj.transform.position);
            bool showOutline = distanceToPlayer <= distanceToShowOutlines;
            obj.enabled = showOutline;

           
        }
    }

    public void ToggleOutlines(bool enabled)
    {
        foreach (var obj in outlinedObjects)
        {
            obj.enabled = enabled;
        }
    }
}


