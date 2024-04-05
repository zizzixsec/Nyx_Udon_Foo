using UdonSharp;

namespace nyx.ui {
    public class contextuals : UdonSharpBehaviour{
        public UdonSharpBehaviour m_Target;
        public System.String m_Event;

        public override void Interact() {
            if ((bool)m_Target.GetProgramVariable("Active"))
                m_Target.SendCustomEvent(m_Event);
        }
    }
}