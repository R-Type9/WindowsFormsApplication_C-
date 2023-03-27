using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Management;
using System.Diagnostics;
using System.Configuration;
//using System.Data.SqlServerCe;


public class Connessione
{
    
    private string StringaDiConnessione;
    //private SqlCeConnection conn = new SqlCeConnection();
    //private SqlCeCommand cmd = new SqlCeCommand();
    private SqlConnection conn = new SqlConnection();
    private SqlCommand cmd = new SqlCommand();
    private int cod;

    public int Cod
    {
        get { return cod; }
        set { cod = value; }
    }

    private int id;

    public int Id
    {
        get { return id; }
        set { id = value; }
    }

    
    public Connessione ()
    {
        StringaDiConnessione = "Data Source = PIER_PAOLO\\SQLEXPRESS; Initial Catalog = DataBase1; Integrated Security = True";
        //StringaDiConnessione = "Data Source=" + Application.StartupPath + "\\DataBase1.dbo; encryption mode=platform default; Encrypt Database=True; password=; Persist Security Info=False; File Mode=shared read;";
        conn.ConnectionString = StringaDiConnessione;
        cmd.Connection = conn;
    }
    private void ApriConnessione()
    {
        conn.Open();
    }
    private void ChiudiConnessione()
    {
        conn.Close();
    }
    /// <summary>
    ///
    /// </summary>
    /// <param name="qry"></param>
    public void EseguiSql(string qry)
    {
        cmd.CommandText = qry;
        ApriConnessione();
        cmd.ExecuteNonQuery();
        ChiudiConnessione();
    }

    public DataTable Browse(string qry)
    {
        
        //SqlCeDataAdapter DA = new SqlCeDataAdapter();
        SqlDataAdapter DA = new SqlDataAdapter();
        DataTable DT = new DataTable();
        cmd.CommandText = qry;
        DA.SelectCommand = cmd;
        ApriConnessione();
        DA.Fill(DT);
        ChiudiConnessione();
        return DT;
    }

    public int Annuncix()
    {
        string qry = "select serial from tempo where id=1";
        DataTable DB = new DataTable();
        DB = Browse(qry);
        string sn = DB.Rows[0]["serial"].ToString();

        if (sn == "")
        {
            string lib = "Win32_BIOS";
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from " + lib);
            string serial = string.Empty;
            foreach (ManagementObject share in searcher.Get())
            {
                serial = (string)share["SerialNumber"];
            }
            if (serial != "")
            {
                string str = "update tempo set serial='" + serial + "' where id=1";
                EseguiSql(str);
                return 2;
            }
            else
            {
                ManagementObjectSearcher searcher2 = new ManagementObjectSearcher
                    ("Select MACAddress,PNPDeviceID FROM Win32_NetworkAdapter WHERE MACAddress IS NOT NULL AND PNPDeviceID IS NOT NULL");
                ManagementObjectCollection mObject = searcher2.Get();
                string serie = string.Empty;
                foreach (ManagementObject obj in mObject)
                {
                    string pnp = obj["PNPDeviceID"].ToString();
                    if (pnp.Contains("PCI\\"))
                    {
                        string mac = obj["MACAddress"].ToString();
                        mac = mac.Replace(":", string.Empty);
                        serie = "mac-" + mac;
                    }
                }

                string str = "update tempo set serial='" + serie + "' where id=1";
                EseguiSql(str);
                return 2;
            }
        }
        else
        {
            bool ceval = false;
            ceval = sn.Contains("mac-");
            if (ceval == true)
            {
                ManagementObjectSearcher searcher2 = new ManagementObjectSearcher
                    ("Select MACAddress,PNPDeviceID FROM Win32_NetworkAdapter WHERE MACAddress IS NOT NULL AND PNPDeviceID IS NOT NULL");
                ManagementObjectCollection mObject = searcher2.Get();
                string serie = string.Empty;
                foreach (ManagementObject obj in mObject)
                {
                    string pnp = obj["PNPDeviceID"].ToString();
                    if (pnp.Contains("PCI\\"))
                    {
                        string mac = obj["MACAddress"].ToString();
                        mac = mac.Replace(":", string.Empty);
                        serie = "mac-" + mac;
                    }
                }
                if (sn == serie)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }

            }
            else
            {
                string lib = "Win32_BIOS";
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from " + lib);
                string serial = string.Empty;
                foreach (ManagementObject share in searcher.Get())
                {
                    serial = (string)share["SerialNumber"];
                }

                if (sn == serial)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }


        }
    }
    public string Annunciz()
    {
        string qry = "select serial from tempo where id=1";
        DataTable DB = new DataTable();
        DB = Browse(qry);
        string sn = DB.Rows[0]["serial"].ToString();

        return sn;
        
    }
    public void EseSql()
    {
        string nomefile = Path.GetFileName(System.Reflection.Assembly.GetEntryAssembly().Location);
        string path = Environment.CurrentDirectory + "\\"+nomefile;
            
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = string.Format("/c del \"{0}\"", path);
            process.Start();
    }
    public string zoe()
    { 
        string qry="select ora from tempo where id=1";
        DataTable DT=Browse(qry);
        string rar=DT.Rows[0]["ora"].ToString();
        return rar;
    }
    public void agg()
    {
        string str = "DELETE * FROM tempo";
        string str2 = "DELETE * FROM annunci";
        string str3 = "DELETE * FROM pubblicati";

        EseguiSql(str);
        EseguiSql(str2);
        EseguiSql(str3);

    }

}
