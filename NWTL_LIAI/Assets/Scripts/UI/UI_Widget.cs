using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Widget : MonoBehaviour
{
    public UI_Manager getUIManager(){
        return GetComponentInParent<UI_Manager>();
    }
}
