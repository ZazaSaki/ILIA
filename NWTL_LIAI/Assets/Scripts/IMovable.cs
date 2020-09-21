using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovable : IKeyHandable{
    void SelfMove(float HorizontalAxis, float VerticalAxis);

    void jump();
    void walk();
    void sprint();
}
