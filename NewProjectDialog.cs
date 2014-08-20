//
// NewProjectDialog.cs
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
using Gtk;
using Mono.Unix;

namespace NewProjectDialogTest
{
	public partial class NewProjectDialog : Dialog
	{
		INewProjectController controller;

		public NewProjectDialog ()
		{
			Build ();

			templateCategoriesTreeView.Selection.Changed += TemplateCategoriesTreeViewSelectionChanged;
			templatesTreeView.Selection.Changed += TemplatesTreeViewSelectionChanged;
			cancelButton.Clicked += CancelButtonClicked;
			nextButton.Clicked += (sender, e) => MoveToNextPage ();
			previousButton.Clicked += (sender, e) => MoveToPreviousPage ();
		}

		void TemplateCategoriesTreeViewSelectionChanged (object sender, EventArgs e)
		{
			ShowTemplatesForSelectedCategory ();
		}

		void TemplatesTreeViewSelectionChanged (object sender, EventArgs e)
		{
			ShowSelectedTemplate ();
		}

		void CancelButtonClicked (object sender, EventArgs e)
		{
			Destroy ();
		}

		public void RegisterController (INewProjectController controller)
		{
			this.controller = controller;
			LoadTemplates ();
			SelectFirstSubTemplateCategory ();
		}

		void LoadTemplates ()
		{
			foreach (TemplateCategory category in controller.TemplateCategories) {
				AddTopLevelTemplateCategory (category);
			}
		}

		void AddTopLevelTemplateCategory (TemplateCategory category)
		{
			templateCategoriesListStore.AppendValues (
				new Gdk.Pixbuf (typeof (NewProjectDialog).Assembly, category.IconId),
				MarkupTopLevelCategoryName (category.Name),
				category);

			foreach (TemplateCategory subCategory in category.Categories) {
				AddSubTemplateCategory (subCategory);
			}
		}

		void AddSubTemplateCategory (TemplateCategory category)
		{
			templateCategoriesListStore.AppendValues (
				null,
				category.Name,
				category);
		}

		static string MarkupTopLevelCategoryName (string name)
		{
			return "<span font_weight='bold' size='larger'>" + name + "</span>";
		}

		void ShowTemplatesForSelectedCategory ()
		{
			ClearSelectedCategoryInformation ();

			TemplateCategory category = GetSelectedTemplateCategory ();
			if ((category != null) && (category.IconId == null)) {
				ShowTemplatesForCategory (category);
				SelectFirstTemplate ();
			}
		}

		void ClearSelectedCategoryInformation ()
		{
			templatesListStore.Clear ();
		}

		TemplateCategory GetSelectedTemplateCategory ()
		{
			TreeIter item;
			if (templateCategoriesTreeView.Selection.GetSelected (out item)) {
				return templateCategoriesListStore.GetValue (item, TemplateCategoryColumn) as TemplateCategory;
			}
			return null;
		}

		void ShowTemplatesForCategory (TemplateCategory category)
		{
			foreach (TemplateCategory subCategory in category.Categories) {
				templatesListStore.AppendValues (
					null,
					MarkupTopLevelCategoryName (subCategory.Name),
					null);

				foreach (SolutionTemplate template in subCategory.Templates) {
					templatesListStore.AppendValues (
						new Gdk.Pixbuf (typeof (NewProjectDialog).Assembly, template.IconId),
						template.Name,
						template);
				}
			}
		}

		void ShowSelectedTemplate ()
		{
			ClearSelectedTemplateInformation ();

			SolutionTemplate template = GetSelectedTemplate ();
			if (template != null) {
				ShowTemplate (template);
			}
		}

		void ClearSelectedTemplateInformation ()
		{
			templateVBox.Visible = false;
		}

		SolutionTemplate GetSelectedTemplate ()
		{
			TreeIter item;
			if (templatesTreeView.Selection.GetSelected (out item)) {
				return templatesListStore.GetValue (item, TemplateColumn) as SolutionTemplate;
			}
			return null;
		}

		void ShowTemplate (SolutionTemplate template)
		{
			templateNameLabel.Markup = MarkupTopLevelCategoryName (template.Name);
			templateDescriptionLabel.Text = template.Description;
			templateImage.Pixbuf = new Gdk.Pixbuf (typeof(NewProjectDialog).Assembly, template.LargeImageId);
			templateVBox.Visible = true;
			templateVBox.ShowAll ();
		}

		void SelectFirstSubTemplateCategory ()
		{
			TreeIter iter = TreeIter.Zero;
			if (templateCategoriesListStore.IterNthChild (out iter, 1)) {
				templateCategoriesTreeView.Selection.SelectIter (iter);
			}
		}

		void SelectFirstTemplate ()
		{
			TreeIter iter = TreeIter.Zero;
			if (templatesListStore.IterNthChild (out iter, 1)) {
				templatesTreeView.Selection.SelectIter (iter);
			}
		}

		void MoveToNextPage ()
		{
			centreVBox.Remove (templatesHBox);
			projectConfigurationWidget.Show ();
			centreVBox.PackStart (projectConfigurationWidget, true, true, 0);

			topBannerLabel.Text = configureYourProjectBannerText;

			previousButton.Sensitive = true;
			nextButton.Label = Catalog.GetString ("Create");
		}

		void MoveToPreviousPage ()
		{
			centreVBox.Remove (projectConfigurationWidget);
			centreVBox.PackStart (templatesHBox, true, true, 0);

			topBannerLabel.Text = chooseTemplateBannerText;

			previousButton.Sensitive = false;
			nextButton.Label = Catalog.GetString ("Next");
		}
	}
}

