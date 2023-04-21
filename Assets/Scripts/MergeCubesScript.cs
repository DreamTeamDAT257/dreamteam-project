using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeCubesScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        // Get the parent object of the transform that this script is attached to
        GameObject parentObject = transform.parent.gameObject;

        // Get all the child mesh filters of the parent object
        MeshFilter[] meshFilters = parentObject.GetComponentsInChildren<MeshFilter>();

        // Create a new combined mesh
        CombineInstance[] combine = new CombineInstance[meshFilters.Length];
        int i = 0;
        while (i < meshFilters.Length)
        {
            combine[i].mesh = meshFilters[i].sharedMesh;
            combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
            meshFilters[i].gameObject.SetActive(false);
            i++;
        }


        

        parentObject.AddComponent<MeshFilter>();
        parentObject.AddComponent<MeshRenderer>();
        parentObject.GetComponent<MeshFilter>().mesh = new Mesh();
        parentObject.GetComponent<MeshFilter>().mesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt32;
        parentObject.GetComponent<MeshFilter>().mesh.CombineMeshes(combine);
        parentObject.GetComponent<MeshRenderer>().material = meshFilters[0].GetComponent<MeshRenderer>().material;
        parentObject.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
