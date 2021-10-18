using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.XR.ARFoundation;

public class ARManager : MonoBehaviour
{
    private static ARManager _instance;
    
    [FormerlySerializedAs("minigamePrefab")] [SerializeField] private GameObject minigameManagerPrefab;
    
    private ARTrackedImageManager _imageManager;
    private GameObject _minigameManagerInstance;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            _imageManager = GetComponent<ARTrackedImageManager>();
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
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
        if(_minigameManagerInstance != null)
            return;
        
        if (args.added.Count > 0)
        {
            ARTrackedImage img = args.added[0];
            _minigameManagerInstance = Instantiate(minigameManagerPrefab, img.transform);
        }
            
    }

    //this is where score would be sent to database
    public static void EndCurrentGame()
    {
        Destroy(_instance._minigameManagerInstance);
        _instance._minigameManagerInstance = null;
    }
}
