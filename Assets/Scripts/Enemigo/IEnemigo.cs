using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IEnemigo
{
    void MoveToPlayer(Vector2 playerDistance);
    void Active(bool index);
}
