﻿//
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

using Gdk;
using Gtk;
using Mono.Unix;

namespace NewProjectDialogTest
{
	public partial class NewProjectDialog : Dialog
	{
		Color blueBackgroundColor = new Color (54, 155, 220);
		Color whiteColor = new Color (255, 255, 255);
		Color categoriesBackgroundColor = new Color (227, 227, 227);
		Color templateListBackgroundColor = new Color (242, 242, 242);
		Color templateBackgroundColor = new Color (255, 255, 255);
		Color templateSectionSeparatorColor = new Gdk.Color (208, 208, 208);
		Color selectedRowBackgroundColor = new Color (19, 112, 216);

		string chooseTemplateBannerText =  Catalog.GetString ("Choose a template for your new project");
		string configureYourProjectBannerText = Catalog.GetString ("Configure your new project");

		VBox centreVBox;
		HBox templatesHBox;
		Button cancelButton;
		Button previousButton;
		Button nextButton;
		Label topBannerLabel;

		TreeView templateCategoriesTreeView;
		const int TemplateCategoryColumn = 2;
		ListStore templateCategoriesListStore =
			new ListStore(typeof (Pixbuf), typeof (string), typeof(TemplateCategory));
		TreeView templatesTreeView;
		const int TemplateColumn = 2;
		ListStore templatesListStore =
			new ListStore(typeof (Pixbuf), typeof (string), typeof(SolutionTemplate));
		VBox templateVBox;
		Gtk.Image templateImage;
		Label templateNameLabel;
		Label templateDescriptionLabel;
		ProjectConfigurationWidget projectConfigurationWidget;
		TemplateCellRendererText templateTextRenderer;

