 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CubeControl : MonoBehaviour
{
    [Header("Cube Settings")]
    [SerializeField] private Vector3 volume;
    [SerializeField] private float distanceFactor;
    [SerializeField] private Transform start;
    [SerializeField] private GameObject cube;
    [SerializeField] private float explosionRadius = 5.0F;
    [SerializeField] private float explosionPower = 10.0F;
    [SerializeField] private int explosionWaitTime = 10;
    
    public Transform targetTransform;
    
    private readonly List<MeshRenderer> _meshRenderers = new List<MeshRenderer>();
    private readonly List<Rigidbody> _rigidBodies = new List<Rigidbody>();
    
    [Header("Materials")]
    [SerializeField] private Material matOne;
    [SerializeField] private Material matTwo;
    [SerializeField] private Material matThree;
    [SerializeField] private Material matFour;

    private void Start()
    {
        for (int x = 0; x < volume.x; x++) {
            for (int y = 0; y < volume.y; y++){
                for (int z = 0; z < volume.z; z++){
                    GameObject g = Instantiate(cube, start.position + new Vector3(x*distanceFactor, y*distanceFactor, z*distanceFactor), Quaternion.identity);
                    _meshRenderers.Add(g.GetComponent<MeshRenderer>());
                    _rigidBodies.Add(g.GetComponent<Rigidbody>());
                }
            }
        }
        StartCoroutine(WaitThenExplode());
    }

    private IEnumerator WaitThenExplode()
    {
        yield return new WaitForSeconds(explosionWaitTime);
        Vector3 explosionPos = transform.position + volume*distanceFactor/2 + new Vector3(0.05f, 0.05f, 0.05f);
        Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null){rb.AddExplosionForce(explosionPower, explosionPos, explosionRadius, 0f);}
        }
    }
    
    private void Update()
    {
        //set color based on distance of each cube to cubes target
        foreach (var meshRenderer in _meshRenderers)
        {
            float distanceToTarget = Vector3.Distance(meshRenderer.transform.position, targetTransform.transform.position);
            if (distanceToTarget < 0.1f) {meshRenderer.material = matOne;}
            else if (distanceToTarget <  0.2f) {meshRenderer.material = matTwo;}
            else if (distanceToTarget <  0.5f) {meshRenderer.material = matThree;}
            else if (distanceToTarget <  1) {meshRenderer.material = matFour;}
            else {meshRenderer.material = matFour;}
        }
        //applies a force on each cube in the direction of the cubes target
        foreach (var rb in _rigidBodies)
        {
            var rbPosition = rb.transform.position;
            var targetPosition = targetTransform.position;
            var dir = (targetPosition - rbPosition).normalized;
            rb.AddForce(dir * 15/(Mathf.Pow(Vector3.Distance(rbPosition, targetPosition),1.3f)+1));
        }
    }
}
