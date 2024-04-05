using System;
using UdonSharp;
using UnityEngine;
using VRC.SDK3.StringLoading;
using VRC.SDKBase;
using VRC.Udon.Common.Interfaces;

namespace nyx.auth {
    public class checkadmin : UdonSharpBehaviour {
        public VRCUrl ListUrl;
        public GameObject[] Objs;
        public float Refresh = 60;
        private string Response;
        private string[] Results;

        private bool IsAdmin;
        private string localName;

        private void Start() {
            localName = Networking.LocalPlayer.displayName;
            _DownloadList();
        }

        public void _DownloadList() {
            VRCStringDownloader.LoadUrl(ListUrl, (IUdonEventReceiver)this);
            SendCustomEventDelayedSeconds(nameof(_DownloadList), Refresh);
        }

        public override void OnStringLoadSuccess(IVRCStringDownload result) {
            Response = result.Result;
            Results = Response.Split( new string[] {"\r","\n"}, StringSplitOptions.RemoveEmptyEntries);

            IsAdmin = false;
            foreach(string r in Results) {
                if(r == localName) {
                    IsAdmin = true;
                    break;
                }
            }

            Debug.Log("Admin Status:" + IsAdmin);

            foreach(GameObject obj in Objs) {
                obj.SetActive(IsAdmin);
            }
        }

        public override void OnStringLoadError(IVRCStringDownload result) {
            Debug.Log(result.Error);
        }
    }
}