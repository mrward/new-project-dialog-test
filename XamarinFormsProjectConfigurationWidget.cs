//
// XamarinFormsProjectConfigurationWidget.cs
//
// Author:
//       Matt Ward <matt.ward@xamarin.com>
//
// Copyright (c) 2014 Xamarin Inc. (http://xamarin.com)
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
//

using System;
using Gdk;
using Gtk;
using Mono.Unix;

namespace NewProjectDialogTest
{
	[System.ComponentModel.ToolboxItem (true)]
	public partial class XamarinFormsProjectConfigurationWidget : WizardPage
	{
		int imageHeight;
		int imageWidth;

		public XamarinFormsProjectConfigurationWidget ()
		{
			this.Build ();
			mainEventBox.ModifyBg (StateType.Normal, new Color (255, 255, 255));
			Title = Catalog.GetString ("Configure your Xamarin.Forms app");

			imageHeight = backgroundImage.Pixbuf.Height;
			imageWidth = backgroundImage.Pixbuf.Width;

			appNameTextBox.Changed += AppNameTextBoxChanged;
			backgroundImage.ExposeEvent += BackgroundImageExposed;
		}

		string appName = String.Empty;

		public string AppName {
			get { return appName; }
			set {
				appName = value;
				if (IsRealized) {
					QueueDraw ();
				}
			}
		}

		void AppNameTextBoxChanged (object sender, EventArgs e)
		{
			AppName = appNameTextBox.Text;
		}

		void BackgroundImageExposed (object o, ExposeEventArgs args)
		{
			using (var layout = new Pango.Layout (backgroundImage.PangoContext)) {
				int yOffset = (backgroundImage.Allocation.Height - imageHeight) / 2;

				layout.SetMarkup ("<span foreground='#FFFFFF' size='xx-large'>" + GetShortAppName () + "</span>");
				int x = backgroundImage.Allocation.X + 112;
				int y = backgroundImage.Allocation.Y + 97 + yOffset;
				backgroundImage.GdkWindow.DrawLayout (backgroundImage.Style.TextGC (StateType.Normal), x, y, layout);

				layout.SetMarkup ("<span foreground='#FFFFFF' size='larger'>" + appName + "</span>");
				x = backgroundImage.Allocation.X + 90;
				y = backgroundImage.Allocation.Y + 152 + yOffset;
				backgroundImage.GdkWindow.DrawLayout (backgroundImage.Style.TextGC (StateType.Normal), x, y, layout);
			}
		}

		string GetShortAppName ()
		{
			if (AppName.Length > 2) {
				return AppName.Substring (0, 2);
			}
			return AppName;
		}
	}
}

