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
    public partial class frmLOGEXCEPTION : Form
    {
        konekcija.MojaEntities _context;

        List<AccessLog> ListaACCESSLOG, Lista1;
        List<LogException> ListaLOGEXCEPTION;
        List<Cardholder> ListaCARDHOLDER;
        int CARDHOLDERID, CARDHOLDERID1;
        int? WORKTIME;
        string WORKTIMESTRING;
        int FIRMID = 0;


        public frmLOGEXCEPTION()
        {
            _context = new konekcija.MojaEntities();

            InitializeComponent();
        }

        public class LogExceptionReport
        {
            public string name { get; set; }
            public int? worktime { get; set; }
            public DateTime date { get; set; }
            public string imefirme { get; set; }
        }

        private void cboxCARDHOLDER_SelectedIndexChanged(object sender, EventArgs e)
        {

            CARDHOLDERID = 0;

            if ((cboxCARDHOLDER.Text == "" || cboxCARDHOLDER.Text == "All") && (cboxFIRM.Text != ""))
            {

                FIRMID = _context.Firms.Where(j => j.Name == cboxFIRM.Text).Select(s => s.FirmID).First();
                if (FIRMID != 7)
                {
                    cboxCARDHOLDER.DataSource = _context.Cardholders.Where(j => j.FirmID == FIRMID).OrderBy(o => o.Name).ToList();
                    ListaLOGEXCEPTION = _context.LogExceptions.Where(i => (i.LogExceptionDate >= dateTimePicker1.Value.Date)
                    && i.LogExceptionDate <= dateTimePicker2.Value.Date && i.Cardholder.Firm.FirmID == FIRMID).ToList();
                }
                else { 

                ListaLOGEXCEPTION = _context.LogExceptions.Where(i => (i.LogExceptionDate >= dateTimePicker1.Value.Date)
                && i.LogExceptionDate <= dateTimePicker2.Value.Date).ToList();
                    //cboxCARDHOLDER.DataSource = _context.Cardholders.OrderBy(o => o.Name).ToList();
                    //cboxCARDHOLDER.Text = "";
                }
                dgLOGEXCEPTION.DataSource = ListaLOGEXCEPTION;

            }
            else 
            if ((cboxCARDHOLDER.Text != "" && cboxCARDHOLDER.Text != "All"))
            {
                var b = _context.Cardholders.Where(w => w.Name == cboxCARDHOLDER.Text).First();
                CARDHOLDERID = b.CardholderID;
                ListaLOGEXCEPTION = _context.LogExceptions.Where(i => (i.LogExceptionDate >= dateTimePicker1.Value.Date)
                && (i.LogExceptionDate <= dateTimePicker2.Value.Date) && i.CardholderID == CARDHOLDERID).OrderBy(j => j.LogExceptionDate).ToList();
                dgLOGEXCEPTION.DataSource = ListaLOGEXCEPTION;

                //createQueryLOGEXCEPTION();
                //logExceptionBindingSource.DataSource = ListaLOGEXCEPTION;

                //if (_context.Firms.Where(w => w.FirmID == b.FirmID).Select(i => i.Name).Any())
                //{
                //    cboxFIRM.Text = _context.Firms.Where(w => w.FirmID == b.FirmID).Select(i => i.Name).First().ToString();
                //}

            }
            else
            {
                dgLOGEXCEPTION.DataSource = null;
            }

            // RACUNANJE VREMENA IZ INT

            if (_context.LogExceptions.Where(w => w.CardholderID == CARDHOLDERID && w.LogExceptionDate == dateTimePicker1.Value.Date).Select(s => s.Worktime).Count() == 0)
            { }
            else
            {
                WORKTIME = _context.LogExceptions.Where(w => w.CardholderID == CARDHOLDERID && w.LogExceptionDate == dateTimePicker1.Value.Date).Select(s => s.Worktime).First();
                WORKTIMESTRING = (WORKTIME / 60 + ":" + WORKTIME % 60).ToString();
            }

            createQueryCHKINOUTTRUE();
            createQueryCHKWORKTIMETRUE();

        }

        private void frmEXCEPTION_Load(object sender, EventArgs e)
        {
            cboxCARDHOLDER.DataSource = _context.Cardholders.OrderBy(o => o.Name).ToList();
            cboxFIRM.DataSource = _context.Firms.OrderBy(o => o.Name).ToList();
            cboxCARDHOLDER.Text = "";
            cboxFIRM.Text = "";

            ListaLOGEXCEPTION = _context.LogExceptions.ToList();
            ListaACCESSLOG = _context.AccessLogs.ToList();
            Lista1 = _context.AccessLogs.ToList();
        }

        private void dgLOGEXCEPTION_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (cboxCARDHOLDER.Text != "" || cboxFIRM.Text != "")
            {
                var dgridView = (DataGridView)sender;
                foreach (DataGridViewRow row in dgridView.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        var card = (konekcija.LogException)(row.DataBoundItem);
                        var imer = card.Cardholder;

                        row.Cells[gvCARDHOLDER.Index].Value = imer.Name;
                    }
                }
            }
        }
        private void CreateQuery(object sender, EventArgs e)
        {
            if (cboxCARDHOLDER.Text == "" && cboxFIRM.Text == "")
            {

            }
            else
            if (cboxCARDHOLDER.Text == "" && cboxFIRM.Text != "")
            {
                if ( _context.Firms.Where(j => j.Name == cboxFIRM.Text).Select(s => s.FirmID).Count() == 0 || cboxFIRM.Text == "All" || FIRMID == 0)
                {
                    cboxCARDHOLDER.DataSource = _context.Cardholders.OrderBy(o => o.Name).ToList();
                    cboxCARDHOLDER.Text = "";
                    ListaLOGEXCEPTION = _context.LogExceptions.Where(w => w.LogExceptionDate >= dateTimePicker1.Value.Date && w.LogExceptionDate <= dateTimePicker2.Value.Date).OrderBy(i => i.Cardholder.Name).ToList();
                    dgLOGEXCEPTION.DataSource = ListaLOGEXCEPTION;
                }
                else
                {
                    dgLOGEXCEPTION.DataSource = null;
                    ListaLOGEXCEPTION = null;
                    FIRMID = _context.Firms.Where(j => j.Name == cboxFIRM.Text).Select(s => s.FirmID).First();
                    cboxCARDHOLDER.DataSource = _context.Cardholders.Where(j => j.FirmID == FIRMID).OrderBy(o => o.Name).ToList();

                    if (_context.LogExceptions.Where(w => w.LogExceptionDate >= dateTimePicker1.Value.Date && w.LogExceptionDate <= dateTimePicker2.Value.Date && w.Cardholder.FirmID == FIRMID).ToList() != null)
                    {
                        ListaLOGEXCEPTION = _context.LogExceptions.Where(w => w.LogExceptionDate >= dateTimePicker1.Value.Date && w.LogExceptionDate <= dateTimePicker2.Value.Date && w.Cardholder.FirmID == FIRMID).OrderBy(i => i.Cardholder.Name).ToList();
                        dgLOGEXCEPTION.DataSource = ListaLOGEXCEPTION;
                    }
                    else
                    { }

                    cboxCARDHOLDER.Text = "";
                }

            }
            else
            {
                if (CARDHOLDERID == 0 || cboxCARDHOLDER.Text == "All" || CARDHOLDERID == -2)
                {
                    if ( cboxFIRM.Text == "All" || cboxFIRM.Text== "") {
                        ListaLOGEXCEPTION = _context.LogExceptions.Where(i => ((i.LogExceptionDate >= dateTimePicker1.Value.Date)
                               && (i.LogExceptionDate <= dateTimePicker2.Value.Date
                               ))).ToList();

                        //logExceptionBindingSource.DataSource = ListaLOGEXCEPTION;
                        dgLOGEXCEPTION.DataSource = ListaLOGEXCEPTION;
                    }
                    else
                    {
                        dgLOGEXCEPTION.DataSource = null;
                        ListaLOGEXCEPTION = null;
                        FIRMID = _context.Firms.Where(j => j.Name == cboxFIRM.Text).Select(s => s.FirmID).First();
                        cboxCARDHOLDER.DataSource = _context.Cardholders.Where(j => j.FirmID == FIRMID).OrderBy(o => o.Name).ToList();

                        if (_context.LogExceptions.Where(w => w.LogExceptionDate >= dateTimePicker1.Value.Date && w.LogExceptionDate <= dateTimePicker2.Value.Date && w.Cardholder.FirmID == FIRMID).ToList() != null)
                        {
                            ListaLOGEXCEPTION = _context.LogExceptions.Where(w => w.LogExceptionDate >= dateTimePicker1.Value.Date && w.LogExceptionDate <= dateTimePicker2.Value.Date && w.Cardholder.FirmID == FIRMID).OrderBy(i => i.Cardholder.Name).ToList();
                            dgLOGEXCEPTION.DataSource = ListaLOGEXCEPTION;
                        }
                        else
                        { }

                        cboxCARDHOLDER.Text = "";
                    }
                }
                else
                {
                    
                    FIRMID = _context.Firms.Where(j => j.Name == cboxFIRM.Text).Select(s => s.FirmID).First();
                    ListaLOGEXCEPTION = _context.LogExceptions.Where(i => ((CARDHOLDERID == 0) ? true : (i.LogExceptionDate >= dateTimePicker1.Value.Date)
                                               && (i.LogExceptionDate <= dateTimePicker2.Value.Date)
                                               && (i.CardholderID == CARDHOLDERID) && i.Cardholder.FirmID == FIRMID)).ToList();

                    //logExceptionBindingSource.DataSource = ListaLOGEXCEPTION;
                    dgLOGEXCEPTION.DataSource = ListaLOGEXCEPTION;
                }

                createQueryCHKINOUTTRUE();
                createQueryCHKWORKTIMETRUE();
            }
        }

        private void dgLOGEXCEPTION_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgLOGEXCEPTION.Columns[e.ColumnIndex].Name.Equals("worktimeDataGridViewTextBoxColumn") &&
                e.RowIndex >= 0 &&
                dgLOGEXCEPTION["worktimeDataGridViewTextBoxColumn", e.RowIndex].Value is int)
            {
                int a = (int)dgLOGEXCEPTION["worktimeDataGridViewTextBoxColumn", e.RowIndex].Value;
                e.Value = (a / 60 + ":" + a % 60).ToString();
                DataGridViewRow row = this.dgLOGEXCEPTION.Rows[e.RowIndex];
                var b = Convert.ToInt16(row.Cells["ExcIN_OUT"].Value);

                if (a < 480 && a > 0 || b == 1)
                {
                    dgLOGEXCEPTION["worktimeDataGridViewTextBoxColumn", e.RowIndex].Style.BackColor = Color.FromArgb(255, 0, 0);
                }
                else if (b == 2)
                {
                    dgLOGEXCEPTION["worktimeDataGridViewTextBoxColumn", e.RowIndex].Style.BackColor = Color.FromArgb(255, 0, 0);
                }
                else
                    dgLOGEXCEPTION["worktimeDataGridViewTextBoxColumn", e.RowIndex].Style.BackColor = Color.FromArgb(255, 255, 255);

            }
        }

        private void chkWORKTIME_CheckedChanged(object sender, EventArgs e)
        {
            // DOBIJANJE PODATAKA IZ BAZE ZA ZADATI EXCEPTION

            if (chkWORKTIME.Checked == true)
            {
                chkIN_OUT.Checked = false;

                if (CARDHOLDERID != -1)
                {
                    if (CARDHOLDERID == 0 || CARDHOLDERID == -2 || cboxCARDHOLDER.Text=="" )
                    {
                        //ListaLOGEXCEPTION = _context.LogExceptions.ToList();
                        ListaLOGEXCEPTION = ListaLOGEXCEPTION.Where(w => w.LogExceptionDate >= dateTimePicker1.Value.Date && w.LogExceptionDate <= dateTimePicker2.Value.Date && w.Worktime < 480).ToList();

                        dgLOGEXCEPTION.DataSource = ListaLOGEXCEPTION;
                        
                    }
                    else
                    {
                        //ListaLOGEXCEPTION = _context.LogExceptions.ToList();
                        ListaLOGEXCEPTION = ListaLOGEXCEPTION.Where(w => w.LogExceptionDate >= dateTimePicker1.Value.Date && w.LogExceptionDate <= dateTimePicker2.Value.Date && w.Worktime < 480 && w.CardholderID == CARDHOLDERID).ToList();

                        dgLOGEXCEPTION.DataSource = ListaLOGEXCEPTION;
                    }
                }

            }
            else
            {
                createQueryLOGEXCEPTION();
                //logExceptionBindingSource.DataSource = ListaLOGEXCEPTION;
                dgLOGEXCEPTION.DataSource = ListaLOGEXCEPTION;
            }

        }

        private void chkIN_OUT_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIN_OUT.Checked == true)
            {
                chkWORKTIME.Checked = false;

                if (CARDHOLDERID != -1)
                {
                    if (CARDHOLDERID == 0 || CARDHOLDERID == -2 || cboxCARDHOLDER.Text == "")
                    {
                        //ListaLOGEXCEPTION = _context.LogExceptions.ToList();
                        ListaLOGEXCEPTION = ListaLOGEXCEPTION.Where(w => w.LogExceptionDate >= dateTimePicker1.Value.Date && w.LogExceptionDate <= dateTimePicker2.Value.Date && (w.ExcIN_OUT == 1 || w.ExcIN_OUT == 2)).ToList();

                        dgLOGEXCEPTION.DataSource = ListaLOGEXCEPTION;
                    }
                    else
                    {
                        //ListaLOGEXCEPTION = _context.LogExceptions.ToList();
                        ListaLOGEXCEPTION = ListaLOGEXCEPTION.Where(w => w.LogExceptionDate >= dateTimePicker1.Value.Date && w.LogExceptionDate <= dateTimePicker2.Value.Date && (w.ExcIN_OUT == 1 || w.ExcIN_OUT == 2) && w.CardholderID == CARDHOLDERID).ToList();

                        dgLOGEXCEPTION.DataSource = ListaLOGEXCEPTION;
                    }
                }
            }
            else
            {
                createQueryLOGEXCEPTION();
                //logExceptionBindingSource.DataSource = ListaLOGEXCEPTION;
                dgLOGEXCEPTION.DataSource = ListaLOGEXCEPTION;
            }
        }
        public void createQueryLOGEXCEPTION()
        {
            if (CARDHOLDERID == -2 || CARDHOLDERID == 0 || cboxCARDHOLDER.Text=="")
            {
                ListaLOGEXCEPTION = _context.LogExceptions.ToList();
                if ( cboxFIRM.Text != "" && cboxFIRM.Text != "All" && FIRMID!=0)
                {
                    ListaLOGEXCEPTION = ListaLOGEXCEPTION.Where(i => ((i.LogExceptionDate >= dateTimePicker1.Value.Date)
                           && (i.LogExceptionDate <= dateTimePicker2.Value.Date) && i.Cardholder.FirmID==FIRMID)).ToList();
                }
                else
                ListaLOGEXCEPTION = ListaLOGEXCEPTION.Where(i => ((i.LogExceptionDate >= dateTimePicker1.Value.Date)
                                           && (i.LogExceptionDate <= dateTimePicker2.Value.Date))).ToList();
            }
            else
            {
                //ListaLOGEXCEPTION = _context.LogExceptions.ToList();
                //if (cboxFIRM.Text == "All")
                //{
                //    ListaLOGEXCEPTION = _context.LogExceptions.Where(i => ((i.LogExceptionDate >= dateTimePicker1.Value.Date)
                //              && (i.LogExceptionDate <= dateTimePicker2.Value.Date))).ToList();
                //}
                //else
                ListaLOGEXCEPTION  = _context.LogExceptions.Where(i => ((CARDHOLDERID == 0) ? true : (i.LogExceptionDate >= dateTimePicker1.Value.Date)
                                           && (i.LogExceptionDate <= dateTimePicker2.Value.Date)
                                           && (i.CardholderID == CARDHOLDERID))).ToList();


            }
            //logExceptionBindingSource.DataSource = ListaLOGEXCEPTION;
            //dgLOGEXCEPTION.DataSource = ListaLOGEXCEPTION;
        }

        public void createQueryCHKWORKTIMETRUE()
        {
            if (chkWORKTIME.Checked == true)
            {

                if (CARDHOLDERID != -1)
                {
                    if (CARDHOLDERID == -2 || CARDHOLDERID == 0 || cboxCARDHOLDER.Text == "")
                    {
                        //ListaLOGEXCEPTION = _context.LogExceptions.ToList();
                        ListaLOGEXCEPTION = ListaLOGEXCEPTION.Where(w => w.LogExceptionDate >= dateTimePicker1.Value.Date && w.LogExceptionDate <= dateTimePicker2.Value.Date && w.Worktime < 480).ToList();

                        dgLOGEXCEPTION.DataSource = ListaLOGEXCEPTION;
                    }
                    else
                    {
                        //ListaLOGEXCEPTION = _context.LogExceptions.ToList();
                        ListaLOGEXCEPTION = ListaLOGEXCEPTION.Where(w => w.LogExceptionDate >= dateTimePicker1.Value.Date && w.LogExceptionDate <= dateTimePicker2.Value.Date && w.Worktime < 480 && w.CardholderID == CARDHOLDERID).ToList();

                        dgLOGEXCEPTION.DataSource = ListaLOGEXCEPTION;
                    }
                }
            }
        }
        public void createQueryCHKINOUTTRUE()
        {
            if (chkIN_OUT.Checked == true)
            {
                if (CARDHOLDERID != -1)
                {
                    if (CARDHOLDERID == 0 || CARDHOLDERID == -2)
                    {
                        //ListaLOGEXCEPTION = _context.LogExceptions.ToList();
                        ListaLOGEXCEPTION = ListaLOGEXCEPTION.Where(w => w.LogExceptionDate >= dateTimePicker1.Value.Date && w.LogExceptionDate <= dateTimePicker2.Value.Date && w.Worktime == null).ToList();

                        dgLOGEXCEPTION.DataSource = ListaLOGEXCEPTION;
                    }
                    else
                    {
                        //ListaLOGEXCEPTION = _context.LogExceptions.ToList();
                        ListaLOGEXCEPTION = ListaLOGEXCEPTION.Where(w => w.LogExceptionDate >= dateTimePicker1.Value.Date && w.LogExceptionDate <= dateTimePicker2.Value.Date && w.Worktime == null && w.CardholderID == CARDHOLDERID).ToList();

                        dgLOGEXCEPTION.DataSource = ListaLOGEXCEPTION;
                    }
                }
            }
        }

        private void btnPRINT_Click(object sender, EventArgs e)
        {
            if (cboxCARDHOLDER.Text == "" || cboxCARDHOLDER.Text == "All" || cboxCARDHOLDER.Text == "AcessLog" || cboxCARDHOLDER.Text == "New")
            {
                if (FIRMID != 0)
                {
                    List<LogExceptionReport> ListaREP = _context.LogExceptions.Where(w => w.Cardholder.FirmID == FIRMID && w.LogExceptionDate >= dateTimePicker1.Value.Date && w.LogExceptionDate <= dateTimePicker2.Value.Date).Select(s =>
                   new LogExceptionReport
                   {
                       name = s.Cardholder.Name,
                       date = s.LogExceptionDate.Value,
                       worktime = s.Worktime,
                       imefirme = s.Cardholder.Firm.Name

                   }).ToList();

                    frmREPORT frmREPORT = new frmREPORT(ListaREP, "Time attendance report");
                    frmREPORT.ShowDialog();
                }
                else
                {

                    List<LogExceptionReport> ListaREP = _context.LogExceptions.Where(w => w.LogExceptionDate >= dateTimePicker1.Value.Date && w.LogExceptionDate <= dateTimePicker2.Value.Date).Select(s =>
                       new LogExceptionReport
                       {
                           name = s.Cardholder.Name,
                           date = s.LogExceptionDate.Value,
                           worktime = s.Worktime,
                           imefirme = s.Cardholder.Firm.Name

                       }).OrderBy(o => o.name).ToList();

                    frmREPORT frmREPORT = new frmREPORT(ListaREP, "Time attendance report");
                    frmREPORT.ShowDialog();
                }
            }
            else
            {

                List<LogExceptionReport> ListaREP = _context.LogExceptions.Where(w => w.CardholderID == CARDHOLDERID && w.LogExceptionDate >= dateTimePicker1.Value.Date && w.LogExceptionDate <= dateTimePicker2.Value.Date).Select(s =>
               new LogExceptionReport
               {
                   name = s.Cardholder.Name,
                   date = s.LogExceptionDate.Value,
                   worktime = s.Worktime,
                   imefirme = s.Cardholder.Firm.Name

               }).ToList();

                frmREPORT frmREPORT = new frmREPORT(ListaREP, "Time attendance report");
                frmREPORT.ShowDialog();

            }
            
        }
        private void dgLOGEXCEPTION_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dgLOGEXCEPTION.CurrentCell == null || e.RowIndex == -1) return;


            if (e.RowIndex >= 0)
            {                
                DataGridViewRow row = this.dgLOGEXCEPTION.Rows[e.RowIndex];

                string cardholID = row.Cells["gvCARDHOLDER"].Value.ToString();
                CARDHOLDERID1 = _context.Cardholders.Where(j => j.Name == cardholID).Select(s => s.CardholderID).First();

                var a = row.Cells["LogExceptionDate"].Value;
                string c = a.ToString();
                DateTime x = Convert.ToDateTime(c);
                dgLogDetails.DataSource = null;
                Lista1.Clear();
                Lista1 = _context.AccessLogs.ToList();
                Lista1 = Lista1.Where(i => ((CARDHOLDERID1 == 0) ? true : (i.LocalTime.Value.Date == x.Date) && (i.CardholderID == CARDHOLDERID1))).ToList();
                dgLogDetails.DataSource = Lista1;
                dgLogDetails.Visible = true;
            }
        }

        private void cboxFIRM_SelectedIndexChanged(object sender, EventArgs e)
        {
            FIRMID = _context.Firms.Where(j => j.Name == cboxFIRM.Text).Select(s => s.FirmID).First();
            if (cboxFIRM.Text == "" || _context.Firms.Where(j => j.Name == cboxFIRM.Text).Select(s => s.FirmID).Count() == 0 || cboxFIRM.Text == "All" || FIRMID == 0)
            {
                
                cboxCARDHOLDER.DataSource = _context.Cardholders.OrderBy(o => o.Name).ToList();
                cboxCARDHOLDER.Text = "";
                ListaLOGEXCEPTION = _context.LogExceptions.Where(w => w.LogExceptionDate >= dateTimePicker1.Value.Date && w.LogExceptionDate <= dateTimePicker2.Value.Date).OrderBy(i => i.Cardholder.Name).ToList();
                dgLOGEXCEPTION.DataSource = ListaLOGEXCEPTION;

            }
            else
            {
                dgLOGEXCEPTION.DataSource = null;
                ListaLOGEXCEPTION = null;
                FIRMID = _context.Firms.Where(j => j.Name == cboxFIRM.Text).Select(s => s.FirmID).First();
                cboxCARDHOLDER.DataSource = _context.Cardholders.Where(j => j.FirmID == FIRMID).OrderBy(o => o.Name).ToList();

                if (_context.LogExceptions.Where(w => w.LogExceptionDate >= dateTimePicker1.Value.Date && w.LogExceptionDate <= dateTimePicker2.Value.Date && w.Cardholder.FirmID == FIRMID).ToList() != null) {
                    ListaLOGEXCEPTION = _context.LogExceptions.Where(w => w.LogExceptionDate >= dateTimePicker1.Value.Date && w.LogExceptionDate <= dateTimePicker2.Value.Date && w.Cardholder.FirmID == FIRMID).OrderBy(i=> i.Cardholder.Name).ToList();
                    dgLOGEXCEPTION.DataSource = ListaLOGEXCEPTION;
                }
                else
                {                }

                cboxCARDHOLDER.Text = "";
            }
        }


        //private void cboxFIRM_TextChanged(object sender, EventArgs e)
        //{

        //}
        //private void cboxCARDHOLDER_TextChanged(object sender, EventArgs e)
        //{
        //    CARDHOLDERID = 0;

        //    // dgLogDetails.Visible = false;

        //    if (cboxCARDHOLDER.Text == "" || cboxCARDHOLDER.Text == "AccessLog")
        //    {

        //    }
        //    else
        //    {
        //        CARDHOLDERID = _context.Cardholders.Where(w => w.Name == cboxCARDHOLDER.Text).Select(s => s.CardholderID).First();

        //        createQueryLOGEXCEPTION();
        //        //logExceptionBindingSource.DataSource = ListaLOGEXCEPTION;
        //        dgLOGEXCEPTION.DataSource = ListaLOGEXCEPTION;
        //    }

        //    // RACUNANJE VREMENA IZ INT

        //    if (_context.LogExceptions.Where(w => w.CardholderID == CARDHOLDERID && w.LogExceptionDate == dateTimePicker1.Value.Date).Select(s => s.Worktime).Count() == 0)
        //    {

        //    }
        //    else
        //    {
        //        WORKTIME = _context.LogExceptions.Where(w => w.CardholderID == CARDHOLDERID && w.LogExceptionDate == dateTimePicker1.Value.Date).Select(s => s.Worktime).First();
        //        WORKTIMESTRING = (WORKTIME / 60 + ":" + WORKTIME % 60).ToString();
        //    }

        //    createQueryCHKINOUTTRUE();
        //    createQueryCHKWORKTIMETRUE();
        //}

        //private void cboxCARDHOLDER_TextChanged_1(object sender, EventArgs e)
        //{
        //    FIRMID = 0;

        //    if (cboxCARDHOLDER.Text == "All")
        //    {
        //        if (cboxFIRM.Text != "")
        //        {
        //            if (_context.Firms.Where(j => j.Name == cboxFIRM.Text).Select(s => s.FirmID).Count() == 0)
        //            {

        //            }
        //            else
        //            {
        //                FIRMID = _context.Firms.Where(j => j.Name == cboxFIRM.Text).Select(s => s.FirmID).First();
        //                ListaLOGEXCEPTION = _context.LogExceptions.ToList();
        //                ListaLOGEXCEPTION = ListaLOGEXCEPTION.Where(i => ((i.LogExceptionDate >= dateTimePicker1.Value.Date)
        //                                           && (i.LogExceptionDate <= dateTimePicker2.Value.Date
        //                                           && i.Cardholder.FirmID == FIRMID))).ToList();

        //                //logExceptionBindingSource.DataSource = ListaLOGEXCEPTION;
        //                dgLOGEXCEPTION.DataSource = ListaLOGEXCEPTION;
        //            }                                      

        //            createQueryCHKINOUTTRUE();
        //            createQueryCHKWORKTIMETRUE();
        //        }
        //        else
        //        {                   
        //                ListaLOGEXCEPTION = _context.LogExceptions.ToList();

        //                ListaLOGEXCEPTION = ListaLOGEXCEPTION.Where(i => ((CARDHOLDERID == 0) ? true : (i.LogExceptionDate >= dateTimePicker1.Value.Date)
        //                                           && (i.LogExceptionDate <= dateTimePicker2.Value.Date)
        //                                           && (i.CardholderID == CARDHOLDERID))).ToList();

        //                //logExceptionBindingSource.DataSource = ListaLOGEXCEPTION;
        //                dgLOGEXCEPTION.DataSource = ListaLOGEXCEPTION;

        //            createQueryCHKINOUTTRUE();
        //            createQueryCHKWORKTIMETRUE();

        //        }
        //    }
        //}

        private void dgLogDetails_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgLogDetails.Columns[e.ColumnIndex].Name.Equals("direction") && e.RowIndex >= 0 && dgLogDetails["direction", e.RowIndex].Value is int)
            {

                switch ((int)dgLogDetails["direction", e.RowIndex].Value)
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
            if (dgLogDetails.Columns[e.ColumnIndex].Name.Equals("localTime") &&
                e.RowIndex >= 0)
            {
                var a = dgLogDetails["localTime", e.RowIndex].Value;
                string c = a.ToString();
                DateTime x = Convert.ToDateTime(c);
                e.Value = x.ToLongTimeString();

            }

        }

    }
    
}
