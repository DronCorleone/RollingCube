using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    public bool IsActive { get; private set; }

    public virtual void On()
    {
        IsActive = true;
    }

    public virtual void Off()
    {
        IsActive = false;
    }

    public void Switch()
    {
        if (!IsActive)
        {
            On();
        }
        else
        {
            Off();
        }
    }
}
