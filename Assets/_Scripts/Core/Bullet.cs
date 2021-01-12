using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private float fireSpeed;

    public void Fire(Vector3 direction)
    {
        rigidbody.velocity = direction* fireSpeed;
        gameObject.SetActive(true);
    }

    public void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
    }
}
