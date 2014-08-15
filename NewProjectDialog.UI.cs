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
		Gdk.Color categoriesBackgroundColor = new Gdk.Color (227, 227, 227);
		Gdk.Color templateListBackgroundColor = new Gdk.Color (242, 242, 242);
		Gdk.Color templateBackgroundColor = new Gdk.Color (255, 255, 255);
		Gdk.Color templateSectionSeparatorColor = new Gdk.Color (208, 208, 208);

		void Build ()
		{
			BorderWidth = 0;
			DefaultWidth = 900;
			DefaultHeight = 560;

			Modal = true;
			Name = "NewProjectDialog";
			Title = Catalog.GetString ("New Project");
			WindowPosition = WindowPosition.CenterOnParent;

			// Top banner of dialog.
			var topLabelEventBox = new EventBox ();
			topLabelEventBox.HeightRequest = 53;
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

			// Main templates section.
			var centreVBox = new VBox ();
			VBox.PackStart (centreVBox, true, true, 0);
			var templatesHBox = new HBox ();
			centreVBox.PackEnd (templatesHBox, true, true, 0);

			// Template categories.
			var categoriesEventBox = new EventBox ();
			categoriesEventBox.ModifyBg (StateType.Normal, categoriesBackgroundColor);
			categoriesEventBox.WidthRequest = 220;
			templatesHBox.PackStart (categoriesEventBox, false, false, 0);

			// Template categories.
			var templateListEventBox = new EventBox ();
			templateListEventBox.ModifyBg (StateType.Normal, templateListBackgroundColor);
			templateListEventBox.WidthRequest = 217;
			templatesHBox.PackStart (templateListEventBox, false, false, 0);

			// Template
			var templateEventBox = new EventBox ();
			templateEventBox.ModifyBg (StateType.Normal, templateBackgroundColor);
			templatesHBox.PackStart (templateEventBox, true, true, 0);

			// Template - button separator.
			var templateSectionSeparatorEventBox = new EventBox ();
			templateSectionSeparatorEventBox.HeightRequest = 1;
			templateSectionSeparatorEventBox.ModifyBg (StateType.Normal, templateSectionSeparatorColor);
			VBox.PackStart (templateSectionSeparatorEventBox, false, false, 0);

			// Buttons at bottom of dialog.
			var bottomHBox = new HBox ();
			VBox.PackStart (bottomHBox, false, false, 0);

			// Cancel button - bottom left.
			var cancelButtonBox = new HButtonBox ();
			cancelButtonBox.BorderWidth = 14;
			var cancelButton = new Button ();
			cancelButton.Label = "gtk-cancel";
			cancelButton.UseStock = true;
			cancelButtonBox.PackStart (cancelButton, false, false, 0);
			bottomHBox.PackStart (cancelButtonBox, false, false, 0);

			// Previous button - bottom right.
			var previousNextButtonBox = new HButtonBox ();
			previousNextButtonBox.BorderWidth = 14;
			previousNextButtonBox.Spacing = 9;
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