		void Build ()
		{
			BorderWidth = 0;
			DefaultWidth = 900;
			DefaultHeight = 560;

			Modal = true;
			Name = "NewProjectDialog";
			Title = Catalog.GetString ("New Project");
			WindowPosition = WindowPosition.CenterOnParent;

			projectConfigurationWidget = new ProjectConfigurationWidget ();

			// Top banner of dialog.
			var topLabelEventBox = new EventBox ();
			topLabelEventBox.HeightRequest = 53;
			topLabelEventBox.ModifyBg (StateType.Normal, blueBackgroundColor);
			topLabelEventBox.ModifyFg (StateType.Normal, whiteColor);
			topLabelEventBox.BorderWidth = 0;

			topBannerLabel = new Label ();
			topBannerLabel.Text = chooseTemplateBannerText;
			Pango.FontDescription font = topBannerLabel.Style.FontDescription.Copy ();
			font.Size = (int)(font.Size * 1.8);
			topBannerLabel.ModifyFont (font);
			topBannerLabel.ModifyFg (StateType.Normal, whiteColor);
			var topLabelHBox = new HBox ();
			topLabelHBox.PackStart (topBannerLabel, false, false, 20);
			topLabelEventBox.Add (topLabelHBox);

			VBox.PackStart (topLabelEventBox, false, false, 0);

			// Main templates section.
			centreVBox = new VBox ();
			VBox.PackStart (centreVBox, true, true, 0);
			templatesHBox = new HBox ();
			centreVBox.PackEnd (templatesHBox, true, true, 0);

			// Template categories.
			var templateCategoriesVBox = new VBox ();
			templateCategoriesVBox.BorderWidth = 0;
			templateCategoriesVBox.WidthRequest = 220;
			var templateCategoriesScrolledWindow = new ScrolledWindow ();
			templateCategoriesScrolledWindow.HscrollbarPolicy = PolicyType.Never;

			// Template categories tree view.
			templateCategoriesTreeView = new TreeView ();
			templateCategoriesTreeView.BorderWidth = 0;
			templateCategoriesTreeView.HeadersVisible = false;
			templateCategoriesTreeView.Model = templateCategoriesListStore;
			templateCategoriesTreeView.ModifyBase (StateType.Normal, categoriesBackgroundColor);
			templateCategoriesTreeView.ModifyBase (StateType.Selected, selectedRowBackgroundColor);
			templateCategoriesTreeView.ModifyText (StateType.Selected, whiteColor);
			templateCategoriesTreeView.AppendColumn (CreateTemplateCategoriesTreeViewColumn ());
			templateCategoriesScrolledWindow.Add (templateCategoriesTreeView);
			templateCategoriesVBox.PackStart (templateCategoriesScrolledWindow, true, true, 0);
			templatesHBox.PackStart (templateCategoriesVBox, false, false, 0);

			// Templates.
			var templatesVBox = new VBox ();
			templatesVBox.WidthRequest = 217;
			templatesHBox.PackStart (templatesVBox, false, false, 0);
			var templatesScrolledWindow = new ScrolledWindow ();
			templatesScrolledWindow.HscrollbarPolicy = PolicyType.Never;

			// Templates tree view.
			templatesTreeView = new TreeView ();
			templatesTreeView.HeadersVisible = false;
			templatesTreeView.Model = templatesListStore;
			templatesTreeView.ModifyBase (StateType.Normal, templateListBackgroundColor);
			templatesTreeView.ModifyBase (StateType.Selected, selectedRowBackgroundColor);
			templatesTreeView.ModifyText (StateType.Selected, whiteColor);
			templatesTreeView.AppendColumn (CreateTemplateListTreeViewColumn ());
			templatesScrolledWindow.Add (templatesTreeView);
			templatesVBox.PackStart (templatesScrolledWindow, true, true, 0);

			// Template
			var templateEventBox = new EventBox ();
			templateEventBox.ModifyBg (StateType.Normal, templateBackgroundColor);
			templatesHBox.PackStart (templateEventBox, true, true, 0);
			templateVBox = new VBox ();
			templateVBox.Visible = false;
			templateEventBox.Add (templateVBox);

			// Template large image.
			templateImage = new Gtk.Image ();
			templateImage.HeightRequest = 300;
			templateVBox.PackStart (templateImage, false, false, 20);

			// Template description.
			var templateNameHBox = new HBox ();
			templateNameLabel = new Label ();
			templateNameHBox.PackStart (templateNameLabel, false, false, 40);
			var templateNamePaddingLabel = new Label ();
			templateNameHBox.PackStart (templateNamePaddingLabel, true, true, 0);
			templateVBox.PackStart (templateNameHBox, false, false, 0);
			var templateDescriptionHBox = new HBox ();
			templateDescriptionLabel = new Label ();
			templateDescriptionLabel.Wrap = true;
			templateDescriptionLabel.WidthRequest = 400;
			templateDescriptionHBox.PackStart (templateDescriptionLabel, false, false, 40);
			var templateDescriptionPaddingLabel = new Label ();
			templateDescriptionHBox.PackStart (templateDescriptionPaddingLabel, true, true, 0);
			templateVBox.PackStart (templateDescriptionHBox, true, true, 10);
			templateVBox.PackStart (new Label (), true, true, 0);

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
			cancelButton = new Button ();
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

			previousButton = new Button ();
			previousButton.Label = Catalog.GetString ("Previous");
			previousButton.Sensitive = false;
			previousNextButtonBox.PackEnd (previousButton);

			// Next button - bottom right.
			nextButton = new Button ();
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

		TreeViewColumn CreateTemplateCategoriesTreeViewColumn ()
		{
			var column = new TreeViewColumn ();

			var iconRenderer = new CellRendererPixbuf ();
			column.PackStart (iconRenderer, false);
			iconRenderer.CellBackgroundGdk = categoriesBackgroundColor;
			column.AddAttribute (iconRenderer, "pixbuf", column: 0);

			var textRenderer = new CellRendererText ();
			textRenderer.CellBackgroundGdk = categoriesBackgroundColor;

			column.PackStart (textRenderer, true);
			column.AddAttribute (textRenderer, "markup", column: 1);

			return column;
		}

		TreeViewColumn CreateTemplateListTreeViewColumn ()
		{
			var column = new TreeViewColumn ();

			var iconRenderer = new CellRendererPixbuf ();
			column.PackStart (iconRenderer, false);
			iconRenderer.CellBackgroundGdk = templateListBackgroundColor;
			column.AddAttribute (iconRenderer, "pixbuf", column: 0);

			templateTextRenderer = new TemplateCellRendererText ();
			templateTextRenderer.CellBackgroundGdk = templateListBackgroundColor;

			column.PackStart (templateTextRenderer, true);
			column.AddAttribute (templateTextRenderer, "markup", column: 1);

			return column;
		}
	}
}

