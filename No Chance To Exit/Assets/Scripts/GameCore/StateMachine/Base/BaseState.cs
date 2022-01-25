using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameCore
{
    public abstract class BaseState
    {

        public virtual void InitializeState()
        {
            
        }

        public virtual void UpdateState()
        {

        }

        public virtual void DestroyState()
        {

        }
    }
}

