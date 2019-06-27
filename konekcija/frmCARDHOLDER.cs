using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace konekcija
{
    public partial class frmCARDHOLDER : Form
    {
        konekcija.MojaEntities _context { get; set; }        

        List<Cardholder> ListaCARDHOLDER;
        List<AccessLog> ListaACCESSLOG;
        List<Card> ListaCARD;
        List<LogException> ListaLOGEXCEPTION;        

        int CARDHOLDERID;
        int? WORKTIMEINT;
        string WORKTIME;

        int EXCEPTIONID;
        int LOGID;
        

        public frmCARDHOLDER()
        {
            InitializeComponent();             
        }      

        private void Form2_Load(object sender, EventArgs e)
        {
            _context = new konekcija.MojaEntities();

            cboxCARDHOLDER.DataSource = _context.Cardholders.OrderBy(o => o.Name).ToList();
            cboxCARDHOLDER.Text = "";            
           // dgCHECKLIST.DataSource = _context.AccessLogs.ToList();           
            ListaCARD = _context.Cards.ToList();
            ListaACCESSLOG = _context.AccessLogs.ToList();
            ListaCARDHOLDER = _context.Cardholders.ToList();
            ListaLOGEXCEPTION = _context.LogExceptions.ToList();
            foreach (var item in ListaCARDHOLDER)
            {
                checkComboBox1.Items.Add(new CheckComboBox.ComboboxData(item.Name, false));
            }
        }

        private void CreateQuery ()
        {
            if (cboxCARDHOLDER.Text == ""
                || dateTimePicker1.Value.Date >= System.DateTime.Now.Date)
            {

            }
            else
            {
                if (cboxCARDHOLDER.Text == "All")
                {
                    ListaACCESSLOG = _context.AccessLogs.ToList();
                    dgCHECKLIST.Columns[3].Visible = false;
                    ListaACCESSLOG = ListaACCESSLOG.Where(i => i.LocalTime >= dateTimePicker1.Value.Date && i.LocalTime <= dateTimePicker2.Value.Date).ToList();

                    accessLogBindingSource.DataSource = ListaACCESSLOG;
                    dgCHECKLIST.DataSource = ListaACCESSLOG;
                }
                else
                {
                    dgCHECKLIST.Columns[3].Visible = true;
                    CARDHOLDERID = _context.Cardholders.Where(w => w.Name == cboxCARDHOLDER.Text).Select(s => s.CardholderID).First();

                    ListaACCESSLOG = _context.AccessLogs.ToList();

                    ListaACCESSLOG = ListaACCESSLOG.Where(i => ((CARDHOLDERID == 0) ? true : (i.LocalTime >= dateTimePicker1.Value.Date)
                                               && (i.LocalTime <= dateTimePicker2.Value.Date)
                                               && (i.CardholderID == CARDHOLDERID))).ToList();

                    accessLogBindingSource.DataSource = ListaACCESSLOG;
                    dgCHECKLIST.DataSource = ListaACCESSLOG;
                }
                
                
            }          
        }
        private void QueryButtonEnable()
        {
            if (cboxCARDHOLDER.Text == "" || CARDHOLDERID == 0)
            {
                btnPRINT.Enabled = false;
            }
            else
            {
                btnPRINT.Enabled = true;
            }
            
        }       

        private void cboxCARDHOLDER_SelectedIndexChanged(object sender, EventArgs e)
        {
            CARDHOLDERID = 0;
            CreateQuery();
            
        }

        public class AccessLogReport
        {
            public int? cardholderid { get; set; }
            public string name { get; set; }           
            public DateTime? date { get; set; }
            public int? checkIN { get; set; }
            public int? checkOUT { get; set; }            
        }

        private void btnPRINT_Click(object sender, EventArgs e)
        {          
            if (CARDHOLDERID == 0 || cboxCARDHOLDER.Text == "" || cboxCARDHOLDER.Text == "All")
            {
                List<AccessLogReport> ListaREP = _context.AccessLogs.Where(w => w.LocalTime >= dateTimePicker1.Value.Date && w.LocalTime <= dateTimePicker2.Value.Date).Select(s =>
                    new AccessLogReport
                    {
                        name = s.Cardholder.Name,
                        checkIN = s.Direction,
                        checkOUT = s.Direction,
                        date = s.LocalTime.Value

                    }).ToList();

                frmREPORT frmREPORT = new frmREPORT(ListaREP, "Check IN/OUT report");
                frmREPORT.ShowDialog();
            }
            else
            {
               
                List<AccessLogReport> ListaREP = _context.AccessLogs.Where(w => w.CardholderID == CARDHOLDERID && w.LocalTime >= dateTimePicker1.Value.Date && w.LocalTime <= dateTimePicker2.Value.Date).Select(s =>
                    new AccessLogReport
                    {
                        name = s.Cardholder.Name,
                        checkIN = s.Direction,
                        checkOUT = s.Direction,
                        date = s.LocalTime.Value                       

                    }).ToList();

                frmREPORT frmREPORT = new frmREPORT(ListaREP, "Check IN/OUT report");
                frmREPORT.ShowDialog();
            }

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            CreateQuery();
           
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            CreateQuery();
            
        }

        private void dgCHECKLIST_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgCHECKLIST.Columns[e.ColumnIndex].Name.Equals("direction") &&
               e.RowIndex >= 0 &&
               dgCHECKLIST["direction", e.RowIndex].Value is int)
            {

                switch ((int)dgCHECKLIST["direction", e.RowIndex].Value)
                {
                    case 2:
                        e.Value = "OUT";
                        e.FormattingApplied = true;
                        break;
                    case 1:
                        e.Value = "IN";
                        e.FormattingApplied = true;
                        break;
                }
            }

            if (dgCHECKLIST.Columns[e.ColumnIndex].Name.Equals("TotalWorktime"))
            {
                var a = dgCHECKLIST["localTime", e.RowIndex].Value;
                string c = a.ToString();
                DateTime x = Convert.ToDateTime(c);
                if (_context.LogExceptions.Where(w => w.CardholderID == CARDHOLDERID && w.LogExceptionDate == x.Date).Select(s => s.Worktime).Count() == 0)
                {

                }
                else
                {
                    int? b = _context.LogExceptions.Where(w => w.CardholderID == CARDHOLDERID && w.LogExceptionDate == x.Date).Select(s => s.Worktime).First();
                    string z = (b / 60 + ":" + b % 60).ToString();
                    e.Value = z;
                }
            }
            if (dgCHECKLIST.Columns[e.ColumnIndex].Name.Equals("Name"))
            {
                int a = Convert.ToInt16(dgCHECKLIST["CArdholderIDColumn", e.RowIndex].Value);
                if ((_context.Cardholders.Where(w => w.CardholderID == a).FirstOrDefault() == null )|| a==-1 || a==0)
                {
                    e.Value = "Unknown";
                    e.CellStyle.BackColor= Color.FromArgb(100, 100, 0);

                }
                else
                {
                    var b = _context.Cardholders.Where(w => w.CardholderID == a).Single();

                    e.Value = b.Name;
                }

                
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnFIRM_Click(object sender, EventArgs e)
        {
            Form frmCARDHOLDERFIRM = new frmCARDHOLDERFIRM();
            frmCARDHOLDERFIRM.ShowDialog();
        }

        private void checkComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<CheckComboBox.ComboboxData> dat1 = checkComboBox1.CheckItems;
            foreach (var item in dat1)
            {
                if (item.Checked)
                {
                    MessageBox.Show(item.Data);
                }
            }
        }
    }
}
