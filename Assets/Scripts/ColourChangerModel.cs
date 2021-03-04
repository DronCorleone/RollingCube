using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourChangerModel : MonoBehaviour
{
    private Camera _camera;
    private int _layerMask;
    [SerializeField]private Transform _transform;
    [SerializeField]private MeshRenderer _renderer;
    [SerializeField]private Material _material;
    [SerializeField]private Background _background;
    private Vector3 _temp;
    private float _localScaleModifyier = 1;
    private float _scaleDelta = 0.5f;
    private readonly float _maxModifyer = 50;
    //private bool _isColourChange = false;
    private bool _inChangingColour = false;
    private Ray ray;
    private RaycastHit hit;
    void Start()
    {
        
        _camera = FindObjectOfType<Camera>();
        _layerMask =( 1 << LayerMask.NameToLayer("Plane"));
        ray = _camera.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, _layerMask))
        {
            Debug.Log($"Hit on {hit.transform.gameObject.name}");            
        }
        else
        { 
            Debug.Log($"Hit on nothing");
        
        }
    }

    void Update()
    {
        if (_inChangingColour)
        {
            if (_localScaleModifyier < _maxModifyer)
            {
                
                _localScaleModifyier += _scaleDelta;
                _temp.x = _localScaleModifyier;
                _temp.y = 0.1f;
                _temp.z = _localScaleModifyier;
                _transform.localScale = _temp;
            }
            else
            {
                _localScaleModifyier = 1;
                _inChangingColour = false;
                _temp.x = 1f;
                _temp.z = 1f;
                _transform.localScale = _temp;
                _renderer.enabled = false;
                _background.SetMaterial(_material);
            }
        }
    }

    public void SetNewColourChanger( Material material)
    {        
        _material = material;
        ray = _camera.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));        
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, _layerMask))
        {
            Debug.Log($"Hit on {hit.transform.gameObject.name}");
            _temp.x = hit.point.x;
            _temp.y = -8f;
            _temp.z = hit.point.z;
            _transform.position = _temp;
            _renderer.enabled = true;
            _inChangingColour = true;
        }
    }

    public void SetNewColourChanger()
    {
        SetNewColourChanger(_material);
    }



}
