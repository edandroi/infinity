using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeManager : MonoBehaviour
{
    private List<GameObject> shapes;
    public int maxShapeCount = 30;
    void Start()
    {
        shapes = new List<GameObject>();
    }
    
    void Update()
    {
        if (shapes.Count > maxShapeCount)
        {
            Services.GameManager.nextScene = true;
        }
    }

    public void AddShape(GameObject shapeObj)
    {
        shapes.Add(shapeObj);
    }
    
    public void RemoveShape(GameObject shapeObj)
    {
        shapes.Remove(shapeObj);
    }
}
