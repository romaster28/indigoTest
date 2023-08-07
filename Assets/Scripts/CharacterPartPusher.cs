using UnityEngine;

public class CharacterPartPusher : MonoBehaviour
{
    [SerializeField] private float _force = 250;
    
    public void Push(Collider part, Vector3 position)
    {
        var rigidbodyPart = part.GetComponent<Rigidbody>();
        
        rigidbodyPart.AddForceAtPosition(Vector3.forward * _force, position);
    }

    public void Push(RaycastHit raycastHit)
    {
        Push(raycastHit.collider, raycastHit.point);
    }
}