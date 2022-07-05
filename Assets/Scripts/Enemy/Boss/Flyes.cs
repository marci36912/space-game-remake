using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flyes : MonoBehaviour
{
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
        Destroy(gameObject);
    }
}
