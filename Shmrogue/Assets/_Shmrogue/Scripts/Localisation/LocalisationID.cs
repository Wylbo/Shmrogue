///-----------------------------------------------------------------
/// Author : Maximilien Galea
/// Date : 18/05/2020 11:59
///-----------------------------------------------------------------

using System;
using UnityEngine;
using UnityEngine.UI;

namespace Com.MaxmilienGalea.SummerTime.Localisation {
	public class LocalisationID : MonoBehaviour {
		private string _key = "";
		private Text _text;
		private bool _initialized = false;
		private bool _isValidKey = false;
		private Font _defaultFont;
		private float _defaultLineSpacing;
		private int _defaultFontSize;
		private TextAnchor _defaultAlignment;
		private string[] _params;

		private void Awake() {
			if (!_initialized) {
				init();
			}
			_UpdateTranslation();
		}

		private void OnEnable() {
			if (!_initialized) {
				init();
			}
			_UpdateTranslation();
		}

		private void init() {
			_text = GetComponent<Text>();
			_defaultFont = _text.font;
			_defaultLineSpacing = _text.lineSpacing;
			_defaultFontSize = _text.fontSize;
			_defaultAlignment = _text.alignment;
			_key = _text.text;
			_initialized = true;

			//LocalisationManager.OnLanguageChanged += LocalisationManager_OnLanguageChanged;

			if (!_key.StartsWith("^")) {
				_isValidKey = false;
				Debug.LogWarning(string.Format("{0}: translation key was not found ! Found {0}", this._key));
			} else {
				_isValidKey = true;
			}

			if (!_text) {
				Debug.LogWarning(string.Format("{0}: Text component was not found", this));
			}

		}

		//private void LocalisationManager_OnLanguageChanged(LanguageCode languageCode) {
		//	_UpdateTranslation();
		//}

		private void _UpdateTranslation() {
			if (_text) {
				if (!_isValidKey) {
					_key = _text.text;
					if (_key.StartsWith("^")) {
						_isValidKey = true;
					}
				}
				//_text.text = LocalisationManager.instance.GetValue(_key, _params);
			}
		}

		public void UpdateTranslation(bool invalidateKey = false) {
			if (invalidateKey) {
				_isValidKey = false;
			}
			_UpdateTranslation();
		}
	}
}