/*
 * Created by SharpDevelop.
 * User: Benoit Le Guern
 * Date: 17/07/2008
 * Time: 15:04
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace xls2csv
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.buttonXls = new System.Windows.Forms.Button();
			this.textBoxXlsFolder = new System.Windows.Forms.TextBox();
			this.buttonOpenXlsFolder = new System.Windows.Forms.Button();
			this.folderBrowserDialogXls = new System.Windows.Forms.FolderBrowserDialog();
			this.groupBoxPF = new System.Windows.Forms.GroupBox();
			this.groupBox7 = new System.Windows.Forms.GroupBox();
			this.buttonOpenItemGeneralParamsFile = new System.Windows.Forms.Button();
			this.textBoxItemGeneralParamsFile = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.textBoxItemV9CostFile = new System.Windows.Forms.TextBox();
			this.buttonOpenItemV9CostFile = new System.Windows.Forms.Button();
			this.label24 = new System.Windows.Forms.Label();
			this.textBoxItemV9ProdLineFile = new System.Windows.Forms.TextBox();
			this.labelV9File = new System.Windows.Forms.Label();
			this.buttonOpenItemV9ProdLineFile = new System.Windows.Forms.Button();
			this.textBoxItemV9File = new System.Windows.Forms.TextBox();
			this.textBoxItemV9LastProdLineFile = new System.Windows.Forms.TextBox();
			this.buttonOpenItemV9LastProdLineFile = new System.Windows.Forms.Button();
			this.buttonOpenItemV9File = new System.Windows.Forms.Button();
			this.labelV9LigneProdFile = new System.Windows.Forms.Label();
			this.labelV9LastLigneProdFile = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.buttonOpenItemAnalysisCodeBrandFile = new System.Windows.Forms.Button();
			this.textBoxItemAnalysisCodeBrandFile = new System.Windows.Forms.TextBox();
			this.label28 = new System.Windows.Forms.Label();
			this.label27 = new System.Windows.Forms.Label();
			this.buttonOpenItemIntrastatCodeFile = new System.Windows.Forms.Button();
			this.textBoxItemIntrastatCodeFile = new System.Windows.Forms.TextBox();
			this.textBoxItemCostFile = new System.Windows.Forms.TextBox();
			this.label25 = new System.Windows.Forms.Label();
			this.buttonOpenItemCostFile = new System.Windows.Forms.Button();
			this.textBoxItemDSRPFile = new System.Windows.Forms.TextBox();
			this.label18 = new System.Windows.Forms.Label();
			this.labelRawFile = new System.Windows.Forms.Label();
			this.buttonOpenItemDSRPFile = new System.Windows.Forms.Button();
			this.label22 = new System.Windows.Forms.Label();
			this.textBoxItemRawFile = new System.Windows.Forms.TextBox();
			this.buttonOpenItemRawFile = new System.Windows.Forms.Button();
			this.buttonOpenItemIntrastatFile = new System.Windows.Forms.Button();
			this.textBoxItemIntrastatFile = new System.Windows.Forms.TextBox();
			this.buttonOpenItemAnalysisCodeFile = new System.Windows.Forms.Button();
			this.textBoxItemAnalysisCodeFile = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.labelPFFile = new System.Windows.Forms.Label();
			this.textBoxItemFile = new System.Windows.Forms.TextBox();
			this.buttonOpenItemFile = new System.Windows.Forms.Button();
			this.textBoxItemSiteCellProdLineFile = new System.Windows.Forms.TextBox();
			this.buttonOpenItemSiteCellProdLineFile = new System.Windows.Forms.Button();
			this.textBoxItemProdLineFile = new System.Windows.Forms.TextBox();
			this.buttonOpenItemProdLineFile = new System.Windows.Forms.Button();
			this.labelLeaderFile = new System.Windows.Forms.Label();
			this.labelSiteCelluleFile = new System.Windows.Forms.Label();
			this.buttonOpenItemLeaderFile = new System.Windows.Forms.Button();
			this.labelLigneProdFile = new System.Windows.Forms.Label();
			this.textBoxItemLeaderFile = new System.Windows.Forms.TextBox();
			this.buttonItem = new System.Windows.Forms.Button();
			this.openFileDialogItem = new System.Windows.Forms.OpenFileDialog();
			this.labelXls = new System.Windows.Forms.Label();
			this.buttonQuit = new System.Windows.Forms.Button();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.textBoxCustomerGeneralParamsFile = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.buttonOpenCustomerGeneralParamsFile = new System.Windows.Forms.Button();
			this.buttonOpenCustomerItemFile = new System.Windows.Forms.Button();
			this.label15 = new System.Windows.Forms.Label();
			this.textBoxCustomerItemFile = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.buttonOpenCustomerTreeFile = new System.Windows.Forms.Button();
			this.textBoxCustomerTreeFile = new System.Windows.Forms.TextBox();
			this.buttonCustomer = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.textBoxCustomerBusinessRelationFile = new System.Windows.Forms.TextBox();
			this.buttonOpenCustomerBusinessRelationFile = new System.Windows.Forms.Button();
			this.textBoxCustomerFinancialFile = new System.Windows.Forms.TextBox();
			this.buttonOpenCustomerFinancialFile = new System.Windows.Forms.Button();
			this.textBoxCustomerFile = new System.Windows.Forms.TextBox();
			this.buttonOpenCustomerFile = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.buttonOpenCustomerDeliveryFile = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.textBoxCustomerDeliveryFile = new System.Windows.Forms.TextBox();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.textBoxSupplierItemFile = new System.Windows.Forms.TextBox();
			this.buttonOpenSupplierItemFile = new System.Windows.Forms.Button();
			this.label17 = new System.Windows.Forms.Label();
			this.textBoxSupplierV9ItemFile = new System.Windows.Forms.TextBox();
			this.buttonOpenSupplierV9ItemFile = new System.Windows.Forms.Button();
			this.label16 = new System.Windows.Forms.Label();
			this.textBoxSupplierGeneralParamsFile = new System.Windows.Forms.TextBox();
			this.buttonOpenSupplierGeneralParamsFile = new System.Windows.Forms.Button();
			this.label14 = new System.Windows.Forms.Label();
			this.textBoxSupplierV9File = new System.Windows.Forms.TextBox();
			this.buttonOpenSupplierV9File = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.buttonSupplier = new System.Windows.Forms.Button();
			this.label8 = new System.Windows.Forms.Label();
			this.textBoxSupplierBusinessRelationFile = new System.Windows.Forms.TextBox();
			this.buttonOpenSupplierBusinessRelationFile = new System.Windows.Forms.Button();
			this.textBoxSupplierFinancialFile = new System.Windows.Forms.TextBox();
			this.buttonOpenSupplierFinancialFile = new System.Windows.Forms.Button();
			this.textBoxSupplierFile = new System.Windows.Forms.TextBox();
			this.buttonOpenSupplierFile = new System.Windows.Forms.Button();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.groupBox9 = new System.Windows.Forms.GroupBox();
			this.label21 = new System.Windows.Forms.Label();
			this.textBoxProdStructV9File = new System.Windows.Forms.TextBox();
			this.buttonOpenProdStructV9File = new System.Windows.Forms.Button();
			this.label7 = new System.Windows.Forms.Label();
			this.textBoxProdStructFile = new System.Windows.Forms.TextBox();
			this.buttonOpenProdStructFile = new System.Windows.Forms.Button();
			this.buttonProdStruct = new System.Windows.Forms.Button();
			this.textBoxProdStructCodeV9File = new System.Windows.Forms.TextBox();
			this.label19 = new System.Windows.Forms.Label();
			this.buttonOpenProdStructCodeV9File = new System.Windows.Forms.Button();
			this.textBoxProdStructCodeFile = new System.Windows.Forms.TextBox();
			this.buttonOpenProdStructCodeFile = new System.Windows.Forms.Button();
			this.label20 = new System.Windows.Forms.Label();
			this.label26 = new System.Windows.Forms.Label();
			this.buttonOpenRoutingFile = new System.Windows.Forms.Button();
			this.textBoxRoutingFile = new System.Windows.Forms.TextBox();
			this.buttonOpenRoutingV9File = new System.Windows.Forms.Button();
			this.textBoxRoutingV9File = new System.Windows.Forms.TextBox();
			this.label23 = new System.Windows.Forms.Label();
			this.buttonRouting = new System.Windows.Forms.Button();
			this.groupBox10 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.buttonWorkCenter = new System.Windows.Forms.Button();
			this.label29 = new System.Windows.Forms.Label();
			this.textBoxWorkCenterV9File = new System.Windows.Forms.TextBox();
			this.buttonOpenWorkCenterV9File = new System.Windows.Forms.Button();
			this.textBoxWorkCenterFile = new System.Windows.Forms.TextBox();
			this.buttonOpenWorkCenterFile = new System.Windows.Forms.Button();
			this.label30 = new System.Windows.Forms.Label();
			this.groupBox8 = new System.Windows.Forms.GroupBox();
			this.buttonProductionLine = new System.Windows.Forms.Button();
			this.buttonOpenProductionLineFile = new System.Windows.Forms.Button();
			this.textBoxProductionLineFile = new System.Windows.Forms.TextBox();
			this.label31 = new System.Windows.Forms.Label();
			this.groupBoxPF.SuspendLayout();
			this.groupBox7.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.groupBox9.SuspendLayout();
			this.groupBox10.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox8.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonXls
			// 
			this.buttonXls.Enabled = false;
			this.buttonXls.Location = new System.Drawing.Point(482, 10);
			this.buttonXls.Name = "buttonXls";
			this.buttonXls.Size = new System.Drawing.Size(51, 23);
			this.buttonXls.TabIndex = 0;
			this.buttonXls.Text = "OK";
			this.buttonXls.UseVisualStyleBackColor = true;
			this.buttonXls.Click += new System.EventHandler(this.ButtonXlsClick);
			// 
			// textBoxXlsFolder
			// 
			this.textBoxXlsFolder.Location = new System.Drawing.Point(134, 13);
			this.textBoxXlsFolder.Name = "textBoxXlsFolder";
			this.textBoxXlsFolder.ReadOnly = true;
			this.textBoxXlsFolder.Size = new System.Drawing.Size(291, 20);
			this.textBoxXlsFolder.TabIndex = 1;
			// 
			// buttonOpenXlsFolder
			// 
			this.buttonOpenXlsFolder.Location = new System.Drawing.Point(431, 10);
			this.buttonOpenXlsFolder.Name = "buttonOpenXlsFolder";
			this.buttonOpenXlsFolder.Size = new System.Drawing.Size(45, 23);
			this.buttonOpenXlsFolder.TabIndex = 2;
			this.buttonOpenXlsFolder.Text = "Ouvrir";
			this.buttonOpenXlsFolder.UseVisualStyleBackColor = true;
			this.buttonOpenXlsFolder.Click += new System.EventHandler(this.ButtonOpenFolderClick);
			// 
			// groupBoxPF
			// 
			this.groupBoxPF.Controls.Add(this.groupBox7);
			this.groupBoxPF.Controls.Add(this.groupBox4);
			this.groupBoxPF.Controls.Add(this.groupBox1);
			this.groupBoxPF.Controls.Add(this.buttonItem);
			this.groupBoxPF.Location = new System.Drawing.Point(12, 60);
			this.groupBoxPF.Name = "groupBoxPF";
			this.groupBoxPF.Size = new System.Drawing.Size(541, 533);
			this.groupBoxPF.TabIndex = 4;
			this.groupBoxPF.TabStop = false;
			this.groupBoxPF.Text = "Articles";
			// 
			// groupBox7
			// 
			this.groupBox7.Controls.Add(this.buttonOpenItemGeneralParamsFile);
			this.groupBox7.Controls.Add(this.textBoxItemGeneralParamsFile);
			this.groupBox7.Controls.Add(this.label13);
			this.groupBox7.Location = new System.Drawing.Point(6, 471);
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.Size = new System.Drawing.Size(471, 53);
			this.groupBox7.TabIndex = 28;
			this.groupBox7.TabStop = false;
			this.groupBox7.Text = "Paramètres généraux";
			// 
			// buttonOpenItemGeneralParamsFile
			// 
			this.buttonOpenItemGeneralParamsFile.Location = new System.Drawing.Point(417, 17);
			this.buttonOpenItemGeneralParamsFile.Name = "buttonOpenItemGeneralParamsFile";
			this.buttonOpenItemGeneralParamsFile.Size = new System.Drawing.Size(44, 23);
			this.buttonOpenItemGeneralParamsFile.TabIndex = 27;
			this.buttonOpenItemGeneralParamsFile.Text = "Ouvrir";
			this.buttonOpenItemGeneralParamsFile.UseVisualStyleBackColor = true;
			this.buttonOpenItemGeneralParamsFile.Click += new System.EventHandler(this.ButtonOpenItemGeneralParamsFileClick);
			// 
			// textBoxItemGeneralParamsFile
			// 
			this.textBoxItemGeneralParamsFile.Location = new System.Drawing.Point(202, 19);
			this.textBoxItemGeneralParamsFile.Name = "textBoxItemGeneralParamsFile";
			this.textBoxItemGeneralParamsFile.ReadOnly = true;
			this.textBoxItemGeneralParamsFile.Size = new System.Drawing.Size(209, 20);
			this.textBoxItemGeneralParamsFile.TabIndex = 26;
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(4, 22);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(193, 16);
			this.label13.TabIndex = 25;
			this.label13.Text = "Paramètres généraux :";
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.textBoxItemV9CostFile);
			this.groupBox4.Controls.Add(this.buttonOpenItemV9CostFile);
			this.groupBox4.Controls.Add(this.label24);
			this.groupBox4.Controls.Add(this.textBoxItemV9ProdLineFile);
			this.groupBox4.Controls.Add(this.labelV9File);
			this.groupBox4.Controls.Add(this.buttonOpenItemV9ProdLineFile);
			this.groupBox4.Controls.Add(this.textBoxItemV9File);
			this.groupBox4.Controls.Add(this.textBoxItemV9LastProdLineFile);
			this.groupBox4.Controls.Add(this.buttonOpenItemV9LastProdLineFile);
			this.groupBox4.Controls.Add(this.buttonOpenItemV9File);
			this.groupBox4.Controls.Add(this.labelV9LigneProdFile);
			this.groupBox4.Controls.Add(this.labelV9LastLigneProdFile);
			this.groupBox4.Location = new System.Drawing.Point(6, 336);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(470, 129);
			this.groupBox4.TabIndex = 27;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Articles V9";
			// 
			// textBoxItemV9CostFile
			// 
			this.textBoxItemV9CostFile.Location = new System.Drawing.Point(202, 97);
			this.textBoxItemV9CostFile.Name = "textBoxItemV9CostFile";
			this.textBoxItemV9CostFile.ReadOnly = true;
			this.textBoxItemV9CostFile.Size = new System.Drawing.Size(209, 20);
			this.textBoxItemV9CostFile.TabIndex = 25;
			// 
			// buttonOpenItemV9CostFile
			// 
			this.buttonOpenItemV9CostFile.Location = new System.Drawing.Point(417, 95);
			this.buttonOpenItemV9CostFile.Name = "buttonOpenItemV9CostFile";
			this.buttonOpenItemV9CostFile.Size = new System.Drawing.Size(45, 23);
			this.buttonOpenItemV9CostFile.TabIndex = 26;
			this.buttonOpenItemV9CostFile.Text = "Ouvrir";
			this.buttonOpenItemV9CostFile.UseVisualStyleBackColor = true;
			this.buttonOpenItemV9CostFile.Click += new System.EventHandler(this.ButtonOpenItemV9CostFileClick);
			// 
			// label24
			// 
			this.label24.Location = new System.Drawing.Point(4, 100);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(193, 16);
			this.label24.TabIndex = 27;
			this.label24.Text = "Coûts V9 :";
			// 
			// textBoxItemV9ProdLineFile
			// 
			this.textBoxItemV9ProdLineFile.Location = new System.Drawing.Point(202, 45);
			this.textBoxItemV9ProdLineFile.Name = "textBoxItemV9ProdLineFile";
			this.textBoxItemV9ProdLineFile.ReadOnly = true;
			this.textBoxItemV9ProdLineFile.Size = new System.Drawing.Size(209, 20);
			this.textBoxItemV9ProdLineFile.TabIndex = 19;
			// 
			// labelV9File
			// 
			this.labelV9File.Location = new System.Drawing.Point(6, 22);
			this.labelV9File.Name = "labelV9File";
			this.labelV9File.Size = new System.Drawing.Size(193, 16);
			this.labelV9File.TabIndex = 21;
			this.labelV9File.Text = "Articles V9 :";
			// 
			// buttonOpenItemV9ProdLineFile
			// 
			this.buttonOpenItemV9ProdLineFile.Location = new System.Drawing.Point(417, 43);
			this.buttonOpenItemV9ProdLineFile.Name = "buttonOpenItemV9ProdLineFile";
			this.buttonOpenItemV9ProdLineFile.Size = new System.Drawing.Size(45, 23);
			this.buttonOpenItemV9ProdLineFile.TabIndex = 20;
			this.buttonOpenItemV9ProdLineFile.Text = "Ouvrir";
			this.buttonOpenItemV9ProdLineFile.UseVisualStyleBackColor = true;
			this.buttonOpenItemV9ProdLineFile.Click += new System.EventHandler(this.ButtonOpenItemV9ProdLineFileClick);
			// 
			// textBoxItemV9File
			// 
			this.textBoxItemV9File.Location = new System.Drawing.Point(202, 19);
			this.textBoxItemV9File.Name = "textBoxItemV9File";
			this.textBoxItemV9File.ReadOnly = true;
			this.textBoxItemV9File.Size = new System.Drawing.Size(209, 20);
			this.textBoxItemV9File.TabIndex = 19;
			// 
			// textBoxItemV9LastProdLineFile
			// 
			this.textBoxItemV9LastProdLineFile.Location = new System.Drawing.Point(202, 71);
			this.textBoxItemV9LastProdLineFile.Name = "textBoxItemV9LastProdLineFile";
			this.textBoxItemV9LastProdLineFile.ReadOnly = true;
			this.textBoxItemV9LastProdLineFile.Size = new System.Drawing.Size(209, 20);
			this.textBoxItemV9LastProdLineFile.TabIndex = 21;
			// 
			// buttonOpenItemV9LastProdLineFile
			// 
			this.buttonOpenItemV9LastProdLineFile.Location = new System.Drawing.Point(417, 69);
			this.buttonOpenItemV9LastProdLineFile.Name = "buttonOpenItemV9LastProdLineFile";
			this.buttonOpenItemV9LastProdLineFile.Size = new System.Drawing.Size(45, 23);
			this.buttonOpenItemV9LastProdLineFile.TabIndex = 22;
			this.buttonOpenItemV9LastProdLineFile.Text = "Ouvrir";
			this.buttonOpenItemV9LastProdLineFile.UseVisualStyleBackColor = true;
			this.buttonOpenItemV9LastProdLineFile.Click += new System.EventHandler(this.ButtonOpenItemV9LastProdLineFileClick);
			// 
			// buttonOpenItemV9File
			// 
			this.buttonOpenItemV9File.Location = new System.Drawing.Point(417, 17);
			this.buttonOpenItemV9File.Name = "buttonOpenItemV9File";
			this.buttonOpenItemV9File.Size = new System.Drawing.Size(45, 23);
			this.buttonOpenItemV9File.TabIndex = 20;
			this.buttonOpenItemV9File.Text = "Ouvrir";
			this.buttonOpenItemV9File.UseVisualStyleBackColor = true;
			this.buttonOpenItemV9File.Click += new System.EventHandler(this.ButtonOpenItemV9FileClick);
			// 
			// labelV9LigneProdFile
			// 
			this.labelV9LigneProdFile.Location = new System.Drawing.Point(3, 49);
			this.labelV9LigneProdFile.Name = "labelV9LigneProdFile";
			this.labelV9LigneProdFile.Size = new System.Drawing.Size(193, 16);
			this.labelV9LigneProdFile.TabIndex = 23;
			this.labelV9LigneProdFile.Text = "Lignes produit V9 (1, 2, 3) :";
			// 
			// labelV9LastLigneProdFile
			// 
			this.labelV9LastLigneProdFile.Location = new System.Drawing.Point(4, 74);
			this.labelV9LastLigneProdFile.Name = "labelV9LastLigneProdFile";
			this.labelV9LastLigneProdFile.Size = new System.Drawing.Size(193, 16);
			this.labelV9LastLigneProdFile.TabIndex = 24;
			this.labelV9LastLigneProdFile.Text = "Lignes produit V9 (4) :";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.buttonOpenItemAnalysisCodeBrandFile);
			this.groupBox1.Controls.Add(this.textBoxItemAnalysisCodeBrandFile);
			this.groupBox1.Controls.Add(this.label28);
			this.groupBox1.Controls.Add(this.label27);
			this.groupBox1.Controls.Add(this.buttonOpenItemIntrastatCodeFile);
			this.groupBox1.Controls.Add(this.textBoxItemIntrastatCodeFile);
			this.groupBox1.Controls.Add(this.textBoxItemCostFile);
			this.groupBox1.Controls.Add(this.label25);
			this.groupBox1.Controls.Add(this.buttonOpenItemCostFile);
			this.groupBox1.Controls.Add(this.textBoxItemDSRPFile);
			this.groupBox1.Controls.Add(this.label18);
			this.groupBox1.Controls.Add(this.labelRawFile);
			this.groupBox1.Controls.Add(this.buttonOpenItemDSRPFile);
			this.groupBox1.Controls.Add(this.label22);
			this.groupBox1.Controls.Add(this.textBoxItemRawFile);
			this.groupBox1.Controls.Add(this.buttonOpenItemRawFile);
			this.groupBox1.Controls.Add(this.buttonOpenItemIntrastatFile);
			this.groupBox1.Controls.Add(this.textBoxItemIntrastatFile);
			this.groupBox1.Controls.Add(this.buttonOpenItemAnalysisCodeFile);
			this.groupBox1.Controls.Add(this.textBoxItemAnalysisCodeFile);
			this.groupBox1.Controls.Add(this.label12);
			this.groupBox1.Controls.Add(this.labelPFFile);
			this.groupBox1.Controls.Add(this.textBoxItemFile);
			this.groupBox1.Controls.Add(this.buttonOpenItemFile);
			this.groupBox1.Controls.Add(this.textBoxItemSiteCellProdLineFile);
			this.groupBox1.Controls.Add(this.buttonOpenItemSiteCellProdLineFile);
			this.groupBox1.Controls.Add(this.textBoxItemProdLineFile);
			this.groupBox1.Controls.Add(this.buttonOpenItemProdLineFile);
			this.groupBox1.Controls.Add(this.labelLeaderFile);
			this.groupBox1.Controls.Add(this.labelSiteCelluleFile);
			this.groupBox1.Controls.Add(this.buttonOpenItemLeaderFile);
			this.groupBox1.Controls.Add(this.labelLigneProdFile);
			this.groupBox1.Controls.Add(this.textBoxItemLeaderFile);
			this.groupBox1.Location = new System.Drawing.Point(5, 19);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(471, 311);
			this.groupBox1.TabIndex = 25;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Produits finis : 1.4.1, 1.4.15, 36.2.13";
			// 
			// buttonOpenItemAnalysisCodeBrandFile
			// 
			this.buttonOpenItemAnalysisCodeBrandFile.Location = new System.Drawing.Point(417, 147);
			this.buttonOpenItemAnalysisCodeBrandFile.Name = "buttonOpenItemAnalysisCodeBrandFile";
			this.buttonOpenItemAnalysisCodeBrandFile.Size = new System.Drawing.Size(45, 23);
			this.buttonOpenItemAnalysisCodeBrandFile.TabIndex = 36;
			this.buttonOpenItemAnalysisCodeBrandFile.Text = "Ouvrir";
			this.buttonOpenItemAnalysisCodeBrandFile.UseVisualStyleBackColor = true;
			this.buttonOpenItemAnalysisCodeBrandFile.Click += new System.EventHandler(this.ButtonOpenItemAnalysisCodeBrandFileClick);
			// 
			// textBoxItemAnalysisCodeBrandFile
			// 
			this.textBoxItemAnalysisCodeBrandFile.Location = new System.Drawing.Point(201, 149);
			this.textBoxItemAnalysisCodeBrandFile.Name = "textBoxItemAnalysisCodeBrandFile";
			this.textBoxItemAnalysisCodeBrandFile.ReadOnly = true;
			this.textBoxItemAnalysisCodeBrandFile.Size = new System.Drawing.Size(210, 20);
			this.textBoxItemAnalysisCodeBrandFile.TabIndex = 35;
			// 
			// label28
			// 
			this.label28.Location = new System.Drawing.Point(3, 152);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(193, 16);
			this.label28.TabIndex = 34;
			this.label28.Text = "Codes analyses marque :";
			// 
			// label27
			// 
			this.label27.Location = new System.Drawing.Point(4, 177);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(193, 16);
			this.label27.TabIndex = 33;
			this.label27.Text = "Codes nomenclatures douanières :";
			// 
			// buttonOpenItemIntrastatCodeFile
			// 
			this.buttonOpenItemIntrastatCodeFile.Location = new System.Drawing.Point(417, 174);
			this.buttonOpenItemIntrastatCodeFile.Name = "buttonOpenItemIntrastatCodeFile";
			this.buttonOpenItemIntrastatCodeFile.Size = new System.Drawing.Size(45, 23);
			this.buttonOpenItemIntrastatCodeFile.TabIndex = 32;
			this.buttonOpenItemIntrastatCodeFile.Text = "Ouvrir";
			this.buttonOpenItemIntrastatCodeFile.UseVisualStyleBackColor = true;
			this.buttonOpenItemIntrastatCodeFile.Click += new System.EventHandler(this.ButtonOpenItemIntrastatCodeFileClick);
			// 
			// textBoxItemIntrastatCodeFile
			// 
			this.textBoxItemIntrastatCodeFile.Location = new System.Drawing.Point(201, 174);
			this.textBoxItemIntrastatCodeFile.Name = "textBoxItemIntrastatCodeFile";
			this.textBoxItemIntrastatCodeFile.ReadOnly = true;
			this.textBoxItemIntrastatCodeFile.Size = new System.Drawing.Size(211, 20);
			this.textBoxItemIntrastatCodeFile.TabIndex = 31;
			// 
			// textBoxItemCostFile
			// 
			this.textBoxItemCostFile.Location = new System.Drawing.Point(202, 278);
			this.textBoxItemCostFile.Name = "textBoxItemCostFile";
			this.textBoxItemCostFile.ReadOnly = true;
			this.textBoxItemCostFile.Size = new System.Drawing.Size(211, 20);
			this.textBoxItemCostFile.TabIndex = 28;
			// 
			// label25
			// 
			this.label25.Location = new System.Drawing.Point(6, 281);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(193, 16);
			this.label25.TabIndex = 30;
			this.label25.Text = "Coûts :";
			// 
			// buttonOpenItemCostFile
			// 
			this.buttonOpenItemCostFile.Location = new System.Drawing.Point(417, 277);
			this.buttonOpenItemCostFile.Name = "buttonOpenItemCostFile";
			this.buttonOpenItemCostFile.Size = new System.Drawing.Size(45, 23);
			this.buttonOpenItemCostFile.TabIndex = 29;
			this.buttonOpenItemCostFile.Text = "Ouvrir";
			this.buttonOpenItemCostFile.UseVisualStyleBackColor = true;
			this.buttonOpenItemCostFile.Click += new System.EventHandler(this.ButtonOpenItemCostFileClick);
			// 
			// textBoxItemDSRPFile
			// 
			this.textBoxItemDSRPFile.Location = new System.Drawing.Point(202, 252);
			this.textBoxItemDSRPFile.Name = "textBoxItemDSRPFile";
			this.textBoxItemDSRPFile.ReadOnly = true;
			this.textBoxItemDSRPFile.Size = new System.Drawing.Size(210, 20);
			this.textBoxItemDSRPFile.TabIndex = 25;
			// 
			// label18
			// 
			this.label18.Location = new System.Drawing.Point(6, 255);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(193, 16);
			this.label18.TabIndex = 27;
			this.label18.Text = "Données DS/DSRP :";
			// 
			// labelRawFile
			// 
			this.labelRawFile.Location = new System.Drawing.Point(5, 229);
			this.labelRawFile.Name = "labelRawFile";
			this.labelRawFile.Size = new System.Drawing.Size(193, 16);
			this.labelRawFile.TabIndex = 24;
			this.labelRawFile.Text = "Matières premières :";
			// 
			// buttonOpenItemDSRPFile
			// 
			this.buttonOpenItemDSRPFile.Location = new System.Drawing.Point(417, 251);
			this.buttonOpenItemDSRPFile.Name = "buttonOpenItemDSRPFile";
			this.buttonOpenItemDSRPFile.Size = new System.Drawing.Size(45, 23);
			this.buttonOpenItemDSRPFile.TabIndex = 26;
			this.buttonOpenItemDSRPFile.Text = "Ouvrir";
			this.buttonOpenItemDSRPFile.UseVisualStyleBackColor = true;
			this.buttonOpenItemDSRPFile.Click += new System.EventHandler(this.ButtonOpenItemDSRPFileClick);
			// 
			// label22
			// 
			this.label22.Location = new System.Drawing.Point(4, 203);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(193, 16);
			this.label22.TabIndex = 24;
			this.label22.Text = "Nomenclatures douanières :";
			// 
			// textBoxItemRawFile
			// 
			this.textBoxItemRawFile.Location = new System.Drawing.Point(202, 226);
			this.textBoxItemRawFile.Name = "textBoxItemRawFile";
			this.textBoxItemRawFile.ReadOnly = true;
			this.textBoxItemRawFile.Size = new System.Drawing.Size(210, 20);
			this.textBoxItemRawFile.TabIndex = 22;
			// 
			// buttonOpenItemRawFile
			// 
			this.buttonOpenItemRawFile.Location = new System.Drawing.Point(417, 224);
			this.buttonOpenItemRawFile.Name = "buttonOpenItemRawFile";
			this.buttonOpenItemRawFile.Size = new System.Drawing.Size(45, 23);
			this.buttonOpenItemRawFile.TabIndex = 23;
			this.buttonOpenItemRawFile.Text = "Ouvrir";
			this.buttonOpenItemRawFile.UseVisualStyleBackColor = true;
			this.buttonOpenItemRawFile.Click += new System.EventHandler(this.ButtonOpenItemRawFileClick);
			// 
			// buttonOpenItemIntrastatFile
			// 
			this.buttonOpenItemIntrastatFile.Location = new System.Drawing.Point(417, 200);
			this.buttonOpenItemIntrastatFile.Name = "buttonOpenItemIntrastatFile";
			this.buttonOpenItemIntrastatFile.Size = new System.Drawing.Size(45, 23);
			this.buttonOpenItemIntrastatFile.TabIndex = 23;
			this.buttonOpenItemIntrastatFile.Text = "Ouvrir";
			this.buttonOpenItemIntrastatFile.UseVisualStyleBackColor = true;
			this.buttonOpenItemIntrastatFile.Click += new System.EventHandler(this.ButtonOpenItemIntrastatFileClick);
			// 
			// textBoxItemIntrastatFile
			// 
			this.textBoxItemIntrastatFile.Location = new System.Drawing.Point(201, 200);
			this.textBoxItemIntrastatFile.Name = "textBoxItemIntrastatFile";
			this.textBoxItemIntrastatFile.ReadOnly = true;
			this.textBoxItemIntrastatFile.Size = new System.Drawing.Size(211, 20);
			this.textBoxItemIntrastatFile.TabIndex = 22;
			// 
			// buttonOpenItemAnalysisCodeFile
			// 
			this.buttonOpenItemAnalysisCodeFile.Location = new System.Drawing.Point(418, 121);
			this.buttonOpenItemAnalysisCodeFile.Name = "buttonOpenItemAnalysisCodeFile";
			this.buttonOpenItemAnalysisCodeFile.Size = new System.Drawing.Size(45, 23);
			this.buttonOpenItemAnalysisCodeFile.TabIndex = 21;
			this.buttonOpenItemAnalysisCodeFile.Text = "Ouvrir";
			this.buttonOpenItemAnalysisCodeFile.UseVisualStyleBackColor = true;
			this.buttonOpenItemAnalysisCodeFile.Click += new System.EventHandler(this.ButtonOpenItemAnalysisCodeFileClick);
			// 
			// textBoxItemAnalysisCodeFile
			// 
			this.textBoxItemAnalysisCodeFile.Location = new System.Drawing.Point(202, 123);
			this.textBoxItemAnalysisCodeFile.Name = "textBoxItemAnalysisCodeFile";
			this.textBoxItemAnalysisCodeFile.ReadOnly = true;
			this.textBoxItemAnalysisCodeFile.Size = new System.Drawing.Size(210, 20);
			this.textBoxItemAnalysisCodeFile.TabIndex = 20;
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(4, 126);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(193, 16);
			this.label12.TabIndex = 19;
			this.label12.Text = "Codes analyses produit :";
			// 
			// labelPFFile
			// 
			this.labelPFFile.Location = new System.Drawing.Point(6, 23);
			this.labelPFFile.Name = "labelPFFile";
			this.labelPFFile.Size = new System.Drawing.Size(193, 16);
			this.labelPFFile.TabIndex = 11;
			this.labelPFFile.Text = "Produits finis :";
			// 
			// textBoxItemFile
			// 
			this.textBoxItemFile.Location = new System.Drawing.Point(204, 19);
			this.textBoxItemFile.Name = "textBoxItemFile";
			this.textBoxItemFile.ReadOnly = true;
			this.textBoxItemFile.Size = new System.Drawing.Size(209, 20);
			this.textBoxItemFile.TabIndex = 5;
			// 
			// buttonOpenItemFile
			// 
			this.buttonOpenItemFile.Location = new System.Drawing.Point(418, 16);
			this.buttonOpenItemFile.Name = "buttonOpenItemFile";
			this.buttonOpenItemFile.Size = new System.Drawing.Size(45, 23);
			this.buttonOpenItemFile.TabIndex = 6;
			this.buttonOpenItemFile.Text = "Ouvrir";
			this.buttonOpenItemFile.UseVisualStyleBackColor = true;
			this.buttonOpenItemFile.Click += new System.EventHandler(this.ButtonOpenItemFileClick);
			// 
			// textBoxItemSiteCellProdLineFile
			// 
			this.textBoxItemSiteCellProdLineFile.Location = new System.Drawing.Point(203, 45);
			this.textBoxItemSiteCellProdLineFile.Name = "textBoxItemSiteCellProdLineFile";
			this.textBoxItemSiteCellProdLineFile.ReadOnly = true;
			this.textBoxItemSiteCellProdLineFile.Size = new System.Drawing.Size(209, 20);
			this.textBoxItemSiteCellProdLineFile.TabIndex = 7;
			// 
			// buttonOpenItemSiteCellProdLineFile
			// 
			this.buttonOpenItemSiteCellProdLineFile.Location = new System.Drawing.Point(418, 42);
			this.buttonOpenItemSiteCellProdLineFile.Name = "buttonOpenItemSiteCellProdLineFile";
			this.buttonOpenItemSiteCellProdLineFile.Size = new System.Drawing.Size(45, 23);
			this.buttonOpenItemSiteCellProdLineFile.TabIndex = 8;
			this.buttonOpenItemSiteCellProdLineFile.Text = "Ouvrir";
			this.buttonOpenItemSiteCellProdLineFile.UseVisualStyleBackColor = true;
			this.buttonOpenItemSiteCellProdLineFile.Click += new System.EventHandler(this.ButtonOpenItemSiteCellProdLineFileClick);
			// 
			// textBoxItemProdLineFile
			// 
			this.textBoxItemProdLineFile.Location = new System.Drawing.Point(203, 71);
			this.textBoxItemProdLineFile.Name = "textBoxItemProdLineFile";
			this.textBoxItemProdLineFile.ReadOnly = true;
			this.textBoxItemProdLineFile.Size = new System.Drawing.Size(209, 20);
			this.textBoxItemProdLineFile.TabIndex = 9;
			// 
			// buttonOpenItemProdLineFile
			// 
			this.buttonOpenItemProdLineFile.Location = new System.Drawing.Point(418, 68);
			this.buttonOpenItemProdLineFile.Name = "buttonOpenItemProdLineFile";
			this.buttonOpenItemProdLineFile.Size = new System.Drawing.Size(45, 23);
			this.buttonOpenItemProdLineFile.TabIndex = 10;
			this.buttonOpenItemProdLineFile.Text = "Ouvrir";
			this.buttonOpenItemProdLineFile.UseVisualStyleBackColor = true;
			this.buttonOpenItemProdLineFile.Click += new System.EventHandler(this.ButtonOpenItemProdLineFileClick);
			// 
			// labelLeaderFile
			// 
			this.labelLeaderFile.Location = new System.Drawing.Point(4, 100);
			this.labelLeaderFile.Name = "labelLeaderFile";
			this.labelLeaderFile.Size = new System.Drawing.Size(193, 16);
			this.labelLeaderFile.TabIndex = 18;
			this.labelLeaderFile.Text = "Codes leaders :";
			// 
			// labelSiteCelluleFile
			// 
			this.labelSiteCelluleFile.Location = new System.Drawing.Point(4, 49);
			this.labelSiteCelluleFile.Name = "labelSiteCelluleFile";
			this.labelSiteCelluleFile.Size = new System.Drawing.Size(193, 16);
			this.labelSiteCelluleFile.TabIndex = 12;
			this.labelSiteCelluleFile.Text = "Sites - cellules - lignes produit (1, 2, 3) :";
			// 
			// buttonOpenItemLeaderFile
			// 
			this.buttonOpenItemLeaderFile.Location = new System.Drawing.Point(418, 94);
			this.buttonOpenItemLeaderFile.Name = "buttonOpenItemLeaderFile";
			this.buttonOpenItemLeaderFile.Size = new System.Drawing.Size(45, 23);
			this.buttonOpenItemLeaderFile.TabIndex = 17;
			this.buttonOpenItemLeaderFile.Text = "Ouvrir";
			this.buttonOpenItemLeaderFile.UseVisualStyleBackColor = true;
			this.buttonOpenItemLeaderFile.Click += new System.EventHandler(this.ButtonOpenItemLeaderFileClick);
			// 
			// labelLigneProdFile
			// 
			this.labelLigneProdFile.Location = new System.Drawing.Point(4, 75);
			this.labelLigneProdFile.Name = "labelLigneProdFile";
			this.labelLigneProdFile.Size = new System.Drawing.Size(193, 16);
			this.labelLigneProdFile.TabIndex = 13;
			this.labelLigneProdFile.Text = "Lignes produit (4) :";
			// 
			// textBoxItemLeaderFile
			// 
			this.textBoxItemLeaderFile.Location = new System.Drawing.Point(202, 97);
			this.textBoxItemLeaderFile.Name = "textBoxItemLeaderFile";
			this.textBoxItemLeaderFile.ReadOnly = true;
			this.textBoxItemLeaderFile.Size = new System.Drawing.Size(210, 20);
			this.textBoxItemLeaderFile.TabIndex = 16;
			// 
			// buttonItem
			// 
			this.buttonItem.Enabled = false;
			this.buttonItem.Location = new System.Drawing.Point(482, 24);
			this.buttonItem.Name = "buttonItem";
			this.buttonItem.Size = new System.Drawing.Size(51, 500);
			this.buttonItem.TabIndex = 5;
			this.buttonItem.Text = "OK";
			this.buttonItem.UseVisualStyleBackColor = true;
			this.buttonItem.Click += new System.EventHandler(this.ButtonItemClick);
			// 
			// labelXls
			// 
			this.labelXls.Location = new System.Drawing.Point(6, 16);
			this.labelXls.Name = "labelXls";
			this.labelXls.Size = new System.Drawing.Size(114, 15);
			this.labelXls.TabIndex = 14;
			this.labelXls.Text = "Fichiers Excel :";
			// 
			// buttonQuit
			// 
			this.buttonQuit.Location = new System.Drawing.Point(12, 658);
			this.buttonQuit.Name = "buttonQuit";
			this.buttonQuit.Size = new System.Drawing.Size(541, 68);
			this.buttonQuit.TabIndex = 15;
			this.buttonQuit.Text = "QUITTER";
			this.buttonQuit.UseVisualStyleBackColor = true;
			this.buttonQuit.Click += new System.EventHandler(this.ButtonQuitClick);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.buttonXls);
			this.groupBox3.Controls.Add(this.textBoxXlsFolder);
			this.groupBox3.Controls.Add(this.labelXls);
			this.groupBox3.Controls.Add(this.buttonOpenXlsFolder);
			this.groupBox3.Location = new System.Drawing.Point(12, 12);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(541, 40);
			this.groupBox3.TabIndex = 16;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Excels";
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.textBoxCustomerGeneralParamsFile);
			this.groupBox5.Controls.Add(this.label9);
			this.groupBox5.Controls.Add(this.buttonOpenCustomerGeneralParamsFile);
			this.groupBox5.Controls.Add(this.buttonOpenCustomerItemFile);
			this.groupBox5.Controls.Add(this.label15);
			this.groupBox5.Controls.Add(this.textBoxCustomerItemFile);
			this.groupBox5.Controls.Add(this.label6);
			this.groupBox5.Controls.Add(this.buttonOpenCustomerTreeFile);
			this.groupBox5.Controls.Add(this.textBoxCustomerTreeFile);
			this.groupBox5.Controls.Add(this.buttonCustomer);
			this.groupBox5.Controls.Add(this.label1);
			this.groupBox5.Controls.Add(this.textBoxCustomerBusinessRelationFile);
			this.groupBox5.Controls.Add(this.buttonOpenCustomerBusinessRelationFile);
			this.groupBox5.Controls.Add(this.textBoxCustomerFinancialFile);
			this.groupBox5.Controls.Add(this.buttonOpenCustomerFinancialFile);
			this.groupBox5.Controls.Add(this.textBoxCustomerFile);
			this.groupBox5.Controls.Add(this.buttonOpenCustomerFile);
			this.groupBox5.Controls.Add(this.label2);
			this.groupBox5.Controls.Add(this.label3);
			this.groupBox5.Controls.Add(this.buttonOpenCustomerDeliveryFile);
			this.groupBox5.Controls.Add(this.label4);
			this.groupBox5.Controls.Add(this.textBoxCustomerDeliveryFile);
			this.groupBox5.Location = new System.Drawing.Point(559, 12);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(522, 209);
			this.groupBox5.TabIndex = 26;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Clients : 36.1.4.3.1, 27.20.1.1, 2.1.1, 36.2.13, 1.15";
			// 
			// textBoxCustomerGeneralParamsFile
			// 
			this.textBoxCustomerGeneralParamsFile.Location = new System.Drawing.Point(172, 177);
			this.textBoxCustomerGeneralParamsFile.Name = "textBoxCustomerGeneralParamsFile";
			this.textBoxCustomerGeneralParamsFile.ReadOnly = true;
			this.textBoxCustomerGeneralParamsFile.Size = new System.Drawing.Size(236, 20);
			this.textBoxCustomerGeneralParamsFile.TabIndex = 26;
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(6, 151);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(138, 16);
			this.label9.TabIndex = 25;
			this.label9.Text = "Lien article - client :";
			// 
			// buttonOpenCustomerGeneralParamsFile
			// 
			this.buttonOpenCustomerGeneralParamsFile.Location = new System.Drawing.Point(414, 175);
			this.buttonOpenCustomerGeneralParamsFile.Name = "buttonOpenCustomerGeneralParamsFile";
			this.buttonOpenCustomerGeneralParamsFile.Size = new System.Drawing.Size(43, 23);
			this.buttonOpenCustomerGeneralParamsFile.TabIndex = 27;
			this.buttonOpenCustomerGeneralParamsFile.Text = "Ouvrir";
			this.buttonOpenCustomerGeneralParamsFile.UseVisualStyleBackColor = true;
			this.buttonOpenCustomerGeneralParamsFile.Click += new System.EventHandler(this.ButtonOpenCustomerGeneralParamsFileClick);
			// 
			// buttonOpenCustomerItemFile
			// 
			this.buttonOpenCustomerItemFile.Location = new System.Drawing.Point(414, 148);
			this.buttonOpenCustomerItemFile.Name = "buttonOpenCustomerItemFile";
			this.buttonOpenCustomerItemFile.Size = new System.Drawing.Size(43, 23);
			this.buttonOpenCustomerItemFile.TabIndex = 24;
			this.buttonOpenCustomerItemFile.Text = "Ouvrir";
			this.buttonOpenCustomerItemFile.UseVisualStyleBackColor = true;
			this.buttonOpenCustomerItemFile.Click += new System.EventHandler(this.ButtonOpenCustomerItemFileClick);
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(6, 180);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(138, 16);
			this.label15.TabIndex = 28;
			this.label15.Text = "Paramètres généraux :";
			// 
			// textBoxCustomerItemFile
			// 
			this.textBoxCustomerItemFile.Location = new System.Drawing.Point(172, 149);
			this.textBoxCustomerItemFile.Name = "textBoxCustomerItemFile";
			this.textBoxCustomerItemFile.ReadOnly = true;
			this.textBoxCustomerItemFile.Size = new System.Drawing.Size(236, 20);
			this.textBoxCustomerItemFile.TabIndex = 23;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(6, 125);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(138, 16);
			this.label6.TabIndex = 22;
			this.label6.Text = "Arborescence client :";
			// 
			// buttonOpenCustomerTreeFile
			// 
			this.buttonOpenCustomerTreeFile.Location = new System.Drawing.Point(416, 121);
			this.buttonOpenCustomerTreeFile.Name = "buttonOpenCustomerTreeFile";
			this.buttonOpenCustomerTreeFile.Size = new System.Drawing.Size(43, 23);
			this.buttonOpenCustomerTreeFile.TabIndex = 21;
			this.buttonOpenCustomerTreeFile.Text = "Ouvrir";
			this.buttonOpenCustomerTreeFile.UseVisualStyleBackColor = true;
			this.buttonOpenCustomerTreeFile.Click += new System.EventHandler(this.ButtonOpenCustomerTreeFileClick);
			// 
			// textBoxCustomerTreeFile
			// 
			this.textBoxCustomerTreeFile.Location = new System.Drawing.Point(172, 123);
			this.textBoxCustomerTreeFile.Name = "textBoxCustomerTreeFile";
			this.textBoxCustomerTreeFile.ReadOnly = true;
			this.textBoxCustomerTreeFile.Size = new System.Drawing.Size(236, 20);
			this.textBoxCustomerTreeFile.TabIndex = 20;
			// 
			// buttonCustomer
			// 
			this.buttonCustomer.Enabled = false;
			this.buttonCustomer.Location = new System.Drawing.Point(462, 17);
			this.buttonCustomer.Name = "buttonCustomer";
			this.buttonCustomer.Size = new System.Drawing.Size(50, 180);
			this.buttonCustomer.TabIndex = 15;
			this.buttonCustomer.Text = "OK";
			this.buttonCustomer.UseVisualStyleBackColor = true;
			this.buttonCustomer.Click += new System.EventHandler(this.ButtonCustomerClick);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(6, 21);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(138, 16);
			this.label1.TabIndex = 11;
			this.label1.Text = "Relations d\'affaire :";
			// 
			// textBoxCustomerBusinessRelationFile
			// 
			this.textBoxCustomerBusinessRelationFile.Location = new System.Drawing.Point(172, 19);
			this.textBoxCustomerBusinessRelationFile.Name = "textBoxCustomerBusinessRelationFile";
			this.textBoxCustomerBusinessRelationFile.ReadOnly = true;
			this.textBoxCustomerBusinessRelationFile.Size = new System.Drawing.Size(238, 20);
			this.textBoxCustomerBusinessRelationFile.TabIndex = 5;
			// 
			// buttonOpenCustomerBusinessRelationFile
			// 
			this.buttonOpenCustomerBusinessRelationFile.Location = new System.Drawing.Point(416, 17);
			this.buttonOpenCustomerBusinessRelationFile.Name = "buttonOpenCustomerBusinessRelationFile";
			this.buttonOpenCustomerBusinessRelationFile.Size = new System.Drawing.Size(43, 23);
			this.buttonOpenCustomerBusinessRelationFile.TabIndex = 6;
			this.buttonOpenCustomerBusinessRelationFile.Text = "Ouvrir";
			this.buttonOpenCustomerBusinessRelationFile.UseVisualStyleBackColor = true;
			this.buttonOpenCustomerBusinessRelationFile.Click += new System.EventHandler(this.ButtonOpenCustomerBusinessRelationFileClick);
			// 
			// textBoxCustomerFinancialFile
			// 
			this.textBoxCustomerFinancialFile.Location = new System.Drawing.Point(172, 45);
			this.textBoxCustomerFinancialFile.Name = "textBoxCustomerFinancialFile";
			this.textBoxCustomerFinancialFile.ReadOnly = true;
			this.textBoxCustomerFinancialFile.Size = new System.Drawing.Size(238, 20);
			this.textBoxCustomerFinancialFile.TabIndex = 7;
			// 
			// buttonOpenCustomerFinancialFile
			// 
			this.buttonOpenCustomerFinancialFile.Location = new System.Drawing.Point(416, 44);
			this.buttonOpenCustomerFinancialFile.Name = "buttonOpenCustomerFinancialFile";
			this.buttonOpenCustomerFinancialFile.Size = new System.Drawing.Size(43, 23);
			this.buttonOpenCustomerFinancialFile.TabIndex = 8;
			this.buttonOpenCustomerFinancialFile.Text = "Ouvrir";
			this.buttonOpenCustomerFinancialFile.UseVisualStyleBackColor = true;
			this.buttonOpenCustomerFinancialFile.Click += new System.EventHandler(this.ButtonOpenCustomerFinancialFileClick);
			// 
			// textBoxCustomerFile
			// 
			this.textBoxCustomerFile.Location = new System.Drawing.Point(172, 71);
			this.textBoxCustomerFile.Name = "textBoxCustomerFile";
			this.textBoxCustomerFile.ReadOnly = true;
			this.textBoxCustomerFile.Size = new System.Drawing.Size(238, 20);
			this.textBoxCustomerFile.TabIndex = 9;
			// 
			// buttonOpenCustomerFile
			// 
			this.buttonOpenCustomerFile.Location = new System.Drawing.Point(416, 69);
			this.buttonOpenCustomerFile.Name = "buttonOpenCustomerFile";
			this.buttonOpenCustomerFile.Size = new System.Drawing.Size(43, 23);
			this.buttonOpenCustomerFile.TabIndex = 10;
			this.buttonOpenCustomerFile.Text = "Ouvrir";
			this.buttonOpenCustomerFile.UseVisualStyleBackColor = true;
			this.buttonOpenCustomerFile.Click += new System.EventHandler(this.ButtonOpenCustomerFileClick);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(6, 100);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(138, 16);
			this.label2.TabIndex = 18;
			this.label2.Text = "Adresses livraison :";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(6, 48);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(138, 16);
			this.label3.TabIndex = 12;
			this.label3.Text = "Clients finance :";
			// 
			// buttonOpenCustomerDeliveryFile
			// 
			this.buttonOpenCustomerDeliveryFile.Location = new System.Drawing.Point(416, 96);
			this.buttonOpenCustomerDeliveryFile.Name = "buttonOpenCustomerDeliveryFile";
			this.buttonOpenCustomerDeliveryFile.Size = new System.Drawing.Size(43, 23);
			this.buttonOpenCustomerDeliveryFile.TabIndex = 17;
			this.buttonOpenCustomerDeliveryFile.Text = "Ouvrir";
			this.buttonOpenCustomerDeliveryFile.UseVisualStyleBackColor = true;
			this.buttonOpenCustomerDeliveryFile.Click += new System.EventHandler(this.ButtonOpenCustomerDeliveryFileClick);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(6, 74);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(138, 16);
			this.label4.TabIndex = 13;
			this.label4.Text = "Clients opérationnels :";
			// 
			// textBoxCustomerDeliveryFile
			// 
			this.textBoxCustomerDeliveryFile.Location = new System.Drawing.Point(172, 97);
			this.textBoxCustomerDeliveryFile.Name = "textBoxCustomerDeliveryFile";
			this.textBoxCustomerDeliveryFile.ReadOnly = true;
			this.textBoxCustomerDeliveryFile.Size = new System.Drawing.Size(238, 20);
			this.textBoxCustomerDeliveryFile.TabIndex = 16;
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.textBoxSupplierItemFile);
			this.groupBox6.Controls.Add(this.buttonOpenSupplierItemFile);
			this.groupBox6.Controls.Add(this.label17);
			this.groupBox6.Controls.Add(this.textBoxSupplierV9ItemFile);
			this.groupBox6.Controls.Add(this.buttonOpenSupplierV9ItemFile);
			this.groupBox6.Controls.Add(this.label16);
			this.groupBox6.Controls.Add(this.textBoxSupplierGeneralParamsFile);
			this.groupBox6.Controls.Add(this.buttonOpenSupplierGeneralParamsFile);
			this.groupBox6.Controls.Add(this.label14);
			this.groupBox6.Controls.Add(this.textBoxSupplierV9File);
			this.groupBox6.Controls.Add(this.buttonOpenSupplierV9File);
			this.groupBox6.Controls.Add(this.label5);
			this.groupBox6.Controls.Add(this.buttonSupplier);
			this.groupBox6.Controls.Add(this.label8);
			this.groupBox6.Controls.Add(this.textBoxSupplierBusinessRelationFile);
			this.groupBox6.Controls.Add(this.buttonOpenSupplierBusinessRelationFile);
			this.groupBox6.Controls.Add(this.textBoxSupplierFinancialFile);
			this.groupBox6.Controls.Add(this.buttonOpenSupplierFinancialFile);
			this.groupBox6.Controls.Add(this.textBoxSupplierFile);
			this.groupBox6.Controls.Add(this.buttonOpenSupplierFile);
			this.groupBox6.Controls.Add(this.label10);
			this.groupBox6.Controls.Add(this.label11);
			this.groupBox6.Location = new System.Drawing.Point(559, 227);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(522, 204);
			this.groupBox6.TabIndex = 27;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Fournisseurs : 36.1.4.3.1, 28.20.1.1, 2.3.1, 36.2.13";
			// 
			// textBoxSupplierItemFile
			// 
			this.textBoxSupplierItemFile.Location = new System.Drawing.Point(172, 97);
			this.textBoxSupplierItemFile.Name = "textBoxSupplierItemFile";
			this.textBoxSupplierItemFile.ReadOnly = true;
			this.textBoxSupplierItemFile.Size = new System.Drawing.Size(236, 20);
			this.textBoxSupplierItemFile.TabIndex = 29;
			// 
			// buttonOpenSupplierItemFile
			// 
			this.buttonOpenSupplierItemFile.Location = new System.Drawing.Point(414, 95);
			this.buttonOpenSupplierItemFile.Name = "buttonOpenSupplierItemFile";
			this.buttonOpenSupplierItemFile.Size = new System.Drawing.Size(43, 23);
			this.buttonOpenSupplierItemFile.TabIndex = 30;
			this.buttonOpenSupplierItemFile.Text = "Ouvrir";
			this.buttonOpenSupplierItemFile.UseVisualStyleBackColor = true;
			this.buttonOpenSupplierItemFile.Click += new System.EventHandler(this.ButtonOpenSupplierItemFileClick);
			// 
			// label17
			// 
			this.label17.Location = new System.Drawing.Point(6, 100);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(151, 16);
			this.label17.TabIndex = 31;
			this.label17.Text = "Liens article - fournisseurs :";
			// 
			// textBoxSupplierV9ItemFile
			// 
			this.textBoxSupplierV9ItemFile.Location = new System.Drawing.Point(172, 151);
			this.textBoxSupplierV9ItemFile.Name = "textBoxSupplierV9ItemFile";
			this.textBoxSupplierV9ItemFile.ReadOnly = true;
			this.textBoxSupplierV9ItemFile.Size = new System.Drawing.Size(236, 20);
			this.textBoxSupplierV9ItemFile.TabIndex = 26;
			// 
			// buttonOpenSupplierV9ItemFile
			// 
			this.buttonOpenSupplierV9ItemFile.Location = new System.Drawing.Point(414, 148);
			this.buttonOpenSupplierV9ItemFile.Name = "buttonOpenSupplierV9ItemFile";
			this.buttonOpenSupplierV9ItemFile.Size = new System.Drawing.Size(43, 23);
			this.buttonOpenSupplierV9ItemFile.TabIndex = 27;
			this.buttonOpenSupplierV9ItemFile.Text = "Ouvrir";
			this.buttonOpenSupplierV9ItemFile.UseVisualStyleBackColor = true;
			this.buttonOpenSupplierV9ItemFile.Click += new System.EventHandler(this.ButtonOpenSupplierV9ItemFileClick);
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(6, 154);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(151, 16);
			this.label16.TabIndex = 28;
			this.label16.Text = "Liens article - fournisseurs V9 :";
			// 
			// textBoxSupplierGeneralParamsFile
			// 
			this.textBoxSupplierGeneralParamsFile.Location = new System.Drawing.Point(172, 177);
			this.textBoxSupplierGeneralParamsFile.Name = "textBoxSupplierGeneralParamsFile";
			this.textBoxSupplierGeneralParamsFile.ReadOnly = true;
			this.textBoxSupplierGeneralParamsFile.Size = new System.Drawing.Size(236, 20);
			this.textBoxSupplierGeneralParamsFile.TabIndex = 23;
			// 
			// buttonOpenSupplierGeneralParamsFile
			// 
			this.buttonOpenSupplierGeneralParamsFile.Location = new System.Drawing.Point(414, 175);
			this.buttonOpenSupplierGeneralParamsFile.Name = "buttonOpenSupplierGeneralParamsFile";
			this.buttonOpenSupplierGeneralParamsFile.Size = new System.Drawing.Size(43, 23);
			this.buttonOpenSupplierGeneralParamsFile.TabIndex = 24;
			this.buttonOpenSupplierGeneralParamsFile.Text = "Ouvrir";
			this.buttonOpenSupplierGeneralParamsFile.UseVisualStyleBackColor = true;
			this.buttonOpenSupplierGeneralParamsFile.Click += new System.EventHandler(this.ButtonOpenSupplierGeneralParamsFileClick);
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(6, 182);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(138, 16);
			this.label14.TabIndex = 25;
			this.label14.Text = "Paramètres généraux :";
			// 
			// textBoxSupplierV9File
			// 
			this.textBoxSupplierV9File.Location = new System.Drawing.Point(172, 123);
			this.textBoxSupplierV9File.Name = "textBoxSupplierV9File";
			this.textBoxSupplierV9File.ReadOnly = true;
			this.textBoxSupplierV9File.Size = new System.Drawing.Size(236, 20);
			this.textBoxSupplierV9File.TabIndex = 20;
			// 
			// buttonOpenSupplierV9File
			// 
			this.buttonOpenSupplierV9File.Location = new System.Drawing.Point(414, 121);
			this.buttonOpenSupplierV9File.Name = "buttonOpenSupplierV9File";
			this.buttonOpenSupplierV9File.Size = new System.Drawing.Size(43, 23);
			this.buttonOpenSupplierV9File.TabIndex = 21;
			this.buttonOpenSupplierV9File.Text = "Ouvrir";
			this.buttonOpenSupplierV9File.UseVisualStyleBackColor = true;
			this.buttonOpenSupplierV9File.Click += new System.EventHandler(this.ButtonOpenSupplierV9FileClick);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(6, 127);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(138, 16);
			this.label5.TabIndex = 22;
			this.label5.Text = "Fournisseurs V9 :";
			// 
			// buttonSupplier
			// 
			this.buttonSupplier.Enabled = false;
			this.buttonSupplier.Location = new System.Drawing.Point(463, 17);
			this.buttonSupplier.Name = "buttonSupplier";
			this.buttonSupplier.Size = new System.Drawing.Size(50, 180);
			this.buttonSupplier.TabIndex = 15;
			this.buttonSupplier.Text = "OK";
			this.buttonSupplier.UseVisualStyleBackColor = true;
			this.buttonSupplier.Click += new System.EventHandler(this.ButtonSupplierClick);
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(6, 19);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(138, 16);
			this.label8.TabIndex = 11;
			this.label8.Text = "Relations d\'affaire :";
			// 
			// textBoxSupplierBusinessRelationFile
			// 
			this.textBoxSupplierBusinessRelationFile.Location = new System.Drawing.Point(172, 19);
			this.textBoxSupplierBusinessRelationFile.Name = "textBoxSupplierBusinessRelationFile";
			this.textBoxSupplierBusinessRelationFile.ReadOnly = true;
			this.textBoxSupplierBusinessRelationFile.Size = new System.Drawing.Size(236, 20);
			this.textBoxSupplierBusinessRelationFile.TabIndex = 5;
			// 
			// buttonOpenSupplierBusinessRelationFile
			// 
			this.buttonOpenSupplierBusinessRelationFile.Location = new System.Drawing.Point(414, 17);
			this.buttonOpenSupplierBusinessRelationFile.Name = "buttonOpenSupplierBusinessRelationFile";
			this.buttonOpenSupplierBusinessRelationFile.Size = new System.Drawing.Size(43, 23);
			this.buttonOpenSupplierBusinessRelationFile.TabIndex = 6;
			this.buttonOpenSupplierBusinessRelationFile.Text = "Ouvrir";
			this.buttonOpenSupplierBusinessRelationFile.UseVisualStyleBackColor = true;
			this.buttonOpenSupplierBusinessRelationFile.Click += new System.EventHandler(this.ButtonOpenSupplierBusinessRelationFileClick);
			// 
			// textBoxSupplierFinancialFile
			// 
			this.textBoxSupplierFinancialFile.Location = new System.Drawing.Point(172, 45);
			this.textBoxSupplierFinancialFile.Name = "textBoxSupplierFinancialFile";
			this.textBoxSupplierFinancialFile.ReadOnly = true;
			this.textBoxSupplierFinancialFile.Size = new System.Drawing.Size(236, 20);
			this.textBoxSupplierFinancialFile.TabIndex = 7;
			// 
			// buttonOpenSupplierFinancialFile
			// 
			this.buttonOpenSupplierFinancialFile.Location = new System.Drawing.Point(414, 44);
			this.buttonOpenSupplierFinancialFile.Name = "buttonOpenSupplierFinancialFile";
			this.buttonOpenSupplierFinancialFile.Size = new System.Drawing.Size(43, 23);
			this.buttonOpenSupplierFinancialFile.TabIndex = 8;
			this.buttonOpenSupplierFinancialFile.Text = "Ouvrir";
			this.buttonOpenSupplierFinancialFile.UseVisualStyleBackColor = true;
			this.buttonOpenSupplierFinancialFile.Click += new System.EventHandler(this.ButtonOpenSupplierFinancialFileClick);
			// 
			// textBoxSupplierFile
			// 
			this.textBoxSupplierFile.Location = new System.Drawing.Point(172, 71);
			this.textBoxSupplierFile.Name = "textBoxSupplierFile";
			this.textBoxSupplierFile.ReadOnly = true;
			this.textBoxSupplierFile.Size = new System.Drawing.Size(236, 20);
			this.textBoxSupplierFile.TabIndex = 9;
			// 
			// buttonOpenSupplierFile
			// 
			this.buttonOpenSupplierFile.Location = new System.Drawing.Point(414, 69);
			this.buttonOpenSupplierFile.Name = "buttonOpenSupplierFile";
			this.buttonOpenSupplierFile.Size = new System.Drawing.Size(43, 23);
			this.buttonOpenSupplierFile.TabIndex = 10;
			this.buttonOpenSupplierFile.Text = "Ouvrir";
			this.buttonOpenSupplierFile.UseVisualStyleBackColor = true;
			this.buttonOpenSupplierFile.Click += new System.EventHandler(this.ButtonOpenSupplierFileClick);
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(6, 46);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(138, 16);
			this.label10.TabIndex = 12;
			this.label10.Text = "Fournisseurs finance :";
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(6, 74);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(138, 16);
			this.label11.TabIndex = 13;
			this.label11.Text = "Fournisseurs opérationnels :";
			// 
			// groupBox9
			// 
			this.groupBox9.Controls.Add(this.label21);
			this.groupBox9.Controls.Add(this.textBoxProdStructV9File);
			this.groupBox9.Controls.Add(this.buttonOpenProdStructV9File);
			this.groupBox9.Controls.Add(this.label7);
			this.groupBox9.Controls.Add(this.textBoxProdStructFile);
			this.groupBox9.Controls.Add(this.buttonOpenProdStructFile);
			this.groupBox9.Controls.Add(this.buttonProdStruct);
			this.groupBox9.Controls.Add(this.textBoxProdStructCodeV9File);
			this.groupBox9.Controls.Add(this.label19);
			this.groupBox9.Controls.Add(this.buttonOpenProdStructCodeV9File);
			this.groupBox9.Controls.Add(this.textBoxProdStructCodeFile);
			this.groupBox9.Controls.Add(this.buttonOpenProdStructCodeFile);
			this.groupBox9.Controls.Add(this.label20);
			this.groupBox9.Location = new System.Drawing.Point(559, 437);
			this.groupBox9.Name = "groupBox9";
			this.groupBox9.Size = new System.Drawing.Size(523, 127);
			this.groupBox9.TabIndex = 28;
			this.groupBox9.TabStop = false;
			this.groupBox9.Text = "Nomenclatures : 13.1, 13.5";
			// 
			// label21
			// 
			this.label21.Location = new System.Drawing.Point(6, 97);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(160, 19);
			this.label21.TabIndex = 38;
			this.label21.Text = "Nomenclatures V9 :";
			// 
			// textBoxProdStructV9File
			// 
			this.textBoxProdStructV9File.Location = new System.Drawing.Point(172, 97);
			this.textBoxProdStructV9File.Name = "textBoxProdStructV9File";
			this.textBoxProdStructV9File.ReadOnly = true;
			this.textBoxProdStructV9File.Size = new System.Drawing.Size(236, 20);
			this.textBoxProdStructV9File.TabIndex = 36;
			// 
			// buttonOpenProdStructV9File
			// 
			this.buttonOpenProdStructV9File.Location = new System.Drawing.Point(412, 95);
			this.buttonOpenProdStructV9File.Name = "buttonOpenProdStructV9File";
			this.buttonOpenProdStructV9File.Size = new System.Drawing.Size(45, 23);
			this.buttonOpenProdStructV9File.TabIndex = 37;
			this.buttonOpenProdStructV9File.Text = "Ouvrir";
			this.buttonOpenProdStructV9File.UseVisualStyleBackColor = true;
			this.buttonOpenProdStructV9File.Click += new System.EventHandler(this.ButtonOpenProdStructV9FileClick);
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(6, 45);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(160, 19);
			this.label7.TabIndex = 35;
			this.label7.Text = "Nomenclatures :";
			// 
			// textBoxProdStructFile
			// 
			this.textBoxProdStructFile.Location = new System.Drawing.Point(172, 45);
			this.textBoxProdStructFile.Name = "textBoxProdStructFile";
			this.textBoxProdStructFile.ReadOnly = true;
			this.textBoxProdStructFile.Size = new System.Drawing.Size(236, 20);
			this.textBoxProdStructFile.TabIndex = 33;
			// 
			// buttonOpenProdStructFile
			// 
			this.buttonOpenProdStructFile.Location = new System.Drawing.Point(412, 43);
			this.buttonOpenProdStructFile.Name = "buttonOpenProdStructFile";
			this.buttonOpenProdStructFile.Size = new System.Drawing.Size(45, 23);
			this.buttonOpenProdStructFile.TabIndex = 34;
			this.buttonOpenProdStructFile.Text = "Ouvrir";
			this.buttonOpenProdStructFile.UseVisualStyleBackColor = true;
			this.buttonOpenProdStructFile.Click += new System.EventHandler(this.ButtonOpenProdStructFileClick);
			// 
			// buttonProdStruct
			// 
			this.buttonProdStruct.Enabled = false;
			this.buttonProdStruct.Location = new System.Drawing.Point(463, 16);
			this.buttonProdStruct.Name = "buttonProdStruct";
			this.buttonProdStruct.Size = new System.Drawing.Size(50, 102);
			this.buttonProdStruct.TabIndex = 32;
			this.buttonProdStruct.Text = "OK";
			this.buttonProdStruct.UseVisualStyleBackColor = true;
			this.buttonProdStruct.Click += new System.EventHandler(this.ButtonProdStructClick);
			// 
			// textBoxProdStructCodeV9File
			// 
			this.textBoxProdStructCodeV9File.Location = new System.Drawing.Point(172, 71);
			this.textBoxProdStructCodeV9File.Name = "textBoxProdStructCodeV9File";
			this.textBoxProdStructCodeV9File.ReadOnly = true;
			this.textBoxProdStructCodeV9File.Size = new System.Drawing.Size(236, 20);
			this.textBoxProdStructCodeV9File.TabIndex = 19;
			// 
			// label19
			// 
			this.label19.Location = new System.Drawing.Point(6, 19);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(160, 19);
			this.label19.TabIndex = 21;
			this.label19.Text = "Codes nomenclatures :";
			// 
			// buttonOpenProdStructCodeV9File
			// 
			this.buttonOpenProdStructCodeV9File.Location = new System.Drawing.Point(412, 68);
			this.buttonOpenProdStructCodeV9File.Name = "buttonOpenProdStructCodeV9File";
			this.buttonOpenProdStructCodeV9File.Size = new System.Drawing.Size(45, 23);
			this.buttonOpenProdStructCodeV9File.TabIndex = 20;
			this.buttonOpenProdStructCodeV9File.Text = "Ouvrir";
			this.buttonOpenProdStructCodeV9File.UseVisualStyleBackColor = true;
			this.buttonOpenProdStructCodeV9File.Click += new System.EventHandler(this.ButtonOpenProdStructCodeV9FileClick);
			// 
			// textBoxProdStructCodeFile
			// 
			this.textBoxProdStructCodeFile.Location = new System.Drawing.Point(172, 18);
			this.textBoxProdStructCodeFile.Name = "textBoxProdStructCodeFile";
			this.textBoxProdStructCodeFile.ReadOnly = true;
			this.textBoxProdStructCodeFile.Size = new System.Drawing.Size(236, 20);
			this.textBoxProdStructCodeFile.TabIndex = 19;
			// 
			// buttonOpenProdStructCodeFile
			// 
			this.buttonOpenProdStructCodeFile.Location = new System.Drawing.Point(412, 16);
			this.buttonOpenProdStructCodeFile.Name = "buttonOpenProdStructCodeFile";
			this.buttonOpenProdStructCodeFile.Size = new System.Drawing.Size(45, 23);
			this.buttonOpenProdStructCodeFile.TabIndex = 20;
			this.buttonOpenProdStructCodeFile.Text = "Ouvrir";
			this.buttonOpenProdStructCodeFile.UseVisualStyleBackColor = true;
			this.buttonOpenProdStructCodeFile.Click += new System.EventHandler(this.ButtonOpenProdStructCodeFileClick);
			// 
			// label20
			// 
			this.label20.Location = new System.Drawing.Point(6, 73);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(154, 19);
			this.label20.TabIndex = 23;
			this.label20.Text = "Codes nomenclatures V9 :";
			// 
			// label26
			// 
			this.label26.Location = new System.Drawing.Point(8, 20);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(158, 19);
			this.label26.TabIndex = 23;
			this.label26.Text = "Gammes :";
			// 
			// buttonOpenRoutingFile
			// 
			this.buttonOpenRoutingFile.Location = new System.Drawing.Point(414, 17);
			this.buttonOpenRoutingFile.Name = "buttonOpenRoutingFile";
			this.buttonOpenRoutingFile.Size = new System.Drawing.Size(45, 23);
			this.buttonOpenRoutingFile.TabIndex = 20;
			this.buttonOpenRoutingFile.Text = "Ouvrir";
			this.buttonOpenRoutingFile.UseVisualStyleBackColor = true;
			this.buttonOpenRoutingFile.Click += new System.EventHandler(this.ButtonOpenRoutingFileClick);
			// 
			// textBoxRoutingFile
			// 
			this.textBoxRoutingFile.Location = new System.Drawing.Point(172, 19);
			this.textBoxRoutingFile.Name = "textBoxRoutingFile";
			this.textBoxRoutingFile.ReadOnly = true;
			this.textBoxRoutingFile.Size = new System.Drawing.Size(238, 20);
			this.textBoxRoutingFile.TabIndex = 19;
			// 
			// buttonOpenRoutingV9File
			// 
			this.buttonOpenRoutingV9File.Location = new System.Drawing.Point(414, 42);
			this.buttonOpenRoutingV9File.Name = "buttonOpenRoutingV9File";
			this.buttonOpenRoutingV9File.Size = new System.Drawing.Size(45, 23);
			this.buttonOpenRoutingV9File.TabIndex = 37;
			this.buttonOpenRoutingV9File.Text = "Ouvrir";
			this.buttonOpenRoutingV9File.UseVisualStyleBackColor = true;
			this.buttonOpenRoutingV9File.Click += new System.EventHandler(this.ButtonOpenRoutingV9FileClick);
			// 
			// textBoxRoutingV9File
			// 
			this.textBoxRoutingV9File.Location = new System.Drawing.Point(172, 44);
			this.textBoxRoutingV9File.Name = "textBoxRoutingV9File";
			this.textBoxRoutingV9File.ReadOnly = true;
			this.textBoxRoutingV9File.Size = new System.Drawing.Size(238, 20);
			this.textBoxRoutingV9File.TabIndex = 36;
			// 
			// label23
			// 
			this.label23.Location = new System.Drawing.Point(8, 48);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(158, 19);
			this.label23.TabIndex = 38;
			this.label23.Text = "Gammes V9 :";
			// 
			// buttonRouting
			// 
			this.buttonRouting.Enabled = false;
			this.buttonRouting.Location = new System.Drawing.Point(463, 17);
			this.buttonRouting.Name = "buttonRouting";
			this.buttonRouting.Size = new System.Drawing.Size(51, 49);
			this.buttonRouting.TabIndex = 30;
			this.buttonRouting.Text = "OK";
			this.buttonRouting.UseVisualStyleBackColor = true;
			this.buttonRouting.Click += new System.EventHandler(this.ButtonRoutingClick);
			// 
			// groupBox10
			// 
			this.groupBox10.Controls.Add(this.buttonRouting);
			this.groupBox10.Controls.Add(this.label23);
			this.groupBox10.Controls.Add(this.textBoxRoutingV9File);
			this.groupBox10.Controls.Add(this.buttonOpenRoutingV9File);
			this.groupBox10.Controls.Add(this.textBoxRoutingFile);
			this.groupBox10.Controls.Add(this.buttonOpenRoutingFile);
			this.groupBox10.Controls.Add(this.label26);
			this.groupBox10.Location = new System.Drawing.Point(559, 570);
			this.groupBox10.Name = "groupBox10";
			this.groupBox10.Size = new System.Drawing.Size(523, 75);
			this.groupBox10.TabIndex = 29;
			this.groupBox10.TabStop = false;
			this.groupBox10.Text = "Gammes : 14.13.1";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.buttonWorkCenter);
			this.groupBox2.Controls.Add(this.label29);
			this.groupBox2.Controls.Add(this.textBoxWorkCenterV9File);
			this.groupBox2.Controls.Add(this.buttonOpenWorkCenterV9File);
			this.groupBox2.Controls.Add(this.textBoxWorkCenterFile);
			this.groupBox2.Controls.Add(this.buttonOpenWorkCenterFile);
			this.groupBox2.Controls.Add(this.label30);
			this.groupBox2.Location = new System.Drawing.Point(559, 651);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(523, 75);
			this.groupBox2.TabIndex = 39;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Centres de charge - machines : 14.5";
			// 
			// buttonWorkCenter
			// 
			this.buttonWorkCenter.Enabled = false;
			this.buttonWorkCenter.Location = new System.Drawing.Point(463, 17);
			this.buttonWorkCenter.Name = "buttonWorkCenter";
			this.buttonWorkCenter.Size = new System.Drawing.Size(51, 49);
			this.buttonWorkCenter.TabIndex = 30;
			this.buttonWorkCenter.Text = "OK";
			this.buttonWorkCenter.UseVisualStyleBackColor = true;
			this.buttonWorkCenter.Click += new System.EventHandler(this.ButtonWorkCenterClick);
			// 
			// label29
			// 
			this.label29.Location = new System.Drawing.Point(8, 48);
			this.label29.Name = "label29";
			this.label29.Size = new System.Drawing.Size(158, 19);
			this.label29.TabIndex = 38;
			this.label29.Text = "Centres de charge V9 :";
			// 
			// textBoxWorkCenterV9File
			// 
			this.textBoxWorkCenterV9File.Location = new System.Drawing.Point(172, 44);
			this.textBoxWorkCenterV9File.Name = "textBoxWorkCenterV9File";
			this.textBoxWorkCenterV9File.ReadOnly = true;
			this.textBoxWorkCenterV9File.Size = new System.Drawing.Size(238, 20);
			this.textBoxWorkCenterV9File.TabIndex = 36;
			// 
			// buttonOpenWorkCenterV9File
			// 
			this.buttonOpenWorkCenterV9File.Location = new System.Drawing.Point(414, 42);
			this.buttonOpenWorkCenterV9File.Name = "buttonOpenWorkCenterV9File";
			this.buttonOpenWorkCenterV9File.Size = new System.Drawing.Size(45, 23);
			this.buttonOpenWorkCenterV9File.TabIndex = 37;
			this.buttonOpenWorkCenterV9File.Text = "Ouvrir";
			this.buttonOpenWorkCenterV9File.UseVisualStyleBackColor = true;
			this.buttonOpenWorkCenterV9File.Click += new System.EventHandler(this.ButtonOpenWorkCenterV9FileClick);
			// 
			// textBoxWorkCenterFile
			// 
			this.textBoxWorkCenterFile.Location = new System.Drawing.Point(172, 19);
			this.textBoxWorkCenterFile.Name = "textBoxWorkCenterFile";
			this.textBoxWorkCenterFile.ReadOnly = true;
			this.textBoxWorkCenterFile.Size = new System.Drawing.Size(238, 20);
			this.textBoxWorkCenterFile.TabIndex = 19;
			// 
			// buttonOpenWorkCenterFile
			// 
			this.buttonOpenWorkCenterFile.Location = new System.Drawing.Point(414, 17);
			this.buttonOpenWorkCenterFile.Name = "buttonOpenWorkCenterFile";
			this.buttonOpenWorkCenterFile.Size = new System.Drawing.Size(45, 23);
			this.buttonOpenWorkCenterFile.TabIndex = 20;
			this.buttonOpenWorkCenterFile.Text = "Ouvrir";
			this.buttonOpenWorkCenterFile.UseVisualStyleBackColor = true;
			this.buttonOpenWorkCenterFile.Click += new System.EventHandler(this.ButtonOpenWorkCenterFileClick);
			// 
			// label30
			// 
			this.label30.Location = new System.Drawing.Point(8, 20);
			this.label30.Name = "label30";
			this.label30.Size = new System.Drawing.Size(158, 19);
			this.label30.TabIndex = 23;
			this.label30.Text = "Centres de charge :";
			// 
			// groupBox8
			// 
			this.groupBox8.Controls.Add(this.buttonProductionLine);
			this.groupBox8.Controls.Add(this.buttonOpenProductionLineFile);
			this.groupBox8.Controls.Add(this.textBoxProductionLineFile);
			this.groupBox8.Controls.Add(this.label31);
			this.groupBox8.Location = new System.Drawing.Point(12, 599);
			this.groupBox8.Name = "groupBox8";
			this.groupBox8.Size = new System.Drawing.Size(541, 53);
			this.groupBox8.TabIndex = 29;
			this.groupBox8.TabStop = false;
			this.groupBox8.Text = "Lignes de production : 18.22.1.1";
			// 
			// buttonProductionLine
			// 
			this.buttonProductionLine.Enabled = false;
			this.buttonProductionLine.Location = new System.Drawing.Point(482, 19);
			this.buttonProductionLine.Name = "buttonProductionLine";
			this.buttonProductionLine.Size = new System.Drawing.Size(51, 23);
			this.buttonProductionLine.TabIndex = 31;
			this.buttonProductionLine.Text = "OK";
			this.buttonProductionLine.UseVisualStyleBackColor = true;
			this.buttonProductionLine.Click += new System.EventHandler(this.ButtonProductionLineClick);
			// 
			// buttonOpenProductionLineFile
			// 
			this.buttonOpenProductionLineFile.Location = new System.Drawing.Point(431, 19);
			this.buttonOpenProductionLineFile.Name = "buttonOpenProductionLineFile";
			this.buttonOpenProductionLineFile.Size = new System.Drawing.Size(44, 23);
			this.buttonOpenProductionLineFile.TabIndex = 27;
			this.buttonOpenProductionLineFile.Text = "Ouvrir";
			this.buttonOpenProductionLineFile.UseVisualStyleBackColor = true;
			this.buttonOpenProductionLineFile.Click += new System.EventHandler(this.ButtonOpenProductionLineFileClick);
			// 
			// textBoxProductionLineFile
			// 
			this.textBoxProductionLineFile.Location = new System.Drawing.Point(208, 19);
			this.textBoxProductionLineFile.Name = "textBoxProductionLineFile";
			this.textBoxProductionLineFile.ReadOnly = true;
			this.textBoxProductionLineFile.Size = new System.Drawing.Size(217, 20);
			this.textBoxProductionLineFile.TabIndex = 26;
			// 
			// label31
			// 
			this.label31.Location = new System.Drawing.Point(4, 22);
			this.label31.Name = "label31";
			this.label31.Size = new System.Drawing.Size(193, 16);
			this.label31.TabIndex = 25;
			this.label31.Text = "Lignes de production :";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1092, 736);
			this.Controls.Add(this.groupBox8);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox10);
			this.Controls.Add(this.groupBox9);
			this.Controls.Add(this.groupBox6);
			this.Controls.Add(this.groupBox5);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.buttonQuit);
			this.Controls.Add(this.groupBoxPF);
			this.Name = "MainForm";
			this.ShowIcon = false;
			this.Text = "Super Uploader";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.groupBoxPF.ResumeLayout(false);
			this.groupBox7.ResumeLayout(false);
			this.groupBox7.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			this.groupBox6.ResumeLayout(false);
			this.groupBox6.PerformLayout();
			this.groupBox9.ResumeLayout(false);
			this.groupBox9.PerformLayout();
			this.groupBox10.ResumeLayout(false);
			this.groupBox10.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox8.ResumeLayout(false);
			this.groupBox8.PerformLayout();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.TextBox textBoxProductionLineFile;
		private System.Windows.Forms.Button buttonOpenProductionLineFile;
		private System.Windows.Forms.Button buttonProductionLine;
		private System.Windows.Forms.GroupBox groupBox8;
		private System.Windows.Forms.Label label30;
		private System.Windows.Forms.Button buttonOpenWorkCenterFile;
		private System.Windows.Forms.TextBox textBoxWorkCenterFile;
		private System.Windows.Forms.Button buttonOpenWorkCenterV9File;
		private System.Windows.Forms.TextBox textBoxWorkCenterV9File;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.Button buttonWorkCenter;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.TextBox textBoxItemAnalysisCodeBrandFile;
		private System.Windows.Forms.Button buttonOpenItemAnalysisCodeBrandFile;
		private System.Windows.Forms.Button buttonOpenItemIntrastatCodeFile;
		private System.Windows.Forms.TextBox textBoxItemIntrastatCodeFile;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.Button buttonOpenItemCostFile;
		private System.Windows.Forms.TextBox textBoxItemCostFile;
		private System.Windows.Forms.Button buttonOpenItemV9CostFile;
		private System.Windows.Forms.TextBox textBoxItemV9CostFile;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.OpenFileDialog openFileDialogItem;
		private System.Windows.Forms.TextBox textBoxXlsFolder;
		private System.Windows.Forms.Button buttonOpenXlsFolder;
		private System.Windows.Forms.TextBox textBoxCustomerGeneralParamsFile;
		private System.Windows.Forms.Button buttonOpenCustomerGeneralParamsFile;
		private System.Windows.Forms.TextBox textBoxSupplierGeneralParamsFile;
		private System.Windows.Forms.Button buttonOpenSupplierGeneralParamsFile;
		private System.Windows.Forms.TextBox textBoxSupplierItemFile;
		private System.Windows.Forms.Button buttonOpenSupplierItemFile;
		private System.Windows.Forms.TextBox textBoxSupplierV9ItemFile;
		private System.Windows.Forms.Button buttonOpenSupplierV9ItemFile;
		private System.Windows.Forms.TextBox textBoxProdStructV9File;
		private System.Windows.Forms.Button buttonOpenProdStructV9File;
		private System.Windows.Forms.TextBox textBoxProdStructFile;
		private System.Windows.Forms.Button buttonOpenProdStructFile;
		private System.Windows.Forms.Button buttonProdStruct;
		private System.Windows.Forms.TextBox textBoxProdStructCodeV9File;
		private System.Windows.Forms.Button buttonOpenProdStructCodeV9File;
		private System.Windows.Forms.TextBox textBoxProdStructCodeFile;
		private System.Windows.Forms.Button buttonOpenProdStructCodeFile;
		private System.Windows.Forms.Button buttonRouting;
		private System.Windows.Forms.TextBox textBoxRoutingV9File;
		private System.Windows.Forms.Button buttonOpenRoutingV9File;
		private System.Windows.Forms.TextBox textBoxRoutingFile;
		private System.Windows.Forms.Button buttonOpenRoutingFile;
		private System.Windows.Forms.Button buttonOpenItemFile;
		private System.Windows.Forms.TextBox textBoxItemSiteCellProdLineFile;
		private System.Windows.Forms.Button buttonOpenItemSiteCellProdLineFile;
		private System.Windows.Forms.TextBox textBoxItemProdLineFile;
		private System.Windows.Forms.Button buttonOpenItemProdLineFile;
		private System.Windows.Forms.Button buttonItem;
		private System.Windows.Forms.TextBox textBoxItemFile;
		private System.Windows.Forms.TextBox textBoxItemLeaderFile;
		private System.Windows.Forms.Button buttonOpenItemLeaderFile;
		private System.Windows.Forms.Button buttonOpenItemV9File;
		private System.Windows.Forms.TextBox textBoxItemV9File;
		private System.Windows.Forms.TextBox textBoxItemRawFile;
		private System.Windows.Forms.Button buttonOpenItemRawFile;
		private System.Windows.Forms.TextBox textBoxItemV9ProdLineFile;
		private System.Windows.Forms.Button buttonOpenItemV9ProdLineFile;
		private System.Windows.Forms.TextBox textBoxItemV9LastProdLineFile;
		private System.Windows.Forms.Button buttonOpenItemV9LastProdLineFile;
		private System.Windows.Forms.Button buttonOpenItemGeneralParamsFile;
		private System.Windows.Forms.TextBox textBoxItemGeneralParamsFile;
		private System.Windows.Forms.Button buttonOpenItemAnalysisCodeFile;
		private System.Windows.Forms.TextBox textBoxItemAnalysisCodeFile;
		private System.Windows.Forms.TextBox textBoxItemDSRPFile;
		private System.Windows.Forms.Button buttonOpenItemDSRPFile;
		private System.Windows.Forms.Button buttonOpenItemIntrastatFile;
		private System.Windows.Forms.TextBox textBoxItemIntrastatFile;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.GroupBox groupBox10;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.GroupBox groupBox9;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.GroupBox groupBox7;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Button buttonOpenSupplierFile;
		private System.Windows.Forms.TextBox textBoxSupplierFile;
		private System.Windows.Forms.Button buttonOpenSupplierFinancialFile;
		private System.Windows.Forms.TextBox textBoxSupplierFinancialFile;
		private System.Windows.Forms.Button buttonOpenSupplierBusinessRelationFile;
		private System.Windows.Forms.TextBox textBoxSupplierBusinessRelationFile;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Button buttonSupplier;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button buttonOpenSupplierV9File;
		private System.Windows.Forms.TextBox textBoxSupplierV9File;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.TextBox textBoxCustomerItemFile;
		private System.Windows.Forms.Button buttonOpenCustomerItemFile;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Button buttonOpenCustomerFinancialFile;
		private System.Windows.Forms.TextBox textBoxCustomerFinancialFile;
		private System.Windows.Forms.Button buttonOpenCustomerBusinessRelationFile;
		private System.Windows.Forms.TextBox textBoxCustomerBusinessRelationFile;
		private System.Windows.Forms.TextBox textBoxCustomerTreeFile;
		private System.Windows.Forms.Button buttonOpenCustomerTreeFile;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button buttonCustomer;
		private System.Windows.Forms.TextBox textBoxCustomerFile;
		private System.Windows.Forms.Button buttonOpenCustomerFile;
		private System.Windows.Forms.Button buttonOpenCustomerDeliveryFile;
		private System.Windows.Forms.TextBox textBoxCustomerDeliveryFile;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.Label labelV9LastLigneProdFile;
		private System.Windows.Forms.Label labelV9LigneProdFile;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.GroupBox groupBox1;
		
		private System.Windows.Forms.Button buttonQuit;
		private System.Windows.Forms.Label labelRawFile;
		private System.Windows.Forms.Label labelV9File;
		private System.Windows.Forms.Label labelLeaderFile;
		private System.Windows.Forms.Label labelXls;
		private System.Windows.Forms.Label labelSiteCelluleFile;
		private System.Windows.Forms.Label labelLigneProdFile;
		private System.Windows.Forms.Button buttonXls;
		private System.Windows.Forms.GroupBox groupBoxPF;
		private System.Windows.Forms.Label labelPFFile;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogXls;
	}
}
