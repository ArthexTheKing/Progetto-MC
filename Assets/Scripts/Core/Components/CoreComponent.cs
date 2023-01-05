using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreComponent : MonoBehaviour
{
    protected Core core;

    protected virtual void Awake()
    {
        if (!transform.parent.TryGetComponent(out core)) { Debug.LogError("Missing Core Element"); }
    }
}
