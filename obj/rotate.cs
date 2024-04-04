
using UdonSharp;
using UnityEngine;
// using VRC.SDKBase;
// using VRC.Udon;

namespace nyx.obj {
    public class rotate : UdonSharpBehaviour {

        public GameObject gameObj;
        private bool spin = false;

        public void Update() {
            if(spin) {
                gameObj.transform.Rotate(Vector3.up, 90f * Time.deltaTime);
                gameObj.transform.Rotate(Vector3.right, 90f * Time.deltaTime);
            }
        }

        public override void Interact() {
            spin = !spin;
        }
    }
}

