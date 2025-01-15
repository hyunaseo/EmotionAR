using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngerEvent : MonoBehaviour
{
    // BE SURE TO ASSIGN THIS IN THE INSPECTOR //
    public UltimateRadialMenu radialMenu;
    public Vector3 spawnPosition;
    public GameObject spherePrefab;
    public GameObject cube;
    public Material newMat;

    private Coroutine spawnCoroutine;

    void Start()
    {
        radialMenu.OnButtonEnter += (buttonIndex) =>
        {
            // // Log into the console.
            // Debug.Log( $"Input has entered button index: {buttonIndex}!" );

            // // Additionally, you can access the UltimateRadialButtonList of the hovered button.
            // Debug.Log( $"Button has the name: {radialMenu.UltimateRadialButtonList[ buttonIndex ].name}." );

            // Start spawning spheres every 3 seconds
            if (spawnCoroutine == null)
            {
                spawnCoroutine = StartCoroutine(SpawnSpheresContinuously());
            }
        };
    }

    IEnumerator SpawnSpheresContinuously()
    {
        while (true)
        {
            SpawnAndDropSphere();
            yield return new WaitForSeconds(3f);
        }
    }

    public void SpawnAndDropSphere()
    {
        // Check if the sphere prefab is assigned
        if (spherePrefab == null)
        {
            Debug.LogError("Sphere prefab is not assigned!");
            return;
        }

        // Instantiate a new sphere at the specified position
        GameObject newSphere = Instantiate(spherePrefab, spawnPosition, Quaternion.identity);

        // Ensure the sphere has a Rigidbody component for physics simulation
        Rigidbody rb = newSphere.GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = newSphere.AddComponent<Rigidbody>();
        }

        // Optionally, you can modify the Rigidbody properties, like mass or drag
        rb.mass = 1f;
        rb.drag = 0f;
        rb.angularDrag = 0.05f;
    }

    public void ChangeCubeColor(){
        Renderer renderer = cube.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material = newMat;
        }
        else
        {
            Debug.LogError("Renderer component not found on the Cube object!");
        }
    }
}