using UnityEngine;

namespace GameCore
{
    public abstract class BaseController : MonoBehaviour
    {
        private BaseState currenltyActiveState;

        protected abstract void InjectReferences();

        protected virtual void Start()
        {
            InjectReferences();
            currenltyActiveState?.InitializeState(); 
        }

        protected virtual void Update()
        {
            currenltyActiveState?.UpdateState();
        }

        protected virtual void OnDestroy()
        {
            currenltyActiveState?.DestroyState();
        }

        public void ChangeState(BaseState newState)
        {
            currenltyActiveState?.DestroyState();
            currenltyActiveState = newState;
            currenltyActiveState?.InitializeState();
        }
    }
}
