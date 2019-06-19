﻿using System;

namespace HotForms {

	public abstract class HotPage : ViewBuilder {

		public HotPage()
		{
			this.PropertyChanged += HotPage_PropertyChanged;
		}

		private void HotPage_PropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			if (contentPage == null)
				return;
			if(e.PropertyName == nameof(View)) {
				ContentPage.Content = View;
			}
		}

		Xamarin.Forms.ContentPage contentPage;
		protected Xamarin.Forms.ContentPage ContentPage {
			get => contentPage ?? (contentPage = CreateContentPage ());
			set => contentPage = value;
		}

		Xamarin.Forms.ContentPage CreateContentPage() =>new Xamarin.Forms.ContentPage {
				Content = ReBuildView(),
			};


		public static implicit operator Xamarin.Forms.ContentPage (HotPage page) => page.ContentPage;
	}
}
