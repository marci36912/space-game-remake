using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flyes : MonoBehaviour
{
    [SerializeField] private ParticleSystem death;
    private void Start()
    {
        BossHealth.destroyThem += destroyMe;
    }

    private void OnDestroy()
    {
        BossHealth.destroyThem -= destroyMe;
    }

    private void destroyMe()
    {
        if(death != null) Instantiate(death, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
