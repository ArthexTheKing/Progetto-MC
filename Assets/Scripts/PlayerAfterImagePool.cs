using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAfterImagePool : MonoBehaviour {

    [SerializeField]
    private GameObject afterImagePreFab;

    private Queue<GameObject> availableObject = new Queue<GameObject>();

    public static PlayerAfterImagePool Instance { get; private set; }

    /* Unity */
    void Awake() {
        Instance = this;
        GrowPool();
    }

    /* Function */
    private void GrowPool() {
        for (int i = 0; i < 10; i++) {
            var instanceToAdd = Instantiate(afterImagePreFab);
            instanceToAdd.transform.SetParent(transform);
            AddToPool(instanceToAdd);
        }
    }

    public void AddToPool(GameObject instance) {
        instance.SetActive(false);
        availableObject.Enqueue(instance);
    }

    public GameObject GetFromPool() {
        if(availableObject.Count == 0) {
            GrowPool();
        }

        var instance = availableObject.Dequeue();
        instance.SetActive(true);
        return instance;
    }
    
}
