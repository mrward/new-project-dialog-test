//
// NewProjectController.cs
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
using System.Collections.Generic;

namespace NewProjectDialogTest
{
	public class NewProjectController : INewProjectController
	{
		List<TemplateCategory> templateCategories;

		public NewProjectController ()
		{
			LoadTemplateCategories ();
		}

		public IEnumerable<TemplateCategory> TemplateCategories {
			get { return templateCategories; }
		}

		void LoadTemplateCategories ()
		{
			templateCategories = new List<TemplateCategory> ();

			var appCategory = new TemplateCategory ("app", "App", null);
			var libraryCategory = new TemplateCategory ("library", "Library", null);
			var testsCategory = new TemplateCategory ("test", "Tests", null);

			var crossPlatformCategory = new TemplateCategory ("CrossPlat", "Cross-platform", "md-crossplatform-category");
			crossPlatformCategory.AddCategory (appCategory);
			crossPlatformCategory.AddCategory (libraryCategory);
			crossPlatformCategory.AddCategory (testsCategory);
			templateCategories.Add (crossPlatformCategory);

			var iosCategory = new TemplateCategory ("ios", "iOS", "md-ios-category");
			iosCategory.AddCategory (appCategory);
			iosCategory.AddCategory (libraryCategory);
			iosCategory.AddCategory (testsCategory);
			templateCategories.Add (iosCategory);

			var androidCategory = new TemplateCategory ("android", "Android", "md-android-category");
			androidCategory.AddCategory (appCategory);
			androidCategory.AddCategory (libraryCategory);
			androidCategory.AddCategory (testsCategory);
			templateCategories.Add (androidCategory);

			var osxCategory = new TemplateCategory ("osx", "OS X", "md-osx-category");
			osxCategory.AddCategory (appCategory);
			osxCategory.AddCategory (libraryCategory);
			templateCategories.Add (osxCategory);

			var aspNetCategory = new TemplateCategory ("aspnet", "ASP.NET", null);
			var miscCategory = new TemplateCategory ("misc", "Miscellaneous", null);
			var otherCategory = new TemplateCategory ("other", "Other", "md-other-category");
			otherCategory.AddCategory (aspNetCategory);
			otherCategory.AddCategory (miscCategory);
			templateCategories.Add (otherCategory);
		}
	}
}

