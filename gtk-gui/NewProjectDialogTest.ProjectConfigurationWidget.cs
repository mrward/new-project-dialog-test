
// This file has been generated by the GUI designer. Do not modify.
namespace NewProjectDialogTest
{
	public partial class ProjectConfigurationWidget
	{
		private global::Gtk.HBox mainHBox;
		
		private global::Gtk.EventBox projectConfigurationTableEventBox;
		
		private global::Gtk.Table projectConfigurationTable;
		
		private global::Gtk.Button browseButton;
		
		private global::Gtk.CheckButton createGitIgnoreFileCheckBox;
		
		private global::Gtk.CheckButton createProjectWithinSolutionDirectoryCheckBox;
		
		private global::Gtk.Label gitSpacerLabel1;
		
		private global::Gtk.Label gitSpacerLabel2;
		
		private global::Gtk.HBox locationLabelHBox;
		
		private global::Gtk.Label locationPaddingLabel;
		
		private global::Gtk.Label locationLabel;
		
		private global::Gtk.Entry locationTextBox;
		
		private global::Gtk.HBox projectNameLabelHBox;
		
		private global::Gtk.Label projectNamePaddingLabel;
		
		private global::Gtk.Label projectNameLabel;
		
		private global::Gtk.Entry projectNameTextBox;
		
		private global::Gtk.Label solutionLocationSpacerLabel1;
		
		private global::Gtk.Label solutionLocationSpacerLabel2;
		
		private global::Gtk.HBox solutionNameLabelHBox;
		
		private global::Gtk.Label solutionNamePaddingLabel;
		
		private global::Gtk.Label solutionNameLabel;
		
		private global::Gtk.Entry solutionNameTextBox;
		
		private global::Gtk.CheckButton useGitCheckBox;
		
		private global::Gtk.HBox versionControlLabelHBox;
		
		private global::Gtk.Label versionControlPaddingLabel;
		
		private global::Gtk.Label versionControlLabel;
		
