using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARManager : MonoBehaviour
{
    [SerializeField] private GameObject minigamePrefab;
    
    private ARTrackedImageManager _imageManager;
    private GameObject _minigameInstance;

    private void Awake()
    {
        _imageManager = GetComponent<ARTrackedImageManager>();
    }

    private void OnEnable()
    {
        _imageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    private void OnDisable()
    {
        _imageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs args)
    {
        if(_minigameInstance != null)
            return;
        
        if (args.added.Count > 0)
        {
            ARTrackedImage img = args.added[0];
            _minigameInstance = Instantiate(minigamePrefab, img.transform);
        }
            
    }
}
