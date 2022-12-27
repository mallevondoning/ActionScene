using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private PlayerController _player;
    private Rigidbody _localRB;
    private Explosion _childEXP;

    private float _explosionForce = 5000f;
    private float _explosionRadius = 10f;

    public void Setup(PlayerController player, Vector3 position, Vector3 forward, float speed)
    {
        _player = player;
        _localRB = GetComponent<Rigidbody>();
        _childEXP = GetComponentInChildren<Explosion>();
        transform.position = position;

        SetMovement(forward, speed);
    }

    public void SetMovement(Vector3 forward, float speed)
    {
        _localRB.AddForce(forward * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        _player.AddExplodeForce(_explosionForce, transform.position, _explosionRadius);
        StartCoroutine(_childEXP.Explode(gameObject));
    }

    private void OnTriggerEnter(Collider other)
    {
        EnemyController checkEC = other.gameObject.GetComponent<EnemyController>();
        if (checkEC == null)
            Destroy(gameObject);
    }
}
