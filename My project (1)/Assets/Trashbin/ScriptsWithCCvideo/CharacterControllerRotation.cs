using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerRotation : BaseRotation
{
    private new void Update()
    {
        base.Update();
        RotateCharacter();
    }
}
