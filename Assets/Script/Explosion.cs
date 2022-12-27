using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour
{
    [SerializeField]
    float range = 45f;
    [SerializeField]
    float maximumStress = 0.6f;

    public IEnumerator Explode(GameObject destroyedOBJ)
    {

        float distance = Vector3.Distance(transform.position, ShakeableTransform.Instance.transform.position);
        float distanceIO = Mathf.Clamp01(distance / range);

        float stress = (1 - Mathf.Pow(distanceIO, 2)) * maximumStress;
        
        ShakeableTransform.Instance.InduceStress(stress);

        ParticleSystem explosionPS = GetComponent<ParticleSystem>();
        float explosionLength = explosionPS.main.duration;

        explosionPS.Play();
        yield return new WaitForSeconds(explosionLength);

        Destroy(destroyedOBJ);
    }
}