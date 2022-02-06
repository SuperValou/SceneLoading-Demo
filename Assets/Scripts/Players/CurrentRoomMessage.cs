using System.IO;
using Packages.UniKit.Runtime.Extensions;
using Packages.UniKit.Runtime.PersistentVariables;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Players
{
    public class CurrentRoomMessage : MonoBehaviour
    {
        public PersistentString playerCurrentRoom;

        private TMP_Text _text;
        private string _initialText;

        void Start()
        {
            _text = this.GetOrThrow<TMP_Text>();
            _initialText = _text.text;

            var roomName = Path.GetFileNameWithoutExtension(playerCurrentRoom.Value);
            _text.text = string.Format(_initialText, roomName);
            playerCurrentRoom.ValueChanged += OnValueChanged;
        }

        private void OnValueChanged(string newRoom)
        {
            var roomName = Path.GetFileNameWithoutExtension(newRoom);
            _text.text = string.Format(_initialText, roomName);
        }

        void OnDestroy()
        {
            playerCurrentRoom.ValueChanged -= OnValueChanged;
        }
    }
}