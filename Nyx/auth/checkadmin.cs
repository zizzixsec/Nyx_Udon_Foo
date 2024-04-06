using System;
using UdonSharp;
using UnityEngine;
using VRC.SDK3.StringLoading;
using VRC.SDKBase;
using VRC.Udon.Common.Interfaces;

namespace nyx.auth {
    public class checkadmin : UdonSharpBehaviour {

        public UdonSharpBehaviour m_Target;
        public VRCUrl m_Url;
        public GameObject[] m_Objs;
        private string m_Response;
        private string[] m_Results;

        private bool m_IsAdmin;
        private string m_localName;


        private void _CheckAdmin() {
            m_localName = Networking.LocalPlayer.displayName;
            _DownloadList();
        }

        public void _DownloadList() {
            VRCStringDownloader.LoadUrl(m_Url, (IUdonEventReceiver)this);
            SendCustomEvent(nameof(_DownloadList));
        }

        public override void OnStringLoadSuccess(IVRCStringDownload result) {
            m_Response = result.Result;
            m_Results = m_Response.Split( new string[] {"\r","\n"}, StringSplitOptions.RemoveEmptyEntries);

            m_IsAdmin = false;
            foreach(string r in m_Results) {
                if(r == m_localName) {
                    m_IsAdmin = true;
                    break;
                }
            }

            Debug.Log("Admin Status:" + m_IsAdmin);

            foreach(GameObject obj in m_Objs) {
                obj.SetActive(m_IsAdmin);
            }
        }

        public override void OnStringLoadError(IVRCStringDownload result) {
            Debug.Log(result.Error);
        }
    }
}