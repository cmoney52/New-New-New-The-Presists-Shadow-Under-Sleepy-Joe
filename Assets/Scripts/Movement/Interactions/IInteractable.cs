using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Events;

namespace Assets.Scripts.Movement.Interactions
{
    internal interface IInteractable    
    {
        public UnityEvent onInteract { get; protected set; }
        public void Interact();
    }
}
