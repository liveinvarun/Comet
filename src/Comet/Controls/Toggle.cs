﻿using System;
using System.Collections.Generic;
using Microsoft.Maui;
using Microsoft.Maui.Graphics;

namespace Comet
{
	public class Toggle : View, ISwitch, IThumbView
	{
		protected static Dictionary<string, string> SliderHandlerPropertyMapper = new()
		{
			[nameof(Color)] = nameof(ISwitch.TrackColor),
			[nameof(EnvironmentKeys.Slider.ThumbColor)] = nameof(ISwitch.ThumbColor),
			[nameof(IsOn)] = nameof(ISwitch.IsToggled),
		};

		public Toggle(
			Binding<bool> value = null,
			Action<bool> onChanged = null)
		{
			IsOn = value;
			IsOnChanged = new MulticastAction<bool>(IsOn, onChanged);
		}

		Binding<bool> _isOn;
		public Binding<bool> IsOn
		{
			get => _isOn;
			private set => this.SetBindingValue(ref _isOn, value);
		}

		public Action<bool> IsOnChanged { get; private set; }
		bool ISwitch.IsToggled { get => IsOn; set => IsOn.Set(value); }

		Color ISwitch.TrackColor => this.GetColor();

		Color ISwitch.ThumbColor => this.GetThumbColor();
	}
}
