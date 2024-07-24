using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class SomeTemp : MonoBehaviour
{
    [SerializeField] private AssetLabelReference _labelReference;
    
    private void Start()
    {
        var handle = Addressables.LoadAssetsAsync<object>(_labelReference, o => Debug.Log(o.GetType()));
        handle.Completed += operationHandle => Debug.Log(operationHandle.Status);
    }
}