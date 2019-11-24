namespace SSI.UI.Forms
{
    partial class UserManagement
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserManagement));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barEditItem1 = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.barToggleSwitchItem1 = new DevExpress.XtraBars.BarToggleSwitchItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.userLocalBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.userView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserCreateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPassword = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.toggleSwitch3 = new DevExpress.XtraEditors.ToggleSwitch();
            this.toggleSwitch2 = new DevExpress.XtraEditors.ToggleSwitch();
            this.toggleSwitch1 = new DevExpress.XtraEditors.ToggleSwitch();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userLocalBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userView)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.toggleSwitch3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleSwitch2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleSwitch1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.barEditItem1,
            this.barToggleSwitchItem1,
            this.barButtonItem1,
            this.barButtonItem2});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 5;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEdit1});
            this.ribbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.ribbonControl1.Size = new System.Drawing.Size(594, 95);
            this.ribbonControl1.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // barEditItem1
            // 
            this.barEditItem1.Caption = "barEditItem1";
            this.barEditItem1.Edit = this.repositoryItemButtonEdit1;
            this.barEditItem1.Id = 1;
            this.barEditItem1.Name = "barEditItem1";
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            // 
            // barToggleSwitchItem1
            // 
            this.barToggleSwitchItem1.Caption = "barToggleSwitchItem1";
            this.barToggleSwitchItem1.Id = 2;
            this.barToggleSwitchItem1.Name = "barToggleSwitchItem1";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Добавить пользователя";
            this.barButtonItem1.Id = 3;
            this.barButtonItem1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem1.ImageOptions.SvgImage")));
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Удалить пользователя";
            this.barButtonItem2.Id = 4;
            this.barButtonItem2.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem2.ImageOptions.SvgImage")));
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Упралвение пользователями";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem1);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem2);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Инструменты";
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.userLocalBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 95);
            this.gridControl1.MainView = this.userView;
            this.gridControl1.MenuManager = this.ribbonControl1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.ShowOnlyPredefinedDetails = true;
            this.gridControl1.Size = new System.Drawing.Size(594, 324);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.userView});
            // 
            // userView
            // 
            this.userView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colEmail,
            this.colUserName,
            this.colUserCreateDate,
            this.colPassword});
            this.userView.GridControl = this.gridControl1;
            this.userView.Name = "userView";
            this.userView.OptionsBehavior.Editable = false;
            this.userView.OptionsView.ShowGroupPanel = false;
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            // 
            // colEmail
            // 
            this.colEmail.FieldName = "Email";
            this.colEmail.Name = "colEmail";
            // 
            // colUserName
            // 
            this.colUserName.Caption = "Пользователь";
            this.colUserName.FieldName = "UserName";
            this.colUserName.Name = "colUserName";
            this.colUserName.Visible = true;
            this.colUserName.VisibleIndex = 0;
            // 
            // colUserCreateDate
            // 
            this.colUserCreateDate.Caption = "Дата регистрации";
            this.colUserCreateDate.DisplayFormat.FormatString = "dd.MM.yyyy hh:mm";
            this.colUserCreateDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colUserCreateDate.FieldName = "CreatedDate";
            this.colUserCreateDate.Name = "colUserCreateDate";
            this.colUserCreateDate.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colUserCreateDate.Visible = true;
            this.colUserCreateDate.VisibleIndex = 1;
            // 
            // colPassword
            // 
            this.colPassword.FieldName = "Password";
            this.colPassword.Name = "colPassword";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.toggleSwitch3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.toggleSwitch2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.toggleSwitch1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 419);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(594, 29);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // toggleSwitch3
            // 
            this.toggleSwitch3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toggleSwitch3.Location = new System.Drawing.Point(399, 3);
            this.toggleSwitch3.MenuManager = this.ribbonControl1;
            this.toggleSwitch3.Name = "toggleSwitch3";
            this.toggleSwitch3.Properties.AccessibleName = "";
            this.toggleSwitch3.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.toggleSwitch3.Properties.OffText = "Диспечер OFF";
            this.toggleSwitch3.Properties.OnText = "Диспечер ON";
            this.toggleSwitch3.Size = new System.Drawing.Size(192, 23);
            this.toggleSwitch3.TabIndex = 2;
            this.toggleSwitch3.EditValueChanged += new System.EventHandler(this.toggleSwitch3_EditValueChanged);
            // 
            // toggleSwitch2
            // 
            this.toggleSwitch2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toggleSwitch2.Location = new System.Drawing.Point(201, 3);
            this.toggleSwitch2.MenuManager = this.ribbonControl1;
            this.toggleSwitch2.Name = "toggleSwitch2";
            this.toggleSwitch2.Properties.AccessibleName = "";
            this.toggleSwitch2.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.toggleSwitch2.Properties.OffText = "Оператор OFF";
            this.toggleSwitch2.Properties.OnText = "Оператор ON";
            this.toggleSwitch2.Size = new System.Drawing.Size(192, 23);
            this.toggleSwitch2.TabIndex = 1;
            this.toggleSwitch2.EditValueChanged += new System.EventHandler(this.toggleSwitch2_EditValueChanged);
            // 
            // toggleSwitch1
            // 
            this.toggleSwitch1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toggleSwitch1.Location = new System.Drawing.Point(3, 3);
            this.toggleSwitch1.MenuManager = this.ribbonControl1;
            this.toggleSwitch1.Name = "toggleSwitch1";
            this.toggleSwitch1.Properties.AccessibleName = "";
            this.toggleSwitch1.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.toggleSwitch1.Properties.NullText = "Администратор";
            this.toggleSwitch1.Properties.OffText = "Администратор OFF";
            this.toggleSwitch1.Properties.OnText = "Администратор ON";
            this.toggleSwitch1.Size = new System.Drawing.Size(192, 23);
            this.toggleSwitch1.TabIndex = 0;
            this.toggleSwitch1.EditValueChanged += new System.EventHandler(this.toggleSwitch1_EditValueChanged);
            // 
            // UserManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 448);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "UserManagement";
            this.ShowIcon = false;
            this.Text = "Упралвение пользователями";
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userLocalBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userView)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.toggleSwitch3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleSwitch2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleSwitch1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.BindingSource userLocalBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView userView;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colEmail;
        private DevExpress.XtraGrid.Columns.GridColumn colUserName;
        private DevExpress.XtraGrid.Columns.GridColumn colUserCreateDate;
        private DevExpress.XtraGrid.Columns.GridColumn colPassword;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraBars.BarEditItem barEditItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private DevExpress.XtraBars.BarToggleSwitchItem barToggleSwitchItem1;
        private DevExpress.XtraEditors.ToggleSwitch toggleSwitch3;
        private DevExpress.XtraEditors.ToggleSwitch toggleSwitch2;
        private DevExpress.XtraEditors.ToggleSwitch toggleSwitch1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
    }
}