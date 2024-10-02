using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace ProjectGaryn
{
    [Serializable]
    public class PlayerDashData
    {
        [field: SerializeField][field: Range(1f, 3f)] public float SpeedModifier { get; private set; } = 2f;
        [field: SerializeField][field: Range(0f, 2f)] public float TimeToBeConsiderConsecutive { get; private set; } = 1f;
        [field: SerializeField][field: Range(1, 10)] public int ConsecutiveDashesLimitAmount { get; private set; } = 2;
        [field: SerializeField][field: Range(0f, 35)] public float DashLimitReachedCooldown { get; private set; } = 1.75f;
    }
}
