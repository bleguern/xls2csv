/*
 * Created by SharpDevelop.
 * User: Benoit Le Guern
 * Date: 17/07/2008
 * Time: 15:04
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.Collections;
using System.Data;
using System.Xml;

namespace xls2csv
{
	
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		private string files = null;
		private int nbFiles = 0;
		private const string CONFIG_FILENAME = "config.xml";
	
		[STAThread]
		public static void Main(string[] args)
		{
			System.Windows.Forms.Application.EnableVisualStyles();
			System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
			System.Windows.Forms.Application.Run(new MainForm());
		}
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			LoadConfigFile();
			UpdateXls();
			UpdateItem();
			UpdateCustomer();
			UpdateSupplier();
			UpdateRouting();
			UpdateProdStruct();
			UpdateWorkCenter();
			UpdateProductionLine();
		}
		
		private void LoadConfigFile()
		{				
			string xls_folder, 
			item_file, 
			item_site_cell_prod_line_file, 
			item_prod_line_file, 
			item_leader_file, 
			item_analysis_code_file,
			item_analysis_code_brand_file,
			item_intrastat_code_file,
			item_intrastat_file,
			item_raw_file, 
			item_dsrp_file,
			item_cost_file,
			item_v9_file, 
			item_v9_prod_line_file, 
			item_v9_last_prod_line_file, 
			item_v9_cost_file,
			item_general_params_file,
			customer_business_relation_file, 
			customer_financial_file, 
			customer_file,
			customer_delivery_file,
			customer_tree_file,
			customer_item_file,
			customer_general_params_file,
			supplier_business_relation_file,
			supplier_financial_file,
			supplier_file,
			supplier_item_file,
			supplier_v9_file,
			supplier_v9_item_file,
			supplier_general_params_file,
			routing_file,
			routing_v9_file,
			prod_struct_file,
			prod_struct_v9_file,
			prod_struct_code_file,
			prod_struct_code_v9_file,
			work_center_file,
			work_center_v9_file,
			production_line_file;
			
			if (File.Exists(System.Windows.Forms.Application.StartupPath + "\\" + CONFIG_FILENAME))
			{
				try
	            {
	                XmlDocument config = new XmlDocument();
	
	                config.Load(System.Windows.Forms.Application.StartupPath + "\\" + CONFIG_FILENAME);
	
	                xls_folder = config.DocumentElement.SelectSingleNode("//config/directories/directory[@name='xls_folder']/@value").Value;
			
	                item_file = config.DocumentElement.SelectSingleNode("//config/files/file[@name='item_file']/@value").Value;
	                item_site_cell_prod_line_file = config.DocumentElement.SelectSingleNode("//config/files/file[@name='item_site_cell_prod_line_file']/@value").Value;
	                item_prod_line_file = config.DocumentElement.SelectSingleNode("//config/files/file[@name='item_prod_line_file']/@value").Value;
	                item_leader_file = config.DocumentElement.SelectSingleNode("//config/files/file[@name='item_leader_file']/@value").Value;
	                item_analysis_code_file = config.DocumentElement.SelectSingleNode("//config/files/file[@name='item_analysis_code_file']/@value").Value;
	                item_analysis_code_brand_file = config.DocumentElement.SelectSingleNode("//config/files/file[@name='item_analysis_code_brand_file']/@value").Value;
	                item_intrastat_code_file = config.DocumentElement.SelectSingleNode("//config/files/file[@name='item_intrastat_code_file']/@value").Value;
	                item_intrastat_file = config.DocumentElement.SelectSingleNode("//config/files/file[@name='item_intrastat_file']/@value").Value;
	                item_raw_file = config.DocumentElement.SelectSingleNode("//config/files/file[@name='item_raw_file']/@value").Value;
	                item_dsrp_file = config.DocumentElement.SelectSingleNode("//config/files/file[@name='item_dsrp_file']/@value").Value;
	                item_cost_file = config.DocumentElement.SelectSingleNode("//config/files/file[@name='item_cost_file']/@value").Value;
	      			item_v9_file = config.DocumentElement.SelectSingleNode("//config/files/file[@name='item_v9_file']/@value").Value;
	                item_v9_prod_line_file = config.DocumentElement.SelectSingleNode("//config/files/file[@name='item_v9_prod_line_file']/@value").Value;
	                item_v9_last_prod_line_file = config.DocumentElement.SelectSingleNode("//config/files/file[@name='item_v9_last_prod_line_file']/@value").Value;
	                item_v9_cost_file  = config.DocumentElement.SelectSingleNode("//config/files/file[@name='item_v9_cost_file']/@value").Value;
					item_general_params_file = config.DocumentElement.SelectSingleNode("//config/files/file[@name='item_general_params_file']/@value").Value;
			
	                customer_business_relation_file = config.DocumentElement.SelectSingleNode("//config/files/file[@name='customer_business_relation_file']/@value").Value;
					customer_financial_file = config.DocumentElement.SelectSingleNode("//config/files/file[@name='customer_financial_file']/@value").Value;
					customer_file = config.DocumentElement.SelectSingleNode("//config/files/file[@name='customer_file']/@value").Value;
					customer_delivery_file = config.DocumentElement.SelectSingleNode("//config/files/file[@name='customer_delivery_file']/@value").Value;
					customer_tree_file = config.DocumentElement.SelectSingleNode("//config/files/file[@name='customer_tree_file']/@value").Value;
	                customer_item_file = config.DocumentElement.SelectSingleNode("//config/files/file[@name='customer_item_file']/@value").Value;
	                customer_general_params_file = config.DocumentElement.SelectSingleNode("//config/files/file[@name='customer_general_params_file']/@value").Value;
				
	                supplier_business_relation_file = config.DocumentElement.SelectSingleNode("//config/files/file[@name='supplier_business_relation_file']/@value").Value;
					supplier_financial_file = config.DocumentElement.SelectSingleNode("//config/files/file[@name='supplier_financial_file']/@value").Value;
					supplier_file = config.DocumentElement.SelectSingleNode("//config/files/file[@name='supplier_file']/@value").Value;
					supplier_item_file = config.DocumentElement.SelectSingleNode("//config/files/file[@name='supplier_item_file']/@value").Value;
					supplier_v9_file = config.DocumentElement.SelectSingleNode("//config/files/file[@name='supplier_v9_file']/@value").Value;
					supplier_v9_item_file = config.DocumentElement.SelectSingleNode("//config/files/file[@name='supplier_v9_item_file']/@value").Value;
					supplier_general_params_file = config.DocumentElement.SelectSingleNode("//config/files/file[@name='supplier_general_params_file']/@value").Value;
	            
					routing_file = config.DocumentElement.SelectSingleNode("//config/files/file[@name='routing_file']/@value").Value;
	                routing_v9_file = config.DocumentElement.SelectSingleNode("//config/files/file[@name='routing_v9_file']/@value").Value;
	                prod_struct_file = config.DocumentElement.SelectSingleNode("//config/files/file[@name='prod_struct_file']/@value").Value;
	                prod_struct_v9_file = config.DocumentElement.SelectSingleNode("//config/files/file[@name='prod_struct_v9_file']/@value").Value;
	                prod_struct_code_file = config.DocumentElement.SelectSingleNode("//config/files/file[@name='prod_struct_code_file']/@value").Value;
	                prod_struct_code_v9_file = config.DocumentElement.SelectSingleNode("//config/files/file[@name='prod_struct_code_v9_file']/@value").Value;
	                
	                work_center_file = config.DocumentElement.SelectSingleNode("//config/files/file[@name='work_center_file']/@value").Value;
	                work_center_v9_file = config.DocumentElement.SelectSingleNode("//config/files/file[@name='work_center_v9_file']/@value").Value;
	               
	                production_line_file = config.DocumentElement.SelectSingleNode("//config/files/file[@name='production_line_file']/@value").Value;
	               
	                if ((xls_folder != null) && (Directory.Exists(xls_folder)))
	            	{
						textBoxXlsFolder.Text = xls_folder;
					}
					
					if ((item_file != null) && (File.Exists(item_file)))
		            {
		            	textBoxItemFile.Text = item_file;
		            }
					
					if ((item_site_cell_prod_line_file != null) && (File.Exists(item_site_cell_prod_line_file)))
		            {
		            	textBoxItemSiteCellProdLineFile.Text = item_site_cell_prod_line_file;
		            }
					
					if ((item_prod_line_file != null) && (File.Exists(item_prod_line_file)))
		            {
		            	textBoxItemProdLineFile.Text = item_prod_line_file;
		            }
					
					if ((item_leader_file != null) && (File.Exists(item_leader_file)))
		            {
		            	textBoxItemLeaderFile.Text = item_leader_file;
		            }
					
					if ((item_analysis_code_file != null) && (File.Exists(item_analysis_code_file)))
		            {
		            	textBoxItemAnalysisCodeFile.Text = item_analysis_code_file;
		            }
					
					if ((item_analysis_code_brand_file != null) && (File.Exists(item_analysis_code_brand_file)))
		            {
		            	textBoxItemAnalysisCodeBrandFile.Text = item_analysis_code_brand_file;
		            }
					
					if ((item_intrastat_code_file != null) && (File.Exists(item_intrastat_code_file)))
		            {
		            	textBoxItemIntrastatCodeFile.Text = item_intrastat_code_file;
		            }
					
					if ((item_intrastat_file != null) && (File.Exists(item_intrastat_file)))
		            {
		            	textBoxItemIntrastatFile.Text = item_intrastat_file;
		            }
					
					if ((item_raw_file != null) && (File.Exists(item_raw_file)))
		            {
		            	textBoxItemRawFile.Text = item_raw_file;
		            }
					
					if ((item_dsrp_file != null) && (File.Exists(item_dsrp_file)))
		            {
		            	textBoxItemDSRPFile.Text = item_dsrp_file;
		            }
					
					if ((item_cost_file != null) && (File.Exists(item_cost_file)))
		            {
		            	textBoxItemCostFile.Text = item_cost_file;
		            }
					
					if ((item_v9_file != null) && (File.Exists(item_v9_file)))
		            {
		            	textBoxItemV9File.Text = item_v9_file;
		            }
					
					if ((item_v9_prod_line_file != null) && (File.Exists(item_v9_prod_line_file)))
		            {
		            	textBoxItemV9ProdLineFile.Text = item_v9_prod_line_file;
		            }
					
					if ((item_v9_last_prod_line_file != null) && (File.Exists(item_v9_last_prod_line_file)))
		            {
		            	textBoxItemV9LastProdLineFile.Text = item_v9_last_prod_line_file;
		            }
					
					if ((item_v9_cost_file != null) && (File.Exists(item_v9_cost_file)))
		            {
		            	textBoxItemV9CostFile.Text = item_v9_cost_file;
		            }
					
					if ((item_general_params_file != null) && (File.Exists(item_general_params_file)))
		            {
		            	textBoxItemGeneralParamsFile.Text = item_general_params_file;
		            }
					
					
					if ((customer_business_relation_file != null) && (File.Exists(customer_business_relation_file)))
		            {
		            	textBoxCustomerBusinessRelationFile.Text = customer_business_relation_file;
		            }
					
					if ((customer_financial_file != null) && (File.Exists(customer_financial_file)))
		            {
		            	textBoxCustomerFinancialFile.Text = customer_financial_file;
		            }
					
					if ((customer_file != null) && (File.Exists(customer_file)))
		            {
		            	textBoxCustomerFile.Text = customer_file;
		            }
					
					if ((customer_delivery_file != null) && (File.Exists(customer_delivery_file)))
		            {
		            	textBoxCustomerDeliveryFile.Text = customer_delivery_file;
		            }
					
					if ((customer_tree_file != null) && (File.Exists(customer_tree_file)))
		            {
		            	textBoxCustomerTreeFile.Text = customer_tree_file;
		            }
					
					if ((customer_item_file != null) && (File.Exists(customer_item_file)))
		            {
		            	textBoxCustomerItemFile.Text = customer_item_file;
		            }
					
					if ((customer_general_params_file != null) && (File.Exists(customer_general_params_file)))
		            {
		            	textBoxCustomerGeneralParamsFile.Text = customer_general_params_file;
		            }
					
					
					if ((supplier_business_relation_file != null) && (File.Exists(supplier_business_relation_file)))
		            {
		            	textBoxSupplierBusinessRelationFile.Text = supplier_business_relation_file;
		            }
					
					if ((supplier_financial_file != null) && (File.Exists(supplier_financial_file)))
		            {
		            	textBoxSupplierFinancialFile.Text = supplier_financial_file;
		            }
					
					if ((supplier_file != null) && (File.Exists(supplier_file)))
		            {
		            	textBoxSupplierFile.Text = supplier_file;
		            }
					
					if ((supplier_item_file != null) && (File.Exists(supplier_item_file)))
		            {
		            	textBoxSupplierItemFile.Text = supplier_item_file;
		            }
					
					if ((supplier_v9_file != null) && (File.Exists(supplier_v9_file)))
		            {
		            	textBoxSupplierV9File.Text = supplier_v9_file;
		            }
					
					if ((supplier_v9_item_file != null) && (File.Exists(supplier_v9_item_file)))
		            {
		            	textBoxSupplierV9ItemFile.Text = supplier_v9_item_file;
		            }
					
					if ((supplier_general_params_file != null) && (File.Exists(supplier_general_params_file)))
		            {
		            	textBoxSupplierGeneralParamsFile.Text = supplier_general_params_file;
		            }
					
					
					if ((routing_file != null) && (File.Exists(routing_file)))
		            {
		            	textBoxRoutingFile.Text = routing_file;
		            }
					
					if ((routing_v9_file != null) && (File.Exists(routing_v9_file)))
		            {
		            	textBoxRoutingV9File.Text = routing_v9_file;
		            }
					
					
					if ((prod_struct_file != null) && (File.Exists(prod_struct_file)))
		            {
		            	textBoxProdStructFile.Text = prod_struct_file;
		            }
					if ((prod_struct_v9_file != null) && (File.Exists(prod_struct_v9_file)))
		            {
		            	textBoxProdStructV9File.Text = prod_struct_v9_file;
		            }
					if ((prod_struct_code_file != null) && (File.Exists(prod_struct_code_file)))
		            {
		            	textBoxProdStructCodeFile.Text = prod_struct_code_file;
		            }
					if ((prod_struct_code_v9_file != null) && (File.Exists(prod_struct_code_v9_file)))
		            {
		            	textBoxProdStructCodeV9File.Text = prod_struct_code_v9_file;
		            }
					
					
					if ((work_center_file != null) && (File.Exists(work_center_file)))
		            {
		            	textBoxWorkCenterFile.Text = work_center_file;
		            }
					
					if ((work_center_v9_file != null) && (File.Exists(work_center_v9_file)))
		            {
		            	textBoxWorkCenterV9File.Text = work_center_v9_file;
		            }
					
					
					if ((production_line_file != null) && (File.Exists(production_line_file)))
		            {
		            	textBoxProductionLineFile.Text = production_line_file;
		            }
				}
	            catch (Exception)
	            {
	            	
	            }
			}
		}
		
		private void UpdateXls()
		{
			/* INIT */
			files = null;
			nbFiles = 0;
			buttonXls.Enabled = false;
			
			if (Directory.Exists(textBoxXlsFolder.Text))
			{
				string [] tmpFiles = Directory.GetFiles(textBoxXlsFolder.Text);
				
				foreach (string tmpFile in tmpFiles)
				{
					if (Path.GetExtension(tmpFile).ToLower().Equals(".xls"))
					{
						files += tmpFile.ToLower() + ";";
						nbFiles++;
					}
				}
			}
			
			if (nbFiles > 0)
			{
				buttonXls.Enabled = true;
			}
		}
		
		private void UpdateItem()
		{
			if ((textBoxItemFile.Text != "") &&
			    (textBoxItemSiteCellProdLineFile.Text != "") &&
			    (textBoxItemProdLineFile.Text != "") && 
			    (textBoxItemAnalysisCodeFile.Text != "") &&
			    (textBoxItemAnalysisCodeBrandFile.Text != "") &&
			    (textBoxItemIntrastatFile.Text != "") &&
			    (textBoxItemIntrastatCodeFile.Text != "") &&
			    (textBoxItemLeaderFile.Text != "") &&
			    (textBoxItemRawFile.Text != "") &&
			    (textBoxItemV9File.Text != "") && 
			    (textBoxItemV9ProdLineFile.Text != "") && 
			    (textBoxItemV9LastProdLineFile.Text != ""))
			{
				buttonItem.Enabled = true;
			}
			else
			{
				buttonItem.Enabled = false;
			}
		}
		
		private void UpdateCustomer()
		{
			if ((textBoxCustomerBusinessRelationFile.Text != "") &&
			    (textBoxCustomerFile.Text != "") &&
			    (textBoxCustomerFinancialFile.Text != "") && 
			    (textBoxCustomerDeliveryFile.Text != "") &&
			    (textBoxCustomerTreeFile.Text != "") &&
			    (textBoxCustomerItemFile.Text != ""))
			{
				buttonCustomer.Enabled = true;
			}
			else
			{
				buttonCustomer.Enabled = false;
			}
		}
		
		private void UpdateSupplier()
		{
			if ((textBoxSupplierBusinessRelationFile.Text != "") &&
			    (textBoxSupplierFile.Text != "") &&
			    (textBoxSupplierFinancialFile.Text != "") && 
			    (textBoxSupplierV9File.Text != ""))
			{
				buttonSupplier.Enabled = true;
			}
			else
			{
				buttonSupplier.Enabled = false;
			}
		}
		
		private void UpdateRouting()
		{
			if ((textBoxRoutingFile.Text != "") &&
			    (textBoxRoutingV9File.Text != ""))
			{
				buttonRouting.Enabled = true;
			}
			else
			{
				buttonRouting.Enabled = false;
			}
		}
		
		private void UpdateProdStruct()
		{
			if ((textBoxProdStructFile.Text != "") &&
			    (textBoxProdStructV9File.Text != "")&&
			    (textBoxProdStructCodeFile.Text != "")&&
			    (textBoxProdStructCodeV9File.Text != ""))
			{
				buttonProdStruct.Enabled = true;
			}
			else
			{
				buttonProdStruct.Enabled = false;
			}
		}
		
		void ButtonOpenFolderClick(object sender, EventArgs e)
		{
			folderBrowserDialogXls = new FolderBrowserDialog();
			
			if (textBoxXlsFolder.Text != "")
			{
				folderBrowserDialogXls.SelectedPath = textBoxXlsFolder.Text;
			}
			
			if (folderBrowserDialogXls.ShowDialog() == DialogResult.OK)
			{
				textBoxXlsFolder.Text = folderBrowserDialogXls.SelectedPath;
				
				UpdateXls();
			}
		}
		
		void ButtonXlsClick(object sender, EventArgs e)
		{
			buttonOpenXlsFolder.Enabled = false;
			buttonXls.Enabled = false;
			
			if (nbFiles > 0)
			{
				string [] filenames = files.Split(";".ToCharArray());
				
				foreach (string filename in filenames)
				{
					if (filename != "")
					{
						ConvertXlsToCsv(filename);
					}
				}
			}
			
			buttonXls.Enabled = true;
			buttonOpenXlsFolder.Enabled = true;
		}		
		
		void ConvertXlsToCsv(string filename)
		{
			ApplicationClass app = new ApplicationClass(); // the Excel application.
		    Workbook book = null;
		    Worksheet sheet = null;
		    Range range = null;
		    
		    app.Visible = false;
		    app.ScreenUpdating = false;
		    app.DisplayAlerts = false;
		    
		    book = app.Workbooks.Open(filename, 
		                              Missing.Value, Missing.Value, Missing.Value,
		                              Missing.Value, Missing.Value, Missing.Value, Missing.Value,
		                              Missing.Value, Missing.Value, Missing.Value, Missing.Value,
		                              Missing.Value, Missing.Value, Missing.Value);
    		
		    sheet = (Worksheet) book.Worksheets[1];
		    
		    range = sheet.get_Range("A1", Missing.Value);
		    range = range.get_End(XlDirection.xlToRight);
		    range = range.get_End(XlDirection.xlDown);
		    
		    string downAddress = range.get_Address(false, false, XlReferenceStyle.xlA1, Type.Missing, Type.Missing);
		    
		    range = sheet.get_Range("A1", downAddress);
		    
		    
		    object[,] values = (object[,]) range.Value2;
		    
		    if (values != null)
		    {
		    	StreamWriter sw = new StreamWriter(filename.Replace(".xls", ".csv"), true);

		    	for (int i = 1; i <= values.GetLength(0); i++) 
		    	{
		        	for (int j = 1; j <= values.GetLength(1); j++) 
		        	{
		        		string strValue = "";
		        		
		        		if (values[i, j] != null)
		        		{
			        		strValue = values[i, j].ToString().Trim();
			        		strValue = strValue.ToLower();
			        		strValue = strValue.Replace(';', ' ');
			        		strValue = strValue.Replace('"', ' ');
			        		strValue = strValue.Replace('é', 'e');
			        		strValue = strValue.Replace('è', 'e');
			        		strValue = strValue.Replace('ë', 'e');
			        		strValue = strValue.Replace('ê', 'e');
			        		strValue = strValue.Replace('à', 'a');
			        		strValue = strValue.Replace('ä', 'a');
			        		strValue = strValue.Replace('â', 'a');
			        		strValue = strValue.Replace('ü', 'u');
			        		strValue = strValue.Replace('ù', 'u');
			        		strValue = strValue.Replace('û', 'u');
			        		strValue = strValue.Replace('ö', 'o');
			        		strValue = strValue.Replace('ô', 'o');
			        		strValue = strValue.Replace('°', 'o');
			        		strValue = strValue.Replace('î', 'i');
			        		strValue = strValue.Replace('ï', 'i');
			        		strValue = strValue.ToUpper();
		        		}
		        		
		        		if (j == values.GetLength(1))
		        		{
		        			sw.Write("{0}", strValue);
		        		}
		        		else
		        		{
		            		sw.Write("{0}", strValue + ";");
		        		}
		       	 	}
		    		
		        	sw.WriteLine();
			    }
		    	
		    	sw.Close();
		    }
		    
		    values = null;
		    range.Clear();
		    app.Quit();
		}
		
		void ButtonOpenItemFileClick(object sender, EventArgs e)
		{
			openFileDialogItem = new OpenFileDialog();
			openFileDialogItem.Multiselect = false;
			openFileDialogItem.Filter = "CSV files|*.csv";
			
			if (textBoxItemFile.Text != "")
			{
				openFileDialogItem.FileName = textBoxItemFile.Text;
			}
			
			if (openFileDialogItem.ShowDialog() == DialogResult.OK)
			{
				textBoxItemFile.Text = openFileDialogItem.FileName;
			}
			
			UpdateItem();
		}
		
		void ButtonOpenItemSiteCellProdLineFileClick(object sender, EventArgs e)
		{
			openFileDialogItem = new OpenFileDialog();
			openFileDialogItem.Multiselect = false;
			openFileDialogItem.Filter = "CSV files|*.csv";
			
			if (textBoxItemSiteCellProdLineFile.Text != "")
			{
				openFileDialogItem.FileName = textBoxItemSiteCellProdLineFile.Text;
			}
			
			if (openFileDialogItem.ShowDialog() == DialogResult.OK)
			{
				textBoxItemSiteCellProdLineFile.Text = openFileDialogItem.FileName;
			}
			
			UpdateItem();
		}
		
		void ButtonOpenItemProdLineFileClick(object sender, EventArgs e)
		{
			openFileDialogItem = new OpenFileDialog();
			openFileDialogItem.Multiselect = false;
			openFileDialogItem.Filter = "CSV files (*.csv)|*.csv";
			
			if (textBoxItemProdLineFile.Text != "")
			{
				openFileDialogItem.FileName = textBoxItemProdLineFile.Text;
			}
			
			if (openFileDialogItem.ShowDialog() == DialogResult.OK)
			{
				textBoxItemProdLineFile.Text = openFileDialogItem.FileName;
			}
			
			UpdateItem();
		}		
				
		void ButtonOpenItemLeaderFileClick(object sender, EventArgs e)
		{
			openFileDialogItem = new OpenFileDialog();
			openFileDialogItem.Multiselect = false;
			openFileDialogItem.Filter = "CSV files (*.csv)|*.csv";
			
			if (textBoxItemLeaderFile.Text != "")
			{
				openFileDialogItem.FileName = textBoxItemLeaderFile.Text;
			}
			
			if (openFileDialogItem.ShowDialog() == DialogResult.OK)
			{
				textBoxItemLeaderFile.Text = openFileDialogItem.FileName;
			}
			
			UpdateItem();
		}
		
		void ButtonOpenItemRawFileClick(object sender, EventArgs e)
		{
			openFileDialogItem = new OpenFileDialog();
			openFileDialogItem.Multiselect = false;
			openFileDialogItem.Filter = "CSV files (*.csv)|*.csv";
			
			if (textBoxItemRawFile.Text != "")
			{
				openFileDialogItem.FileName = textBoxItemRawFile.Text;
			}
			
			if (openFileDialogItem.ShowDialog() == DialogResult.OK)
			{
				textBoxItemRawFile.Text = openFileDialogItem.FileName;
			}
			
			UpdateItem();
		}
		
		void ButtonOpenItemV9FileClick(object sender, EventArgs e)
		{
			openFileDialogItem = new OpenFileDialog();
			openFileDialogItem.Multiselect = false;
			openFileDialogItem.Filter = "CSV files (*.csv)|*.csv";
			
			if (textBoxItemV9File.Text != "")
			{
				openFileDialogItem.FileName = textBoxItemV9File.Text;
			}
			
			if (openFileDialogItem.ShowDialog() == DialogResult.OK)
			{
				textBoxItemV9File.Text = openFileDialogItem.FileName;
			}
			
			UpdateItem();
		}
		
		void ButtonOpenItemV9ProdLineFileClick(object sender, EventArgs e)
		{
			openFileDialogItem = new OpenFileDialog();
			openFileDialogItem.Multiselect = false;
			openFileDialogItem.Filter = "CSV files (*.csv)|*.csv";
			
			if (textBoxItemV9ProdLineFile.Text != "")
			{
				openFileDialogItem.FileName = textBoxItemV9ProdLineFile.Text;
			}
			
			if (openFileDialogItem.ShowDialog() == DialogResult.OK)
			{
				textBoxItemV9ProdLineFile.Text = openFileDialogItem.FileName;
			}
			
			UpdateItem();
		}
		
		void ButtonOpenItemV9LastProdLineFileClick(object sender, EventArgs e)
		{
			openFileDialogItem = new OpenFileDialog();
			openFileDialogItem.Multiselect = false;
			openFileDialogItem.Filter = "CSV files (*.csv)|*.csv";
			
			if (textBoxItemV9LastProdLineFile.Text != "")
			{
				openFileDialogItem.FileName = textBoxItemV9LastProdLineFile.Text;
			}
			
			if (openFileDialogItem.ShowDialog() == DialogResult.OK)
			{
				textBoxItemV9LastProdLineFile.Text = openFileDialogItem.FileName;
			}
			
			UpdateItem();
		}
		
		void ButtonOpenItemAnalysisCodeFileClick(object sender, EventArgs e)
		{
			openFileDialogItem = new OpenFileDialog();
			openFileDialogItem.Multiselect = false;
			openFileDialogItem.Filter = "CSV files (*.csv)|*.csv";
			
			if (textBoxItemAnalysisCodeFile.Text != "")
			{
				openFileDialogItem.FileName = textBoxItemAnalysisCodeFile.Text;
			}
			
			if (openFileDialogItem.ShowDialog() == DialogResult.OK)
			{
				textBoxItemAnalysisCodeFile.Text = openFileDialogItem.FileName;
			}
			
			UpdateItem();
		}
		
		void ButtonOpenItemIntrastatFileClick(object sender, EventArgs e)
		{
			openFileDialogItem = new OpenFileDialog();
			openFileDialogItem.Multiselect = false;
			openFileDialogItem.Filter = "CSV files (*.csv)|*.csv";
			
			if (textBoxItemIntrastatFile.Text != "")
			{
				openFileDialogItem.FileName = textBoxItemIntrastatFile.Text;
			}
			
			if (openFileDialogItem.ShowDialog() == DialogResult.OK)
			{
				textBoxItemIntrastatFile.Text = openFileDialogItem.FileName;
			}
			
			UpdateItem();
		}
		
		void ButtonOpenItemDSRPFileClick(object sender, EventArgs e)
		{
			openFileDialogItem = new OpenFileDialog();
			openFileDialogItem.Multiselect = false;
			openFileDialogItem.Filter = "CSV files (*.csv)|*.csv";
			
			if (textBoxItemDSRPFile.Text != "")
			{
				openFileDialogItem.FileName = textBoxItemDSRPFile.Text;
			}
			
			if (openFileDialogItem.ShowDialog() == DialogResult.OK)
			{
				textBoxItemDSRPFile.Text = openFileDialogItem.FileName;
			}
			
			UpdateItem();
		}
		
		void ButtonOpenItemGeneralParamsFileClick(object sender, EventArgs e)
		{
			openFileDialogItem = new OpenFileDialog();
			openFileDialogItem.Multiselect = false;
			openFileDialogItem.Filter = "CSV files (*.csv)|*.csv";
			
			if (textBoxItemGeneralParamsFile.Text != "")
			{
				openFileDialogItem.FileName = textBoxItemGeneralParamsFile.Text;
			}
			
			if (openFileDialogItem.ShowDialog() == DialogResult.OK)
			{
				textBoxItemGeneralParamsFile.Text = openFileDialogItem.FileName;
			}
			
			UpdateItem();
		}
		
		void ButtonItemClick(object sender, EventArgs e)
		{
			buttonOpenItemFile.Enabled = false;
			buttonOpenItemSiteCellProdLineFile.Enabled = false;
			buttonOpenItemProdLineFile.Enabled = false;
			buttonOpenItemLeaderFile.Enabled = false;
			buttonOpenItemAnalysisCodeFile.Enabled = false;
			buttonOpenItemAnalysisCodeBrandFile.Enabled = false;
			buttonOpenItemIntrastatCodeFile.Enabled = false;
			buttonOpenItemIntrastatFile.Enabled = false;
			buttonOpenItemRawFile.Enabled = false;
			buttonOpenItemCostFile.Enabled = false;
			buttonOpenItemV9File.Enabled = false;
			buttonOpenItemV9ProdLineFile.Enabled = false;
			buttonOpenItemV9LastProdLineFile.Enabled = false;
			buttonOpenItemV9CostFile.Enabled = false;
			buttonOpenItemDSRPFile.Enabled = false;
			buttonOpenItemGeneralParamsFile.Enabled = false;
			buttonItem.Enabled = false;
			
			System.Data.DataTable itemFile = Build.GetDataTableFromCsvFile(textBoxItemFile.Text);
			System.Data.DataTable itemSiteCellProdLineFile = Build.GetDataTableFromCsvFile(textBoxItemSiteCellProdLineFile.Text);
			System.Data.DataTable itemProdLineFile = Build.GetDataTableFromCsvFile(textBoxItemProdLineFile.Text);
			System.Data.DataTable itemLeaderFile = Build.GetDataTableFromCsvFile(textBoxItemLeaderFile.Text);
			System.Data.DataTable itemAnalysisCodeFile = Build.GetDataTableFromCsvFile(textBoxItemAnalysisCodeFile.Text);
			System.Data.DataTable itemAnalysisCodeBrandFile = Build.GetDataTableFromCsvFile(textBoxItemAnalysisCodeBrandFile.Text);
			System.Data.DataTable itemIntrastatCodeFile = Build.GetDataTableFromCsvFile(textBoxItemIntrastatCodeFile.Text);
			System.Data.DataTable itemIntrastatFile = Build.GetDataTableFromCsvFile(textBoxItemIntrastatFile.Text);
			System.Data.DataTable itemRawFile = Build.GetDataTableFromCsvFile(textBoxItemRawFile.Text);
			System.Data.DataTable itemCostFile = Build.GetDataTableFromCsvFile(textBoxItemCostFile.Text);
			System.Data.DataTable itemV9File = Build.GetDataTableFromCsvFile(textBoxItemV9File.Text);
			System.Data.DataTable itemV9ProdLineFile = Build.GetDataTableFromCsvFile(textBoxItemV9ProdLineFile.Text);
			System.Data.DataTable itemV9LastProdLineFile = Build.GetDataTableFromCsvFile(textBoxItemV9LastProdLineFile.Text);
			System.Data.DataTable itemV9CostFile = Build.GetDataTableFromCsvFile(textBoxItemV9CostFile.Text);
			System.Data.DataTable itemDSRPFile = Build.GetDataTableFromCsvFile(textBoxItemDSRPFile.Text);
			System.Data.DataTable itemGeneralParamsFile = Build.GetDataTableFromCsvFile(textBoxItemGeneralParamsFile.Text);
			
			System.Data.DataTable itemTable = Build.Write141_Items(itemFile, 
					                                               itemSiteCellProdLineFile,
					                                               itemProdLineFile,
												                   itemLeaderFile, 
												                   itemRawFile,
												                   itemV9File,
												                   itemV9ProdLineFile, 
												                   itemV9LastProdLineFile,
												                   itemDSRPFile);
			if (itemTable != null)
			{
				Build.Write36213_Items(itemGeneralParamsFile, itemTable);
			}
			
			if (itemTable != null)
			{
				Build.Write1415_Items(itemRawFile, itemV9CostFile, itemTable);
			}
			
			Build.Write29223_Items(itemIntrastatCodeFile);
			
			if (itemTable != null)
			{
				Build.Write29226_Items(itemIntrastatFile, itemTable);
			}
			
			Build.WriteAnalysisCode_Items(itemAnalysisCodeFile, itemAnalysisCodeBrandFile, itemTable);
			
			buttonOpenItemFile.Enabled = true;
			buttonOpenItemSiteCellProdLineFile.Enabled = true;
			buttonOpenItemProdLineFile.Enabled = true;
			buttonOpenItemLeaderFile.Enabled = true;
			buttonOpenItemAnalysisCodeFile.Enabled = true;
			buttonOpenItemAnalysisCodeBrandFile.Enabled = true;
			buttonOpenItemIntrastatCodeFile.Enabled = true;
			buttonOpenItemIntrastatFile.Enabled = true;
			buttonOpenItemRawFile.Enabled = true;
			buttonOpenItemCostFile.Enabled = true;
			buttonOpenItemV9File.Enabled = true;
			buttonOpenItemV9ProdLineFile.Enabled = true;
			buttonOpenItemV9LastProdLineFile.Enabled = true;
			buttonOpenItemV9CostFile.Enabled = true;
			buttonOpenItemDSRPFile.Enabled = true;
			buttonOpenItemGeneralParamsFile.Enabled = true;
			buttonItem.Enabled = true;
		}
		
		void ButtonOpenCustomerBusinessRelationFileClick(object sender, EventArgs e)
		{
			openFileDialogItem = new OpenFileDialog();
			openFileDialogItem.Multiselect = false;
			openFileDialogItem.Filter = "CSV files (*.csv)|*.csv";
			
			if (textBoxCustomerBusinessRelationFile.Text != "")
			{
				openFileDialogItem.FileName = textBoxCustomerBusinessRelationFile.Text;
			}
			
			if (openFileDialogItem.ShowDialog() == DialogResult.OK)
			{
				textBoxCustomerBusinessRelationFile.Text = openFileDialogItem.FileName;
			}
			
			UpdateCustomer();
		}
		
		void ButtonOpenCustomerFinancialFileClick(object sender, EventArgs e)
		{
			openFileDialogItem = new OpenFileDialog();
			openFileDialogItem.Multiselect = false;
			openFileDialogItem.Filter = "CSV files (*.csv)|*.csv";
			
			if (textBoxCustomerFinancialFile.Text != "")
			{
				openFileDialogItem.FileName = textBoxCustomerFinancialFile.Text;
			}
			
			if (openFileDialogItem.ShowDialog() == DialogResult.OK)
			{
				textBoxCustomerFinancialFile.Text = openFileDialogItem.FileName;
			}
			
			UpdateCustomer();
		}
		
		void ButtonOpenCustomerFileClick(object sender, EventArgs e)
		{
			openFileDialogItem = new OpenFileDialog();
			openFileDialogItem.Multiselect = false;
			openFileDialogItem.Filter = "CSV files (*.csv)|*.csv";
			
			if (textBoxCustomerFile.Text != "")
			{
				openFileDialogItem.FileName = textBoxCustomerFile.Text;
			}
			
			if (openFileDialogItem.ShowDialog() == DialogResult.OK)
			{
				textBoxCustomerFile.Text = openFileDialogItem.FileName;
			}
			
			UpdateCustomer();
		}
		
		void ButtonOpenCustomerDeliveryFileClick(object sender, EventArgs e)
		{
			openFileDialogItem = new OpenFileDialog();
			openFileDialogItem.Multiselect = false;
			openFileDialogItem.Filter = "CSV files (*.csv)|*.csv";
			
			if (textBoxCustomerDeliveryFile.Text != "")
			{
				openFileDialogItem.FileName = textBoxCustomerDeliveryFile.Text;
			}
			
			if (openFileDialogItem.ShowDialog() == DialogResult.OK)
			{
				textBoxCustomerDeliveryFile.Text = openFileDialogItem.FileName;
			}
			
			UpdateCustomer();
		}
		
		void ButtonOpenCustomerTreeFileClick(object sender, EventArgs e)
		{
			openFileDialogItem = new OpenFileDialog();
			openFileDialogItem.Multiselect = false;
			openFileDialogItem.Filter = "CSV files (*.csv)|*.csv";
			
			if (textBoxCustomerTreeFile.Text != "")
			{
				openFileDialogItem.FileName = textBoxCustomerTreeFile.Text;
			}
			
			if (openFileDialogItem.ShowDialog() == DialogResult.OK)
			{
				textBoxCustomerTreeFile.Text = openFileDialogItem.FileName;
			}
			
			UpdateCustomer();
		}
			
		void ButtonOpenCustomerItemFileClick(object sender, EventArgs e)
		{
			openFileDialogItem = new OpenFileDialog();
			openFileDialogItem.Multiselect = false;
			openFileDialogItem.Filter = "CSV files (*.csv)|*.csv";
			
			if (textBoxCustomerItemFile.Text != "")
			{
				openFileDialogItem.FileName = textBoxCustomerItemFile.Text;
			}
			
			if (openFileDialogItem.ShowDialog() == DialogResult.OK)
			{
				textBoxCustomerItemFile.Text = openFileDialogItem.FileName;
			}
			
			UpdateCustomer();
		}	
		
		void ButtonCustomerClick(object sender, EventArgs e)
		{
			buttonOpenCustomerBusinessRelationFile.Enabled = false;
			buttonOpenCustomerFinancialFile.Enabled = false;
			buttonOpenCustomerFile.Enabled = false;
			buttonOpenCustomerDeliveryFile.Enabled = false;
			buttonOpenCustomerTreeFile.Enabled = false;
			buttonOpenCustomerItemFile.Enabled = false;
			buttonOpenCustomerGeneralParamsFile.Enabled = false;
			buttonCustomer.Enabled = false;
			
			System.Data.DataTable customerBusinessRelationFile = Build.GetDataTableFromCsvFile(textBoxCustomerBusinessRelationFile.Text);
			System.Data.DataTable customerFinancialFile = Build.GetDataTableFromCsvFile(textBoxCustomerFinancialFile.Text);
			System.Data.DataTable customerFile = Build.GetDataTableFromCsvFile(textBoxCustomerFile.Text);
			System.Data.DataTable customerDeliveryFile = Build.GetDataTableFromCsvFile(textBoxCustomerDeliveryFile.Text);
			System.Data.DataTable customerTreeFile = Build.GetDataTableFromCsvFile(textBoxCustomerTreeFile.Text);
			System.Data.DataTable customerItemFile = Build.GetDataTableFromCsvFile(textBoxCustomerItemFile.Text);
			System.Data.DataTable customerGeneralParamsFile = Build.GetDataTableFromCsvFile(textBoxCustomerGeneralParamsFile.Text);
			
			System.Data.DataTable businessRelationTable = Build.Write361431_Customers(customerBusinessRelationFile);
			System.Data.DataTable customerFinancialTable = Build.Write272011_Customers(customerFinancialFile);
			System.Data.DataTable customerTable = Build.Write211_Customers(customerFile);
			System.Data.DataTable customerDeliveryTable = Build.Write272021_Customers(customerDeliveryFile);
			System.Data.DataTable customerTreeTable = Build.Write181_Customers(customerTreeFile);
			System.Data.DataTable customerItemTable = Build.Write115_Customers(customerItemFile);
			System.Data.DataTable customerGeneralParamsTable = Build.Write36213_Customers(customerGeneralParamsFile, customerTable);
			
			
			buttonOpenCustomerBusinessRelationFile.Enabled = true;
			buttonOpenCustomerFinancialFile.Enabled = true;
			buttonOpenCustomerFile.Enabled = true;
			buttonOpenCustomerDeliveryFile.Enabled = true;
			buttonOpenCustomerTreeFile.Enabled = true;
			buttonOpenCustomerItemFile.Enabled = true;
			buttonOpenCustomerGeneralParamsFile.Enabled = true;
			buttonCustomer.Enabled = true;
		}
			
		void ButtonOpenSupplierBusinessRelationFileClick(object sender, EventArgs e)
		{
			openFileDialogItem = new OpenFileDialog();
			openFileDialogItem.Multiselect = false;
			openFileDialogItem.Filter = "CSV files (*.csv)|*.csv";
			
			if (textBoxSupplierBusinessRelationFile.Text != "")
			{
				openFileDialogItem.FileName = textBoxSupplierBusinessRelationFile.Text;
			}
			
			if (openFileDialogItem.ShowDialog() == DialogResult.OK)
			{
				textBoxSupplierBusinessRelationFile.Text = openFileDialogItem.FileName;
			}
			
			UpdateSupplier();
		}
		
		void ButtonOpenSupplierFinancialFileClick(object sender, EventArgs e)
		{
			openFileDialogItem = new OpenFileDialog();
			openFileDialogItem.Multiselect = false;
			openFileDialogItem.Filter = "CSV files (*.csv)|*.csv";
			
			if (textBoxSupplierFinancialFile.Text != "")
			{
				openFileDialogItem.FileName = textBoxSupplierFinancialFile.Text;
			}
			
			if (openFileDialogItem.ShowDialog() == DialogResult.OK)
			{
				textBoxSupplierFinancialFile.Text = openFileDialogItem.FileName;
			}
			
			UpdateSupplier();
		}
		
		void ButtonOpenSupplierFileClick(object sender, EventArgs e)
		{
			openFileDialogItem = new OpenFileDialog();
			openFileDialogItem.Multiselect = false;
			openFileDialogItem.Filter = "CSV files (*.csv)|*.csv";
			
			if (textBoxSupplierFile.Text != "")
			{
				openFileDialogItem.FileName = textBoxSupplierFile.Text;
			}
			
			if (openFileDialogItem.ShowDialog() == DialogResult.OK)
			{
				textBoxSupplierFile.Text = openFileDialogItem.FileName;
			}
			
			UpdateSupplier();
		}
					
		void ButtonOpenSupplierV9FileClick(object sender, EventArgs e)
		{
			openFileDialogItem = new OpenFileDialog();
			openFileDialogItem.Multiselect = false;
			openFileDialogItem.Filter = "CSV files (*.csv)|*.csv";
			
			if (textBoxSupplierV9File.Text != "")
			{
				openFileDialogItem.FileName = textBoxSupplierV9File.Text;
			}
			
			if (openFileDialogItem.ShowDialog() == DialogResult.OK)
			{
				textBoxSupplierV9File.Text = openFileDialogItem.FileName;
			}
			
			UpdateSupplier();
		}
		
		void ButtonSupplierClick(object sender, EventArgs e)
		{
			buttonOpenSupplierBusinessRelationFile.Enabled = false;
			buttonOpenSupplierFinancialFile.Enabled = false;
			buttonOpenSupplierFile.Enabled = false;
			buttonOpenSupplierItemFile.Enabled = false;
			buttonOpenSupplierV9File.Enabled = false;
			buttonOpenSupplierV9ItemFile.Enabled = false;
			buttonOpenSupplierGeneralParamsFile.Enabled = false;
			buttonSupplier.Enabled = false;
			
			System.Data.DataTable businessRelationFile = Build.GetDataTableFromCsvFile(textBoxSupplierBusinessRelationFile.Text);
			System.Data.DataTable supplierFinancialFile = Build.GetDataTableFromCsvFile(textBoxSupplierFinancialFile.Text);
			System.Data.DataTable supplierFile = Build.GetDataTableFromCsvFile(textBoxSupplierFile.Text);
			System.Data.DataTable supplierItemFile = Build.GetDataTableFromCsvFile(textBoxSupplierItemFile.Text);
			System.Data.DataTable supplierV9File = Build.GetDataTableFromCsvFile(textBoxSupplierV9File.Text);
			System.Data.DataTable supplierV9ItemFile = Build.GetDataTableFromCsvFile(textBoxSupplierV9ItemFile.Text);
			System.Data.DataTable supplierGeneralParamsFile = Build.GetDataTableFromCsvFile(textBoxSupplierGeneralParamsFile.Text);
			
			System.Data.DataTable businessRelationTable = Build.Write361431_Suppliers(businessRelationFile);
			System.Data.DataTable supplierFinancialTable = Build.Write282011_Suppliers(supplierFinancialFile);
			
			/* TEMPORAIRE */
			System.Data.DataTable supplierTable = Build.Write231_Suppliers(supplierFinancialFile, null);
			/* FIN */
			
			System.Data.DataTable supplierGeneralParamsTable = Build.Write36213_Suppliers(supplierGeneralParamsFile, supplierFile, supplierV9File);
			
			buttonOpenSupplierBusinessRelationFile.Enabled = true;
			buttonOpenSupplierFinancialFile.Enabled = true;
			buttonOpenSupplierFile.Enabled = true;
			buttonOpenSupplierItemFile.Enabled = true;
			buttonOpenSupplierV9File.Enabled = true;
			buttonOpenSupplierV9ItemFile.Enabled = true;
			buttonOpenSupplierGeneralParamsFile.Enabled = true;
			buttonSupplier.Enabled = true;
		}
		
		void ButtonQuitClick(object sender, System.EventArgs e)
		{
			try
            {
                XmlDocument config = new XmlDocument();			
			
                config.LoadXml("<?xml version=\"1.0\"?>" +
                               "<config>" +
                                "<directories>" +
                                    "<directory name=\"xls_folder\" value=\"" + textBoxXlsFolder.Text + "\" />" +
                               "</directories>" + 
                                "<files>" +
                                	"<file name=\"item_file\" value=\"" + textBoxItemFile.Text + "\" />" +
                                	"<file name=\"item_site_cell_prod_line_file\" value=\"" + textBoxItemSiteCellProdLineFile.Text + "\" />" +
                                	"<file name=\"item_prod_line_file\" value=\"" + textBoxItemProdLineFile.Text + "\" />" +
                                	"<file name=\"item_leader_file\" value=\"" + textBoxItemLeaderFile.Text + "\" />" +
                                	"<file name=\"item_analysis_code_file\" value=\"" + textBoxItemAnalysisCodeFile.Text + "\" />" +
                                	"<file name=\"item_analysis_code_brand_file\" value=\"" + textBoxItemAnalysisCodeBrandFile.Text + "\" />" +
                                	"<file name=\"item_intrastat_code_file\" value=\"" + textBoxItemIntrastatCodeFile.Text + "\" />" +
                                	"<file name=\"item_intrastat_file\" value=\"" + textBoxItemIntrastatFile.Text + "\" />" +
                                	"<file name=\"item_raw_file\" value=\"" + textBoxItemRawFile.Text + "\" />" +
                                	"<file name=\"item_dsrp_file\" value=\"" + textBoxItemDSRPFile.Text + "\" />" +
                                	"<file name=\"item_cost_file\" value=\"" + textBoxItemCostFile.Text + "\" />" +
                                	"<file name=\"item_v9_file\" value=\"" + textBoxItemV9File.Text + "\" />" +
                                	"<file name=\"item_v9_prod_line_file\" value=\"" + textBoxItemV9ProdLineFile.Text + "\" />" +
                                	"<file name=\"item_v9_last_prod_line_file\" value=\"" + textBoxItemV9LastProdLineFile.Text + "\" />" +
                                	"<file name=\"item_v9_cost_file\" value=\"" + textBoxItemV9CostFile.Text + "\" />" +
                                	"<file name=\"item_general_params_file\" value=\"" + textBoxItemGeneralParamsFile.Text + "\" />" +
                                	"<file name=\"customer_business_relation_file\" value=\"" + textBoxCustomerBusinessRelationFile.Text + "\" />" +
                                	"<file name=\"customer_financial_file\" value=\"" + textBoxCustomerFinancialFile.Text + "\" />" +
                                	"<file name=\"customer_file\" value=\"" + textBoxCustomerFile.Text + "\" />" +
                                	"<file name=\"customer_delivery_file\" value=\"" + textBoxCustomerDeliveryFile.Text + "\" />" +
                                	"<file name=\"customer_tree_file\" value=\"" + textBoxCustomerTreeFile.Text + "\" />" +
                                	"<file name=\"customer_item_file\" value=\"" + textBoxCustomerItemFile.Text + "\" />" +
                                	"<file name=\"customer_general_params_file\" value=\"" + textBoxCustomerGeneralParamsFile.Text + "\" />" +
                                	"<file name=\"supplier_business_relation_file\" value=\"" + textBoxSupplierBusinessRelationFile.Text + "\" />" +
                                	"<file name=\"supplier_financial_file\" value=\"" + textBoxSupplierFinancialFile.Text + "\" />" +
                                	"<file name=\"supplier_file\" value=\"" + textBoxSupplierFile.Text + "\" />" +
                                	"<file name=\"supplier_item_file\" value=\"" + textBoxSupplierItemFile.Text + "\" />" +
                                	"<file name=\"supplier_v9_file\" value=\"" + textBoxSupplierV9File.Text + "\" />" +
                                	"<file name=\"supplier_v9_item_file\" value=\"" + textBoxSupplierV9ItemFile.Text + "\" />" +
                                	"<file name=\"supplier_general_params_file\" value=\"" + textBoxSupplierGeneralParamsFile.Text + "\" />" +
                                	"<file name=\"routing_file\" value=\"" + textBoxRoutingFile.Text + "\" />" +
                                	"<file name=\"routing_v9_file\" value=\"" + textBoxRoutingV9File.Text + "\" />" +
                                	"<file name=\"prod_struct_file\" value=\"" + textBoxProdStructFile.Text + "\" />" +
                                	"<file name=\"prod_struct_v9_file\" value=\"" + textBoxProdStructV9File.Text + "\" />" +
                                	"<file name=\"prod_struct_code_file\" value=\"" + textBoxProdStructCodeFile.Text + "\" />" +
                                	"<file name=\"prod_struct_code_v9_file\" value=\"" + textBoxProdStructCodeV9File.Text + "\" />" +
                                	"<file name=\"work_center_file\" value=\"" + textBoxWorkCenterFile.Text + "\" />" +
                                	"<file name=\"work_center_v9_file\" value=\"" + textBoxWorkCenterV9File.Text + "\" />" +
                                	"<file name=\"production_line_file\" value=\"" + textBoxProductionLineFile.Text + "\" />" +
                                "</files>" + 
                               "</config>");

                config.Save(System.Windows.Forms.Application.StartupPath + "\\" + CONFIG_FILENAME);
            }
            catch (Exception)
            {
            	
            }
            
            this.Close();
            System.Windows.Forms.Application.Exit();
		}
		
		void ButtonOpenRoutingFileClick(object sender, EventArgs e)
		{
			openFileDialogItem = new OpenFileDialog();
			openFileDialogItem.Multiselect = false;
			openFileDialogItem.Filter = "CSV files (*.csv)|*.csv";
			
			if (textBoxRoutingFile.Text != "")
			{
				openFileDialogItem.FileName = textBoxRoutingFile.Text;
			}
			
			if (openFileDialogItem.ShowDialog() == DialogResult.OK)
			{
				textBoxRoutingFile.Text = openFileDialogItem.FileName;
			}
			
			UpdateRouting();
		}
		
		void ButtonOpenRoutingV9FileClick(object sender, EventArgs e)
		{
			openFileDialogItem = new OpenFileDialog();
			openFileDialogItem.Multiselect = false;
			openFileDialogItem.Filter = "CSV files (*.csv)|*.csv";
			
			if (textBoxRoutingV9File.Text != "")
			{
				openFileDialogItem.FileName = textBoxRoutingV9File.Text;
			}
			
			if (openFileDialogItem.ShowDialog() == DialogResult.OK)
			{
				textBoxRoutingV9File.Text = openFileDialogItem.FileName;
			}
			
			UpdateRouting();
		}
		
		void ButtonRoutingClick(object sender, EventArgs e)
		{
			buttonOpenRoutingFile.Enabled = false;
			buttonOpenRoutingV9File.Enabled = false;
			buttonRouting.Enabled = false;
			
			System.Data.DataTable routingFile = Build.GetDataTableFromCsvFile(textBoxRoutingFile.Text);
			System.Data.DataTable routingV9File = Build.GetDataTableFromCsvFile(textBoxRoutingV9File.Text);
			
			System.Data.DataTable routingTable = Build.Write14131_Routing(routingFile, routingV9File);
			
			buttonOpenRoutingFile.Enabled = true;
			buttonOpenRoutingV9File.Enabled = true;
			buttonRouting.Enabled = true;
		}
		
		void ButtonOpenCustomerGeneralParamsFileClick(object sender, EventArgs e)
		{
			openFileDialogItem = new OpenFileDialog();
			openFileDialogItem.Multiselect = false;
			openFileDialogItem.Filter = "CSV files (*.csv)|*.csv";
			
			if (textBoxCustomerGeneralParamsFile.Text != "")
			{
				openFileDialogItem.FileName = textBoxCustomerGeneralParamsFile.Text;
			}
			
			if (openFileDialogItem.ShowDialog() == DialogResult.OK)
			{
				textBoxCustomerGeneralParamsFile.Text = openFileDialogItem.FileName;
			}
			
			UpdateCustomer();
		}
		
		void ButtonOpenSupplierGeneralParamsFileClick(object sender, EventArgs e)
		{
			openFileDialogItem = new OpenFileDialog();
			openFileDialogItem.Multiselect = false;
			openFileDialogItem.Filter = "CSV files (*.csv)|*.csv";
			
			if (textBoxSupplierGeneralParamsFile.Text != "")
			{
				openFileDialogItem.FileName = textBoxSupplierGeneralParamsFile.Text;
			}
			
			if (openFileDialogItem.ShowDialog() == DialogResult.OK)
			{
				textBoxSupplierGeneralParamsFile.Text = openFileDialogItem.FileName;
			}
			
			UpdateSupplier();
		}
		
		void ButtonProdStructClick(object sender, EventArgs e)
		{
			buttonOpenProdStructCodeFile.Enabled = false;
			buttonOpenProdStructFile.Enabled = false;
			buttonOpenProdStructCodeV9File.Enabled = false;
			buttonOpenProdStructV9File.Enabled = false;
			buttonProdStruct.Enabled = false;
			
			System.Data.DataTable prodStructCodeFile = Build.GetDataTableFromCsvFile(textBoxProdStructCodeFile.Text);
			System.Data.DataTable prodStructCodeV9File = Build.GetDataTableFromCsvFile(textBoxProdStructCodeV9File.Text);
			System.Data.DataTable prodStructFile = Build.GetDataTableFromCsvFile(textBoxProdStructFile.Text);
			System.Data.DataTable prodStructV9File = Build.GetDataTableFromCsvFile(textBoxProdStructV9File.Text);
			
			System.Data.DataTable prodStructCodeTable = Build.Write131_CodeProdStruct(prodStructCodeFile, prodStructCodeV9File, null);
			System.Data.DataTable prodStructTable = Build.Write135_ProdStruct(prodStructFile, prodStructV9File);
			
			buttonOpenProdStructCodeFile.Enabled = true;
			buttonOpenProdStructFile.Enabled = true;
			buttonOpenProdStructCodeV9File.Enabled = true;
			buttonOpenProdStructV9File.Enabled = true;
			buttonProdStruct.Enabled = true;
		}
		
		void ButtonOpenProdStructCodeV9FileClick(object sender, EventArgs e)
		{
			openFileDialogItem = new OpenFileDialog();
			openFileDialogItem.Multiselect = false;
			openFileDialogItem.Filter = "CSV files (*.csv)|*.csv";
			
			if (textBoxProdStructCodeV9File.Text != "")
			{
				openFileDialogItem.FileName = textBoxProdStructCodeV9File.Text;
			}
			
			if (openFileDialogItem.ShowDialog() == DialogResult.OK)
			{
				textBoxProdStructCodeV9File.Text = openFileDialogItem.FileName;
			}
			
			UpdateProdStruct();
		}
		
		void ButtonOpenProdStructCodeFileClick(object sender, EventArgs e)
		{
			openFileDialogItem = new OpenFileDialog();
			openFileDialogItem.Multiselect = false;
			openFileDialogItem.Filter = "CSV files (*.csv)|*.csv";
			
			if (textBoxProdStructCodeFile.Text != "")
			{
				openFileDialogItem.FileName = textBoxProdStructCodeFile.Text;
			}
			
			if (openFileDialogItem.ShowDialog() == DialogResult.OK)
			{
				textBoxProdStructCodeFile.Text = openFileDialogItem.FileName;
			}
			
			UpdateProdStruct();
		}
		
		void ButtonOpenProdStructFileClick(object sender, EventArgs e)
		{
			openFileDialogItem = new OpenFileDialog();
			openFileDialogItem.Multiselect = false;
			openFileDialogItem.Filter = "CSV files (*.csv)|*.csv";
			
			if (textBoxProdStructFile.Text != "")
			{
				openFileDialogItem.FileName = textBoxProdStructFile.Text;
			}
			
			if (openFileDialogItem.ShowDialog() == DialogResult.OK)
			{
				textBoxProdStructFile.Text = openFileDialogItem.FileName;
			}
			
			UpdateProdStruct();
		}
		
		void ButtonOpenProdStructV9FileClick(object sender, EventArgs e)
		{
			openFileDialogItem = new OpenFileDialog();
			openFileDialogItem.Multiselect = false;
			openFileDialogItem.Filter = "CSV files (*.csv)|*.csv";
			
			if (textBoxProdStructV9File.Text != "")
			{
				openFileDialogItem.FileName = textBoxProdStructV9File.Text;
			}
			
			if (openFileDialogItem.ShowDialog() == DialogResult.OK)
			{
				textBoxProdStructV9File.Text = openFileDialogItem.FileName;
			}
			
			UpdateProdStruct();
		}
		
		void ButtonOpenItemCostFileClick(object sender, EventArgs e)
		{
			openFileDialogItem = new OpenFileDialog();
			openFileDialogItem.Multiselect = false;
			openFileDialogItem.Filter = "CSV files (*.csv)|*.csv";
			
			if (textBoxItemCostFile.Text != "")
			{
				openFileDialogItem.FileName = textBoxItemCostFile.Text;
			}
			
			if (openFileDialogItem.ShowDialog() == DialogResult.OK)
			{
				textBoxItemCostFile.Text = openFileDialogItem.FileName;
			}
			
			UpdateItem();
		}
		
		void ButtonOpenItemV9CostFileClick(object sender, EventArgs e)
		{
			openFileDialogItem = new OpenFileDialog();
			openFileDialogItem.Multiselect = false;
			openFileDialogItem.Filter = "CSV files (*.csv)|*.csv";
			
			if (textBoxItemV9CostFile.Text != "")
			{
				openFileDialogItem.FileName = textBoxItemV9CostFile.Text;
			}
			
			if (openFileDialogItem.ShowDialog() == DialogResult.OK)
			{
				textBoxItemV9CostFile.Text = openFileDialogItem.FileName;
			}
			
			UpdateItem();
		}
		
		void ButtonOpenSupplierItemFileClick(object sender, EventArgs e)
		{
			openFileDialogItem = new OpenFileDialog();
			openFileDialogItem.Multiselect = false;
			openFileDialogItem.Filter = "CSV files (*.csv)|*.csv";
			
			if (textBoxSupplierItemFile.Text != "")
			{
				openFileDialogItem.FileName = textBoxSupplierItemFile.Text;
			}
			
			if (openFileDialogItem.ShowDialog() == DialogResult.OK)
			{
				textBoxSupplierItemFile.Text = openFileDialogItem.FileName;
			}
			
			UpdateSupplier();
		}
		
		void ButtonOpenSupplierV9ItemFileClick(object sender, EventArgs e)
		{
			openFileDialogItem = new OpenFileDialog();
			openFileDialogItem.Multiselect = false;
			openFileDialogItem.Filter = "CSV files (*.csv)|*.csv";
			
			if (textBoxSupplierV9ItemFile.Text != "")
			{
				openFileDialogItem.FileName = textBoxSupplierV9ItemFile.Text;
			}
			
			if (openFileDialogItem.ShowDialog() == DialogResult.OK)
			{
				textBoxSupplierV9ItemFile.Text = openFileDialogItem.FileName;
			}
			
			UpdateSupplier();
		}
		
		void ButtonOpenItemIntrastatCodeFileClick(object sender, EventArgs e)
		{
			openFileDialogItem = new OpenFileDialog();
			openFileDialogItem.Multiselect = false;
			openFileDialogItem.Filter = "CSV files (*.csv)|*.csv";
			
			if (textBoxItemIntrastatCodeFile.Text != "")
			{
				openFileDialogItem.FileName = textBoxItemIntrastatCodeFile.Text;
			}
			
			if (openFileDialogItem.ShowDialog() == DialogResult.OK)
			{
				textBoxItemIntrastatCodeFile.Text = openFileDialogItem.FileName;
			}
			
			UpdateItem();
		}
		
		void ButtonOpenItemAnalysisCodeBrandFileClick(object sender, EventArgs e)
		{
			openFileDialogItem = new OpenFileDialog();
			openFileDialogItem.Multiselect = false;
			openFileDialogItem.Filter = "CSV files (*.csv)|*.csv";
			
			if (textBoxItemAnalysisCodeBrandFile.Text != "")
			{
				openFileDialogItem.FileName = textBoxItemAnalysisCodeBrandFile.Text;
			}
			
			if (openFileDialogItem.ShowDialog() == DialogResult.OK)
			{
				textBoxItemAnalysisCodeBrandFile.Text = openFileDialogItem.FileName;
			}
			
			UpdateItem();
		}
		
		void ButtonOpenWorkCenterFileClick(object sender, EventArgs e)
		{
			openFileDialogItem = new OpenFileDialog();
			openFileDialogItem.Multiselect = false;
			openFileDialogItem.Filter = "CSV files (*.csv)|*.csv";
			
			if (textBoxWorkCenterFile.Text != "")
			{
				openFileDialogItem.FileName = textBoxWorkCenterFile.Text;
			}
			
			if (openFileDialogItem.ShowDialog() == DialogResult.OK)
			{
				textBoxWorkCenterFile.Text = openFileDialogItem.FileName;
			}
			
			UpdateWorkCenter();
		}
		
		void ButtonOpenWorkCenterV9FileClick(object sender, EventArgs e)
		{
			openFileDialogItem = new OpenFileDialog();
			openFileDialogItem.Multiselect = false;
			openFileDialogItem.Filter = "CSV files (*.csv)|*.csv";
			
			if (textBoxWorkCenterV9File.Text != "")
			{
				openFileDialogItem.FileName = textBoxWorkCenterV9File.Text;
			}
			
			if (openFileDialogItem.ShowDialog() == DialogResult.OK)
			{
				textBoxWorkCenterV9File.Text = openFileDialogItem.FileName;
			}
			
			UpdateWorkCenter();
		}
		
		void ButtonWorkCenterClick(object sender, EventArgs e)
		{
			buttonOpenWorkCenterFile.Enabled = false;
			buttonOpenWorkCenterV9File.Enabled = false;
			buttonWorkCenter.Enabled = false;
			
			System.Data.DataTable workCenterFile = Build.GetDataTableFromCsvFile(textBoxWorkCenterFile.Text);
			System.Data.DataTable workCenterV9File = Build.GetDataTableFromCsvFile(textBoxWorkCenterV9File.Text);
			
			System.Data.DataTable workCenterTable = Build.Write145_WorkCenter(workCenterFile, workCenterV9File);
			
			buttonOpenWorkCenterFile.Enabled = true;
			buttonOpenWorkCenterV9File.Enabled = true;
			buttonWorkCenter.Enabled = true;
		}
		
		void UpdateWorkCenter()
		{
			if ((textBoxWorkCenterFile.Text != "") &&
			    (textBoxWorkCenterV9File.Text != ""))
			{
				buttonWorkCenter.Enabled = true;
			}
			else
			{
				buttonWorkCenter.Enabled = false;
			}
		}
		
		void ButtonOpenProductionLineFileClick(object sender, EventArgs e)
		{
			openFileDialogItem = new OpenFileDialog();
			openFileDialogItem.Multiselect = false;
			openFileDialogItem.Filter = "CSV files (*.csv)|*.csv";
			
			if (textBoxProductionLineFile.Text != "")
			{
				openFileDialogItem.FileName = textBoxProductionLineFile.Text;
			}
			
			if (openFileDialogItem.ShowDialog() == DialogResult.OK)
			{
				textBoxProductionLineFile.Text = openFileDialogItem.FileName;
			}
			
			UpdateProductionLine();
		}
		
		void UpdateProductionLine()
		{
			if (textBoxProductionLineFile.Text != "")
			{
				buttonProductionLine.Enabled = true;
			}
			else
			{
				buttonProductionLine.Enabled = false;
			}
		}
		
		void ButtonProductionLineClick(object sender, EventArgs e)
		{
			buttonOpenProductionLineFile.Enabled = false;
			buttonProductionLine.Enabled = false;
			
			System.Data.DataTable productionLineFile = Build.GetDataTableFromCsvFile(textBoxProductionLineFile.Text);
			
			System.Data.DataTable productionLineTable = Build.Write182211_ProductionLine(productionLineFile);
			
			buttonOpenProductionLineFile.Enabled = true;
			buttonProductionLine.Enabled = true;
		}
	}
}
