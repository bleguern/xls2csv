/*
 * Created by SharpDevelop.
 * User: benoit le guern
 * Date: 18/07/2008
 * Time: 14:17
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Data;
using System.IO;
using Microsoft.Office.Interop.Excel;
using System.Reflection;	
	
namespace xls2csv
{
	/// <summary>
	/// Description of Build.
	/// </summary>
	public class Build
	{
		public Build()
		{
			
		}
		
		public static string FormatDataToCsv(object str)
		{
			return FormatDataToCsv(str, false);
		}
		
		public static string FormatDataToCsv(object str, bool isNumeric)
		{
			string returnValue = "";
			
			if (str != System.DBNull.Value)
			{
				string srtValue = str.ToString().Trim();
					
				if (!isNumeric)
				{
					if (srtValue.ToLower().Equals("yes") || srtValue.ToLower().Equals("oui") || srtValue.ToLower().Equals("o"))
					{
						returnValue = "yes";
					}
					else if (srtValue.ToLower().Equals("no") || srtValue.ToLower().Equals("non") || srtValue.ToLower().Equals("n"))
					{
						returnValue = "no";
					}
					else {
						returnValue = "\"" + srtValue + "\"";
					}
				}
				else
				{
					try
					{
						returnValue = Convert.ToInt32(srtValue).ToString();
					}
					catch (Exception)
					{
						returnValue = "0";
					}
				}
			}
			else
			{
				returnValue = "-";
			}
			
			return returnValue;
		}
		
		public static string FormatDataToCsv(object str, string type)
		{
			string returnValue = "";
			
			if (str != System.DBNull.Value)
			{
				string srtValue = str.ToString().Trim();
				
				if (type.Equals("double"))
				{
					try
					{
						returnValue = Convert.ToDouble(srtValue).ToString("F9");
						returnValue = returnValue.TrimEnd('0').Replace(',', '.').TrimEnd('.');
					}
					catch (Exception)
					{
						returnValue = "0";
					}
				}
				else if (type.Equals("int"))
				{
					try
					{
						returnValue = Convert.ToInt32(srtValue).ToString();
					}
					catch (Exception)
					{
						returnValue = "0";
					}
				}
				else
				{
					if (srtValue.ToLower().Equals("yes") || srtValue.ToLower().Equals("oui") || srtValue.ToLower().Equals("o"))
					{
						returnValue = "yes";
					}
					else if (srtValue.ToLower().Equals("no") || srtValue.ToLower().Equals("non") || srtValue.ToLower().Equals("n"))
					{
						returnValue = "no";
					}
					else
					{
						returnValue = "\"" + srtValue + "\"";
					}
				}
			}
			else
			{
				returnValue = "-";
			}
			
			return returnValue;
		}

		public static string FormatDataToCsv2(object str)
		{
			return FormatDataToCsv2(str, false);
		}
		
		public static string FormatDataToCsv2(object str, bool isNumeric)
		{
			string returnValue = "";
			
			if (str != System.DBNull.Value)
			{
				string srtValue = str.ToString().Trim();
					
				if (!isNumeric)
				{
					if (srtValue.ToLower().Equals("yes") || srtValue.ToLower().Equals("oui") || srtValue.ToLower().Equals("o"))
					{
						returnValue = "TRUE";
					}
					else if (srtValue.ToLower().Equals("no") || srtValue.ToLower().Equals("non") || srtValue.ToLower().Equals("n"))
					{
						returnValue = "FALSE";
					}
					else {
						returnValue = "\"" + srtValue + "\"";
					}
				}
				else
				{
					try
					{
						returnValue = Convert.ToInt32(srtValue).ToString();
					}
					catch (Exception)
					{
						returnValue = "0";
					}
				}
			}
			else
			{
				returnValue = "-";
			}
			
			return returnValue;
		}

		public static System.Data.DataTable GetDataTableFromCsvFile(string filename)
		{
			System.Data.DataTable table = new System.Data.DataTable();
			
			if (File.Exists(filename))
			{
				DataRow row = null;
				string line = null;
				int i = 0;
				
				StreamReader sr = new StreamReader(filename, true);
			
				while ((line = sr.ReadLine()) != null)
				{
					if (i == 0)
					{
						string [] colunmHeaders = line.Split(';');
						
						for (int j = 0; j < colunmHeaders.Length; j++)
						{
							table.Columns.Add(colunmHeaders[j]);
						}
					}
					else
					{
						string [] rowValues = line.Split(';');
						
						row = table.NewRow();
						
						for (int j = 0; j < rowValues.Length; j++)
						{
							row[j] = rowValues[j];
						}
						
						table.Rows.Add(row);
					}
					
					i++;
				}
				
				sr.Close();
			}
			
			return table;
		}
		
		public static bool WriteCsvFromDataTable(System.Data.DataTable table, string filename)
		{
			if (table != null)
			{
				StreamWriter sw = new StreamWriter(filename, true);
				
				foreach (DataRow row in table.Rows)
				{
					for (int i = 0; i < row.ItemArray.Length; i++)
					{
						if (row[i].GetType() == Type.GetType("System.String"))
						{
							sw.Write(Build.FormatDataToCsv(row[i]));
						}
						else if (row[i].GetType() == Type.GetType("System.Double"))
						{
							sw.Write(Build.FormatDataToCsv(row[i], "double"));
						}
						else
						{
							sw.Write(Build.FormatDataToCsv(row[i], true));
						}
						
						if (i != (row.ItemArray.Length - 1))
						{
							sw.Write(";");
						}
					}
					
					sw.WriteLine();
				}
				
				sw.Close();
			}
			
			return true;
		}
		
		/// <summary>
		/// A SUPPRIMER
		/// </summary>
		/// <param name="table"></param>
		/// <param name="filename"></param>
		/// <returns></returns>
		public static bool WriteXlsFromDataTable(System.Data.DataTable table, string filename)
		{
			Microsoft.Office.Interop.Excel.Application application = new Microsoft.Office.Interop.Excel.Application();
            application.Visible = true;
	        Workbook workbook = (Workbook)application.Workbooks.Add(Missing.Value);
            Worksheet worksheet = (Worksheet)application.ActiveSheet;
           	worksheet.Cells.NumberFormat = "@";
		    
            
            if (table != null)
	        {
		        for (int i = 0; i < table.Columns.Count; i++)
		        {
		        	worksheet.Cells[2, i + 1] = table.Columns[i].ColumnName;
		        }
		        
		        for (int i = 0; i < table.Rows.Count; i++)
		        {
		        	if (i == 0)
		        	{
		        		for (int j = 0; j < table.Columns.Count; j++)
			        	{
			        		worksheet.Cells[1, j + 1] = table.Rows[i][j].ToString();
			        	}
		        	}
		        	else
		        	{
		        		for (int j = 0; j < table.Columns.Count; j++)
			        	{
			        		worksheet.Cells[i + 2, j + 1] = table.Rows[i][j].ToString();
			        	}
		        	}
		        }
	        }
	        
	        
	        return true;
		}
		
		/// <summary>
		/// A METTRE A JOUR
		/// </summary>
		/// <param name="table"></param>
		/// <param name="filename"></param>
		/// <returns></returns>
		public static bool WriteCsvFromDataTable2(System.Data.DataTable table, string filename)
		{
			if (table != null)
			{
				StreamWriter sw = new StreamWriter(filename, true);
				
				if (table != null)
		        {
			        for (int i = 0; i < table.Rows.Count; i++)
			        {
			        	if (i == 0)
			        	{
			        		for (int j = 0; j < table.Columns.Count; j++)
				        	{
			        			sw.Write(Build.FormatDataToCsv2(table.Rows[i][j]));
			        			
			        			if (j != (table.Columns.Count - 1))
								{
									sw.Write(";");
								}
				        	}
			        		
			        		sw.WriteLine();
			        		
			        		for (int j = 0; j < table.Columns.Count; j++)
					        {
					        	sw.Write(Build.FormatDataToCsv2(table.Columns[j].ColumnName));
					        	
					        	if (j != (table.Columns.Count - 1))
								{
									sw.Write(";");
								}
					        }
			        		
			        		sw.WriteLine();
			        	}
			        	else
			        	{
			        		for (int j = 0; j < table.Columns.Count; j++)
				        	{
				        		sw.Write(Build.FormatDataToCsv2(table.Rows[i][j]));
				        		
				        		if (j != (table.Columns.Count - 1))
								{
									sw.Write(";");
								}
				        	}
			        		
			        		sw.WriteLine();
			        	}
			        }
		        }
				
				sw.Close();
			}
			
			return true;
		}
		
		public static System.Data.DataTable Write141_Items(System.Data.DataTable item, 
						                            	   System.Data.DataTable siteCellProdLine, 
								                    	   System.Data.DataTable prodLine, 
								                    	   System.Data.DataTable leader,
								                    	   System.Data.DataTable raw,
								                    	   System.Data.DataTable v9,
								                    	   System.Data.DataTable v9LigneProd,
								                    	   System.Data.DataTable v9LastLigneProd,
								                    	   System.Data.DataTable dsrp)
		{
			System.Data.DataTable itemTable = new System.Data.DataTable();
			DataRow row = null;
			
			#region Format du fichier des articles
			// En tête
			itemTable.Columns.Add("pt_part", Type.GetType("System.String"));
			itemTable.Columns.Add("pt_um", Type.GetType("System.String"));
			itemTable.Columns.Add("pt_desc1", Type.GetType("System.String"));
			itemTable.Columns.Add("pt_desc2", Type.GetType("System.String"));
			
			// Données article
			itemTable.Columns.Add("pt_prod_line", Type.GetType("System.String"));
			itemTable.Columns.Add("pt_added", Type.GetType("System.String"));
			itemTable.Columns.Add("pt_dsgn_grp", Type.GetType("System.String"));
			itemTable.Columns.Add("pt_promo", Type.GetType("System.String"));
			itemTable.Columns.Add("pt_part_type", Type.GetType("System.String"));
			itemTable.Columns.Add("pt_status", Type.GetType("System.String"));
			itemTable.Columns.Add("pt_group", Type.GetType("System.String"));
			itemTable.Columns.Add("pt_draw", Type.GetType("System.String"));
			itemTable.Columns.Add("pt_rev_article", Type.GetType("System.String"));
			itemTable.Columns.Add("pt_drwg_loc", Type.GetType("System.String"));
			itemTable.Columns.Add("pt_drwg_size", Type.GetType("System.String"));
			itemTable.Columns.Add("pt_break_cat", Type.GetType("System.String"));
			
			// Données stock article
			itemTable.Columns.Add("pt_abc", Type.GetType("System.String"));
			itemTable.Columns.Add("pt_lot_ser", Type.GetType("System.String"));
			itemTable.Columns.Add("pt_site", Type.GetType("System.String"));
			itemTable.Columns.Add("pt_loc", Type.GetType("System.String"));
			itemTable.Columns.Add("pt_loc_type", Type.GetType("System.String"));
			itemTable.Columns.Add("pt_auto_lot", Type.GetType("System.String"));
			itemTable.Columns.Add("pt_lot_grp", Type.GetType("System.String"));
			itemTable.Columns.Add("pt_article", Type.GetType("System.String"));
			itemTable.Columns.Add("pt_avg_int", Type.GetType("System.Int32"));
			itemTable.Columns.Add("pt_cyc_int", Type.GetType("System.Int32"));
			itemTable.Columns.Add("pt_shelflife", Type.GetType("System.Int32"));
			itemTable.Columns.Add("pt_sngl_lot", Type.GetType("System.String"));
			itemTable.Columns.Add("pt_critical", Type.GetType("System.String"));
			itemTable.Columns.Add("pt_rctpo_status", Type.GetType("System.String"));
			itemTable.Columns.Add("pt_rctpo_active", Type.GetType("System.String"));
			itemTable.Columns.Add("pt_rctwo_status", Type.GetType("System.String"));
			itemTable.Columns.Add("pt_rctwo_active", Type.GetType("System.String"));
			itemTable.Columns.Add("pt_memo_type", Type.GetType("System.String"));
			
			// Données d'expédition article
			itemTable.Columns.Add("l_comm_code", Type.GetType("System.String"));
			itemTable.Columns.Add("pt_ship_wt", Type.GetType("System.Double"));
			itemTable.Columns.Add("pt_ship_wt_um", Type.GetType("System.String"));
			itemTable.Columns.Add("pt_fr_class", Type.GetType("System.String"));
			itemTable.Columns.Add("pt_net_wt", Type.GetType("System.Double"));
			itemTable.Columns.Add("pt_net_wt_um", Type.GetType("System.String"));
			itemTable.Columns.Add("pt_size", Type.GetType("System.Double"));
			itemTable.Columns.Add("pt_size_um", Type.GetType("System.String"));
			
			// Données de planification article
			itemTable.Columns.Add("pt_ms", Type.GetType("System.String"));
			itemTable.Columns.Add("pt_plan_ord", Type.GetType("System.String"));
			itemTable.Columns.Add("pt_timefence", Type.GetType("System.Int32"));
			itemTable.Columns.Add("pt_ord_pol", Type.GetType("System.String"));
			itemTable.Columns.Add("pt_ord_qty", Type.GetType("System.Int32"));
			itemTable.Columns.Add("pt_ord_per", Type.GetType("System.Int32"));
			itemTable.Columns.Add("pt_sfty_stk", Type.GetType("System.Int32"));
			itemTable.Columns.Add("pt_sfty_time", Type.GetType("System.Int32"));
			itemTable.Columns.Add("pt_rop", Type.GetType("System.Int32"));
			itemTable.Columns.Add("pt_rev", Type.GetType("System.String"));
			itemTable.Columns.Add("pt_iss_pol", Type.GetType("System.String"));
			itemTable.Columns.Add("pt_buyer", Type.GetType("System.String"));
			itemTable.Columns.Add("pt_vend", Type.GetType("System.String"));
			itemTable.Columns.Add("pt_po_site", Type.GetType("System.String"));
			itemTable.Columns.Add("pt_pm_code", Type.GetType("System.String"));
			itemTable.Columns.Add("cfg", Type.GetType("System.String"));
			itemTable.Columns.Add("pt_insp_rqd", Type.GetType("System.String"));
			itemTable.Columns.Add("pt_insp_lead", Type.GetType("System.Int32"));
			itemTable.Columns.Add("pt_mfg_lead", Type.GetType("System.Int32"));
			itemTable.Columns.Add("pt_pur_lead", Type.GetType("System.Int32"));
			itemTable.Columns.Add("atp_enforcement", Type.GetType("System.String"));
			itemTable.Columns.Add("pt_atp_family", Type.GetType("System.String"));
			itemTable.Columns.Add("pt_atp_horizon", Type.GetType("System.Int32"));
			itemTable.Columns.Add("pt_run_seq1", Type.GetType("System.String"));
			itemTable.Columns.Add("pt_run_seq2", Type.GetType("System.String"));
			itemTable.Columns.Add("pt_phantom", Type.GetType("System.String"));
			itemTable.Columns.Add("pt_ord_min", Type.GetType("System.Int32"));
			itemTable.Columns.Add("pt_ord_max", Type.GetType("System.Int32"));
			itemTable.Columns.Add("pt_ord_mult", Type.GetType("System.Int32"));
			itemTable.Columns.Add("pt_op_yield", Type.GetType("System.String"));
			itemTable.Columns.Add("pt_yield_pct", Type.GetType("System.Double"));
			itemTable.Columns.Add("pt_run", Type.GetType("System.Double"));
			itemTable.Columns.Add("pt_setup", Type.GetType("System.Double"));
			itemTable.Columns.Add("btb_type", Type.GetType("System.String"));
			itemTable.Columns.Add("pt__qad15", Type.GetType("System.String"));
			itemTable.Columns.Add("pt_network", Type.GetType("System.String"));
			itemTable.Columns.Add("pt_routing", Type.GetType("System.String"));
			itemTable.Columns.Add("pt_bom_code", Type.GetType("System.String"));
		
			// Données de prix article
			itemTable.Columns.Add("pt_price", Type.GetType("System.Double"));
			itemTable.Columns.Add("pt_taxable", Type.GetType("System.String"));
			itemTable.Columns.Add("pt_taxc", Type.GetType("System.String"));
			
			// Données spécifiques article
			itemTable.Columns.Add("xxpt_brand", Type.GetType("System.String"));
			itemTable.Columns.Add("xxpt_leader", Type.GetType("System.String"));
			#endregion

			#region Chargement des PFs - MT / LM / TR
			foreach(DataRow rowItem in item.Rows)
			{
				row = itemTable.NewRow();
				
				// En tête
				row[0] = rowItem[2];                    // pt_part
				row[1] = rowItem[3];                    // pt_um
 				row[2] = rowItem[4];                    // pt_desc1
				row[3] = rowItem[5];                    // pt_desc2
			
				// Données article
				row[4] = GetItemProdLine(rowItem[0].ToString(), rowItem[6].ToString(), siteCellProdLine, prodLine);     // pt_prod_line
				row[5] = GetItemDate(rowItem[7]);       // pt_added
				row[6] = System.DBNull.Value;           // pt_dsgn_grp
				row[7] = "";                            // pt_promo
				row[8] = rowItem[8];                    // pt_part_type
				row[9] = rowItem[9];                    // pt_status
				row[10] = rowItem[10];                  // pt_group
				row[11] = rowItem[11];                  // pt_draw
				row[12] = "";                           // pt_rev
				row[13] = System.DBNull.Value;          // pt_drwg_loc
				row[14] = System.DBNull.Value;          // pt_drwg_size
				row[15] = rowItem[12];                  // pt_break_cat

				// Données stock article
				row[16] = System.DBNull.Value;          // pt_abc
				row[17] = System.DBNull.Value;          // pt_lot_ser
				row[18] = rowItem[14];                  
				row[19] = rowItem[15];                  
				row[20] = System.DBNull.Value;          
				row[21] = System.DBNull.Value;          
				row[22] = System.DBNull.Value;          
				row[23] = rowItem[16];                  // pt_article
				row[24] = System.DBNull.Value;          
				row[25] = System.DBNull.Value;          
				row[26] = System.DBNull.Value;          
				row[27] = System.DBNull.Value;          
				row[28] = System.DBNull.Value;          
				row[29] = System.DBNull.Value;          
				row[30] = System.DBNull.Value;          
				row[31] = System.DBNull.Value;          
				row[32] = System.DBNull.Value;          
				row[33] = System.DBNull.Value;          	
				
				// Données d'expédition article
				row[34] = System.DBNull.Value;
				row[35] = System.DBNull.Value;
				row[36] = System.DBNull.Value;
				row[37] = System.DBNull.Value;
				row[38] = GetItemWeight(rowItem[18]);
				row[39] = "KG";
				row[40] = System.DBNull.Value;
				row[41] = System.DBNull.Value;
				
				// Données de planification article
				row[42] = rowItem[20];                 // pt_ms
				row[43] = rowItem[21];                 // pt_plan_ord
				row[44] = rowItem[22];                 // pt_timefence
				row[45] = rowItem[23];                 // pt_ord_pol
				row[46] = System.DBNull.Value;         // pt_ord_qty
				row[47] = System.DBNull.Value;         // pt_ord_per
				row[48] = System.DBNull.Value;         // pt_sfty_stk
				row[49] = System.DBNull.Value;         // pt_sfty_time
				row[50] = System.DBNull.Value;         // pt_rop
				row[51] = System.DBNull.Value;         // pt_rev
				row[52] = System.DBNull.Value;         // pt_iss_pol
				row[53] = GetItemBuyer(rowItem[0].ToString(), siteCellProdLine);         // pt_buyer
				row[54] = System.DBNull.Value;         // pt_vend
				row[55] = System.DBNull.Value;         // pt_po_site
				row[56] = rowItem[26];                 // pt_pm_code
				row[57] = System.DBNull.Value;         // cfg
				row[58] = System.DBNull.Value;         // pt_insp_rqd
				row[59] = System.DBNull.Value;         // pt_insp_lead
				row[60] = rowItem[27];                 // pt_mfg_lead
				row[61] = rowItem[28];                 // pt_pur_lead
				row[62] = System.DBNull.Value;         // atp_enforcement // rowItem[29]; valeur incorrecte fichier source
				row[63] = "no";                        // pt_atp_family
				row[64] = 0;                           // pt_atp_horizon
				row[65] = rowItem[30];                 // pt_run_seq1
				row[66] = System.DBNull.Value;         // pt_run_seq2
				row[67] = "no";                        // pt_phantom
				row[68] = System.DBNull.Value;         // pt_ord_min
				row[69] = System.DBNull.Value;         // pt_ord_max
				row[70] = System.DBNull.Value;         // pt_ord_mult
				row[71] = rowItem[31];                 // pt_op_yield
				row[72] = rowItem[32];                 // pt_yield_pct
				row[73] = System.DBNull.Value;         // pt_run
				row[74] = System.DBNull.Value;         // pt_setup
				row[75] = System.DBNull.Value;         // rowItem[33];  incorrect               // btb_type
				row[76] = System.DBNull.Value;         // pt__qad15
				row[77] = System.DBNull.Value;         // pt_network
				row[78] = rowItem[34];                 // pt_routing
				row[79] = System.DBNull.Value;         // pt_bom_code
				
				row = GetItemPlanning(ref row, dsrp, v9);
				
				// Données de prix article
				row[80] = System.DBNull.Value;         // pt_price
				row[81] = rowItem[35];                 // pt_taxable
				row[82] = rowItem[36];                 // pt_taxc
				
				// Données spécifiques article
				row[83] = rowItem[13];                                    // xxpt_brand
				row[84] = GetItemLeader(rowItem[2].ToString(), leader);   // xxpt_leader

				itemTable.Rows.Add(row);
			}
			#endregion
			
			#region Chargement des matières premières - semi-finis - maintenance - MT
			foreach(DataRow rowRaw in raw.Rows)
			{
				row = itemTable.NewRow();
				
				// En tête
				row[0] = rowRaw[0];                 // pt_part
				row[1] = rowRaw[1];                 // pt_um 
				row[2] = rowRaw[2];                 // pt_desc1 
				row[3] = rowRaw[3];				    // pt_desc2 
				
				// Données article
				row[4] = rowRaw[4];                 // pt_prod_line
				row[5] = GetItemDate(rowRaw[5]);    // pt_added
				row[6] = rowRaw[6];                 // 
				row[7] = "";                        // pt_promo
				row[8] = "";                        // 
				row[9] = rowRaw[7];                 // 
				row[10] = rowRaw[8];                // 
				row[11] = rowRaw[9];                // 
				row[12] = "";                       // pt_rev
				row[13] = "";                       // 
				row[14] = "";                       // 
				row[15] = "";                       // 
				
				// Données stock article
				row[16] = rowRaw[10];
				row[17] = "";
				row[18] = rowRaw[11];
				row[19] = rowRaw[12];
				row[20] = "";
				row[21] = "no";
				row[22] = "";
				row[23] = "";
				row[24] = System.DBNull.Value;
				row[25] = System.DBNull.Value;
				row[26] = System.DBNull.Value;
				row[27] = "no";
				row[28] = "no";
				row[29] = rowRaw[13];
				row[30] = System.DBNull.Value;
				row[31] = System.DBNull.Value;
				row[32] = System.DBNull.Value;
				row[33] = "";				
				
				// Données d'expédition article
				row[34] = "";
				row[35] = System.DBNull.Value;
				row[36] = "";
				row[37] = "";
				row[38] = System.DBNull.Value;
				row[39] = "KG";
				row[40] = System.DBNull.Value;
				row[41] = "";				
				
				// Données de planification article
				row[42] = rowRaw[16];               // pt_ms
				row[43] = rowRaw[17];               // pt_plan_ord
				row[44] = rowRaw[18];               // pt_timefence
				row[45] = rowRaw[19];               // pt_ord_pol
				row[46] = 0;                        // pt_ord_qty
				row[47] = rowRaw[20];               // pt_ord_per
				row[48] = rowRaw[21];               // pt_sfty_stk
				row[49] = rowRaw[22];               // pt_sfty_time
				row[50] = rowRaw[23];               // pt_rop
				row[51] = "";                       // pt_rev
				row[52] = System.DBNull.Value;      // pt_iss_pol
				row[53] = rowRaw[24];               // pt_buyer
				row[54] = rowRaw[25];               // pt_vend
				row[55] = rowRaw[26];               // pt_po_site
				row[56] = rowRaw[27];               // pt_pm_code
				row[57] = "";                       // cfg
				row[58] = "no";                     // pt_insp_rqd
				row[59] = 0;                        // pt_insp_lead
				row[60] = rowRaw[28];               // pt_mfg_lead
				row[61] = rowRaw[29];               // pt_pur_lead
				row[62] = System.DBNull.Value;      // atp_enforcement
				row[63] = "no";                     // pt_atp_family
				row[64] = 0;                        // pt_atp_horizon
				row[65] = rowRaw[30];               // pt_run_seq1
				row[66] = rowRaw[31];               // pt_run_seq2
				row[67] = "no";                     // pt_phantom
				row[68] = rowRaw[32];               // pt_ord_min
				row[69] = System.DBNull.Value;      // pt_ord_max
				row[70] = rowRaw[33];               // pt_ord_mult
				row[71] = rowRaw[34];               // pt_op_yield
				row[72] = rowRaw[35];               // pt_yield_pct
				row[73] = System.DBNull.Value;      // pt_run
				row[74] = System.DBNull.Value;      // pt_setup
				row[75] = System.DBNull.Value;      // btb_type
				row[76] = System.DBNull.Value;      // pt__qad15
				row[77] = "";                       // pt_network
				row[78] = rowRaw[36];               // pt_routing
				row[79] = "";                       // pt_bom_code
				
				row[80] = System.DBNull.Value;      // pt_price
				row[81] = System.DBNull.Value;      // pt_taxable
				row[82] = System.DBNull.Value;      // pt_taxc
				
				row[83] = "";                       // xxpt_brand
				row[84] = "";                       // xxpt_leader

				itemTable.Rows.Add(row);
			}
			#endregion
			
			#region Chargement des matières premières - semi-finis - LM / TR
			foreach(DataRow rowV9 in v9.Rows)
			{
				row = itemTable.NewRow();
				
				// En tête
				row[0] = rowV9[0];                   // pt_part : OK
				row[1] = rowV9[1];                   // pt_um : OK
				row[2] = rowV9[2];                   // pt_desc1 : OK
				row[3] = rowV9[3];                   // pt_desc2 : OK
			
				// Données article
				row[4] = GetItemProdLineV9(rowV9[4].ToString(), rowV9[8].ToString(), v9LigneProd, v9LastLigneProd);  // pt_prod_line : OK
				row[5] = GetItemDate(rowV9[5]);      // pt_added : OK
				row[6] = "";                         // pt_dsgn_grp : OK
				row[7] = "";                         // pt_promo : OK
				row[8] = "";                         // pt_part_type : OK
				row[9] = rowV9[9];                   // pt_status : OK
				row[10] = "";                        // pt_group : OK
				row[11] = "";                        // pt_draw : OK
				row[12] = "";                        // pt_rev (article) : OK
				row[13] = "";                        // pt_drwg_loc : OK
				row[14] = "";                        // pt_drwg_size : OK
				row[15] = "";                        // pt_break_cat : OK
			
				// Données stock article
				row[16] = "";                        // pt_abc : OK
				row[17] = "";                        // pt_lot_ser : OK
				row[18] = rowV9[18];                 // pt_site : OK
				row[19] = rowV9[19];                 // pt_loc : ATTENTION
				row[20] = "";                        // pt_loc_type : OK
				row[21] = "no";                      // pt_auto_lot : OK
				row[22] = "";                        // pt_lot_grp : OK
				row[23] = "";                        // pt_article : OK
				row[24] = rowV9[24];                 // pt_avg_int : OK
				row[25] = rowV9[25];                 // pt_cyc_int : OK
				row[26] = rowV9[26];                 // pt_shelflife : OK
				row[27] = rowV9[27];                 // pt_sngl_lot : OK
				row[28] = rowV9[28];                 // pt_critical : OK
				row[29] = rowV9[29];                 // pt_rctpo_status : OK
				row[30] = rowV9[30];                 // pt_rctpo_active : OK
				row[31] = rowV9[31];                 // pt_rctwo_status : OK
				row[32] = rowV9[32];                 // pt_rctwo_active : OK
				row[33] = "";                        // pt_memo_type : OK
			
				// Données d'expédition article
				row[34] = "";                        // l_comm_code : OK
				row[35] = rowV9[34];                 // pt_ship_wt : OK
				row[36] = "KG";                      // pt_ship_wt_um : OK
				row[37] = "";                        // pt_fr_class : OK
				row[38] = rowV9[37];                 // pt_net_wt : OK
				row[39] = "KG";                      // pt_net_wt_um : OK
				row[40] = rowV9[39];                 // pt_size : OK
				row[41] = rowV9[40];                 // pt_size_um : OK
			
				// Données de planification article
				row[42] = rowV9[41];                 // pt_ms : OK
				row[43] = "yes";                     // pt_plan_ord : OK
				row[44] = rowV9[43];                 // pt_timefence : OK
				row[45] = rowV9[44];                 // pt_ord_pol : OK
				row[46] = rowV9[45];                 // pt_ord_qty : OK
				row[47] = rowV9[46];                 // pt_ord_per : OK
				row[48] = rowV9[47];                 // pt_sfty_stk : OK
				row[49] = rowV9[48];                 // pt_sfty_time : OK
				row[50] = rowV9[49];                 // pt_rop : OK
				row[51] = "";                        // pt_rev : OK
				row[52] = "yes";                     // pt_iss_pol : OK
				row[53] = rowV9[52];                 // pt_buyer : ATTENTION
				row[54] = rowV9[53];                 // pt_vend : ATTENTION
				row[55] = rowV9[54];                 // pt_po_site : OK
				row[56] = rowV9[55];                 // pt_pm_code : OK
				row[57] = "";                        // cfg : OK
				row[58] = rowV9[57];                 // pt_insp_rqd : OK
				row[59] = rowV9[58];                 // pt_insp_lead : OK
				row[60] = rowV9[59];                 // pt_mfg_lead : OK
				row[61] = rowV9[60];                 // pt_pur_lead : OK
				row[62] = System.DBNull.Value;       // atp_enforcement : OK
				row[63] = "no";                      // pt_atp_family : OK
				row[64] = 0;                         // pt_atp_horizon : OK
				row[65] = "";                        // pt_run_seq1 : OK
				row[66] = "";                        // pt_run_seq2 : OK
				row[67] = rowV9[61];                 // pt_phantom : OK
				row[68] = "0";                       // pt_ord_min : OK
				row[69] = rowV9[63];                 // pt_ord_max : OK
				row[70] = "0";                       // pt_ord_mult : OK
				row[71] = "no";                      // pt_op_yield : OK
				row[72] = rowV9[65];                 // pt_yield_pct : OK
				row[73] = "0";                       // pt_run : OK
				row[74] = rowV9[67];                 // pt_setup : OK
				row[75] = System.DBNull.Value;       // btb_type : OK
				row[76] = "no";                      // pt__qad15 : OK
				row[77] = "";                        // pt_network : OK
				row[78] = rowV9[71];                 // pt_routing : ATTENTION
				row[79] = "";                        // pt_bom_code				
				
				// Données de prix article
				row[80] = "0";                       // pt_price : OK
				row[81] = rowV9[74];                 // pt_taxable : OK
				row[82] = "40";                      // pt_taxc : OK
				
				// Données spécifiques article
				row[83] = "";                        // xxpt_brand : OK
				row[84] = "";                        // xxpt_leader : OK				
				
				if (!rowV9[4].ToString().Equals("F201") && 
				    !rowV9[4].ToString().Equals("F601"))
				{
					itemTable.Rows.Add(row);
				}
			}
			#endregion
			
			Build.WriteCsvFromDataTable(itemTable, "C:\\TEMP\\1.4.1_items.csv");
			return itemTable;
		}
		
		public static System.Data.DataTable Write36213_Items(System.Data.DataTable itemGeneralParams, System.Data.DataTable item)
		{
			System.Data.DataTable generalTable = new System.Data.DataTable();
			
			#region Format du fichier des paramètres généraux
			// Paramètres généraux
			generalTable.Columns.Add("code_fldname", Type.GetType("System.String"));
			generalTable.Columns.Add("code_value", Type.GetType("System.String"));
			generalTable.Columns.Add("code_cmmt", Type.GetType("System.String"));
			#endregion
			
			#region Chargement des paramètres généraux : pt_part_type / pt_group / pt_buyer / pt_vend / xxpt_brand / xxpt_leader
			foreach (DataRow rowItem in item.Rows)
			{
				Build.AddGeneral("pt_part_type", rowItem[8], ref generalTable);
				Build.AddGeneral("pt_group", rowItem[10], ref generalTable);
				Build.AddGeneral("pt_buyer", rowItem[53], ref generalTable);
				Build.AddGeneral("pt_vend", rowItem[54], ref generalTable);				
				Build.AddGeneral("xxpt_brand", rowItem[83], ref generalTable);				
				Build.AddGeneral("xxpt_leader", rowItem[84], ref generalTable);
			}
			#endregion
			
			Build.WriteCsvFromDataTable(generalTable, "C:\\TEMP\\36.2.13_items.csv");
			return generalTable;
		}
		
		public static System.Data.DataTable Write1415_Items(System.Data.DataTable cost, System.Data.DataTable costV9, System.Data.DataTable item)
		{
			System.Data.DataTable costTable = new System.Data.DataTable();
			DataRow row = null;
			
			#region Format du fichier des coûts
			// Coûts
			costTable.Columns.Add("zero_yn", Type.GetType("System.String"));
			costTable.Columns.Add("pt_part", Type.GetType("System.String"));
			costTable.Columns.Add("site", Type.GetType("System.String"));
			costTable.Columns.Add("csset", Type.GetType("System.String"));
			costTable.Columns.Add("sptwkfl_element", Type.GetType("System.String"));
			costTable.Columns.Add("sptwkfl_cst_tl", Type.GetType("System.Double"));
			#endregion		
			
			#region Chargement des coûts
			foreach (DataRow rowCost in cost.Rows)
			{
				foreach (DataRow rowItem in item.Rows)
				{
					if (rowItem[0].Equals(rowCost[0]))
					{
						// Coûts matière
						row = costTable.NewRow();
						
						row[0] = "no";                       // zero_yn
						row[1] = rowCost[0];                 // pt_part
						row[2] = rowCost[11];                // site
						row[3] = "Standard";                 // csset
						row[4] = "Matières";                 // sptwkfl_element
						row[5] = rowCost[37];                // sptwkfl_cst_tl
						
						costTable.Rows.Add(row);
					
						break;
					}					
				}
			}
			#endregion
			
			#region Chargement des coûts V9
			foreach (DataRow rowCostV9 in costV9.Rows)
			{
				foreach (DataRow rowItem in item.Rows)
				{
					if (rowItem[0].Equals(rowCostV9[1]))
					{
						// Coûts sous-traitance
						row = costTable.NewRow();
				
						row[0] = "no";                       // zero_yn
						row[1] = rowCostV9[1];               // pt_part
						row[2] = rowCostV9[2];               // site
						row[3] = "Standard";                 // csset
						row[4] = "Ss-trait";                 // sptwkfl_element
						row[5] = rowCostV9[4];               // sptwkfl_cst_tl
						
						costTable.Rows.Add(row);
						
						// Coûts matière
						row = costTable.NewRow();
						
						row[0] = "no";                       // zero_yn
						row[1] = rowCostV9[1];               // pt_part
						row[2] = rowCostV9[2];               // site
						row[3] = "Standard";                 // csset
						row[4] = "Matières";                 // sptwkfl_element
						row[5] = rowCostV9[6];               // sptwkfl_cst_tl
						
						costTable.Rows.Add(row);
						
						// Coûts main-d'oeuvre
						row = costTable.NewRow();
						
						row[0] = "no";                       // zero_yn
						row[1] = rowCostV9[1];               // pt_part
						row[2] = rowCostV9[2];               // site
						row[3] = "Standard";                 // csset
						row[4] = "Main-oeu";                 // sptwkfl_element
						row[5] = rowCostV9[8];               // sptwkfl_cst_tl
						
						costTable.Rows.Add(row);
						
						// Coûts frais généraux variables
						row = costTable.NewRow();
						
						row[0] = "no";                       // zero_yn
						row[1] = rowCostV9[1];               // pt_part
						row[2] = rowCostV9[2];               // site
						row[3] = "Standard";                 // csset
						row[4] = "FG varia";                 // sptwkfl_element
						row[5] = rowCostV9[10];              // sptwkfl_cst_tl
						
						costTable.Rows.Add(row);
						
						// Coûts frais généraux fixes
						row = costTable.NewRow();
						
						row[0] = "no";                       // zero_yn
						row[1] = rowCostV9[1];               // pt_part
						row[2] = rowCostV9[2];               // site
						row[3] = "Standard";                 // csset
						row[4] = "FG fixes";                 // sptwkfl_element
						row[5] = rowCostV9[12];              // sptwkfl_cst_tl
						
						costTable.Rows.Add(row);
						
						break;
					}					
				}
			}
			#endregion
			
			Build.WriteCsvFromDataTable(costTable, "C:\\TEMP\\1.4.15_items.csv");
			return costTable;
		}
		
		public static System.Data.DataTable Write29223_Items(System.Data.DataTable itemIntrastatCode)
		{
			System.Data.DataTable itemIntrastatCodeTable = new System.Data.DataTable();
			DataRow row = null;
			
			#region Format du fichier des codes Intrastat
			// Codes Intrastat
			itemIntrastatCodeTable.Columns.Add("csim_ctry_code", Type.GetType("System.String"));
			itemIntrastatCodeTable.Columns.Add("csim_ctrl", Type.GetType("System.String"));
			itemIntrastatCodeTable.Columns.Add("csim_desc", Type.GetType("System.String"));
			itemIntrastatCodeTable.Columns.Add("csim_um", Type.GetType("System.String"));
			#endregion		
			
			#region Chargement des codes Intrastat
			foreach (DataRow rowItemIntrastatCode in itemIntrastatCode.Rows)
			{
				// Codes Intrastat
				row = itemIntrastatCodeTable.NewRow();
				
				row[0] = "FR";                                         // csim_ctry_code
				row[1] = rowItemIntrastatCode[0];                      // csim_ctrl
				row[2] = GetValue(rowItemIntrastatCode[1], 28);        // csim_desc
				row[3] = "";                                           // csim_um
				
				itemIntrastatCodeTable.Rows.Add(row);
			}
			#endregion
			
			Build.WriteCsvFromDataTable(itemIntrastatCodeTable, "C:\\TEMP\\29.22.3_items.csv");
			return itemIntrastatCodeTable;
		}
		
		public static System.Data.DataTable Write29226_Items(System.Data.DataTable itemIntrastat, System.Data.DataTable item)
		{
			System.Data.DataTable itemIntrastatTable = new System.Data.DataTable();
			DataRow row = null;
			
			#region Format du fichier Intrastat
			// Intrastat
			itemIntrastatTable.Columns.Add("csid_ctry_code", Type.GetType("System.String"));
			itemIntrastatTable.Columns.Add("csid_part", Type.GetType("System.String"));
			itemIntrastatTable.Columns.Add("csid_ctrl", Type.GetType("System.String"));
			itemIntrastatTable.Columns.Add("csid_orig_ctry", Type.GetType("System.String"));
			itemIntrastatTable.Columns.Add("csid_intrastat", Type.GetType("System.String"));
			#endregion		
			
			#region Chargement des Intrastat
			foreach (DataRow rowItemIntrastat in itemIntrastat.Rows)
			{
				foreach (DataRow rowItem in item.Rows)
				{
					if (rowItem[0].Equals(rowItemIntrastat[1]))
					{
						// Intrastat
						row = itemIntrastatTable.NewRow();
						
						row[0] = rowItemIntrastat[0];        // csid_ctry_code
						row[1] = rowItemIntrastat[1];        // csid_part
						row[2] = rowItemIntrastat[2];        // csid_ctrl
						row[3] = rowItemIntrastat[3];        // csid_orig_ctry
						row[4] = rowItemIntrastat[4];        // csid_intrastat
						
						itemIntrastatTable.Rows.Add(row);
					
						break;
					}					
				}
			}
			#endregion
			
			Build.WriteCsvFromDataTable(itemIntrastatTable, "C:\\TEMP\\29.22.6_items.csv");
			return itemIntrastatTable;
		}
		
		public static System.Data.DataTable WriteAnalysisCode_Items(System.Data.DataTable itemProduct, System.Data.DataTable itemBrand, System.Data.DataTable item)
		{
			System.Data.DataTable itemAnalysisCodeTable = new System.Data.DataTable();
			System.Data.DataTable itemAnalysisCodeSelectionTable = new System.Data.DataTable();
			System.Data.DataTable itemAnalysisCodeLinkTable = new System.Data.DataTable();
			System.Data.DataTable itemAnalysisGeneralParamsTable = new System.Data.DataTable();
			
			#region Format du fichier des codes analyses
			// Codes analyses
			itemAnalysisCodeTable.Columns.Add("antype", Type.GetType("System.String"));
			itemAnalysisCodeTable.Columns.Add("an_code", Type.GetType("System.String"));
			itemAnalysisCodeTable.Columns.Add("an_desc", Type.GetType("System.String"));
			itemAnalysisCodeTable.Columns.Add("an_active", Type.GetType("System.String"));
			itemAnalysisCodeTable.Columns.Add("cmmt_yn", Type.GetType("System.String"));
			#endregion
			
			#region Format du fichier des sélections codes analyse
			// Sélections codes analyse
			itemAnalysisCodeSelectionTable.Columns.Add("antype", Type.GetType("System.String"));
			itemAnalysisCodeSelectionTable.Columns.Add("ans_code", Type.GetType("System.String"));
			itemAnalysisCodeSelectionTable.Columns.Add("cond_field", Type.GetType("System.String"));
			itemAnalysisCodeSelectionTable.Columns.Add("ans_mask", Type.GetType("System.String"));
			itemAnalysisCodeSelectionTable.Columns.Add("ans_sel_low", Type.GetType("System.String"));
			itemAnalysisCodeSelectionTable.Columns.Add("sel_high", Type.GetType("System.String"));
			#endregion	
			
			#region Format du fichier des liens codes analyse
			// Liens codes analyse
			itemAnalysisCodeLinkTable.Columns.Add("antype", Type.GetType("System.String"));
			itemAnalysisCodeLinkTable.Columns.Add("anl_code", Type.GetType("System.String"));
			itemAnalysisCodeLinkTable.Columns.Add("link_ancode", Type.GetType("System.String"));
			itemAnalysisCodeLinkTable.Columns.Add("anl_desc", Type.GetType("System.String"));
			#endregion
			
			#region Format du fichier des paramètres généraux
			// Paramètres généraux
			itemAnalysisGeneralParamsTable.Columns.Add("code_fldname", Type.GetType("System.String"));
			itemAnalysisGeneralParamsTable.Columns.Add("code_value", Type.GetType("System.String"));
			itemAnalysisGeneralParamsTable.Columns.Add("code_cmmt", Type.GetType("System.String"));
			#endregion
			
			#region Chargement des codes analyses produit "pt_group"
			foreach (DataRow rowItemProduct in itemProduct.Rows)
			{
				string level1 = rowItemProduct[0].ToString();
				string level2 = level1 + rowItemProduct[2].ToString();
				string level3 = level2 + rowItemProduct[4].ToString();
				string level4 = level3 + rowItemProduct[6].ToString();
				string level5 = level4 + rowItemProduct[8].ToString();
				
				Build.AddItemAnalysisCode(level1, rowItemProduct[1].ToString(), ref itemAnalysisCodeTable);
				Build.AddItemAnalysisCode(level2, rowItemProduct[3].ToString(), ref itemAnalysisCodeTable);
				Build.AddItemAnalysisCode(level3, rowItemProduct[5].ToString(), ref itemAnalysisCodeTable);
				Build.AddItemAnalysisCode(level4, rowItemProduct[7].ToString(), ref itemAnalysisCodeTable);
				Build.AddItemAnalysisCode(level5, rowItemProduct[9].ToString(), ref itemAnalysisCodeTable);
			
				Build.AddItemAnalysisCodeLink(level1, level2, ref itemAnalysisCodeLinkTable);
				Build.AddItemAnalysisCodeLink(level2, level3, ref itemAnalysisCodeLinkTable);
				Build.AddItemAnalysisCodeLink(level3, level4, ref itemAnalysisCodeLinkTable);
				Build.AddItemAnalysisCodeLink(level4, level5, ref itemAnalysisCodeLinkTable);
				
				Build.AddGeneral("pt_group", level5, rowItemProduct[9], ref itemAnalysisGeneralParamsTable);
			}
			#endregion
			
			#region Chargement des codes analyses marque "xxpt_brand"
			foreach (DataRow rowItemBrand in itemBrand.Rows)
			{
				string level1 = rowItemBrand[0].ToString();
				string level2 = level1 + rowItemBrand[2].ToString();
				string level3 = level2 + rowItemBrand[4].ToString();
				
				Build.AddItemAnalysisCode(level1, rowItemBrand[1].ToString(), ref itemAnalysisCodeTable);
				Build.AddItemAnalysisCode(level2, rowItemBrand[3].ToString(), ref itemAnalysisCodeTable);
				Build.AddItemAnalysisCode(level3, rowItemBrand[5].ToString(), ref itemAnalysisCodeTable);
				
				Build.AddItemAnalysisCodeLink(level1, level2, ref itemAnalysisCodeLinkTable);
				Build.AddItemAnalysisCodeLink(level2, level3, ref itemAnalysisCodeLinkTable);
				
				Build.AddGeneral("xxpt_brand", level3, rowItemBrand[5], ref itemAnalysisGeneralParamsTable);
			}
			#endregion
			
			#region Chargement des codes analyses "pt_article"
			foreach (DataRow rowItem in item.Rows)
			{
				string tmpItem = rowItem[23].ToString();
				
				Build.AddItemAnalysisCode(tmpItem, rowItem[2].ToString(), ref itemAnalysisCodeTable);
				Build.AddItemAnalysisCodeSelection(tmpItem, ref itemAnalysisCodeSelectionTable);
				// Build.AddGeneral("pt_article", tmpItem, rowItem[2], ref itemAnalysisGeneralParamsTable);  // Non nécessaire
			}
			#endregion
			
			Build.WriteCsvFromDataTable(itemAnalysisCodeTable, "C:\\TEMP\\1.8.1_items.csv");
			Build.WriteCsvFromDataTable(itemAnalysisCodeSelectionTable, "C:\\TEMP\\1.8.4_items.csv");
			Build.WriteCsvFromDataTable(itemAnalysisCodeLinkTable, "C:\\TEMP\\1.8.7_items.csv");
			Build.WriteCsvFromDataTable(itemAnalysisGeneralParamsTable, "C:\\TEMP\\36.2.13_items_analysis.csv");
			return itemAnalysisGeneralParamsTable;
		}
		
		
		/// <summary>
		/// Ajout d'un code analyse
		/// </summary>
		/// <param name="strField"></param>
		/// <param name="strValue"></param>
		/// <param name="generalTable"></param>
		private static void AddItemAnalysisCode(string code, string description, ref System.Data.DataTable itemAnalysisCodeTable)
		{
			DataRow newRow = null;
			bool exists = false;
			
			if (!code.Equals(""))
			{
				foreach (DataRow row in itemAnalysisCodeTable.Rows)
				{
					if (row[1].ToString().Equals(code))
					{
						exists = true;
						break;
					}
				}
				
				if (!exists)
				{
					newRow = itemAnalysisCodeTable.NewRow();
					
					newRow[0] = "Item";                              // antype
					newRow[1] = code;                                // an_code
					newRow[2] = GetValue(description, 24);           // an_desc
					newRow[3] = "yes";                               // an_active
					newRow[4] = "no";                                // cmmt_yn
					
					itemAnalysisCodeTable.Rows.Add(newRow);
				}
			}
		}
		
		/// <summary>
		/// Ajout d'une sélection de code analyse
		/// </summary>
		/// <param name="code"></param>
		/// <param name="description"></param>
		/// <param name="itemAnalysisCodeTable"></param>
		private static void AddItemAnalysisCodeSelection(string code, ref System.Data.DataTable itemAnalysisCodeSelectionTable)
		{
			DataRow newRow = null;
			bool exists = false;
			
			if (!code.Equals(""))
			{
				foreach (DataRow row in itemAnalysisCodeSelectionTable.Rows)
				{
					if (row[1].ToString().Equals(code))
					{
						exists = true;
						break;
					}
				}
				
				if (!exists)
				{
					newRow = itemAnalysisCodeSelectionTable.NewRow();
					
					newRow[0] = "Item";                // antype
					newRow[1] = code;                  // ans_code
					newRow[2] = "Article";             // cond_field
					newRow[3] = "*";                   // ans_mask
					newRow[4] = code;                  // ans_sel_low
					newRow[5] = code;                  // sel_high
					
					itemAnalysisCodeSelectionTable.Rows.Add(newRow);
				}
			}
		}
		
		
		/// <summary>
		/// Ajout d'un lien code analyse
		/// </summary>
		/// <param name="strField"></param>
		/// <param name="strValue"></param>
		/// <param name="generalTable"></param>
		private static void AddItemAnalysisCodeLink(string parentCode, string childCode, ref System.Data.DataTable itemAnalysisCodeLinkTable)
		{
			DataRow newRow = null;
			bool exists = false;
			
			if (!parentCode.Equals("") && !childCode.Equals(""))
			{
				foreach (DataRow row in itemAnalysisCodeLinkTable.Rows)
				{
					if (row[1].ToString().Equals(parentCode) && row[2].ToString().Equals(childCode))
					{
						exists = true;
						break;
					}
				}
				
				if (!exists)
				{
					newRow = itemAnalysisCodeLinkTable.NewRow();
					
					newRow[0] = "Item";                                       // antype
					newRow[1] = parentCode;                                   // anl_code
					newRow[2] = childCode;                                    // link_ancode
					newRow[3] = GetValue(parentCode + "/" + childCode, 24);   // anl_desc
					
					itemAnalysisCodeLinkTable.Rows.Add(newRow);
				}
			}
		}
		
		public static System.Data.DataTable Write361431_Customers(System.Data.DataTable businessRelation)
		{
			System.Data.DataTable businessRelationTable = new System.Data.DataTable();
			DataRow row = null;
			
			string tmpName = "", 
				   tmpLang = "",
				   tmpAdress1 = "",
				   tmpAdress2 = "",
				   tmpAdress3 = "",
				   tmpZipCode = "",
				   tmpCity = "";
				   
			int logicKey = 1;
			int contactCount = 0;
			
			#region Format du fichier des relations d'affaire
			// Relations d'affaire
			businessRelationTable.Columns.Add("tBusinessRelation.BusinessRelationCode", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tBusinessRelation.BusinessRelationName1", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tBusinessRelation.BusinessRelationName2", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tBusinessRelation.BusinessRelationName3", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tBusinessRelation.BusinessRelationSearchName", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tBusinessRelation.BusinessRelationICCode", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tBusinessRelation.BusinessRelationIsActive", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tBusinessRelation.BusinessRelationIsInterco", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tBusinessRelation.BusinessRelationIsInComp", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tBusinessRelation.BusinessRelationIsCompens", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tBusinessRelation.BusinessRelationAVRCode", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tBusinessRelation.BusinessRelationEANCode", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tBusinessRelation.BusinessRelationIsTaxRep", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tBusinessRelation.BusinessRelationIsLastFill", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tBusinessRelation.BusinessRelationNameCtrl", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tBusinessRelation.tcCorporateGroupCode", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tBusinessRelation.tcLngCode", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tBusinessRelation.tcSalesPriceListCode", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tBusinessRelation.tcPurchasePriceListCode", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tBusinessRelation.tcCostPriceListCode", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tBusinessRelation.LastModifiedDate", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tBusinessRelation.LastModifiedTime", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tBusinessRelation.LastModifiedUser", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tAddress.AddressStreet1", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tAddress.AddressStreet2", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tAddress.AddressStreet3", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tAddress.AddressZip", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tAddress.AddressCity", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tAddress.AddressName", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tAddress.AddressSearchName", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tAddress.AddressTelephone", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tAddress.AddressEMail", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tAddress.AddressWebSite", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tAddress.AddressFax", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tAddress.AddressFormat", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tAddress.AddressIsTemporary", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tAddress.TxzTaxZone", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tAddress.TxclTaxCls", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tAddress.TxuTaxUsage", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tAddress.AddressPostalAddress1", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tAddress.AddressPostalAddress2", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tAddress.AddressIsSendToPostal", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tAddress.AddressState", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tAddress.AddressPostalZip", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tAddress.AddressPostalCity", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tAddress.AddressCounty", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tAddress.AddressIsTaxable", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tAddress.AddressIsTaxInCity", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tAddress.AddressIsTaxIncluded", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tAddress.AddressTaxIDFederal", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tAddress.AddressTaxIDState", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tAddress.AddressTaxIDMisc1", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tAddress.AddressTaxIDMisc2", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tAddress.AddressTaxIDMisc3", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tAddress.AddressTaxDeclaration", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tAddress.tcCountyCode", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tAddress.tcStateCode", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tAddress.tcCountryCode", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tAddress.tcAddressTypeCode", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tAddress.tcLngCode", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tAddress.tcStateDescription", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tAddress.tcCountyDescription", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tAddress.tcCountryDescription", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tAddress.tiCountryFormat", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tAddress.tcLngDescription", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tAddress.tcCoCNumber", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tAddress.LastModifiedDate", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tAddress.LastModifiedTime", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tAddress.LastModifiedUser", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tContact.ContactFunction", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tContact.ContactName", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tContact.ContactInitials", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tContact.ContactGender", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tContact.ContactTitle", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tContact.ContactTelephone", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tContact.ContactMobilePhone", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tContact.ContactEmail", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tContact.ContactFax", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tContact.ContactIsPrimary", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tContact.ContactIsSecondary", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tContact.tcLngCode", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tContact.LastModifiedDate", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tContact.LastModifiedTime", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tContact.LastModifiedUser", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tBusRelationSafDefault.BusRelationSafDefault_ID", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tBusRelationSafDefault.tcSafConceptCode", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tBusRelationSafDefault.tcSafCode", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tBusRelationSafDefault.LastModifiedDate", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tBusRelationSafDefault.LastModifiedTime", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tBusRelationSafDefault.LastModifiedUser", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tVatNumber.VatNumber_ID", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tVatNumber.VatNumberIdentity", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tVatNumber.VatNumberIsActive", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tVatNumber.VatNumberDeclaration", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tVatNumber.tcIdentityCountryCode", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tVatNumber.tcDeclarationCountryCode", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tVatNumber.LastModifiedDate", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tVatNumber.LastModifiedTime", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tVatNumber.LastModifiedUser", Type.GetType("System.String"));
			#endregion
			
			row = businessRelationTable.NewRow();
			
			#region Intitulés des champs des relations d'affaire
			row[0] = "Code relation d'affaires";
			row[1] = "Nom de la relation d'affaires";
			row[2] = "Deuxième nom";
			row[3] = "Troisième nom";
			row[4] = "Nom de la recherche";
			row[5] = "Code intercompagnies";
			row[6] = "Cpt";
			row[7] = "Intercompagnie";
			row[8] = "Entité interne";
			row[9] = "Compensation DR/CR";
			row[10] = "Code AVR";
			row[11] = "Code EAN";
			row[12] = "Etat taxes";
			row[13] = "Dernière archive";
			row[14] = "Contrôle nom";
			row[15] = "Nom de groupe";
			row[16] = "Lang";
			row[17] = "SalesPriceListCode";
			row[18] = "PurchasePriceListCode";
			row[19] = "Liste prix de revient";
			row[20] = "Date modif";
			row[21] = "Heure modif";
			row[22] = "Utilisateur modif";
			row[23] = "Adresse";
			row[24] = "Adresse";
			row[25] = "Adresse";
			row[26] = "Code postal";
			row[27] = "Ville";
			row[38] = "Nom";
			row[29] = "Nom de la recherche";
			row[30] = "Téléphone";
			row[31] = "E-mail";
			row[32] = "Internet";
			row[33] = "Télécopie";
			row[34] = "Format";
			row[35] = "Temp";
			row[36] = "Zone de taxation";
			row[37] = "Classe de taxe";
			row[38] = "Emploi taxe";
			row[39] = "Adresse postale";
			row[40] = "Adresse postale";
			row[41] = "Envoyer les documents";
			row[42] = "Etat";
			row[43] = "Code postal";
			row[44] = "Ville";
			row[45] = "Comté";
			row[46] = "Adresse de taxation";
			row[47] = "Ville taxe entrante";
			row[48] = "Taxe comprise";
			row[49] = "Taxe fédérale";
			row[50] = "Taxe locale";
			row[51] = "Taxes - Divers 1";
			row[52] = "Taxes - Divers 2";
			row[53] = "Taxes - Divers 3";
			row[54] = "Déclaration fiscale";
			row[55] = "Code comté";
			row[56] = "Etat";
			row[57] = "Pays";
			row[58] = "Type";
			row[59] = "Lang";
			row[60] = "Description";
			row[61] = "Description";
			row[62] = "Description";
			row[63] = "Format pays";
			row[64] = "Description";
			row[65] = "Chamber Of Commerce";
			row[66] = "Date modif";
			row[67] = "Heure modif";
			row[68] = "Utilisateur modif";
			row[69] = "Fonction";
			row[70] = "Nom";
			row[71] = "Initiales";
			row[72] = "Sexe";
			row[73] = "Titre";
			row[74] = "Téléphone";
			row[75] = "Portable";
			row[76] = "E-mail";
			row[77] = "Télécopie";
			row[78] = "Primaire";
			row[79] = "Secondaire";
			row[80] = "Lang";
			row[81] = "Date modif";
			row[82] = "Heure modif";
			row[83] = "Utilisateur modif";
			row[84] = "BusRelationSafDefault_ID";
			row[85] = "Code concept ZAS";
			row[86] = "Code ZAS";
			row[87] = "Last Modified Date";
			row[88] = "Last Modified Time";
			row[89] = "Last Modified User";
			row[90] = "VatNumber_ID";
			row[91] = "N° d'identification TVA";
			row[92] = "Actif";
			row[93] = "N° déclaration TVA";
			row[94] = "Ident pays d'imposition";
			row[95] = "Pays décl TVA";
			row[96] = "Date modif";
			row[97] = "Heure modif";
			row[98] = "Utilisateur modif";
			#endregion
			
			businessRelationTable.Rows.Add(row);
			
			#region Chargement des relations d'affaire
			foreach (DataRow rowBusinessRelation in businessRelation.Rows)
			{
				row = businessRelationTable.NewRow();
				
				// Relation d'affaire
				if (rowBusinessRelation[1].ToString().Equals("0"))
				{
					#region Données relation d'affaire
					row[0] = rowBusinessRelation[3];       // "Code relation d'affaires";
					row[1] = rowBusinessRelation[4];       // "Nom de la relation d'affaires";
					tmpName = rowBusinessRelation[4].ToString();
					row[2] = rowBusinessRelation[6];       // "Deuxième nom";
					row[3] = rowBusinessRelation[7];       // "Troisième nom";
					row[4] = rowBusinessRelation[5];       // "Nom de la recherche";
					row[5] = rowBusinessRelation[12];      // "Code intercompagnies";
					row[6] = rowBusinessRelation[8];       // "Cpt";
					row[7] = rowBusinessRelation[9];       // "Intercompagnie";
					row[8] = rowBusinessRelation[10];      // "Entité interne";
					row[9] = "no";                        // "Compensation DR/CR";
					row[10] = "";                          // "Code AVR";
					row[11] = "";                          // "Code EAN";
					row[12] = rowBusinessRelation[14];     // "Etat taxes";
					row[13] = rowBusinessRelation[16];     // "Dernière archive";
					row[14] = "";                          // "Contrôle nom";
					row[15] = "";                          // "Nom de groupe";
					row[16] = rowBusinessRelation[13];     // "Lang";
					tmpLang = rowBusinessRelation[13].ToString();
					row[17] = "";                          // "SalesPriceListCode";
					row[18] = "";                          // "PurchasePriceListCode";
					row[19] = "";                          // "Liste prix de revient";
					row[20] = "";                          // "Date modif";
					row[21] = "";                          // "Heure modif";
					row[22] = "";                          // "Utilisateur modif";
					row[23] = "";                          // "Adresse";
					row[24] = "";                          // "Adresse";
					row[25] = "";                          // "Adresse";
					row[26] = "";                          // "Code postal";
					row[27] = "";                          // "Ville";
					row[28] = "";                          // "Nom";
					row[29] = "";                          // "Nom de la recherche";
					row[30] = "";                          // "Téléphone";
					row[31] = "";                          // "E-mail";
					row[32] = "";                          // "Internet";
					row[33] = "";                          // "Télécopie";
					row[34] = "";                          // "Format";
					row[35] = "";                          // "Temp";
					row[36] = "";                          // "Zone de taxation";
					row[37] = "";                          // "Classe de taxe";
					row[38] = "";                          // "Emploi taxe";
					row[39] = "";                          // "Adresse postale";
					row[40] = "";                          // "Adresse postale";
					row[41] = "";                          // "Envoyer les documents";
					row[42] = "";                          // "Etat";
					row[43] = "";                          // "Code postal";
					row[44] = "";                          // "Ville";
					row[45] = "";                          // "Comté";
					row[46] = "";                          // "Adresse de taxation";
					row[47] = "";                          // "Ville taxe entrante";
					row[48] = "";                          // "Taxe comprise";
					row[49] = "";                          // "Taxe fédérale";
					row[50] = "";                          // "Taxe locale";
					row[51] = "";                          // "Taxes - Divers 1";
					row[52] = "";                          // "Taxes - Divers 2";
					row[53] = "";                          // "Taxes - Divers 3";
					row[54] = "";                          // "Déclaration fiscale";
					row[55] = "";                          // "Code comté";
					row[56] = "";                          // "Etat";
					row[57] = "";                          // "Pays";
					row[58] = "";                          // "Type";
					row[59] = "";                          // "Lang";
					row[60] = "";                          // "Description";
					row[61] = "";                          // "Description";
					row[62] = "";                          // "Description";
					row[63] = "";                          // "Format pays";
					row[64] = "";                          // "Description";
					row[65] = "";                          // "Chamber Of Commerce";
					row[66] = "";                          // "Date modif";
					row[67] = "";                          // "Heure modif";
					row[68] = "";                          // "Utilisateur modif";
					row[69] = "";                          // "Fonction";
					row[70] = "";                          // "Nom";
					row[71] = "";                          // "Initiales";
					row[72] = "";                          // "Sexe";
					row[73] = "";                          // "Titre";
					row[74] = "";                          // "Téléphone";
					row[75] = "";                          // "Portable";
					row[76] = "";                          // "E-mail";
					row[77] = "";                          // "Télécopie";
					row[78] = "";                          // "Primaire";
					row[79] = "";                          // "Secondaire";
					row[80] = "";                          // "Lang";
					row[81] = "";                          // "Date modif";
					row[82] = "";                          // "Heure modif";
					row[83] = "";                          // "Utilisateur modif";
					row[84] = "";                          // "BusRelationSafDefault_ID";
					row[85] = "";                          // "Code concept ZAS";
					row[86] = "";                          // "Code ZAS";
					row[87] = "";                          // "Last Modified Date";
					row[88] = "";                          // "Last Modified Time";
					row[89] = "";                          // "Last Modified User";
					row[90] = "";                          // "VatNumber_ID";
					row[91] = "";                          // "N° d'identification TVA";
					row[92] = "";                          // "Actif";
					row[93] = "";                          // "N° déclaration TVA";
					row[94] = "";                          // "Ident pays d'imposition";
					row[95] = "";                          // "Pays décl TVA";
					row[96] = "";                          // "Date modif";
					row[97] = "";                          // "Heure modif";
					row[98] = "";                          // "Utilisateur modif";
					#endregion
					
					businessRelationTable.Rows.Add(row);
				}
				else
				{
					// Adresse
					if (rowBusinessRelation[2].ToString().Equals("0"))
					{
						if ((GetValue(rowBusinessRelation[18]) == tmpAdress1) &&
						    (GetValue(rowBusinessRelation[19]) == tmpAdress2) &&
						    ("" == tmpAdress3) &&
						    (GetValue(rowBusinessRelation[20]) == tmpZipCode) &&
						    (GetValue(rowBusinessRelation[21], 20) == tmpCity))
						{
							tmpAdress3 = tmpAdress3 + "(2)";
						}
						else
						{
							tmpAdress1 = GetValue(rowBusinessRelation[18]);
							tmpAdress2 = GetValue(rowBusinessRelation[19]);
							tmpAdress3 = "";
							tmpZipCode = GetValue(rowBusinessRelation[20]);
						    tmpCity = GetValue(rowBusinessRelation[21], 20);
						}
					
						#region Données d'adresse
						row[0] = "";                           // "Code relation d'affaires";
						row[1] = "";                           // "Nom de la relation d'affaires";
						row[2] = "";                           // "Deuxième nom";
						row[3] = "";                           // "Troisième nom";
						row[4] = "";                           // "Nom de la recherche";
						row[5] = "";                           // "Code intercompagnies";
						row[6] = "";                           // "Cpt";
						row[7] = "";                           // "Intercompagnie";
						row[8] = "";                           // "Entité interne";
						row[9] = "";                          // "Compensation DR/CR";
						row[10] = "";                          // "Code AVR";
						row[11] = "";                          // "Code EAN";
						row[12] = "";                          // "Etat taxes";
						row[13] = "";                          // "Dernière archive";
						row[14] = "";                          // "Contrôle nom";
						row[15] = "";                          // "Nom de groupe";
						row[16] = "";                          // "Lang";
						row[17] = "";                          // "SalesPriceListCode";
						row[18] = "";                          // "PurchasePriceListCode";
						row[19] = "";                          // "Liste prix de revient";
						row[20] = "";                          // "Date modif";
						row[21] = "";                          // "Heure modif";
						row[22] = "";                          // "Utilisateur modif";
						row[23] = tmpAdress1;                  // "Adresse";
						row[24] = tmpAdress2;                  // "Adresse";
						row[25] = tmpAdress3;                  // "Adresse";
						row[26] = tmpZipCode;                  // "Code postal";
						row[27] = tmpCity;                     // "Ville";
						row[28] = tmpName;                     // "Nom";
						row[29] = "";                          // "Nom de la recherche";
						row[30] = rowBusinessRelation[26];     // "Téléphone";
						row[31] = rowBusinessRelation[28];     // "E-mail";
						row[32] = "";                          // "Internet";
						row[33] = rowBusinessRelation[27];     // "Télécopie";
						row[34] = "1";                         // "Format";
						row[35] = "no";                        // "Temp";
						row[36] = GetValue(rowBusinessRelation[37], "FR");     // "Zone de taxation";
						row[37] = GetValue(rowBusinessRelation[38], "40");     // "Classe de taxe";
						row[38] = rowBusinessRelation[39];     // "Emploi taxe";
						row[39] = "";                          // "Adresse postale";
						row[40] = "";                          // "Adresse postale";
						row[41] = "no";                        // "Envoyer les documents";
						row[42] = "";                          // "Etat";
						row[43] = "";                          // "Code postal";
						row[44] = "";                          // "Ville";
						row[45] = rowBusinessRelation[23];     // "Comté";
						row[46] = rowBusinessRelation[29];     // "Adresse de taxation";
						row[47] = rowBusinessRelation[36];     // "Ville taxe entrante";
						row[48] = rowBusinessRelation[30];     // "Taxe comprise";
						row[49] = rowBusinessRelation[31];     // "Taxe fédérale";
						row[50] = rowBusinessRelation[32];     // "Taxe locale";
						row[51] = rowBusinessRelation[33];     // "Taxes - Divers 1";
						row[52] = rowBusinessRelation[34];     // "Taxes - Divers 2";
						row[53] = rowBusinessRelation[35];     // "Taxes - Divers 3";
						row[54] = "0";                         // "Déclaration fiscale";
						row[55] = "";                          // "Code comté";
						row[56] = "";                          // "Etat";
						row[57] = rowBusinessRelation[24];     // "Pays";
						row[58] = rowBusinessRelation[17];     // "Type";
						row[59] = tmpLang;                     // "Lang";
						row[60] = "";                          // "Description";
						row[61] = "";                          // "Description";
						row[62] = "";                          // "Description";
						row[63] = "1";                         // "Format pays";
						row[64] = "";                          // "Description";
						row[65] = "";                          // "Chamber Of Commerce";
						row[66] = "";                          // "Date modif";
						row[67] = "";                          // "Heure modif";
						row[68] = "";                          // "Utilisateur modif";
						row[69] = "";                          // "Fonction";
						row[70] = "";                          // "Nom";
						row[71] = "";                          // "Initiales";
						row[72] = "";                          // "Sexe";
						row[73] = "";                          // "Titre";
						row[74] = "";                          // "Téléphone";
						row[75] = "";                          // "Portable";
						row[76] = "";                          // "E-mail";
						row[77] = "";                          // "Télécopie";
						row[78] = "";                          // "Primaire";
						row[79] = "";                          // "Secondaire";
						row[80] = "";                          // "Lang";
						row[81] = "";                          // "Date modif";
						row[82] = "";                          // "Heure modif";
						row[83] = "";                          // "Utilisateur modif";
						row[84] = "";                          // "BusRelationSafDefault_ID";
						row[85] = "";                          // "Code concept ZAS";
						row[86] = "";                          // "Code ZAS";
						row[87] = "";                          // "Last Modified Date";
						row[88] = "";                          // "Last Modified Time";
						row[89] = "";                          // "Last Modified User";
						row[90] = "";                          // "VatNumber_ID";
						row[91] = "";                          // "N° d'identification TVA";
						row[92] = "";                          // "Actif";
						row[93] = "";                          // "N° déclaration TVA";
						row[94] = "";                          // "Ident pays d'imposition";
						row[95] = "";                          // "Pays décl TVA";
						row[96] = "";                         // "Date modif";
						row[97] = "";                         // "Heure modif";
						row[98] = "";                         // "Utilisateur modif";
						#endregion
						
						if (!rowBusinessRelation[17].ToString().Equals("HEADOFFICE") || (logicKey == 1))
						{
							businessRelationTable.Rows.Add(row);
						}
						
						logicKey++;
					}
					else // Contact
					{
						#region Données contact
						row[0] = "";                           // "Code relation d'affaires";
						row[1] = "";                           // "Nom de la relation d'affaires";
						row[2] = "";                           // "Deuxième nom";
						row[3] = "";                           // "Troisième nom";
						row[4] = "";                           // "Nom de la recherche";
						row[5] = "";                           // "Code intercompagnies";
						row[6] = "";                           // "Cpt";
						row[7] = "";                           // "Intercompagnie";
						row[8] = "";                           // "Entité interne";
						row[9] = "";                          // "Compensation DR/CR";
						row[10] = "";                          // "Code AVR";
						row[11] = "";                          // "Code EAN";
						row[12] = "";                          // "Etat taxes";
						row[13] = "";                          // "Dernière archive";
						row[14] = "";                          // "Contrôle nom";
						row[15] = "";                          // "Nom de groupe";
						row[16] = "";                          // "Lang";
						row[17] = "";                          // "SalesPriceListCode";
						row[18] = "";                          // "PurchasePriceListCode";
						row[19] = "";                          // "Liste prix de revient";
						row[20] = "";                          // "Date modif";
						row[21] = "";                          // "Heure modif";
						row[22] = "";                          // "Utilisateur modif";
						row[23] = "";                          // "Adresse";
						row[24] = "";                          // "Adresse";
						row[25] = "";                          // "Adresse";
						row[26] = "";                          // "Code postal";
						row[27] = "";                          // "Ville";
						row[28] = "";                          // "Nom";
						row[29] = "";                          // "Nom de la recherche";
						row[30] = "";                          // "Téléphone";
						row[31] = "";                          // "E-mail";
						row[32] = "";                          // "Internet";
						row[33] = "";                          // "Télécopie";
						row[34] = "";                          // "Format";
						row[35] = "";                          // "Temp";
						row[36] = "";                          // "Zone de taxation";
						row[37] = "";                          // "Classe de taxe";
						row[38] = "";                          // "Emploi taxe";
						row[39] = "";                          // "Adresse postale";
						row[40] = "";                          // "Adresse postale";
						row[41] = "";                          // "Envoyer les documents";
						row[42] = "";                          // "Etat";
						row[43] = "";                          // "Code postal";
						row[44] = "";                          // "Ville";
						row[45] = "";                          // "Comté";
						row[46] = "";                          // "Adresse de taxation";
						row[47] = "";                          // "Ville taxe entrante";
						row[48] = "";                          // "Taxe comprise";
						row[49] = "";                          // "Taxe fédérale";
						row[50] = "";                          // "Taxe locale";
						row[51] = "";                          // "Taxes - Divers 1";
						row[52] = "";                          // "Taxes - Divers 2";
						row[53] = "";                          // "Taxes - Divers 3";
						row[54] = "";                          // "Déclaration fiscale";
						row[55] = "";                          // "Code comté";
						row[56] = "";                          // "Etat";
						row[57] = "";                          // "Pays";
						row[58] = "";                          // "Type";
						row[59] = "";                          // "Lang";
						row[60] = "";                          // "Description";
						row[61] = "";                          // "Description";
						row[62] = "";                          // "Description";
						row[63] = "";                          // "Format pays";
						row[64] = "";                          // "Description";
						row[65] = "";                          // "Chamber Of Commerce";
						row[66] = "";                          // "Date modif";
						row[67] = "";                          // "Heure modif";
						row[68] = "";                          // "Utilisateur modif";
						row[69] = "";                          // "Fonction";
						row[70] = rowBusinessRelation[40];     // "Nom";
						row[71] = "";                          // "Initiales";
						row[72] = "male";                      // "Sexe";
						row[73] = "";                          // "Titre";
						row[74] = rowBusinessRelation[41];     // "Téléphone";
						row[75] = "";                          // "Portable";
						row[76] = rowBusinessRelation[43];     // "E-mail";
						row[77] = rowBusinessRelation[42];     // "Télécopie";
						row[78] = rowBusinessRelation[44];     // "Primaire";
						row[79] = rowBusinessRelation[45];     // "Secondaire";
						row[80] = GetValue(tmpLang, "FR");     // "Lang";
						row[81] = "";                          // "Date modif";
						row[82] = "";                          // "Heure modif";
						row[83] = "";                          // "Utilisateur modif";
						row[84] = "";                          // "BusRelationSafDefault_ID";
						row[85] = "";                          // "Code concept ZAS";
						row[86] = "";                          // "Code ZAS";
						row[87] = "";                          // "Last Modified Date";
						row[88] = "";                          // "Last Modified Time";
						row[89] = "";                          // "Last Modified User";
						row[90] = "";                          // "VatNumber_ID";
						row[91] = "";                          // "N° d'identification TVA";
						row[92] = "";                          // "Actif";
						row[93] = "";                          // "N° déclaration TVA";
						row[94] = "";                          // "Ident pays d'imposition";
						row[95] = "";                          // "Pays décl TVA";
						row[96] = "";                         // "Date modif";
						row[97] = "";                         // "Heure modif";
						row[98] = "";                         // "Utilisateur modif";
						#endregion
						
						/*if(contactCount < 2)
						{*/
							businessRelationTable.Rows.Add(row);
						/*}*/
						
						contactCount++;
					}					
				}				
			}
			#endregion
			
			Build.WriteCsvFromDataTable2(businessRelationTable, "C:\\TEMP\\36.1.4.3.1_customers.txt");
			return businessRelationTable;
		}
		
		public static System.Data.DataTable Write361431_Suppliers(System.Data.DataTable businessRelation)
		{
			System.Data.DataTable businessRelationTable = new System.Data.DataTable();
			DataRow row = null;
			
			string tmpName = "", 
				   tmpLang = "",
				   tmpAdress1 = "",
				   tmpAdress2 = "",
				   tmpAdress3 = "",
				   tmpZipCode = "",
				   tmpCity = "";
				   
			int logicKey = 1;
			int contactCount = 0;
			
			#region Format du fichier des relations d'affaire
			// Relations d'affaire
			businessRelationTable.Columns.Add("tBusinessRelation.BusinessRelationCode", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tBusinessRelation.BusinessRelationName1", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tBusinessRelation.BusinessRelationName2", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tBusinessRelation.BusinessRelationName3", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tBusinessRelation.BusinessRelationSearchName", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tBusinessRelation.BusinessRelationICCode", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tBusinessRelation.BusinessRelationIsActive", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tBusinessRelation.BusinessRelationIsInterco", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tBusinessRelation.BusinessRelationIsInComp", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tBusinessRelation.BusinessRelationIsCompens", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tBusinessRelation.BusinessRelationAVRCode", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tBusinessRelation.BusinessRelationEANCode", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tBusinessRelation.BusinessRelationIsTaxRep", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tBusinessRelation.BusinessRelationIsLastFill", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tBusinessRelation.BusinessRelationNameCtrl", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tBusinessRelation.tcCorporateGroupCode", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tBusinessRelation.tcLngCode", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tBusinessRelation.tcSalesPriceListCode", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tBusinessRelation.tcPurchasePriceListCode", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tBusinessRelation.tcCostPriceListCode", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tBusinessRelation.LastModifiedDate", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tBusinessRelation.LastModifiedTime", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tBusinessRelation.LastModifiedUser", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tAddress.AddressStreet1", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tAddress.AddressStreet2", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tAddress.AddressStreet3", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tAddress.AddressZip", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tAddress.AddressCity", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tAddress.AddressName", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tAddress.AddressSearchName", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tAddress.AddressTelephone", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tAddress.AddressEMail", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tAddress.AddressWebSite", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tAddress.AddressFax", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tAddress.AddressFormat", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tAddress.AddressIsTemporary", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tAddress.TxzTaxZone", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tAddress.TxclTaxCls", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tAddress.TxuTaxUsage", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tAddress.AddressPostalAddress1", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tAddress.AddressPostalAddress2", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tAddress.AddressIsSendToPostal", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tAddress.AddressState", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tAddress.AddressPostalZip", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tAddress.AddressPostalCity", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tAddress.AddressCounty", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tAddress.AddressIsTaxable", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tAddress.AddressIsTaxInCity", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tAddress.AddressIsTaxIncluded", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tAddress.AddressTaxIDFederal", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tAddress.AddressTaxIDState", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tAddress.AddressTaxIDMisc1", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tAddress.AddressTaxIDMisc2", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tAddress.AddressTaxIDMisc3", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tAddress.AddressTaxDeclaration", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tAddress.tcCountyCode", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tAddress.tcStateCode", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tAddress.tcCountryCode", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tAddress.tcAddressTypeCode", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tAddress.tcLngCode", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tAddress.tcStateDescription", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tAddress.tcCountyDescription", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tAddress.tcCountryDescription", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tAddress.tiCountryFormat", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tAddress.tcLngDescription", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tAddress.tcCoCNumber", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tAddress.LastModifiedDate", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tAddress.LastModifiedTime", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tAddress.LastModifiedUser", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tContact.ContactFunction", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tContact.ContactName", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tContact.ContactInitials", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tContact.ContactGender", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tContact.ContactTitle", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tContact.ContactTelephone", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tContact.ContactMobilePhone", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tContact.ContactEmail", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tContact.ContactFax", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tContact.ContactIsPrimary", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tContact.ContactIsSecondary", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tContact.tcLngCode", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tContact.LastModifiedDate", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tContact.LastModifiedTime", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tContact.LastModifiedUser", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tBusRelationSafDefault.BusRelationSafDefault_ID", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tBusRelationSafDefault.tcSafConceptCode", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tBusRelationSafDefault.tcSafCode", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tBusRelationSafDefault.LastModifiedDate", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tBusRelationSafDefault.LastModifiedTime", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tBusRelationSafDefault.LastModifiedUser", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tVatNumber.VatNumber_ID", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tVatNumber.VatNumberIdentity", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tVatNumber.VatNumberIsActive", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tVatNumber.VatNumberDeclaration", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tVatNumber.tcIdentityCountryCode", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tVatNumber.tcDeclarationCountryCode", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tVatNumber.LastModifiedDate", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tVatNumber.LastModifiedTime", Type.GetType("System.String"));
			businessRelationTable.Columns.Add("tVatNumber.LastModifiedUser", Type.GetType("System.String"));
			#endregion
			
			row = businessRelationTable.NewRow();
			
			#region Intitulés des champs des relations d'affaire
			row[0] = "Code relation d'affaires";
			row[1] = "Nom de la relation d'affaires";
			row[2] = "Deuxième nom";
			row[3] = "Troisième nom";
			row[4] = "Nom de la recherche";
			row[5] = "Code intercompagnies";
			row[6] = "Cpt";
			row[7] = "Intercompagnie";
			row[8] = "Entité interne";
			row[9] = "Compensation DR/CR";
			row[10] = "Code AVR";
			row[11] = "Code EAN";
			row[12] = "Etat taxes";
			row[13] = "Dernière archive";
			row[14] = "Contrôle nom";
			row[15] = "Nom de groupe";
			row[16] = "Lang";
			row[17] = "SalesPriceListCode";
			row[18] = "PurchasePriceListCode";
			row[19] = "Liste prix de revient";
			row[20] = "Date modif";
			row[21] = "Heure modif";
			row[22] = "Utilisateur modif";
			row[23] = "Adresse";
			row[24] = "Adresse";
			row[25] = "Adresse";
			row[26] = "Code postal";
			row[27] = "Ville";
			row[38] = "Nom";
			row[29] = "Nom de la recherche";
			row[30] = "Téléphone";
			row[31] = "E-mail";
			row[32] = "Internet";
			row[33] = "Télécopie";
			row[34] = "Format";
			row[35] = "Temp";
			row[36] = "Zone de taxation";
			row[37] = "Classe de taxe";
			row[38] = "Emploi taxe";
			row[39] = "Adresse postale";
			row[40] = "Adresse postale";
			row[41] = "Envoyer les documents";
			row[42] = "Etat";
			row[43] = "Code postal";
			row[44] = "Ville";
			row[45] = "Comté";
			row[46] = "Adresse de taxation";
			row[47] = "Ville taxe entrante";
			row[48] = "Taxe comprise";
			row[49] = "Taxe fédérale";
			row[50] = "Taxe locale";
			row[51] = "Taxes - Divers 1";
			row[52] = "Taxes - Divers 2";
			row[53] = "Taxes - Divers 3";
			row[54] = "Déclaration fiscale";
			row[55] = "Code comté";
			row[56] = "Etat";
			row[57] = "Pays";
			row[58] = "Type";
			row[59] = "Lang";
			row[60] = "Description";
			row[61] = "Description";
			row[62] = "Description";
			row[63] = "Format pays";
			row[64] = "Description";
			row[65] = "Chamber Of Commerce";
			row[66] = "Date modif";
			row[67] = "Heure modif";
			row[68] = "Utilisateur modif";
			row[69] = "Fonction";
			row[70] = "Nom";
			row[71] = "Initiales";
			row[72] = "Sexe";
			row[73] = "Titre";
			row[74] = "Téléphone";
			row[75] = "Portable";
			row[76] = "E-mail";
			row[77] = "Télécopie";
			row[78] = "Primaire";
			row[79] = "Secondaire";
			row[80] = "Lang";
			row[81] = "Date modif";
			row[82] = "Heure modif";
			row[83] = "Utilisateur modif";
			row[84] = "BusRelationSafDefault_ID";
			row[85] = "Code concept ZAS";
			row[86] = "Code ZAS";
			row[87] = "Last Modified Date";
			row[88] = "Last Modified Time";
			row[89] = "Last Modified User";
			row[90] = "VatNumber_ID";
			row[91] = "N° d'identification TVA";
			row[92] = "Actif";
			row[93] = "N° déclaration TVA";
			row[94] = "Ident pays d'imposition";
			row[95] = "Pays décl TVA";
			row[96] = "Date modif";
			row[97] = "Heure modif";
			row[98] = "Utilisateur modif";
			#endregion
			
			businessRelationTable.Rows.Add(row);
			
			#region Chargement des relations d'affaire
			foreach (DataRow rowBusinessRelation in businessRelation.Rows)
			{
				row = businessRelationTable.NewRow();
				
				// Relation d'affaire
				if (rowBusinessRelation[1].ToString().Equals("0"))
				{
					logicKey = 1;
					
					#region Données relation d'affaire
					row[0] = rowBusinessRelation[3];       // "Code relation d'affaires";
					row[1] = rowBusinessRelation[4];       // "Nom de la relation d'affaires";
					tmpName = row[1].ToString();
					row[2] = "";                           // "Deuxième nom";
					row[3] = "";                           // "Troisième nom";
					row[4] = rowBusinessRelation[5];       // "Nom de la recherche";
					row[5] = "";                           // "Code intercompagnies";
					row[6] = rowBusinessRelation[6];       // "Cpt";
					row[7] = rowBusinessRelation[7];       // "Intercompagnie";
					row[8] = rowBusinessRelation[8];       // "Entité interne";
					row[9] = "no";                        // "Compensation DR/CR";
					row[10] = "";                          // "Code AVR";
					row[11] = "";                          // "Code EAN";
					row[12] = rowBusinessRelation[10];     // "Etat taxes";
					row[13] = rowBusinessRelation[11];     // "Dernière archive";
					row[14] = "";                          // "Contrôle nom";
					row[15] = "";                          // "Nom de groupe";
					row[16] = "FR";                        // "Lang";
					tmpLang = row[16].ToString();
					row[17] = "";                          // "SalesPriceListCode";
					row[18] = "";                          // "PurchasePriceListCode";
					row[19] = "";                          // "Liste prix de revient";
					row[20] = "";                          // "Date modif";
					row[21] = "";                          // "Heure modif";
					row[22] = "";                          // "Utilisateur modif";
					row[23] = "";                          // "Adresse";
					row[24] = "";                          // "Adresse";
					row[25] = "";                          // "Adresse";
					row[26] = "";                          // "Code postal";
					row[27] = "";                          // "Ville";
					row[28] = "";                          // "Nom";
					row[29] = "";                          // "Nom de la recherche";
					row[30] = "";                          // "Téléphone";
					row[31] = "";                          // "E-mail";
					row[32] = "";                          // "Internet";
					row[33] = "";                          // "Télécopie";
					row[34] = "";                          // "Format";
					row[35] = "";                          // "Temp";
					row[36] = "";                          // "Zone de taxation";
					row[37] = "";                          // "Classe de taxe";
					row[38] = "";                          // "Emploi taxe";
					row[39] = "";                          // "Adresse postale";
					row[40] = "";                          // "Adresse postale";
					row[41] = "";                          // "Envoyer les documents";
					row[42] = "";                          // "Etat";
					row[43] = "";                          // "Code postal";
					row[44] = "";                          // "Ville";
					row[45] = "";                          // "Comté";
					row[46] = "";                          // "Adresse de taxation";
					row[47] = "";                          // "Ville taxe entrante";
					row[48] = "";                          // "Taxe comprise";
					row[49] = "";                          // "Taxe fédérale";
					row[50] = "";                          // "Taxe locale";
					row[51] = "";                          // "Taxes - Divers 1";
					row[52] = "";                          // "Taxes - Divers 2";
					row[53] = "";                          // "Taxes - Divers 3";
					row[54] = "";                          // "Déclaration fiscale";
					row[55] = "";                          // "Code comté";
					row[56] = "";                          // "Etat";
					row[57] = "";                          // "Pays";
					row[58] = "";                          // "Type";
					row[59] = "";                          // "Lang";
					row[60] = "";                          // "Description";
					row[61] = "";                          // "Description";
					row[62] = "";                          // "Description";
					row[63] = "";                          // "Format pays";
					row[64] = "";                          // "Description";
					row[65] = "";                          // "Chamber Of Commerce";
					row[66] = "";                          // "Date modif";
					row[67] = "";                          // "Heure modif";
					row[68] = "";                          // "Utilisateur modif";
					row[69] = "";                          // "Fonction";
					row[70] = "";                          // "Nom";
					row[71] = "";                          // "Initiales";
					row[72] = "";                          // "Sexe";
					row[73] = "";                          // "Titre";
					row[74] = "";                          // "Téléphone";
					row[75] = "";                          // "Portable";
					row[76] = "";                          // "E-mail";
					row[77] = "";                          // "Télécopie";
					row[78] = "";                          // "Primaire";
					row[79] = "";                          // "Secondaire";
					row[80] = "";                          // "Lang";
					row[81] = "";                          // "Date modif";
					row[82] = "";                          // "Heure modif";
					row[83] = "";                          // "Utilisateur modif";
					row[84] = "";                          // "BusRelationSafDefault_ID";
					row[85] = "";                          // "Code concept ZAS";
					row[86] = "";                          // "Code ZAS";
					row[87] = "";                          // "Last Modified Date";
					row[88] = "";                          // "Last Modified Time";
					row[89] = "";                          // "Last Modified User";
					row[90] = "";                          // "VatNumber_ID";
					row[91] = "";                          // "N° d'identification TVA";
					row[92] = "";                          // "Actif";
					row[93] = "";                          // "N° déclaration TVA";
					row[94] = "";                          // "Ident pays d'imposition";
					row[95] = "";                          // "Pays décl TVA";
					row[96] = "";                         // "Date modif";
					row[97] = "";                         // "Heure modif";
					row[98] = "";                         // "Utilisateur modif";
					#endregion
					
					businessRelationTable.Rows.Add(row);
				}
				else
				{	
					// Adresse
					if (rowBusinessRelation[2].ToString().Equals("0"))
					{
						contactCount = 0;
						
						if ((GetValue(rowBusinessRelation[14]) == tmpAdress1) &&
						    (GetValue(rowBusinessRelation[15]) == tmpAdress2) &&
						    (GetValue(rowBusinessRelation[16]) == tmpAdress3) &&
						    (GetValue(rowBusinessRelation[17]) == tmpZipCode) &&
						    (GetValue(rowBusinessRelation[18], 20) == tmpCity))
						{
							tmpAdress2 = tmpAdress2 + "(2)";
						}
						else
						{
							tmpAdress1 = GetValue(rowBusinessRelation[14]);
							tmpAdress2 = GetValue(rowBusinessRelation[15]);
							tmpAdress3 = GetValue(rowBusinessRelation[16]);
							tmpZipCode = GetValue(rowBusinessRelation[17]);
						    tmpCity = GetValue(rowBusinessRelation[18], 20);
						}
					
						#region Données d'adresse
						row[0] = "";                           // "Code relation d'affaires";
						row[1] = "";                           // "Nom de la relation d'affaires";
						row[2] = "";                           // "Deuxième nom";
						row[3] = "";                           // "Troisième nom";
						row[4] = "";                           // "Nom de la recherche";
						row[5] = "";                           // "Code intercompagnies";
						row[6] = "";                           // "Cpt";
						row[7] = "";                           // "Intercompagnie";
						row[8] = "";                           // "Entité interne";
						row[9] = "";                          // "Compensation DR/CR";
						row[10] = "";                          // "Code AVR";
						row[11] = "";                          // "Code EAN";
						row[12] = "";                          // "Etat taxes";
						row[13] = "";                          // "Dernière archive";
						row[14] = "";                          // "Contrôle nom";
						row[15] = "";                          // "Nom de groupe";
						row[16] = "";                          // "Lang";
						row[17] = "";                          // "SalesPriceListCode";
						row[18] = "";                          // "PurchasePriceListCode";
						row[19] = "";                          // "Liste prix de revient";
						row[20] = "";                          // "Date modif";
						row[21] = "";                          // "Heure modif";
						row[22] = "";                          // "Utilisateur modif";
						row[23] = tmpAdress1;                  // "Adresse";
						row[24] = tmpAdress2;                  // "Adresse";
						row[25] = tmpAdress3;                  // "Adresse";
						row[26] = tmpZipCode;                  // "Code postal";
						row[27] = tmpCity;                     // "Ville";
						row[28] = tmpName;                     // "Nom";
						row[29] = "";                          // "Nom de la recherche";
						row[30] = rowBusinessRelation[22];     // "Téléphone";
						row[31] = "";                          // "E-mail";
						row[32] = "";                          // "Internet";
						row[33] = rowBusinessRelation[23];     // "Télécopie";
						row[34] = "1";                         // "Format";
						row[35] = "no";                        // "Temp";
						row[36] = GetValue(rowBusinessRelation[28], "FR");     // "Zone de taxation";
						row[37] = GetValue(rowBusinessRelation[29], "40");     // "Classe de taxe";
						row[38] = "";                          // "Emploi taxe";
						row[39] = "";                          // "Adresse postale";
						row[40] = "";                          // "Adresse postale";
						row[41] = "no";                        // "Envoyer les documents";
						row[42] = "";                          // "Etat";
						row[43] = "";                          // "Code postal";
						row[44] = "";                          // "Ville";
						row[45] = rowBusinessRelation[19];     // "Comté";
						row[46] = rowBusinessRelation[24];     // "Adresse de taxation";
						row[47] = "yes";                       // "Ville taxe entrante";
						row[48] = rowBusinessRelation[25];     // "Taxe comprise";
						row[49] = rowBusinessRelation[26];     // "Taxe fédérale";
						row[50] = "";                          // "Taxe locale";
						row[51] = "";                          // "Taxes - Divers 1";
						row[52] = "";                          // "Taxes - Divers 2";
						row[53] = "";                          // "Taxes - Divers 3";
						row[54] = "0";                         // "Déclaration fiscale";
						row[55] = "";                          // "Code comté";
						row[56] = "";                          // "Etat";
						row[57] = rowBusinessRelation[20];     // "Pays";
						row[58] = rowBusinessRelation[12];     // "Type";
						row[59] = tmpLang;                     // "Lang";
						row[60] = "";                          // "Description";
						row[61] = "";                          // "Description";
						row[62] = "";                          // "Description";
						row[63] = "1";                         // "Format pays";
						row[64] = "";                          // "Description";
						row[65] = "";                          // "Chamber Of Commerce";
						row[66] = "";                          // "Date modif";
						row[67] = "";                          // "Heure modif";
						row[68] = "";                          // "Utilisateur modif";
						row[69] = "";                          // "Fonction";
						row[70] = "";                          // "Nom";
						row[71] = "";                          // "Initiales";
						row[72] = "";                          // "Sexe";
						row[73] = "";                          // "Titre";
						row[74] = "";                          // "Téléphone";
						row[75] = "";                          // "Portable";
						row[76] = "";                          // "E-mail";
						row[77] = "";                          // "Télécopie";
						row[78] = "";                          // "Primaire";
						row[79] = "";                          // "Secondaire";
						row[80] = "";                          // "Lang";
						row[81] = "";                          // "Date modif";
						row[82] = "";                          // "Heure modif";
						row[83] = "";                          // "Utilisateur modif";
						row[84] = "";                          // "BusRelationSafDefault_ID";
						row[85] = "";                          // "Code concept ZAS";
						row[86] = "";                          // "Code ZAS";
						row[87] = "";                          // "Last Modified Date";
						row[88] = "";                          // "Last Modified Time";
						row[89] = "";                          // "Last Modified User";
						row[90] = "";                          // "VatNumber_ID";
						row[91] = "";                          // "N° d'identification TVA";
						row[92] = "";                          // "Actif";
						row[93] = "";                          // "N° déclaration TVA";
						row[94] = "";                          // "Ident pays d'imposition";
						row[95] = "";                          // "Pays décl TVA";
						row[96] = "";                         // "Date modif";
						row[97] = "";                         // "Heure modif";
						row[98] = "";                         // "Utilisateur modif";
						#endregion
						
						if (!rowBusinessRelation[12].ToString().Equals("HEADOFFICE") || (logicKey == 1))
						{
							businessRelationTable.Rows.Add(row);
						}
						
						logicKey++;
					}
					else // Contact
					{
						#region Données contact
						row[0] = "";                           // "Code relation d'affaires";
						row[1] = "";                           // "Nom de la relation d'affaires";
						row[2] = "";                           // "Deuxième nom";
						row[3] = "";                           // "Troisième nom";
						row[4] = "";                           // "Nom de la recherche";
						row[5] = "";                           // "Code intercompagnies";
						row[6] = "";                           // "Cpt";
						row[7] = "";                           // "Intercompagnie";
						row[8] = "";                           // "Entité interne";
						row[9] = "";                          // "Compensation DR/CR";
						row[10] = "";                          // "Code AVR";
						row[11] = "";                          // "Code EAN";
						row[12] = "";                          // "Etat taxes";
						row[13] = "";                          // "Dernière archive";
						row[14] = "";                          // "Contrôle nom";
						row[15] = "";                          // "Nom de groupe";
						row[16] = "";                          // "Lang";
						row[17] = "";                          // "SalesPriceListCode";
						row[18] = "";                          // "PurchasePriceListCode";
						row[19] = "";                          // "Liste prix de revient";
						row[20] = "";                          // "Date modif";
						row[21] = "";                          // "Heure modif";
						row[22] = "";                          // "Utilisateur modif";
						row[23] = "";                          // "Adresse";
						row[24] = "";                          // "Adresse";
						row[25] = "";                          // "Adresse";
						row[26] = "";                          // "Code postal";
						row[27] = "";                          // "Ville";
						row[28] = "";                          // "Nom";
						row[29] = "";                          // "Nom de la recherche";
						row[30] = "";                          // "Téléphone";
						row[31] = "";                          // "E-mail";
						row[32] = "";                          // "Internet";
						row[33] = "";                          // "Télécopie";
						row[34] = "";                          // "Format";
						row[35] = "";                          // "Temp";
						row[36] = "";                          // "Zone de taxation";
						row[37] = "";                          // "Classe de taxe";
						row[38] = "";                          // "Emploi taxe";
						row[39] = "";                          // "Adresse postale";
						row[40] = "";                          // "Adresse postale";
						row[41] = "";                          // "Envoyer les documents";
						row[42] = "";                          // "Etat";
						row[43] = "";                          // "Code postal";
						row[44] = "";                          // "Ville";
						row[45] = "";                          // "Comté";
						row[46] = "";                          // "Adresse de taxation";
						row[47] = "";                          // "Ville taxe entrante";
						row[48] = "";                          // "Taxe comprise";
						row[49] = "";                          // "Taxe fédérale";
						row[50] = "";                          // "Taxe locale";
						row[51] = "";                          // "Taxes - Divers 1";
						row[52] = "";                          // "Taxes - Divers 2";
						row[53] = "";                          // "Taxes - Divers 3";
						row[54] = "";                          // "Déclaration fiscale";
						row[55] = "";                          // "Code comté";
						row[56] = "";                          // "Etat";
						row[57] = "";                          // "Pays";
						row[58] = "";                          // "Type";
						row[59] = "";                          // "Lang";
						row[60] = "";                          // "Description";
						row[61] = "";                          // "Description";
						row[62] = "";                          // "Description";
						row[63] = "";                          // "Format pays";
						row[64] = "";                          // "Description";
						row[65] = "";                          // "Chamber Of Commerce";
						row[66] = "";                          // "Date modif";
						row[67] = "";                          // "Heure modif";
						row[68] = "";                          // "Utilisateur modif";
						row[69] = rowBusinessRelation[31];     // "Fonction";
						row[70] = rowBusinessRelation[30];     // "Nom";
						row[71] = "";                          // "Initiales";
						row[72] = "male";                      // "Sexe";
						row[73] = "";                          // "Titre";
						row[74] = rowBusinessRelation[32];     // "Téléphone";
						row[75] = "";                          // "Portable";
						row[76] = rowBusinessRelation[34];     // "E-mail";
						row[77] = rowBusinessRelation[33];     // "Télécopie";
						row[78] = rowBusinessRelation[35];     // "Primaire";
						row[79] = rowBusinessRelation[36];     // "Secondaire";
						row[80] = GetValue(tmpLang, "FR");     // "Lang";
						row[81] = "";                          // "Date modif";
						row[82] = "";                          // "Heure modif";
						row[83] = "";                          // "Utilisateur modif";
						row[84] = "";                          // "BusRelationSafDefault_ID";
						row[85] = "";                          // "Code concept ZAS";
						row[86] = "";                          // "Code ZAS";
						row[87] = "";                          // "Last Modified Date";
						row[88] = "";                          // "Last Modified Time";
						row[89] = "";                          // "Last Modified User";
						row[90] = "";                          // "VatNumber_ID";
						row[91] = "";                          // "N° d'identification TVA";
						row[92] = "";                          // "Actif";
						row[93] = "";                          // "N° déclaration TVA";
						row[94] = "";                          // "Ident pays d'imposition";
						row[95] = "";                          // "Pays décl TVA";
						row[96] = "";                         // "Date modif";
						row[97] = "";                         // "Heure modif";
						row[98] = "";                         // "Utilisateur modif";
						#endregion
						
						/*if(contactCount < 2)
						{*/
							businessRelationTable.Rows.Add(row);
						/*}*/
						
						contactCount++;
					}					
				}
			}
			#endregion
			
			Build.WriteCsvFromDataTable2(businessRelationTable, "C:\\TEMP\\36.1.4.3.1_suppliers.txt");
			return businessRelationTable;
		}
		
		public static System.Data.DataTable Write272011_Customers(System.Data.DataTable customerFinancial)
		{
			System.Data.DataTable customerFinancialTable = new System.Data.DataTable();
			DataRow row = null;
			
			#region Format du fichier des clients finances
			// Clients
			customerFinancialTable.Columns.Add("tDebtor.Debtor_ID", Type.GetType("System.String"));
			customerFinancialTable.Columns.Add("tDebtor.VatDeliveryType", Type.GetType("System.String"));
			customerFinancialTable.Columns.Add("tDebtor.DebtorCode", Type.GetType("System.String"));
			customerFinancialTable.Columns.Add("tDebtor.DebtorIsActive", Type.GetType("System.String"));
			customerFinancialTable.Columns.Add("tDebtor.VatPercentageLevel", Type.GetType("System.String"));
			customerFinancialTable.Columns.Add("tDebtor.DebtorIsPrintStatement", Type.GetType("System.String"));
			customerFinancialTable.Columns.Add("tDebtor.DebtorIsPrintReminder", Type.GetType("System.String"));
			customerFinancialTable.Columns.Add("tDebtor.DomiciliationNumber", Type.GetType("System.String"));
			customerFinancialTable.Columns.Add("tDebtor.DebtorIsTaxable", Type.GetType("System.String"));
			customerFinancialTable.Columns.Add("tDebtor.DebtorIsTaxInCity", Type.GetType("System.String"));
			customerFinancialTable.Columns.Add("tDebtor.DebtorIsTaxIncluded", Type.GetType("System.String"));
			customerFinancialTable.Columns.Add("tDebtor.DebtorTaxIDFederal", Type.GetType("System.String"));
			customerFinancialTable.Columns.Add("tDebtor.DebtorTaxIDState", Type.GetType("System.String"));
			customerFinancialTable.Columns.Add("tDebtor.DebtorTaxIDMisc1", Type.GetType("System.String"));
			customerFinancialTable.Columns.Add("tDebtor.DebtorTaxIDMisc2", Type.GetType("System.String"));
			customerFinancialTable.Columns.Add("tDebtor.DebtorTaxIDMisc3", Type.GetType("System.String"));
			customerFinancialTable.Columns.Add("tDebtor.DebtorTaxDeclaration", Type.GetType("System.String"));
			customerFinancialTable.Columns.Add("tDebtor.DebtorIsFixedCredLim", Type.GetType("System.String"));
			customerFinancialTable.Columns.Add("tDebtor.DebtorFixedCredLimTC", Type.GetType("System.String"));
			customerFinancialTable.Columns.Add("tDebtor.DebtorIsTurnOverCredLim", Type.GetType("System.String"));
			customerFinancialTable.Columns.Add("tDebtor.DebtorPercTurnOverCredLim", Type.GetType("System.String"));
			customerFinancialTable.Columns.Add("tDebtor.DebtorIsMaxDaysDueCredLim", Type.GetType("System.String"));
			customerFinancialTable.Columns.Add("tDebtor.DebtorMaxNumDaysCredLim", Type.GetType("System.String"));
			customerFinancialTable.Columns.Add("tDebtor.DebtorIsInclOpenItmCredLim", Type.GetType("System.String"));
			customerFinancialTable.Columns.Add("tDebtor.DebtorIsInclPreInvCredLim", Type.GetType("System.String"));
			customerFinancialTable.Columns.Add("tDebtor.DebtorIsInclSOCredLim", Type.GetType("System.String"));
			customerFinancialTable.Columns.Add("tDebtor.DebtorIsInclDraftCredLim", Type.GetType("System.String"));
			customerFinancialTable.Columns.Add("tDebtor.DebtorIsCheckBefSOCredLim", Type.GetType("System.String"));
			customerFinancialTable.Columns.Add("tDebtor.DebtorIsCheckAftSOCredLim", Type.GetType("System.String"));
			customerFinancialTable.Columns.Add("tDebtor.DebtorIsCheckBefPICredLim", Type.GetType("System.String"));
			customerFinancialTable.Columns.Add("tDebtor.DebtorIsCheckAftPICredLim", Type.GetType("System.String"));
			customerFinancialTable.Columns.Add("tDebtor.DebtorIsCheckBefDICredLim", Type.GetType("System.String"));
			customerFinancialTable.Columns.Add("tDebtor.DebtorIsCheckAftDICredLim", Type.GetType("System.String"));
			customerFinancialTable.Columns.Add("tDebtor.DebtorPercWarningCredLim", Type.GetType("System.String"));
			customerFinancialTable.Columns.Add("tDebtor.DebtorIsOverruleSOCredLim", Type.GetType("System.String"));
			customerFinancialTable.Columns.Add("tDebtor.DebtorIsOverrulePICredLim", Type.GetType("System.String"));
			customerFinancialTable.Columns.Add("tDebtor.DebtorIsOverruleDICredLim", Type.GetType("System.String"));
			customerFinancialTable.Columns.Add("tDebtor.DebtorIsLockedCredLim", Type.GetType("System.String"));
			customerFinancialTable.Columns.Add("tDebtor.DebtorIsToBeLockedCredLim", Type.GetType("System.String"));
			customerFinancialTable.Columns.Add("tDebtor.DebtorIsWithPreInvGroup", Type.GetType("System.String"));
			customerFinancialTable.Columns.Add("tDebtor.DebtorIsGroupingSOOnPreInv", Type.GetType("System.String"));
			customerFinancialTable.Columns.Add("tDebtor.DebtorIsInvoiceByAuth", Type.GetType("System.String"));
			customerFinancialTable.Columns.Add("tDebtor.DebtorDBNumber", Type.GetType("System.String"));
			customerFinancialTable.Columns.Add("tDebtor.DebtorIsFinanceCharge", Type.GetType("System.String"));
			customerFinancialTable.Columns.Add("tDebtor.DebtorStatementCycle", Type.GetType("System.String"));
			customerFinancialTable.Columns.Add("tDebtor.DebtorLastPayment", Type.GetType("System.String"));
			customerFinancialTable.Columns.Add("tDebtor.DebtorLastSale", Type.GetType("System.String"));
			customerFinancialTable.Columns.Add("tDebtor.DebtorHighCredit", Type.GetType("System.String"));
			customerFinancialTable.Columns.Add("tDebtor.DebtorHighCreditDate", Type.GetType("System.String"));
			customerFinancialTable.Columns.Add("tDebtor.DebtorLastCreditReview", Type.GetType("System.String"));
			customerFinancialTable.Columns.Add("tDebtor.DebtorLastCreditUpdate", Type.GetType("System.String"));
			customerFinancialTable.Columns.Add("tDebtor.DebtorCommentNote", Type.GetType("System.String"));
			customerFinancialTable.Columns.Add("tDebtor.DebtorSalesOrderBalance", Type.GetType("System.String"));
			customerFinancialTable.Columns.Add("tDebtor.DebtorLastFinChargeDate", Type.GetType("System.String"));
			customerFinancialTable.Columns.Add("tDebtor.DebtorTotalDaysLate", Type.GetType("System.String"));
			customerFinancialTable.Columns.Add("tDebtor.DebtorTotalNbrOfInvoices", Type.GetType("System.String"));
			customerFinancialTable.Columns.Add("tDebtor.TxzTaxZone", Type.GetType("System.String"));
			customerFinancialTable.Columns.Add("tDebtor.TxclTaxCls", Type.GetType("System.String"));
			customerFinancialTable.Columns.Add("tDebtor.TxuTaxUsage", Type.GetType("System.String"));
			customerFinancialTable.Columns.Add("tDebtor.tlBusinessRelationIsInterco", Type.GetType("System.String"));
			customerFinancialTable.Columns.Add("tDebtor.tcNormalPaymentConditionType", Type.GetType("System.String"));
			customerFinancialTable.Columns.Add("tDebtor.tcInvControlGLProfileCode", Type.GetType("System.String"));
			customerFinancialTable.Columns.Add("tDebtor.tcCnControlGLProfileCode", Type.GetType("System.String"));
			customerFinancialTable.Columns.Add("tDebtor.tcFinanceChgProfileCode", Type.GetType("System.String"));
			customerFinancialTable.Columns.Add("tDebtor.tcDivisionProfileCode", Type.GetType("System.String"));
			customerFinancialTable.Columns.Add("tDebtor.tcSalesAccountGLProfileCode", Type.GetType("System.String"));
			customerFinancialTable.Columns.Add("tDebtor.tcPrepayControlGLProfileCode", Type.GetType("System.String"));
			customerFinancialTable.Columns.Add("tDebtor.tcBLWIGroupCode", Type.GetType("System.String"));
			customerFinancialTable.Columns.Add("tDebtor.tcNormalPaymentConditionCode", Type.GetType("System.String"));
			customerFinancialTable.Columns.Add("tDebtor.tcBusinessRelationName1", Type.GetType("System.String"));
			customerFinancialTable.Columns.Add("tDebtor.tcBusinessRelationCode", Type.GetType("System.String"));
			customerFinancialTable.Columns.Add("tDebtor.tcReasonCode", Type.GetType("System.String"));
			customerFinancialTable.Columns.Add("tDebtor.tcCurrencyCode", Type.GetType("System.String"));
			customerFinancialTable.Columns.Add("tDebtor.tcPaymentGroupCode", Type.GetType("System.String"));
			customerFinancialTable.Columns.Add("tDebtor.tcDebtorTypeCode", Type.GetType("System.String"));
			customerFinancialTable.Columns.Add("tDebtor.tcPreInvoiceGroupCode", Type.GetType("System.String"));
			customerFinancialTable.Columns.Add("tDebtor.tcBillToDebtorCode", Type.GetType("System.String"));
			customerFinancialTable.Columns.Add("tDebtor.tcDebtorCreditRatingCode", Type.GetType("System.String"));
			customerFinancialTable.Columns.Add("tDebtor.LastModifiedDate", Type.GetType("System.String"));
			customerFinancialTable.Columns.Add("tDebtor.LastModifiedTime", Type.GetType("System.String"));
			customerFinancialTable.Columns.Add("tDebtor.LastModifiedUser", Type.GetType("System.String"));
			customerFinancialTable.Columns.Add("tDebtorSafDefault.DebtorSafDefault_ID", Type.GetType("System.String"));
			customerFinancialTable.Columns.Add("tDebtorSafDefault.tcSafConceptCode", Type.GetType("System.String"));
			customerFinancialTable.Columns.Add("tDebtorSafDefault.tcSafCode", Type.GetType("System.String"));
			customerFinancialTable.Columns.Add("tDebtorSafDefault.LastModifiedDate", Type.GetType("System.String"));
			customerFinancialTable.Columns.Add("tDebtorSafDefault.LastModifiedTime", Type.GetType("System.String"));
			customerFinancialTable.Columns.Add("tDebtorSafDefault.LastModifiedUser", Type.GetType("System.String"));
			#endregion
			
			#region Intitulés des champs des clients finances
			row = customerFinancialTable.NewRow();
			
			row[0] = "Debtor_ID";
			row[1] = "Tax Nature";
			row[2] = "Customer Code";
			row[3] = "Active";
			row[4] = "Tax Level";
			row[5] = "Print Statement";
			row[6] = "Print Reminder";
			row[7] = "Domiciliation Number";
			row[8] = "Taxable Customer";
			row[9] = "Tax in City";
			row[10] = "Tax Is Included";
			row[11] = "Federal Tax";
			row[12] = "State Tax";
			row[13] = "Miscellaneous Tax 1";
			row[14] = "Miscellaneous Tax 2";
			row[15] = "Miscellaneous Tax 3";
			row[16] = "Tax Declaration";
			row[17] = "Apply Fixed Ceiling";
			row[18] = "Fixed Credit Limit";
			row[19] = "Apply % of Turnover";
			row[20] = "Percentage of Turnover";
			row[21] = "Maximum Days Overdue";
			row[22] = "Maximum Number of Days";
			row[23] = "Include Open Items";
			row[24] = "Include Pre-Invoices";
			row[25] = "Include Sales Orders";
			row[26] = "Include Drafts";
			row[27] = "Check before Sales Order Entry";
			row[28] = "Check after Sales Order Entry";
			row[29] = "Check before Pre-Invoice Entry";
			row[30] = "Check after Pre-Invoice Entry";
			row[31] = "Check before Customer Invoice Entry";
			row[32] = "Check after Customer Invoice Entry";
			row[33] = "Warning Ceiling  %";
			row[34] = "Overrule Allowed";
			row[35] = "Overrule Allowed";
			row[36] = "Overrule Allowed";
			row[37] = "Credit Hold";
			row[38] = "Credit Hold on Overrun";
			row[39] = "Customer is Member of Pre-Invoice Group";
			row[40] = "Group on Pre-Invoice";
			row[41] = "Invoice by Authorization";
			row[42] = "Credit Agency Ref";
			row[43] = "Finance Charge";
			row[44] = "Statement Cycle";
			row[45] = "Last Payment Date";
			row[46] = "Last Sale Date";
			row[47] = "High Credit";
			row[48] = "High Credit Date";
			row[49] = "Last Credit Review";
			row[50] = "Last Credit Update";
			row[51] = "Comment Note";
			row[52] = "Sales Order Balance";
			row[53] = "Last Finance Charge Date";
			row[54] = "Total Days Late";
			row[55] = "Nbr of paid Invoices";
			row[56] = "Tax Zone";
			row[57] = "Tax Class";
			row[58] = "Tax Usage";
			row[59] = "Intercompany";
			row[60] = "Cred Trm Type";
			row[61] = "Control GL Profile (Invoice)";
			row[62] = "Control GL Profile (Credit Note)";
			row[63] = "Finance Charge Profile";
			row[64] = "Sub-Account Profile";
			row[65] = "Sales Account GL Profile";
			row[66] = "Control GL Profile (Pre-payment)";
			row[67] = "BLWI Group";
			row[68] = "Cred Trm";
			row[69] = "Business Relation Name";
			row[70] = "Business Relation Code";
			row[71] = "Invoice Status Code";
			row[72] = "Curr";
			row[73] = "Payment Group";
			row[74] = "Customer Type";
			row[75] = "Group";
			row[76] = "Bill-To";
			row[77] = "Credit Rating";
			row[78] = "Modif Date";
			row[79] = "Modif Time";
			row[80] = "Modif User";
			row[81] = "DebtorSafDefault_ID";
			row[82] = "SAF Concept Code";
			row[83] = "SAF Code";
			row[84] = "Last Modified Date";
			row[85] = "Last Modified Time";
			row[86] = "Last Modified User";
			
			customerFinancialTable.Rows.Add(row);
			#endregion
			
			#region Chargement des clients finances
			foreach (DataRow rowCustomerFinancial in customerFinancial.Rows)
			{
				row = customerFinancialTable.NewRow();
				
				row[0] = "";
				row[1] = "SERVICE";
				row[2] = rowCustomerFinancial[0];
				row[3] = rowCustomerFinancial[1];
				row[4] = "NONE";
				row[5] = rowCustomerFinancial[17];
				row[6] = rowCustomerFinancial[16];
				row[7] = "0";
				row[8] = "yes";
				row[9] = rowCustomerFinancial[48];
				row[10] = "no";
				row[11] = rowCustomerFinancial[46];
				row[12] = "";
				row[13] = rowCustomerFinancial[47];
				row[14] = "";
				row[15] = "";
				row[16] = "0";
				row[17] = rowCustomerFinancial[27];
				row[18] = rowCustomerFinancial[28];
				row[19] = "no";
				row[20] = "0";
				row[21] = "no";
				row[22] = "0";
				row[23] = "yes";
				row[24] = "no";
				row[25] = "yes";
				row[26] = "no";
				row[27] = "yes";
				row[28] = "yes";
				row[29] = "no";
				row[30] = "no";
				row[31] = "yes";
				row[32] = "yes";
				row[33] = "80";
				row[34] = "yes";
				row[35] = "no";
				row[36] = "yes";
				row[37] = rowCustomerFinancial[32];
				row[38] = rowCustomerFinancial[31];
				row[39] = "no";
				row[40] = "no";
				row[41] = "no";
				row[42] = "";
				row[43] = "no";
				row[44] = "";
				row[45] = "";
				row[46] = "";
				row[47] = "";
				row[48] = "";
				row[49] = "";
				row[50] = "";
				row[51] = "";
				row[52] = "";
				row[53] = "";
				row[54] = "";
				row[55] = "";
				row[56] = rowCustomerFinancial[49];
				row[57] = "40";
				row[58] = rowCustomerFinancial[51];
				row[59] = "";
				row[60] = "";
				row[61] = rowCustomerFinancial[4];
				row[62] = rowCustomerFinancial[5];
				row[63] = rowCustomerFinancial[8];
				row[64] = "";
				row[65] = rowCustomerFinancial[7];
				row[66] = rowCustomerFinancial[6];
				row[67] = "";
				row[68] = "10110103";                                      // MANQUANT : "Cred Trm"; rowCustomerFinancial[11];
				row[69] = "";
				row[70] = rowCustomerFinancial[2];
				row[71] = rowCustomerFinancial[12];                        // ATTENTION : FORMAT INCORRECT CVS -> XLS : "Invoice Status Code";
				row[72] = rowCustomerFinancial[9];
				row[73] = "";
				row[74] = rowCustomerFinancial[10];
				row[75] = "";
				row[76] = "";                                              // MANQUANT : "Bill-To"; rowCustomerFinancial[3];
				row[77] = "";
				row[78] = "";
				row[79] = "";
				row[80] = "";
				row[81] = "";
				row[82] = "";
				row[83] = "";
				row[84] = "";
				row[85] = "";
				row[86] = "";
				
				customerFinancialTable.Rows.Add(row);				
			}
			#endregion
			
			Build.WriteCsvFromDataTable2(customerFinancialTable, "C:\\TEMP\\27.20.1.1_customers.txt");
			return customerFinancialTable;
		}
		
		public static System.Data.DataTable Write282011_Suppliers(System.Data.DataTable supplierFinancial)
		{
			System.Data.DataTable supplierFinancialTable = new System.Data.DataTable();
			DataRow row = null;
			
			#region Format du fichier des fournisseurs finances
			// Fournisseurs
			supplierFinancialTable.Columns.Add("tCreditor.CreditorIsActive", Type.GetType("System.String"));
			supplierFinancialTable.Columns.Add("tCreditor.CreditorCode", Type.GetType("System.String"));
			supplierFinancialTable.Columns.Add("tCreditor.VatDeliveryType", Type.GetType("System.String"));
			supplierFinancialTable.Columns.Add("tCreditor.VatPercentageLevel", Type.GetType("System.String"));
			supplierFinancialTable.Columns.Add("tCreditor.CreditorIsSendRemittance", Type.GetType("System.String"));
			supplierFinancialTable.Columns.Add("tCreditor.CreditorIsIndividualPaymnt", Type.GetType("System.String"));
			supplierFinancialTable.Columns.Add("tCreditor.CreditorIsTaxable", Type.GetType("System.String"));
			supplierFinancialTable.Columns.Add("tCreditor.CreditorIsTaxInCity", Type.GetType("System.String"));
			supplierFinancialTable.Columns.Add("tCreditor.CreditorIsTaxIncluded", Type.GetType("System.String"));
			supplierFinancialTable.Columns.Add("tCreditor.CreditorTaxIDFederal", Type.GetType("System.String"));
			supplierFinancialTable.Columns.Add("tCreditor.CreditorTaxIDState", Type.GetType("System.String"));
			supplierFinancialTable.Columns.Add("tCreditor.CreditorTaxIDMisc1", Type.GetType("System.String"));
			supplierFinancialTable.Columns.Add("tCreditor.CreditorTaxIDMisc2", Type.GetType("System.String"));
			supplierFinancialTable.Columns.Add("tCreditor.CreditorTaxIDMisc3", Type.GetType("System.String"));
			supplierFinancialTable.Columns.Add("tCreditor.CreditorTaxDeclaration", Type.GetType("System.String"));
			supplierFinancialTable.Columns.Add("tCreditor.CreditorIsTaxReport", Type.GetType("System.String"));
			supplierFinancialTable.Columns.Add("tCreditor.CreditorDBNumber", Type.GetType("System.String"));
			supplierFinancialTable.Columns.Add("tCreditor.CreditorCocNumber", Type.GetType("System.String"));
			supplierFinancialTable.Columns.Add("tCreditor.CreditorTIDNotice", Type.GetType("System.String"));
			supplierFinancialTable.Columns.Add("tCreditor.CreditorDebtorNumber", Type.GetType("System.String"));
			supplierFinancialTable.Columns.Add("tCreditor.CreditorIsTaxConfirmed", Type.GetType("System.String"));
			supplierFinancialTable.Columns.Add("tCreditor.CreditorCommentNote", Type.GetType("System.String"));
			supplierFinancialTable.Columns.Add("tCreditor.TxzTaxZone", Type.GetType("System.String"));
			supplierFinancialTable.Columns.Add("tCreditor.TxclTaxCls", Type.GetType("System.String"));
			supplierFinancialTable.Columns.Add("tCreditor.TxuTaxUsage", Type.GetType("System.String"));
			supplierFinancialTable.Columns.Add("tCreditor.tcNormalPaymentConditionCode", Type.GetType("System.String"));
			supplierFinancialTable.Columns.Add("tCreditor.tcInvControlGLProfileCode", Type.GetType("System.String"));
			supplierFinancialTable.Columns.Add("tCreditor.tcCnControlGLProfileCode", Type.GetType("System.String"));
			supplierFinancialTable.Columns.Add("tCreditor.tcDivisionProfileCode", Type.GetType("System.String"));
			supplierFinancialTable.Columns.Add("tCreditor.tcReasonCode", Type.GetType("System.String"));
			supplierFinancialTable.Columns.Add("tCreditor.tcBLWIGroupCode", Type.GetType("System.String"));
			supplierFinancialTable.Columns.Add("tCreditor.tlBusinessRelationIsInterco", Type.GetType("System.String"));
			supplierFinancialTable.Columns.Add("tCreditor.tcPaymentGroupCode", Type.GetType("System.String"));
			supplierFinancialTable.Columns.Add("tCreditor.tcBusinessRelationCode", Type.GetType("System.String"));
			supplierFinancialTable.Columns.Add("tCreditor.tcCurrencyCode", Type.GetType("System.String"));
			supplierFinancialTable.Columns.Add("tCreditor.tcCreditorTypeCode", Type.GetType("System.String"));
			supplierFinancialTable.Columns.Add("tCreditor.tcNormalPaymentConditionType", Type.GetType("System.String"));
			supplierFinancialTable.Columns.Add("tCreditor.tcPurchaseGLProfileCode", Type.GetType("System.String"));
			supplierFinancialTable.Columns.Add("tCreditor.tcBusinessRelationName1", Type.GetType("System.String"));
			supplierFinancialTable.Columns.Add("tCreditor.tcPurchaseTypeCode", Type.GetType("System.String"));
			supplierFinancialTable.Columns.Add("tCreditor.tcPrepayControlGLProfileCode", Type.GetType("System.String"));
			supplierFinancialTable.Columns.Add("tCreditor.LastModifiedDate", Type.GetType("System.String"));
			supplierFinancialTable.Columns.Add("tCreditor.LastModifiedTime", Type.GetType("System.String"));
			supplierFinancialTable.Columns.Add("tCreditor.LastModifiedUser", Type.GetType("System.String"));
			supplierFinancialTable.Columns.Add("tCreditorSafDefault.CreditorSafDefault_ID", Type.GetType("System.String"));
			supplierFinancialTable.Columns.Add("tCreditorSafDefault.tcSafConceptCode", Type.GetType("System.String"));
			supplierFinancialTable.Columns.Add("tCreditorSafDefault.tcSafCode", Type.GetType("System.String"));
			supplierFinancialTable.Columns.Add("tCreditorSafDefault.LastModifiedDate", Type.GetType("System.String"));
			supplierFinancialTable.Columns.Add("tCreditorSafDefault.LastModifiedTime", Type.GetType("System.String"));
			supplierFinancialTable.Columns.Add("tCreditorSafDefault.LastModifiedUser", Type.GetType("System.String"));
			#endregion
			
			#region Intitulés des champs des fournisseurs finances
			row = supplierFinancialTable.NewRow();
			
			row[0] = "Active";
			row[1] = "Supplier";
			row[2] = "Tax Nature";
			row[3] = "Tax Level";
			row[4] = "Send Remittance";
			row[5] = "Individual Payments";
			row[6] = "Taxable Supplier";
			row[7] = "Tax in City";
			row[8] = "Tax Is Included";
			row[9] = "Federal Tax";
			row[10] = "State Tax";
			row[11] = "Miscellaneous Tax 1";
			row[12] = "Miscellaneous Tax 2";
			row[13] = "Miscellaneous Tax 3";
			row[14] = "Tax Declaration";
			row[15] = "Tax Report";
			row[16] = "Credit Agency Reference";
			row[17] = "Chamber of Commerce Number";
			row[18] = "TID Notice";
			row[19] = "External Customer Number";
			row[20] = "Tax Confirmed";
			row[21] = "Comment Note";
			row[22] = "Tax Zone";
			row[23] = "Tax Class";
			row[24] = "Tax Usage";
			row[25] = "Credit Terms";
			row[26] = "Control GL Profile (Invoice)";
			row[27] = "Control GL Profile (Credit Note)";
			row[28] = "Sub-Account Profile";
			row[29] = "Invoice Status Code";
			row[30] = "BLWI Group";
			row[31] = "Intercompany";
			row[32] = "Payment Group";
			row[33] = "Business Relation";
			row[34] = "Curr";
			row[35] = "Supplier Type";
			row[36] = "Cred Trm Type";
			row[37] = "Purchases Account GL Profile";
			row[38] = "Name";
			row[39] = "Purchase Type";
			row[40] = "Control GL Profile (Pre-payment)";
			row[41] = "Modif Date";
			row[42] = "Modif Time";
			row[43] = "Modif User";
			row[44] = "CreditorSafDefault_ID";
			row[45] = "SAF Concept Code";
			row[46] = "SAF Code";
			row[47] = "Last Modified Date";
			row[48] = "Last Modified Time";
			row[49] = "Last Modified User";
			
			supplierFinancialTable.Rows.Add(row);
			#endregion
			
			#region Chargement des fournisseurs finances
			foreach (DataRow rowSupplierFinancial in supplierFinancial.Rows)
			{
				row = supplierFinancialTable.NewRow();
				
				row[0] = rowSupplierFinancial[2];
				row[1] = rowSupplierFinancial[0];
				row[2] = "SERVICE";
				row[3] = "NONE";
				row[4] = "no";
				row[5] = rowSupplierFinancial[12];
				row[6] = "no";
				row[7] = rowSupplierFinancial[21];
				row[8] = rowSupplierFinancial[22];
				row[9] = rowSupplierFinancial[20];
				row[10] = "";
				row[11] = "";
				row[12] = "";
				row[13] = "";
				row[14] = "0";
				row[15] = "no";
				row[16] = "";
				row[17] = "";
				row[18] = "";
				row[19] = "";
				row[20] = "no";
				row[21] = "";
				row[22] = rowSupplierFinancial[23];
				row[23] = "40";                         // rowSupplierFinancial[24];
				row[24] = "";
				row[25] = "10110103";                   // MANQUANT : "Cred Trm";  rowSupplierFinancial[10];
 				row[26] = rowSupplierFinancial[3];
				row[27] = rowSupplierFinancial[4];
				row[28] = "";
				row[29] = rowSupplierFinancial[11];
				row[30] = "";
				row[31] = "no";
				row[32] = "";
				row[33] = rowSupplierFinancial[1];
				row[34] = rowSupplierFinancial[8];
				row[35] = rowSupplierFinancial[9];
				row[36] = "NORMAL";
				row[37] = rowSupplierFinancial[6];
				row[38] = "";
				row[39] = "";
				row[40] = rowSupplierFinancial[5];
				row[41] = "";
				row[42] = "";
				row[43] = "";
				row[44] = "";
				row[45] = "";
				row[46] = "";
				row[47] = "";
				row[48] = "";
				row[49] = "";
				
				supplierFinancialTable.Rows.Add(row);				
			}
			#endregion
			
			Build.WriteCsvFromDataTable2(supplierFinancialTable, "C:\\TEMP\\28.20.1.1_suppliers.txt");
			return supplierFinancialTable;
		}
		
		public static System.Data.DataTable Write211_Customers(System.Data.DataTable customer)
		{
			System.Data.DataTable customerTable = new System.Data.DataTable();
			DataRow row = null;
			
			#region Format du fichier des clients
			// Clients
			customerTable.Columns.Add("cm_addr", Type.GetType("System.String"));
			customerTable.Columns.Add("cm_slspsn", Type.GetType("System.String"));
			customerTable.Columns.Add("mult_slspsn", Type.GetType("System.String"));
			customerTable.Columns.Add("cm_shipvia", Type.GetType("System.String"));
			customerTable.Columns.Add("cm_resale", Type.GetType("System.String"));
			customerTable.Columns.Add("cm_rmks", Type.GetType("System.String"));
			customerTable.Columns.Add("cm_region", Type.GetType("System.String"));
			customerTable.Columns.Add("cm_site", Type.GetType("System.String"));
			customerTable.Columns.Add("cm_slspsn1", Type.GetType("System.String"));
			customerTable.Columns.Add("cm_slspsn2", Type.GetType("System.String"));
			customerTable.Columns.Add("cm_slspsn3", Type.GetType("System.String"));
			customerTable.Columns.Add("cm_slspsn4", Type.GetType("System.String"));
			customerTable.Columns.Add("cm_partial", Type.GetType("System.String"));
			customerTable.Columns.Add("cm_pr_list", Type.GetType("System.String"));
			customerTable.Columns.Add("cm_fix_pr", Type.GetType("System.String"));
			customerTable.Columns.Add("cm_daybookset", Type.GetType("System.String"));
			customerTable.Columns.Add("cm_class", Type.GetType("System.String"));
			customerTable.Columns.Add("cm_sic", Type.GetType("System.String"));
			customerTable.Columns.Add("cm_rss_cal_option", Type.GetType("System.String"));
			customerTable.Columns.Add("ad_timezone", Type.GetType("System.String"));
			customerTable.Columns.Add("cm_po_reqd", Type.GetType("System.String"));
			customerTable.Columns.Add("cm_disc_pct", Type.GetType("System.String"));
			customerTable.Columns.Add("cm_fr_list", Type.GetType("System.String"));
			customerTable.Columns.Add("cm_fr_min_wt", Type.GetType("System.String"));
			customerTable.Columns.Add("cm_fr_terms", Type.GetType("System.String"));
			customerTable.Columns.Add("btb_type", Type.GetType("System.String"));
			customerTable.Columns.Add("cm_ship_lt", Type.GetType("System.String"));
			customerTable.Columns.Add("cm_btb_mthd", Type.GetType("System.String"));
			customerTable.Columns.Add("cm_btb_cr", Type.GetType("System.String"));
			customerTable.Columns.Add("xxcm_structure", Type.GetType("System.String"));
			customerTable.Columns.Add("xxcm_fob", Type.GetType("System.String"));
			customerTable.Columns.Add("xxcm_charge", Type.GetType("System.String"));
			customerTable.Columns.Add("xxcm_ord_rec", Type.GetType("System.String"));
			customerTable.Columns.Add("xxcm_fax_mail", Type.GetType("System.String"));
			customerTable.Columns.Add("xxcm_copy_inv", Type.GetType("System.String"));
			customerTable.Columns.Add("xxcm_catalog", Type.GetType("System.String"));
			customerTable.Columns.Add("xxcm_safari", Type.GetType("System.String"));
			customerTable.Columns.Add("xxcm_bo_perm", Type.GetType("System.String"));
			customerTable.Columns.Add("xxcm_bo_season", Type.GetType("System.String"));
			customerTable.Columns.Add("xxcm_perm", Type.GetType("System.String"));
			customerTable.Columns.Add("xxcm_season", Type.GetType("System.String"));
			#endregion
			
			#region Chargement des clients
			foreach (DataRow rowCustomer in customer.Rows)
			{
				row = customerTable.NewRow();
				
				#region Données clients
				row[0] = rowCustomer[0];          // cm_addr
				row[1] = rowCustomer[2];          // cm_slspsn
				row[2] = rowCustomer[3];          // mult_slspsn
				row[3] = rowCustomer[4];          // cm_shipvia
				row[4] = rowCustomer[5];          // cm_resale
				row[5] = rowCustomer[6];          // cm_rmks
				row[6] = rowCustomer[7];          // cm_region
				row[7] = rowCustomer[8];          // cm_site
				row[8] = rowCustomer[2];          // cm_slspsn1
				row[9] = rowCustomer[21];         // cm_slspsn2
				row[10] = rowCustomer[22];        // cm_slspsn3
				row[11] = rowCustomer[23];        // cm_slspsn4
				row[12] = rowCustomer[24];        // cm_partial
				row[13] = System.DBNull.Value;    // cm_pr_list
				row[14] = rowCustomer[25];        // cm_fix_pr
				row[15] = "VENTES";               // cm_daybookset
				row[16] = rowCustomer[26];        // cm_class
				row[17] = "";                     // cm_sic
				row[18] = "1";                    // cm_rss_cal_option
				row[19] = System.DBNull.Value;    // ad_timezone
				row[20] = rowCustomer[27];        // cm_po_reqd
				row[21] = System.DBNull.Value;    // cm_disc_pct
				row[22] = System.DBNull.Value;    // cm_fr_list
				row[23] = System.DBNull.Value;    // cm_fr_min_wt
				row[24] = rowCustomer[11];        // cm_fr_terms
				row[25] = System.DBNull.Value;    // btb_type
				row[26] = System.DBNull.Value;    // cm_ship_lt
				row[27] = System.DBNull.Value;    // cm_btb_mthd
				row[28] = System.DBNull.Value;    // cm_btb_cr
				row[29] = GetValue(rowCustomer[9], "");         // xxcm_structure
				row[30] = GetValue(rowCustomer[10], "");        // xxcm_fob
				row[31] = "";                     // xxcm_charge
				row[32] = "";                     // xxcm_ord_rec
				row[33] = System.DBNull.Value;    // xxcm_fax_mail
				row[34] = System.DBNull.Value;    // xxcm_copy_inv
				row[35] = rowCustomer[15];        // xxcm_catalog
				row[36] = rowCustomer[16];        // xxcm_safari
				row[37] = GetValue(rowCustomer[17], "");        // xxcm_bo_perm
				row[38] = GetValue(rowCustomer[18], "");        // xxcm_bo_season
				row[39] = rowCustomer[19];        // xxcm_perm
				row[40] = rowCustomer[20];        // xxcm_season
				#endregion
				
				customerTable.Rows.Add(row);
			}
			#endregion
			
			Build.WriteCsvFromDataTable(customerTable, "C:\\TEMP\\2.1.1_customers.csv");
			return customerTable;
		}
		
		public static System.Data.DataTable Write231_Suppliers(System.Data.DataTable supplier, System.Data.DataTable supplierV9)
		{
			System.Data.DataTable supplierTable = new System.Data.DataTable();
			DataRow row = null;
			
			#region Format du fichier des fournisseurs
			// Fournisseurs
			supplierTable.Columns.Add("vd_addr", Type.GetType("System.String"));
			supplierTable.Columns.Add("vd_shipvia", Type.GetType("System.String"));
			supplierTable.Columns.Add("vd_rmks", Type.GetType("System.String"));
			supplierTable.Columns.Add("vd_carrier_id", Type.GetType("System.String"));
			supplierTable.Columns.Add("vd_kanban_supplier", Type.GetType("System.String"));
			supplierTable.Columns.Add("vd_pur_cntct", Type.GetType("System.String"));
			supplierTable.Columns.Add("vd_promo", Type.GetType("System.String"));
			supplierTable.Columns.Add("vd_buyer", Type.GetType("System.String"));
			supplierTable.Columns.Add("vd_pr_list2", Type.GetType("System.String"));
			supplierTable.Columns.Add("vd_pr_list", Type.GetType("System.String"));
			supplierTable.Columns.Add("vd_fix_pr", Type.GetType("System.String"));
			supplierTable.Columns.Add("vd_rcv_so_price", Type.GetType("System.String"));
			supplierTable.Columns.Add("vd_rcv_held_so", Type.GetType("System.String"));
			supplierTable.Columns.Add("emt_auto", Type.GetType("System.String"));
			supplierTable.Columns.Add("vd__qadl01", Type.GetType("System.String"));
			supplierTable.Columns.Add("vd_tp_pct", Type.GetType("System.String"));
			supplierTable.Columns.Add("vd_tp_use_pct", Type.GetType("System.String"));
			supplierTable.Columns.Add("vd_partial", Type.GetType("System.String"));
			supplierTable.Columns.Add("vd_disc_pct", Type.GetType("System.String"));
			#endregion
			
			#region Chargement des fournisseurs
			foreach (DataRow rowSupplier in supplier.Rows)
			{
				row = supplierTable.NewRow();
				
				#region Données fournisseur
				row[0] = rowSupplier[0];          // vd_addr
				row[1] = "";                      // vd_shipvia
				row[2] = "";                      // vd_rmks
				row[3] = "";                      // vd_carrier_id
				row[4] = "no";                    // vd_kanban_supplier
				row[5] = "";                      // vd_pur_cntct
				row[6] = "";                      // vd_promo
				row[7] = "";                      // vd_buyer
				row[8] = "";                      // vd_pr_list2
				row[9] = "";                      // vd_pr_list
				row[10] = "yes";                  // vd_fix_pr
				row[11] = "no";                   // vd_rcv_so_price
				row[12] = "no";                   // vd_rcv_held_so
				row[13] = "no";                   // emt_auto
				row[14] = "no";                   // vd__qadl01
				row[15] = "0";                    // vd_tp_pct
				row[16] = "no";                   // vd_tp_use_pct
				row[17] = "yes";                  // vd_partial
				row[18] = "0";                    // vd_disc_pct
				#endregion
				
				supplierTable.Rows.Add(row);
			}
			#endregion
			
			Build.WriteCsvFromDataTable(supplierTable, "C:\\TEMP\\2.3.1_suppliers.csv");
			return supplierTable;
		}
		
		public static System.Data.DataTable Write181_Customers(System.Data.DataTable customerTree)
		{
			System.Data.DataTable customerTreeTable = new System.Data.DataTable();
			// DataRow row = null;
			
			// A COMPLETER
			
			Build.WriteCsvFromDataTable(customerTreeTable, "C:\\TEMP\\1.8.1_customers.csv");
			return customerTreeTable;
		}
			
		public static System.Data.DataTable Write272021_Customers(System.Data.DataTable customerDelivery)
		{
			System.Data.DataTable customerDeliveryTable = new System.Data.DataTable();
			//DataRow row = null;
			
			// A COMPLETER
			
			Build.WriteCsvFromDataTable2(customerDeliveryTable, "C:\\TEMP\\27.20.2.1_customers.txt");
			return customerDeliveryTable;
		}
		
		/// <summary>
		/// Chargement des liens article - client - site
		/// </summary>
		/// <param name="customerItem"></param>
		/// <returns></returns>
		public static System.Data.DataTable Write115_Customers(System.Data.DataTable customerItem)
		{
			System.Data.DataTable customerItemTable = new System.Data.DataTable();
			DataRow row = null;
			
			#region Format du fichier des liens article - client - site
			// Liens article - client - site
			customerItemTable.Columns.Add("xxcp_cust", Type.GetType("System.String"));
			customerItemTable.Columns.Add("xxcp_cust_part", Type.GetType("System.String"));
			customerItemTable.Columns.Add("xxcp_start", Type.GetType("System.String"));
			customerItemTable.Columns.Add("xxcp_part", Type.GetType("System.String"));
			customerItemTable.Columns.Add("xxcp_ship_site", Type.GetType("System.String"));
			customerItemTable.Columns.Add("xxcp_ship_whse", Type.GetType("System.String"));
			customerItemTable.Columns.Add("l_start", Type.GetType("System.String"));
			customerItemTable.Columns.Add("l_end", Type.GetType("System.String"));
			customerItemTable.Columns.Add("xxcp_diff", Type.GetType("System.String"));
			customerItemTable.Columns.Add("xxcp_comment", Type.GetType("System.String"));
			customerItemTable.Columns.Add("xxcp_cust_partd", Type.GetType("System.String"));
			customerItemTable.Columns.Add("xxcp_cust_eco", Type.GetType("System.String"));
			#endregion
			
			#region Chargement des liens article - client
			foreach (DataRow rowCustomerItem in customerItem.Rows)
			{
				row = customerItemTable.NewRow();
				
				#region Données clients
				row[0] = rowCustomerItem[0];          // xxcp_cust
				row[1] = rowCustomerItem[1];          // xxcp_cust_part
				row[2] = "";                          // xxcp_start
				row[3] = rowCustomerItem[2];          // xxcp_part
				row[4] = "";                          // xxcp_ship_site
				row[5] = "";                          // xxcp_ship_whse
				row[6] = "";                          // l_start
				row[7] = "";                          // l_end
				row[8] = System.DBNull.Value;         // xxcp_diff
				row[9] = "";                          // xxcp_comment
				row[10] = "";                         // xxcp_cust_partd
				row[11] = "";                         // xxcp_cust_eco
				#endregion
				
				customerItemTable.Rows.Add(row);
			}
			#endregion
			
			Build.WriteCsvFromDataTable(customerItemTable, "C:\\TEMP\\1.15_customers.csv");
			return customerItemTable;
		}
		
		/// <summary>
		/// Chargement des paramètres généraux - client
		/// </summary>
		/// <param name="customerGeneralParams"></param>
		/// <param name="customer"></param>
		/// <returns></returns>
		public static System.Data.DataTable Write36213_Customers(System.Data.DataTable customerGeneralParams, System.Data.DataTable customer)
		{
			System.Data.DataTable customerGeneralParamsTable = new System.Data.DataTable();
			
			#region Format du fichier des paramètres généraux
			// Paramètres généraux
			customerGeneralParamsTable.Columns.Add("code_fldname", Type.GetType("System.String"));
			customerGeneralParamsTable.Columns.Add("code_value", Type.GetType("System.String"));
			customerGeneralParamsTable.Columns.Add("code_cmmt", Type.GetType("System.String"));
			#endregion
			
			#region Chargement des paramètres généraux : cm_shipvia / cm_region / cm_class / xxcm_structure / xxcm_fob / xxcm_charge / xxcm_ord_rec / xxcm_bo_perm / xxcm_bo_season
			foreach (DataRow rowCustomer in customer.Rows)
			{
				Build.AddGeneral("cm_shipvia", rowCustomer[3], ref customerGeneralParamsTable);
				Build.AddGeneral("cm_region", rowCustomer[6], ref customerGeneralParamsTable);
				Build.AddGeneral("cm_class", rowCustomer[16], ref customerGeneralParamsTable);
				Build.AddGeneral("xxcm_structure", rowCustomer[29], ref customerGeneralParamsTable);
				Build.AddGeneral("xxcm_fob", rowCustomer[30], ref customerGeneralParamsTable);
				Build.AddGeneral("xxcm_charge", rowCustomer[31], ref customerGeneralParamsTable);
				Build.AddGeneral("xxcm_ord_rec", rowCustomer[32], ref customerGeneralParamsTable);
				Build.AddGeneral("xxcm_bo_perm", rowCustomer[37], ref customerGeneralParamsTable);
				Build.AddGeneral("xxcm_bo_season", rowCustomer[38], ref customerGeneralParamsTable);
			}
			#endregion
	
			Build.WriteCsvFromDataTable(customerGeneralParamsTable, "C:\\TEMP\\36.2.13_customers.csv");
			return customerGeneralParamsTable;
		}
		
		/// <summary>
		/// Chargement des paramètres généraux - fournisseur
		/// </summary>
		/// <param name="supplierGeneralParams"></param>
		/// <param name="supplier"></param>
		/// <param name="supplierV9"></param>
		/// <returns></returns>
		public static System.Data.DataTable Write36213_Suppliers(System.Data.DataTable supplierGeneralParams, System.Data.DataTable supplier, System.Data.DataTable supplierV9)
		{
			System.Data.DataTable supplierGeneralParamsTable = new System.Data.DataTable();
			//DataRow row = null;
			
			// A COMPLETER
			Build.WriteCsvFromDataTable(supplierGeneralParamsTable, "C:\\TEMP\\36.2.13_suppliers.csv");
			return supplierGeneralParamsTable;
		}
		
		/// <summary>
		/// Chargement des gammes
		/// </summary>
		/// <param name="routing"></param>
		/// <param name="routingV9"></param>
		/// <returns></returns>
		public static System.Data.DataTable Write14131_Routing(System.Data.DataTable routing, System.Data.DataTable routingV9)
		{
			System.Data.DataTable routingTable = new System.Data.DataTable();
			DataRow row = null;
			
			#region Format du fichier des gammes
			// Gammes
			routingTable.Columns.Add("ro_routing", Type.GetType("System.String"));
			routingTable.Columns.Add("ro_op", Type.GetType("System.Int32"));
			routingTable.Columns.Add("ro_start", Type.GetType("System.String"));
			routingTable.Columns.Add("ro_std_op", Type.GetType("System.String")); //
			routingTable.Columns.Add("ro_wkctr", Type.GetType("System.String"));
			routingTable.Columns.Add("ro_mch", Type.GetType("System.String"));
			routingTable.Columns.Add("ro_desc", Type.GetType("System.String"));
			routingTable.Columns.Add("ro_mch_op", Type.GetType("System.Int32"));
			routingTable.Columns.Add("ro_tran_qty", Type.GetType("System.Int32"));
			routingTable.Columns.Add("ro_queue", Type.GetType("System.Double"));
			routingTable.Columns.Add("ro_wait", Type.GetType("System.Double"));
			routingTable.Columns.Add("ro_milestone", Type.GetType("System.String"));
			routingTable.Columns.Add("ro_sub_lead", Type.GetType("System.Int32"));
			routingTable.Columns.Add("ro_setup_men", Type.GetType("System.Double"));
			routingTable.Columns.Add("ro_men_mch", Type.GetType("System.Double"));
			routingTable.Columns.Add("ro_setup", Type.GetType("System.Double"));
			routingTable.Columns.Add("ro_run", Type.GetType("System.Double"));
			routingTable.Columns.Add("ro_move", Type.GetType("System.Double"));
			routingTable.Columns.Add("rostart", Type.GetType("System.String"));
			routingTable.Columns.Add("roend", Type.GetType("System.String"));
			routingTable.Columns.Add("ro_yield_pct", Type.GetType("System.Double"));
			routingTable.Columns.Add("ro_tool", Type.GetType("System.String"));
			routingTable.Columns.Add("ro_vend", Type.GetType("System.String"));
			routingTable.Columns.Add("ro_inv_value", Type.GetType("System.Double"));
			routingTable.Columns.Add("ro_sub_cost", Type.GetType("System.Double"));
			routingTable.Columns.Add("rocmmts", Type.GetType("System.String"));
			routingTable.Columns.Add("ro_wipmtl_part", Type.GetType("System.String"));
			routingTable.Columns.Add("ro_mv_nxt_op", Type.GetType("System.String"));
			routingTable.Columns.Add("ro_auto_lbr", Type.GetType("System.String"));
			#endregion
			
			#region Chargement des gammes
			foreach (DataRow rowRouting in routing.Rows)
			{
				row = routingTable.NewRow();
				
				#region Données gammes
				row[0] = rowRouting[0];                           // ro_routing
				row[1] = rowRouting[1];                           // ro_op
				row[2] = System.DBNull.Value;                     // ro_start
				row[3] = "";                                      // ro_std_op
				row[4] = rowRouting[3];                           // ro_wkctr
				row[5] = rowRouting[4];                           // ro_mch
				row[6] = GetValue(rowRouting[5], 24);             // ro_desc
				row[7] = rowRouting[6];                           // ro_mch_op
				row[8] = rowRouting[8];                           // ro_tran_qty
				row[9] = System.DBNull.Value;                     // ro_queue
				row[10] = System.DBNull.Value;                     // ro_wait
				row[11] = rowRouting[7];                          // ro_milestone
				row[12] = rowRouting[9];                          // ro_sub_lead
				row[13] = rowRouting[10];                         // ro_setup_men
				row[14] = rowRouting[11];                         // ro_men_mch
				row[15] = System.DBNull.Value;                    // ro_setup
				row[16] = rowRouting[12];                         // ro_run
				row[17] = System.DBNull.Value;                    // ro_move
				row[18] = System.DBNull.Value;                    // rostart
				row[19] = System.DBNull.Value;                    // roend
				row[20] = System.DBNull.Value;                    // ro_yield_pct
				row[21] = System.DBNull.Value;                    // ro_tool
				row[22] = System.DBNull.Value;                    // ro_vend
				row[23] = System.DBNull.Value;                    // ro_inv_value
				row[24] = rowRouting[13];                         // ro_sub_cost
				row[25] = "no";                                   // rocmmts
				row[26] = System.DBNull.Value;                    // ro_wipmtl_part
				row[27] = System.DBNull.Value;                    // ro_mv_nxt_op
				row[28] = System.DBNull.Value;                    // ro_auto_lbr
				#endregion
				
				routingTable.Rows.Add(row);
			}
			#endregion
			
			#region Chargement des gammes V9
			foreach (DataRow rowRouting in routingV9.Rows)
			{
				row = routingTable.NewRow();
				
				#region Données gammes V9
				row[0] = rowRouting[0];                      // ro_routing
				row[1] = rowRouting[1];                      // ro_op
				row[2] = System.DBNull.Value;                // ro_start
				row[3] = "";                                 // ro_std_op
				row[4] = rowRouting[4];                      // ro_wkctr
				row[5] = rowRouting[5];                      // ro_mch
				row[6] = GetValue(rowRouting[6], 24);        // ro_desc
				row[7] = rowRouting[7];                      // ro_mch_op
				row[8] = rowRouting[8];                      // ro_tran_qty
				row[9] = rowRouting[9];                      // ro_queue
				row[10] = rowRouting[10];                     // ro_wait
				row[11] = rowRouting[11];                    // ro_milestone
				row[12] = rowRouting[12];                    // ro_sub_lead
				row[13] = rowRouting[13];                    // ro_setup_men
				row[14] = rowRouting[14];                    // ro_men_mch
				row[15] = rowRouting[15];                    // ro_setup
				row[16] = rowRouting[16];                    // ro_run
				row[17] = rowRouting[17];                    // ro_move
				row[18] = System.DBNull.Value;               // rostart
				row[19] = System.DBNull.Value;               // roend
				row[20] = rowRouting[18];                    // ro_yield_pct
				row[21] = rowRouting[19];                    // ro_tool
				row[22] = rowRouting[20];                    // ro_vend
				row[23] = rowRouting[21];                    // ro_inv_value
				row[24] = rowRouting[22];                    // ro_sub_cost
				row[25] = "no";                              // rocmmts
				row[26] = rowRouting[23];                    // ro_wipmtl_part
				row[27] = rowRouting[26];                    // ro_mv_nxt_op
				row[28] = rowRouting[27];                    // ro_auto_lbr
				#endregion
				
				routingTable.Rows.Add(row);
			}
			#endregion
			
			Build.WriteCsvFromDataTable(routingTable, "C:\\TEMP\\14.13.1_routing.csv");
			return routingTable;
		}
		
		/// <summary>
		/// Chargement des codes nomenclature
		/// </summary>
		/// <param name="codeProdStruct"></param>
		/// <param name="codeProdStructV9"></param>
		/// <returns></returns>
		public static System.Data.DataTable Write131_CodeProdStruct(System.Data.DataTable codeProdStruct, System.Data.DataTable codeProdStructV9, System.Data.DataTable item)
		{
			System.Data.DataTable codeProdStructTable = new System.Data.DataTable();
			DataRow row = null;
			
			#region Format du fichier des codes nomenclature
			// Codes nomenclature
			codeProdStructTable.Columns.Add("bom_parent", Type.GetType("System.String"));
			codeProdStructTable.Columns.Add("bomdesc", Type.GetType("System.String"));
			codeProdStructTable.Columns.Add("bom_batch_um", Type.GetType("System.String"));
			codeProdStructTable.Columns.Add("cmmts", Type.GetType("System.String"));
			#endregion		
			
			#region Chargement des codes nomenclature
			foreach (DataRow rowCodeProdStruct in codeProdStruct.Rows)
			{
				row = codeProdStructTable.NewRow();
				
				#region Données codes nomenclature
				row[0] = rowCodeProdStruct[0];                      // bom_parent
				row[1] = rowCodeProdStruct[1];                      // bomdesc
				row[2] = rowCodeProdStruct[2];                      // bom_batch_um
				row[3] = "no";                                      // cmmts
				#endregion
				
				codeProdStructTable.Rows.Add(row);
			}
			#endregion
			
			#region Chargement des codes nomenclature V9
			foreach (DataRow rowCodeProdStruct in codeProdStructV9.Rows)
			{
				row = codeProdStructTable.NewRow();
				
				#region Données codes nomenclature V9
				row[0] = rowCodeProdStruct[0];                      // bom_parent
				row[1] = rowCodeProdStruct[1];                      // bomdesc
				row[2] = rowCodeProdStruct[2];                      // bom_batch_um
				row[3] = "no";                                      // cmmts
				#endregion
				
				codeProdStructTable.Rows.Add(row);
			}
			#endregion
			
			Build.WriteCsvFromDataTable(codeProdStructTable, "C:\\TEMP\\13.1_code_prod_struct.csv");
			return codeProdStructTable;
		}
		
		/// <summary>
		/// Chargement des nomenclatures
		/// </summary>
		/// <param name="prodStruct"></param>
		/// <param name="prodStructV9"></param>
		/// <returns></returns>
		public static System.Data.DataTable Write135_ProdStruct(System.Data.DataTable prodStruct, System.Data.DataTable prodStructV9)
		{
			System.Data.DataTable prodStructTable = new System.Data.DataTable();
			DataRow row = null;
			
			#region Format du fichier des nomenclatures
			// Nomenclatures
			prodStructTable.Columns.Add("ps_par", Type.GetType("System.String"));
			prodStructTable.Columns.Add("ps_comp", Type.GetType("System.String"));
			prodStructTable.Columns.Add("ps_ref", Type.GetType("System.String"));
			prodStructTable.Columns.Add("ps_start", Type.GetType("System.String"));
			prodStructTable.Columns.Add("ps_qty_per", Type.GetType("System.Double"));
			prodStructTable.Columns.Add("ps_ps_code", Type.GetType("System.String"));
			prodStructTable.Columns.Add("psstart", Type.GetType("System.String"));
			prodStructTable.Columns.Add("psend", Type.GetType("System.String"));
			prodStructTable.Columns.Add("ps_rmks", Type.GetType("System.String"));
			prodStructTable.Columns.Add("ps_scrp_pct", Type.GetType("System.Double"));
			prodStructTable.Columns.Add("ps_lt_off", Type.GetType("System.String"));
			prodStructTable.Columns.Add("ps_op", Type.GetType("System.Int32"));
			prodStructTable.Columns.Add("ps_item_no", Type.GetType("System.Int32"));
			prodStructTable.Columns.Add("ps_fcst_pct", Type.GetType("System.Double"));
			prodStructTable.Columns.Add("ps_group", Type.GetType("System.String"));
			prodStructTable.Columns.Add("ps_process", Type.GetType("System.String"));
			#endregion
			
			#region Chargement des nomenclatures
			foreach (DataRow rowProdStruct in prodStruct.Rows)
			{
				row = prodStructTable.NewRow();
				
				#region Données nomenclatures
				row[0] = rowProdStruct[0];                      // ps_par
				row[1] = rowProdStruct[1];                      // ps_comp
				row[2] = "";                                    // ps_ref
				row[3] = System.DBNull.Value;                   // ps_start
				row[4] = rowProdStruct[2];                      // ps_qty_per
				row[5] = "";                                    // ps_ps_code
				row[6] = System.DBNull.Value;                   // psstart
				row[7] = System.DBNull.Value;                   // psend
				row[8] = "";                                    // ps_rmks
				row[9] = rowProdStruct[3];                      // ps_scrp_pct
				row[10] = "";                                   // ps_lt_off
				row[11] = "10";                                 // ps_op
				row[12] = rowProdStruct[4];                     // ps_item_no
				row[13] = System.DBNull.Value;                  // ps_fcst_pct
				row[14] = "";                                   // ps_group
				row[15] = "";                                   // ps_process
				#endregion
				
				prodStructTable.Rows.Add(row);
			}
			#endregion
			
			#region Chargement des nomenclatures V9
			foreach (DataRow rowProdStruct in prodStructV9.Rows)
			{
				row = prodStructTable.NewRow();
				
				#region Données nomenclatures V9
				row[0] = rowProdStruct[0];                      // ps_par
				row[1] = rowProdStruct[1];                      // ps_comp
				row[2] = rowProdStruct[2];                      // ps_ref
				row[3] = System.DBNull.Value;                   // ps_start
				row[4] = rowProdStruct[5];                      // ps_qty_per
				row[5] = "";                                    // ps_ps_code
				row[6] = System.DBNull.Value;                   // psstart
				row[7] = System.DBNull.Value;                   // psend
				row[8] = rowProdStruct[7];                      // ps_rmks
				row[9] = rowProdStruct[8];                      // ps_scrp_pct
				row[10] = rowProdStruct[9];                     // ps_lt_off
				row[11] = rowProdStruct[10];                    // ps_op
				row[12] = rowProdStruct[11];                    // ps_item_no
				row[13] = rowProdStruct[12];                    // ps_fcst_pct
				row[14] = rowProdStruct[13];                    // ps_group
				row[15] = rowProdStruct[14];                    // ps_process
				#endregion
				
				prodStructTable.Rows.Add(row);
			}
			#endregion
			
			Build.WriteCsvFromDataTable(prodStructTable, "C:\\TEMP\\13.5_prod_struct.csv");
			return prodStructTable;
		}
			
		public static System.Data.DataTable Write145_WorkCenter(System.Data.DataTable workCenter, System.Data.DataTable workCenterV9)
		{
			System.Data.DataTable workCenterTable = new System.Data.DataTable();
			DataRow row = null;
			
			#region Format du fichier des centres de charge
			// Centres de charge
			workCenterTable.Columns.Add("wc_wkctr", Type.GetType("System.String"));
			workCenterTable.Columns.Add("wc_mch", Type.GetType("System.String"));
			workCenterTable.Columns.Add("wc_desc", Type.GetType("System.String"));
			workCenterTable.Columns.Add("wc_dept", Type.GetType("System.String"));
			workCenterTable.Columns.Add("wc_queue", Type.GetType("System.String"));
			workCenterTable.Columns.Add("wc_wait", Type.GetType("System.String"));
			workCenterTable.Columns.Add("wc_mch_op", Type.GetType("System.String"));
			workCenterTable.Columns.Add("wc_setup_men", Type.GetType("System.String"));
			workCenterTable.Columns.Add("wc_men_mch", Type.GetType("System.String"));
			workCenterTable.Columns.Add("wc_mch_wkctr", Type.GetType("System.String"));
			workCenterTable.Columns.Add("wc_mch_bdn", Type.GetType("System.String"));
			workCenterTable.Columns.Add("wc_setup_rte", Type.GetType("System.String"));
			workCenterTable.Columns.Add("wc_lbr_rate", Type.GetType("System.String"));
			workCenterTable.Columns.Add("wc_bdn_rate", Type.GetType("System.String"));
			workCenterTable.Columns.Add("wc_bdn_pct", Type.GetType("System.String"));
			#endregion
			
			#region Chargement des centres de charge
			foreach (DataRow rowWorkCenter in workCenter.Rows)
			{
				row = workCenterTable.NewRow();
				
				#region Données centres de charge
				row[0] = rowWorkCenter[0];                      // wc_wkctr
				row[1] = rowWorkCenter[1];                      // wc_mch
				row[2] = rowWorkCenter[2];                      // wc_desc
				row[3] = rowWorkCenter[3];                      // wc_dept
				row[4] = System.DBNull.Value;                   // wc_queue
				row[5] = System.DBNull.Value;                   // wc_wait
				row[6] = System.DBNull.Value;                   // wc_mch_op
				row[7] = System.DBNull.Value;                   // wc_setup_men
				row[8] = System.DBNull.Value;                   // wc_men_mch
				row[9] = System.DBNull.Value;                   // wc_mch_wkctr
				row[10] = System.DBNull.Value;                  // wc_mch_bdn
				row[11] = System.DBNull.Value;                  // wc_setup_rte
				row[12] = System.DBNull.Value;                  // wc_lbr_rate
				row[13] = System.DBNull.Value;                  // wc_bdn_rate
				row[14] = System.DBNull.Value;                  // wc_bdn_pct
				#endregion
				
				workCenterTable.Rows.Add(row);
			}
			#endregion
			
			#region Chargement des centres de charge V9
			foreach (DataRow rowWorkCenterV9 in workCenterV9.Rows)
			{
				row = workCenterTable.NewRow();
				
				#region Données centres de charge V9
				row[0] = rowWorkCenterV9[0];                    // wc_wkctr
				row[1] = rowWorkCenterV9[1];                    // wc_mch
				row[2] = rowWorkCenterV9[2];                    // wc_desc
				row[3] = rowWorkCenterV9[3];                    // wc_dept
				row[4] = rowWorkCenterV9[5];                    // wc_queue
				row[5] = rowWorkCenterV9[6];                    // wc_wait
				row[6] = rowWorkCenterV9[7];                    // wc_mch_op
				row[7] = rowWorkCenterV9[8];                    // wc_setup_men
				row[8] = rowWorkCenterV9[9];                    // wc_men_mch
				row[9] = rowWorkCenterV9[10];                   // wc_mch_wkctr
				row[10] = rowWorkCenterV9[11];                  // wc_mch_bdn
				row[11] = rowWorkCenterV9[12];                  // wc_setup_rte
				row[12] = rowWorkCenterV9[13];                  // wc_lbr_rate
				row[13] = rowWorkCenterV9[14];                  // wc_bdn_rate
				row[14] = rowWorkCenterV9[15];                  // wc_bdn_pct
				#endregion
				
				workCenterTable.Rows.Add(row);
			}
			#endregion
			
			Build.WriteCsvFromDataTable(workCenterTable, "C:\\TEMP\\14.5_work_center.csv");
			return workCenterTable;
		}
				
		public static System.Data.DataTable Write182211_ProductionLine(System.Data.DataTable productionLine)
		{
			System.Data.DataTable productionLineTable = new System.Data.DataTable();
			DataRow row = null;
			
			#region Format du fichier des lignes de production
			// Lignes de production
			productionLineTable.Columns.Add("ln_line", Type.GetType("System.String"));
			productionLineTable.Columns.Add("ln_site", Type.GetType("System.String"));
			productionLineTable.Columns.Add("ln_desc", Type.GetType("System.String"));
			productionLineTable.Columns.Add("ln_rate", Type.GetType("System.Int32"));
			productionLineTable.Columns.Add("lnd_part", Type.GetType("System.String"));
			productionLineTable.Columns.Add("lnd_start", Type.GetType("System.String"));
			productionLineTable.Columns.Add("lnd_rate", Type.GetType("System.String"));
			productionLineTable.Columns.Add("v_primary", Type.GetType("System.String"));
			productionLineTable.Columns.Add("lnd_setup", Type.GetType("System.String"));
			productionLineTable.Columns.Add("lnd_set_size", Type.GetType("System.String"));
			productionLineTable.Columns.Add("lnd_run", Type.GetType("System.String"));
			productionLineTable.Columns.Add("lnd_run_size", Type.GetType("System.String"));
			productionLineTable.Columns.Add("lnd_tool", Type.GetType("System.String"));
			productionLineTable.Columns.Add("lnd_run_seq1", Type.GetType("System.String"));
			productionLineTable.Columns.Add("lnd_run_seq2", Type.GetType("System.String"));
			productionLineTable.Columns.Add("comments", Type.GetType("System.String"));
			productionLineTable.Columns.Add("xxlnd_routing", Type.GetType("System.String"));
			productionLineTable.Columns.Add("xxlnd_bom_code", Type.GetType("System.String"));
			#endregion
			
			#region Chargement des lignes de production
			foreach (DataRow rowProductionLine in productionLine.Rows)
			{
				row = productionLineTable.NewRow();
				
				#region Données lignes de production
				row[0] = rowProductionLine[0];                      // ln_line
				row[1] = rowProductionLine[1];                      // ln_site
				row[2] = rowProductionLine[2];                      // ln_desc
				row[3] = rowProductionLine[3];                      // ln_rate
				row[4] = rowProductionLine[4];                      // lnd_part
				row[5] = System.DBNull.Value;                       // lnd_start
				row[6] = rowProductionLine[5];                      // lnd_rate
				row[7] = System.DBNull.Value;                       // v_primary
				row[8] = "";                                        // lnd_setup
				row[9] = System.DBNull.Value;                       // lnd_set_size
				row[10] = "";                                       // lnd_run
				row[11] = System.DBNull.Value;                      // lnd_run_size
				row[12] = "";                                       // lnd_tool
				row[13] = "";                                       // lnd_run_seq1
				row[14] = "";                                       // lnd_run_seq2
				row[15] = "no";                                     // comments
				row[16] = "";                                       // xxlnd_routing
				row[17] = "";                                       // xxlnd_bom_code
				#endregion
				
				productionLineTable.Rows.Add(row);
			}
			#endregion
			
			Build.WriteCsvFromDataTable(productionLineTable, "C:\\TEMP\\18.22.1.1_production_line.csv");
			return productionLineTable;
		}
		
		/// <summary>
		/// Ajout d'un paramètre général : OK
		/// </summary>
		/// <param name="strField"></param>
		/// <param name="strValue"></param>
		/// <param name="generalTable"></param>
		private static void AddGeneral(string strField, object strValue, ref System.Data.DataTable generalTable)
		{
			AddGeneral(strField, strValue, strValue, ref generalTable);
		}
		
		private static void AddGeneral(string strField, object strValue, object strDescription, ref System.Data.DataTable generalTable)
		{
			DataRow newRow = null;
			bool exists = false;
			
			if (strValue != System.DBNull.Value)
			{
				foreach (DataRow row in generalTable.Rows)
				{
					if (row[0].ToString().Equals(strField) &&
					    row[1].ToString().Equals(strValue.ToString()))
					{
						exists = true;
						break;
					}
				}
				
				if (!exists)
				{
					newRow = generalTable.NewRow();
					newRow[0] = strField;
					newRow[1] = strValue;
					newRow[2] = GetValue(strDescription, "", 40);
					generalTable.Rows.Add(newRow);
				}
			}
		}
		
		/// <summary>
		/// Ligne produit : OK
		/// </summary>
		/// <param name="reference"></param>
		/// <param name="originalLigneProd"></param>
		/// <param name="siteCellule"></param>
		/// <param name="ligneProd"></param>
		/// <returns></returns>
		private static string GetItemProdLine(string reference, string originalLigneProd, System.Data.DataTable siteCellule, System.Data.DataTable ligneProd)
		{
			string prodLine = "XXX";
			string lastProdLine = "X";
			
			prodLine = originalLigneProd.Substring(0, 3);
			
			if (prodLine.Contains("?"))
			{
				foreach (DataRow rowSiteCellule in siteCellule.Rows)
				{
					if (rowSiteCellule[0].ToString().Equals(reference))
					{						
						for (int i = 0; i < 3; i++)
						{
							if (prodLine.Substring(i, 1).Equals("?"))
							{
								prodLine = prodLine.Remove(i, 1);
								prodLine = prodLine.Insert(i, rowSiteCellule[4 + i].ToString());
							}
						}
						
						break;
					}
				}
				
				prodLine = prodLine.Replace('?', 'X');
			}
			
			if (originalLigneProd.Length == 4)
			{
				foreach (DataRow rowLigneProd in ligneProd.Rows)
				{
					if (rowLigneProd[0].ToString().Equals(originalLigneProd.Substring(3, 1)))
					{
						lastProdLine = rowLigneProd[1].ToString();
						break;
					}
				}
			}
			
			if (prodLine.StartsWith("4") || prodLine.StartsWith("5"))
			{
				prodLine = prodLine.Substring(0, 2) + "3";
			}
			
			return prodLine + lastProdLine;
		}
		
		/// <summary>
		/// Ligne produit V9 : OK
		/// </summary>
		/// <param name="originalLigneProd"></param>
		/// <param name="typeArticle"></param>
		/// <param name="itemV9ProdLine"></param>
		/// <param name="itemV9LastProdLine"></param>
		/// <returns></returns>
		private static string GetItemProdLineV9(string originalLigneProd, string typeArticle, System.Data.DataTable itemV9ProdLine, System.Data.DataTable itemV9LastProdLine)
		{
			string prodLine = "XXX";
			string lastProdLine = "X";
			
			foreach (DataRow rowItemV9ProdLine in itemV9ProdLine.Rows)
			{
				if (rowItemV9ProdLine[0].ToString().Equals(originalLigneProd))
				{
					prodLine = rowItemV9ProdLine[1].ToString() + 
							   rowItemV9ProdLine[2].ToString() + 
							   rowItemV9ProdLine[3].ToString();
					
					break;
				}
			}
			
			foreach (DataRow rowItemV9LastProdLine in itemV9LastProdLine.Rows)
			{
				if (rowItemV9LastProdLine[0].ToString().Equals(typeArticle))
				{
					lastProdLine = rowItemV9LastProdLine[2].ToString();
					break;
				}
			}
			
			// Semi-finis
			if (originalLigneProd.EndsWith("2"))
			{
				lastProdLine = "0";
			}
			
			// Semi-finis fantomes
			if (prodLine.StartsWith("299"))
			{
				lastProdLine = "9";
			}
			
			return prodLine + lastProdLine;
		}
		
		private static double GetItemWeight(object weightValue)
		{
			double returnValue = 0;
			
			try
			{
				returnValue = Convert.ToDouble(weightValue);
				returnValue = returnValue/1000;
			}
			catch (Exception)
			{
				
			}
			
			return returnValue;
		}
		
		private static string GetItemLeader(string reference, System.Data.DataTable itemLeader)
		{
			string returnValue = "AUCUN";
			
			foreach (DataRow rowItemLeader in itemLeader.Rows)
			{
				if (rowItemLeader[0].ToString().Equals(reference))
				{
					returnValue = rowItemLeader[1].ToString();
					break;
				}
			}
				
			return returnValue;
		}
		
		private static string GetItemDate(object dateValue)
		{
			string returnValue = "-";
			
			try
			{
				returnValue = Convert.ToDateTime(dateValue).ToString("01/01/yy");
			}
			catch (Exception)
			{
				
			}
			
			return returnValue;
		}
		
		private static System.Data.DataRow GetItemPlanning(ref System.Data.DataRow row, System.Data.DataTable dsrp, System.Data.DataTable v9)
		{			
			if (row[4].ToString().Substring(0, 1).Equals("2") ||
			    row[4].ToString().Substring(0, 1).Equals("3"))
			{
				foreach (DataRow rowV9 in v9.Rows)
				{
					if (row[0].Equals(rowV9[0]))
					{
						row[42] = rowV9[41];                 // pt_ms : OK
						row[43] = "yes";                     // pt_plan_ord : OK
						row[44] = rowV9[43];                 // pt_timefence : OK
						row[45] = rowV9[44];                 // pt_ord_pol : OK
						row[46] = rowV9[45];                 // pt_ord_qty : OK
						row[47] = rowV9[46];                 // pt_ord_per : OK
						row[48] = rowV9[47];                 // pt_sfty_stk : OK
						row[49] = rowV9[48];                 // pt_sfty_time : OK
						row[50] = rowV9[49];                 // pt_rop : OK
						row[51] = "";                        // pt_rev : OK
						row[52] = "yes";                     // pt_iss_pol : OK
						row[54] = rowV9[53];                 // pt_vend : ATTENTION
						row[55] = rowV9[54];                 // pt_po_site : OK
						row[56] = rowV9[55];                 // pt_pm_code : OK
						row[57] = "";                        // cfg : OK
						row[58] = rowV9[57];                 // pt_insp_rqd : OK
						row[59] = rowV9[58];                 // pt_insp_lead : OK
						row[60] = rowV9[59];                 // pt_mfg_lead : OK
						row[61] = rowV9[60];                 // pt_pur_lead : OK
						row[62] = System.DBNull.Value;       // atp_enforcement : OK
						row[63] = "no";                      // pt_atp_family : OK
						row[64] = 0;                         // pt_atp_horizon : OK
						row[65] = "";                        // pt_run_seq1 : OK
						row[66] = "";                        // pt_run_seq2 : OK
						row[67] = rowV9[61];                 // pt_phantom : OK
						row[68] = "0";                       // pt_ord_min : OK
						row[69] = rowV9[63];                 // pt_ord_max : OK
						row[70] = "0";                       // pt_ord_mult : OK
						row[71] = "no";                      // pt_op_yield : OK
						row[72] = rowV9[65];                 // pt_yield_pct : OK
						row[73] = "0";                       // pt_run : OK
						row[74] = rowV9[67];                 // pt_setup : OK
						row[75] = System.DBNull.Value;       // btb_type : OK
						row[76] = "no";                      // pt__qad15 : OK
						row[77] = "";                        // pt_network : OK
						row[78] = rowV9[71];                 // pt_routing : ATTENTION
						row[79] = "";                        // pt_bom_code
						
						break;
					}
				}
			}
			else
			{
				foreach (DataRow rowDsrp in dsrp.Rows)
				{
					if (row[0].Equals(rowDsrp[0]))
					{
						row[47] = rowDsrp[1];                  // pt_ord_per
						row[48] = rowDsrp[2];                  // pt_sfty_stk
						row[49] = rowDsrp[3];                  // pt_sfty_time
						row[65] = rowDsrp[6];                  // pt_run_seq1
						row[68] = rowDsrp[4];                  // pt_ord_min
						row[70] = rowDsrp[5];                  // pt_ord_mult
						
						break;
					}
				}
			}
			
			return row;
		}
		
		private static string GetItemBuyer(string reference, System.Data.DataTable itemSiteCellProdLine)
		{
			string returnValue = "";
			
			foreach (DataRow rowItemSiteCellProdLine in itemSiteCellProdLine.Rows)
			{
				if (rowItemSiteCellProdLine[0].ToString().Equals(reference))
				{						
					returnValue = rowItemSiteCellProdLine[3].ToString();
					break;
				}
			}
			
			
			return returnValue;
		}
				
		private static string GetValue(object objectValue, string defaultValue, int size)
		{
			string returnValue = defaultValue;
			
			if ((objectValue != null) && !objectValue.ToString().Equals(""))
			{
				returnValue = objectValue.ToString();
			}
			
			if ((size != 0) && (returnValue.Length > size))
			{
				returnValue = returnValue.Substring(0, size);
			}
			
			return returnValue;
		}
		
		private static string GetValue(object objectValue, int size)
		{
			return GetValue(objectValue, "", size);
		}
		
		private static string GetValue(object objectValue, string defaultValue)
		{
			return GetValue(objectValue, defaultValue, 0);
		}
		
		private static string GetValue(object objectValue)
		{
			return GetValue(objectValue, "", 0);
		}
	}
}
