using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] private GameObject _background;
    [SerializeField] private GameObject _player;
    [SerializeField] private ColourChangerModel _colourChanger;
    [SerializeField] private bool _colourNeedChange;
    [SerializeField] private MeshRenderer _renderer;
    // Start is called before the first frame update
    private Vector3 _temp;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_colourNeedChange)
        {
            OnColourChange();
            _colourNeedChange = false;
        }
        _temp.x = _player.transform.position.x;
        _temp.y = _background.transform.position.y;
        _temp.z = _player.transform.position.z;
        _background.transform.position = _temp;
    }

    public void OnColourChange(Material material)
    {
        _colourChanger.SetNewColourChanger(material);
    }

    public void OnColourChange()
    {
        _colourChanger.SetNewColourChanger();
    }

    public void SetMaterial(Material material)
    {
        
        _renderer.material = material;
    }
    
}