		private global::Gtk.EventBox eventbox;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget NewProjectDialogTest.ProjectConfigurationWidget
			global::Stetic.BinContainer.Attach (this);
			this.Name = "NewProjectDialogTest.ProjectConfigurationWidget";
			// Container child NewProjectDialogTest.ProjectConfigurationWidget.Gtk.Container+ContainerChild
			this.mainHBox = new global::Gtk.HBox ();
			this.mainHBox.Name = "mainHBox";
			// Container child mainHBox.Gtk.Box+BoxChild
			this.projectConfigurationTableEventBox = new global::Gtk.EventBox ();
			this.projectConfigurationTableEventBox.Name = "projectConfigurationTableEventBox";
			// Container child projectConfigurationTableEventBox.Gtk.Container+ContainerChild
			this.projectConfigurationTable = new global::Gtk.Table (((uint)(10)), ((uint)(3)), false);
			this.projectConfigurationTable.Name = "projectConfigurationTable";
			this.projectConfigurationTable.RowSpacing = ((uint)(6));
			this.projectConfigurationTable.ColumnSpacing = ((uint)(6));
			this.projectConfigurationTable.BorderWidth = ((uint)(40));
			// Container child projectConfigurationTable.Gtk.Table+TableChild
			this.browseButton = new global::Gtk.Button ();
			this.browseButton.CanFocus = true;
			this.browseButton.Name = "browseButton";
			this.browseButton.UseUnderline = true;
			this.browseButton.Label = global::Mono.Unix.Catalog.GetString ("Browse...");
			this.projectConfigurationTable.Add (this.browseButton);
			global::Gtk.Table.TableChild w1 = ((global::Gtk.Table.TableChild)(this.projectConfigurationTable [this.browseButton]));
			w1.TopAttach = ((uint)(4));
			w1.BottomAttach = ((uint)(5));
			w1.LeftAttach = ((uint)(2));
			w1.RightAttach = ((uint)(3));
			w1.XOptions = ((global::Gtk.AttachOptions)(4));
			w1.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child projectConfigurationTable.Gtk.Table+TableChild
			this.createGitIgnoreFileCheckBox = new global::Gtk.CheckButton ();
			this.createGitIgnoreFileCheckBox.CanFocus = true;
			this.createGitIgnoreFileCheckBox.Name = "createGitIgnoreFileCheckBox";
			this.createGitIgnoreFileCheckBox.Label = global::Mono.Unix.Catalog.GetString ("Create a .gitignore file to ignore inessential files.");
			this.createGitIgnoreFileCheckBox.Active = true;
			this.createGitIgnoreFileCheckBox.DrawIndicator = true;
			this.createGitIgnoreFileCheckBox.UseUnderline = true;
			this.projectConfigurationTable.Add (this.createGitIgnoreFileCheckBox);
			global::Gtk.Table.TableChild w2 = ((global::Gtk.Table.TableChild)(this.projectConfigurationTable [this.createGitIgnoreFileCheckBox]));
			w2.TopAttach = ((uint)(9));
			w2.BottomAttach = ((uint)(10));
			w2.LeftAttach = ((uint)(1));
			w2.RightAttach = ((uint)(3));
			w2.XOptions = ((global::Gtk.AttachOptions)(4));
			w2.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child projectConfigurationTable.Gtk.Table+TableChild
			this.createProjectWithinSolutionDirectoryCheckBox = new global::Gtk.CheckButton ();
			this.createProjectWithinSolutionDirectoryCheckBox.CanFocus = true;
			this.createProjectWithinSolutionDirectoryCheckBox.Name = "createProjectWithinSolutionDirectoryCheckBox";
			this.createProjectWithinSolutionDirectoryCheckBox.Label = global::Mono.Unix.Catalog.GetString ("Create a project within the solution directory.");
			this.createProjectWithinSolutionDirectoryCheckBox.Active = true;
			this.createProjectWithinSolutionDirectoryCheckBox.DrawIndicator = true;
			this.createProjectWithinSolutionDirectoryCheckBox.UseUnderline = true;
			this.projectConfigurationTable.Add (this.createProjectWithinSolutionDirectoryCheckBox);
			global::Gtk.Table.TableChild w3 = ((global::Gtk.Table.TableChild)(this.projectConfigurationTable [this.createProjectWithinSolutionDirectoryCheckBox]));
			w3.TopAttach = ((uint)(5));
			w3.BottomAttach = ((uint)(6));
			w3.LeftAttach = ((uint)(1));
			w3.RightAttach = ((uint)(3));
			w3.XOptions = ((global::Gtk.AttachOptions)(4));
			w3.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child projectConfigurationTable.Gtk.Table+TableChild
			this.gitSpacerLabel1 = new global::Gtk.Label ();
			this.gitSpacerLabel1.Name = "gitSpacerLabel1";
			this.projectConfigurationTable.Add (this.gitSpacerLabel1);
			global::Gtk.Table.TableChild w4 = ((global::Gtk.Table.TableChild)(this.projectConfigurationTable [this.gitSpacerLabel1]));
			w4.TopAttach = ((uint)(6));
			w4.BottomAttach = ((uint)(7));
			w4.XOptions = ((global::Gtk.AttachOptions)(4));
			w4.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child projectConfigurationTable.Gtk.Table+TableChild
			this.gitSpacerLabel2 = new global::Gtk.Label ();
			this.gitSpacerLabel2.Name = "gitSpacerLabel2";
			this.projectConfigurationTable.Add (this.gitSpacerLabel2);
			global::Gtk.Table.TableChild w5 = ((global::Gtk.Table.TableChild)(this.projectConfigurationTable [this.gitSpacerLabel2]));
			w5.TopAttach = ((uint)(7));
			w5.BottomAttach = ((uint)(8));
			w5.XOptions = ((global::Gtk.AttachOptions)(4));
			w5.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child projectConfigurationTable.Gtk.Table+TableChild
			this.locationLabelHBox = new global::Gtk.HBox ();
			this.locationLabelHBox.Name = "locationLabelHBox";
			this.locationLabelHBox.Spacing = 6;
			// Container child locationLabelHBox.Gtk.Box+BoxChild
			this.locationPaddingLabel = new global::Gtk.Label ();
			this.locationPaddingLabel.Name = "locationPaddingLabel";
			this.locationLabelHBox.Add (this.locationPaddingLabel);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.locationLabelHBox [this.locationPaddingLabel]));
			w6.Position = 0;
			// Container child locationLabelHBox.Gtk.Box+BoxChild
			this.locationLabel = new global::Gtk.Label ();
			this.locationLabel.Name = "locationLabel";
			this.locationLabel.Xpad = 5;
			this.locationLabel.LabelProp = global::Mono.Unix.Catalog.GetString ("Location");
			this.locationLabel.Justify = ((global::Gtk.Justification)(1));
			this.locationLabelHBox.Add (this.locationLabel);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.locationLabelHBox [this.locationLabel]));
			w7.Position = 1;
			w7.Expand = false;
			w7.Fill = false;
			this.projectConfigurationTable.Add (this.locationLabelHBox);
			global::Gtk.Table.TableChild w8 = ((global::Gtk.Table.TableChild)(this.projectConfigurationTable [this.locationLabelHBox]));
			w8.TopAttach = ((uint)(4));
			w8.BottomAttach = ((uint)(5));
			w8.XOptions = ((global::Gtk.AttachOptions)(4));
			w8.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child projectConfigurationTable.Gtk.Table+TableChild
			this.locationTextBox = new global::Gtk.Entry ();
			this.locationTextBox.CanFocus = true;
			this.locationTextBox.Name = "locationTextBox";
			this.locationTextBox.IsEditable = true;
			this.locationTextBox.InvisibleChar = '●';
			this.projectConfigurationTable.Add (this.locationTextBox);
			global::Gtk.Table.TableChild w9 = ((global::Gtk.Table.TableChild)(this.projectConfigurationTable [this.locationTextBox]));
			w9.TopAttach = ((uint)(4));
			w9.BottomAttach = ((uint)(5));
			w9.LeftAttach = ((uint)(1));
			w9.RightAttach = ((uint)(2));
			w9.XOptions = ((global::Gtk.AttachOptions)(4));
			w9.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child projectConfigurationTable.Gtk.Table+TableChild
			this.projectNameLabelHBox = new global::Gtk.HBox ();
			this.projectNameLabelHBox.Name = "projectNameLabelHBox";
			this.projectNameLabelHBox.Spacing = 6;
			// Container child projectNameLabelHBox.Gtk.Box+BoxChild
			this.projectNamePaddingLabel = new global::Gtk.Label ();
			this.projectNamePaddingLabel.Name = "projectNamePaddingLabel";
			this.projectNameLabelHBox.Add (this.projectNamePaddingLabel);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.projectNameLabelHBox [this.projectNamePaddingLabel]));
			w10.Position = 0;
			// Container child projectNameLabelHBox.Gtk.Box+BoxChild
			this.projectNameLabel = new global::Gtk.Label ();
			this.projectNameLabel.Name = "projectNameLabel";
			this.projectNameLabel.Xpad = 5;
			this.projectNameLabel.LabelProp = global::Mono.Unix.Catalog.GetString ("Project Name");
			this.projectNameLabel.Justify = ((global::Gtk.Justification)(1));
			this.projectNameLabelHBox.Add (this.projectNameLabel);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.projectNameLabelHBox [this.projectNameLabel]));
			w11.Position = 1;
			w11.Expand = false;
			w11.Fill = false;
			this.projectConfigurationTable.Add (this.projectNameLabelHBox);
			global::Gtk.Table.TableChild w12 = ((global::Gtk.Table.TableChild)(this.projectConfigurationTable [this.projectNameLabelHBox]));
			w12.XOptions = ((global::Gtk.AttachOptions)(4));
			w12.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child projectConfigurationTable.Gtk.Table+TableChild
			this.projectNameTextBox = new global::Gtk.Entry ();
			this.projectNameTextBox.CanFocus = true;
			this.projectNameTextBox.Name = "projectNameTextBox";
			this.projectNameTextBox.IsEditable = true;
			this.projectNameTextBox.InvisibleChar = '●';
			this.projectConfigurationTable.Add (this.projectNameTextBox);
			global::Gtk.Table.TableChild w13 = ((global::Gtk.Table.TableChild)(this.projectConfigurationTable [this.projectNameTextBox]));
			w13.LeftAttach = ((uint)(1));
			w13.RightAttach = ((uint)(2));
			w13.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child projectConfigurationTable.Gtk.Table+TableChild
			this.solutionLocationSpacerLabel1 = new global::Gtk.Label ();
			this.solutionLocationSpacerLabel1.Name = "solutionLocationSpacerLabel1";
			this.projectConfigurationTable.Add (this.solutionLocationSpacerLabel1);
			global::Gtk.Table.TableChild w14 = ((global::Gtk.Table.TableChild)(this.projectConfigurationTable [this.solutionLocationSpacerLabel1]));
			w14.TopAttach = ((uint)(2));
			w14.BottomAttach = ((uint)(3));
			w14.XOptions = ((global::Gtk.AttachOptions)(4));
			w14.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child projectConfigurationTable.Gtk.Table+TableChild
			this.solutionLocationSpacerLabel2 = new global::Gtk.Label ();
			this.solutionLocationSpacerLabel2.Name = "solutionLocationSpacerLabel2";
			this.projectConfigurationTable.Add (this.solutionLocationSpacerLabel2);
			global::Gtk.Table.TableChild w15 = ((global::Gtk.Table.TableChild)(this.projectConfigurationTable [this.solutionLocationSpacerLabel2]));
			w15.TopAttach = ((uint)(3));
			w15.BottomAttach = ((uint)(4));
			w15.XOptions = ((global::Gtk.AttachOptions)(4));
			w15.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child projectConfigurationTable.Gtk.Table+TableChild
			this.solutionNameLabelHBox = new global::Gtk.HBox ();
			this.solutionNameLabelHBox.Name = "solutionNameLabelHBox";
			this.solutionNameLabelHBox.Spacing = 6;
			// Container child solutionNameLabelHBox.Gtk.Box+BoxChild
			this.solutionNamePaddingLabel = new global::Gtk.Label ();
			this.solutionNamePaddingLabel.Name = "solutionNamePaddingLabel";
			this.solutionNameLabelHBox.Add (this.solutionNamePaddingLabel);
			global::Gtk.Box.BoxChild w16 = ((global::Gtk.Box.BoxChild)(this.solutionNameLabelHBox [this.solutionNamePaddingLabel]));
			w16.Position = 0;
			// Container child solutionNameLabelHBox.Gtk.Box+BoxChild
			this.solutionNameLabel = new global::Gtk.Label ();
			this.solutionNameLabel.Name = "solutionNameLabel";
			this.solutionNameLabel.Xpad = 5;
			this.solutionNameLabel.LabelProp = global::Mono.Unix.Catalog.GetString ("Solution Name");
			this.solutionNameLabel.Justify = ((global::Gtk.Justification)(1));
			this.solutionNameLabelHBox.Add (this.solutionNameLabel);
			global::Gtk.Box.BoxChild w17 = ((global::Gtk.Box.BoxChild)(this.solutionNameLabelHBox [this.solutionNameLabel]));
			w17.Position = 1;
			w17.Expand = false;
			w17.Fill = false;
			this.projectConfigurationTable.Add (this.solutionNameLabelHBox);
			global::Gtk.Table.TableChild w18 = ((global::Gtk.Table.TableChild)(this.projectConfigurationTable [this.solutionNameLabelHBox]));
			w18.TopAttach = ((uint)(1));
			w18.BottomAttach = ((uint)(2));
			w18.XOptions = ((global::Gtk.AttachOptions)(4));
			w18.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child projectConfigurationTable.Gtk.Table+TableChild
			this.solutionNameTextBox = new global::Gtk.Entry ();
			this.solutionNameTextBox.CanFocus = true;
			this.solutionNameTextBox.Name = "solutionNameTextBox";
			this.solutionNameTextBox.IsEditable = true;
			this.solutionNameTextBox.InvisibleChar = '●';
			this.projectConfigurationTable.Add (this.solutionNameTextBox);
			global::Gtk.Table.TableChild w19 = ((global::Gtk.Table.TableChild)(this.projectConfigurationTable [this.solutionNameTextBox]));
			w19.TopAttach = ((uint)(1));
			w19.BottomAttach = ((uint)(2));
			w19.LeftAttach = ((uint)(1));
			w19.RightAttach = ((uint)(2));
			w19.XOptions = ((global::Gtk.AttachOptions)(4));
			w19.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child projectConfigurationTable.Gtk.Table+TableChild
			this.useGitCheckBox = new global::Gtk.CheckButton ();
			this.useGitCheckBox.CanFocus = true;
			this.useGitCheckBox.Name = "useGitCheckBox";
			this.useGitCheckBox.Label = global::Mono.Unix.Catalog.GetString ("Use git for version control.");
			this.useGitCheckBox.Active = true;
			this.useGitCheckBox.DrawIndicator = true;
			this.useGitCheckBox.UseUnderline = true;
			this.projectConfigurationTable.Add (this.useGitCheckBox);
			global::Gtk.Table.TableChild w20 = ((global::Gtk.Table.TableChild)(this.projectConfigurationTable [this.useGitCheckBox]));
			w20.TopAttach = ((uint)(8));
			w20.BottomAttach = ((uint)(9));
			w20.LeftAttach = ((uint)(1));
			w20.RightAttach = ((uint)(3));
			w20.XOptions = ((global::Gtk.AttachOptions)(4));
			w20.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child projectConfigurationTable.Gtk.Table+TableChild
			this.versionControlLabelHBox = new global::Gtk.HBox ();
			this.versionControlLabelHBox.Name = "versionControlLabelHBox";
			this.versionControlLabelHBox.Spacing = 6;
			// Container child versionControlLabelHBox.Gtk.Box+BoxChild
			this.versionControlPaddingLabel = new global::Gtk.Label ();
			this.versionControlPaddingLabel.Name = "versionControlPaddingLabel";
			this.versionControlLabelHBox.Add (this.versionControlPaddingLabel);
			global::Gtk.Box.BoxChild w21 = ((global::Gtk.Box.BoxChild)(this.versionControlLabelHBox [this.versionControlPaddingLabel]));
			w21.Position = 0;
			// Container child versionControlLabelHBox.Gtk.Box+BoxChild
			this.versionControlLabel = new global::Gtk.Label ();
			this.versionControlLabel.Name = "versionControlLabel";
			this.versionControlLabel.Xpad = 5;
			this.versionControlLabel.LabelProp = global::Mono.Unix.Catalog.GetString ("Version Control");
			this.versionControlLabel.Justify = ((global::Gtk.Justification)(1));
			this.versionControlLabelHBox.Add (this.versionControlLabel);
			global::Gtk.Box.BoxChild w22 = ((global::Gtk.Box.BoxChild)(this.versionControlLabelHBox [this.versionControlLabel]));
			w22.Position = 1;
			w22.Expand = false;
			w22.Fill = false;
			this.projectConfigurationTable.Add (this.versionControlLabelHBox);
			global::Gtk.Table.TableChild w23 = ((global::Gtk.Table.TableChild)(this.projectConfigurationTable [this.versionControlLabelHBox]));
			w23.TopAttach = ((uint)(8));
			w23.BottomAttach = ((uint)(9));
			w23.XOptions = ((global::Gtk.AttachOptions)(4));
			w23.YOptions = ((global::Gtk.AttachOptions)(4));
			this.projectConfigurationTableEventBox.Add (this.projectConfigurationTable);
			this.mainHBox.Add (this.projectConfigurationTableEventBox);
			global::Gtk.Box.BoxChild w25 = ((global::Gtk.Box.BoxChild)(this.mainHBox [this.projectConfigurationTableEventBox]));
			w25.Position = 0;
			// Container child mainHBox.Gtk.Box+BoxChild
			this.eventbox = new global::Gtk.EventBox ();
			this.eventbox.WidthRequest = 100;
			this.eventbox.Name = "eventbox";
			this.mainHBox.Add (this.eventbox);
			global::Gtk.Box.BoxChild w26 = ((global::Gtk.Box.BoxChild)(this.mainHBox [this.eventbox]));
			w26.Position = 1;
			this.Add (this.mainHBox);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.Hide ();
		}
	}
}
