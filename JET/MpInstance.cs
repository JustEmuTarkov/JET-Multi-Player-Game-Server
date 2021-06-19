using UnityEngine;

namespace JET
{
    public class MpInstance:MonoBehaviour
    {
        public ulong LocalIndex { get; private set; }
        public double LocalTime { get; private set; }
        
        public void FixedUpdate()
        {
            
        }
    }
}