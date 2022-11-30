using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Rendering;
using UnityEngine;


public class LightCollisionHandler : MonoBehaviour
{
    private Light _light;
    [SerializeField] private Transform _playerTransform;

    [SerializeField] private float _offset;
    private RaycastHit _hit;
    private void Awake()
    {
        _light = GetComponent<Light>();
    }
    private void Start()
    {
      
    }
    private void FixedUpdate()
    {

        if (Physics.Raycast(transform.position, (_playerTransform.position - transform.position).normalized, out _hit, _light.range-_offset))
        {
            if (_hit.collider != null)
            {
                if (_hit.transform.CompareTag("Player"))
                {
                    if (Mathf.Abs(Vector3.Distance(transform.position, _hit.collider.transform.position)) > _light.range - _offset)
                    {
                        Debug.Log("player Not in light");
                        return;
                    }
                    if (Mathf.Abs(Vector3.Angle(transform.forward, _hit.collider.transform.position)) > _light.spotAngle)
                    {
                        Debug.Log("player not in light");
                        return;
                    }
                    Debug.Log("player within light");
                }
                else
                {
                    if (Mathf.Abs(Vector3.Distance(transform.position, _hit.collider.transform.position)) > _light.range - _offset)
                    {
                        Debug.Log("not player ");
                        return;
                    }
                }
            }
            else
            {
                Debug.Log("player not in light");
            }

        }

        else
        {
            Debug.Log("player not in light");
        }


    }
    
    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position,(_playerTransform.position- transform.position).normalized);
    }
}
