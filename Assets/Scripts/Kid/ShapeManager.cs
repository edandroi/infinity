using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeManager : MonoBehaviour
{
    private List<GameObject> shapes;
    public int maxShapeCount = 30;

    public GameObject[] allShapes;
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

    public void GenerateShapes(GameObject thisObj)
    {
        int num = Random.Range(0, allShapes.Length);
                
        var newShape = Instantiate(allShapes[num], thisObj.transform.position, Quaternion.identity);
        newShape.transform.localScale = thisObj.transform.localScale * .9f;
        newShape.transform.parent = transform;
    }

    public int shapesCount()
    {
        return allShapes.Length;
    }
}
