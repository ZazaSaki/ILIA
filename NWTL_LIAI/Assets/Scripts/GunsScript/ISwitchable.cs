using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISwitchable : IKeyHandable
{
    void Switch(float MouseWheel);
}

