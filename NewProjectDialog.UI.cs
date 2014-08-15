//
// NewProjectDialog.UI.cs
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

using Gtk;
using Mono.Unix;

namespace NewProjectDialogTest
{
	public partial class NewProjectDialog : Dialog
	{
		Gdk.Color blueBackgroundColor = new Gdk.Color (54, 155, 220);
		Gdk.Color whiteColor = new Gdk.Color (255, 255, 255);

		void Build ()
		{
			BorderWidth = 0;
			DefaultWidth = 930;
			DefaultHeight = 540;

			Modal = true;
			Name = "NewProjectDialog";
			Title = Catalog.GetString ("New Project");
			WindowPosition = WindowPosition.CenterOnParent;

			// Top banner of dialog.
			var topLabelEventBox = new EventBox ();
			topLabelEventBox.HeightRequest = 55;
			topLabelEventBox.ModifyBg (StateType.Normal, blueBackgroundColor);
			topLabelEventBox.ModifyFg (StateType.Normal, new Gdk.Color (255, 255, 255));
			topLabelEventBox.BorderWidth = 0;

			var chooseTemplateLabel = new Label ();
			chooseTemplateLabel.Text = Catalog.GetString ("Choose a template for your new project");
			Pango.FontDescription font = chooseTemplateLabel.Style.FontDescription.Copy ();
			font.Size = (int)(font.Size * 1.8);
			chooseTemplateLabel.ModifyFont (font);
			chooseTemplateLabel.ModifyFg (StateType.Normal, whiteColor);
			var topLabelHBox = new HBox ();
			topLabelHBox.PackStart (chooseTemplateLabel, false, false, 20);
			topLabelEventBox.Add (topLabelHBox);

			VBox.PackStart (topLabelEventBox, false, false, 0);

			var centreVBox = new VBox ();
			var label = new Label ();
			centreVBox.PackEnd (label, true, true, 0);
			VBox.PackStart (centreVBox, true, true, 0);

			// Buttons at bottom of dialog.
			var bottomHBox = new HBox ();
			VBox.PackStart (bottomHBox, false, false, 0);

			// Cancel button - bottom left.
			var cancelButtonBox = new HButtonBox ();
			cancelButtonBox.BorderWidth = 15;
			var cancelButton = new Button ();
			cancelButton.Label = Catalog.GetString ("Cancel");
			cancelButtonBox.PackStart (cancelButton, false, false, 0);
			bottomHBox.PackStart (cancelButtonBox, false, false, 0);

			// Previous button - bottom right.
			var previousNextButtonBox = new HButtonBox ();
			previousNextButtonBox.BorderWidth = 15;
			previousNextButtonBox.Spacing = 10;
			bottomHBox.PackStart (previousNextButtonBox);
			previousNextButtonBox.Layout = ButtonBoxStyle.End;

			var previousButton = new Button ();
			previousButton.Label = Catalog.GetString ("Previous");
			previousNextButtonBox.PackEnd (previousButton);

			// Next button - bottom right.
			var nextButton = new Button ();
			nextButton.Label = Catalog.GetString ("Next");
			previousNextButtonBox.PackEnd (nextButton);

			// Remove default button action area.
			VBox.Remove (ActionArea);

			if (Child != null) {
				Child.ShowAll ();
			}

			Show ();

			VBox.BorderWidth = 0;
		}
	}
}

