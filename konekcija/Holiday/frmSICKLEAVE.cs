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
    public partial class frmSICKLEAVE : Form
    {

        konekcija.MojaEntities _context;


        int CARDHOLDERID;
        int SICKLEAVEID;

        List<SickLeave> ListaSICKLEAVE { get; set; }
        List<DateTime> Lista { get; set; }
        List<ListaSickADD> ListaSICKADD { get; set; }

        public class ListaSickADD
        {
            public DateTime? date { get; set; }
            public int br { get; set; }
        }

        public frmSICKLEAVE()
        {
            InitializeComponent();

            _context = new konekcija.MojaEntities();

            sickLeaveBindingSource.DataSource = ListaSICKLEAVE;
        }
        private void frmSICKLEAVE_Load(object sender, EventArgs e)
        {
            cboxCARDHOLDER.DataSource = _context.Cardholders.OrderBy(o => o.Name).ToList();
            cboxCARDHOLDER.Name = "";

            ListaSICKLEAVE = _context.SickLeaves.ToList();
        }

        private void btnADD_Click(object sender, EventArgs e)
        {
            if (CARDHOLDERID == 0)
            {
                errorProvider1.SetError(cboxCARDHOLDER, "Please, choose the worker.");
                cboxCARDHOLDER.Focus();
                cboxCARDHOLDER.TextChanged += (s, ex) => { errorProvider1.SetError(cboxCARDHOLDER, ""); };
                return;
            }
            else errorProvider1.SetError(cboxCARDHOLDER, "");

            if (_context.SickLeaves.Where(j => j.Date == dateTimePicker1.Value.Date && j.CardholderID == CARDHOLDERID).Select(s => s.SickLeaveID).Count() != 0)
            {
                errorProvider1.SetError(dateTimePicker1, "Sick leave date has been already set. Please choose another date.");
                dateTimePicker1.Focus();
                dateTimePicker1.ValueChanged += (s, ex) => { errorProvider1.SetError(dateTimePicker1, ""); };
                return;
            }
            else errorProvider1.SetError(dateTimePicker1, "");


            try
            {
                var newSickLeave = new SickLeave();
                newSickLeave.CardholderID = CARDHOLDERID;
                newSickLeave.Date = dateTimePicker1.Value.Date;

                _context.SickLeaves.AddObject(newSickLeave);
                _context.SaveChanges();

                MessageBox.Show("Sick leave has been successfully added.", "Successful",
                                  MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                ListaSICKLEAVE = _context.SickLeaves.OrderBy(o => o.Date).ToList();
                dgSICKLEAVE.DataSource = ListaSICKLEAVE.Where(j => j.CardholderID == CARDHOLDERID).ToList();
            }
            catch
            {
                MessageBox.Show("Something went wrong. Please try again or contact your administrator.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void cboxCARDHOLDER_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_context.Cardholders.Where(j => j.Name == cboxCARDHOLDER.Text).Select(s => s.CardholderID).Count() == 0)
            {

            }
            else
            {
                CARDHOLDERID = _context.Cardholders.Where(j => j.Name == cboxCARDHOLDER.Text).Select(s => s.CardholderID).First();

                dgSICKLEAVE.DataSource = null;
                ListaSICKLEAVE = _context.SickLeaves.OrderBy(o => o.Date).ToList();
                dgSICKLEAVE.DataSource = ListaSICKLEAVE.Where(j => j.CardholderID == CARDHOLDERID).ToList();
            }
        }
        private void dgSICKLEAVE_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView gridView = sender as DataGridView;
            if (null != gridView)
            {
                foreach (DataGridViewRow r in gridView.Rows)
                {
                    gridView.Rows[r.Index].HeaderCell.Value =
                                        (r.Index + 1).ToString();
                }
            }
        }
        private void dgSICKADD_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView gridView = sender as DataGridView;
            if (null != gridView)
            {
                foreach (DataGridViewRow r in gridView.Rows)
                {
                    gridView.Rows[r.Index].HeaderCell.Value =
                                        (r.Index + 1).ToString();
                }
            }
        }
        private void dgSICKLEAVE_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            //SAVE BUTTON IN DATAGRIDVIEW
            if (e.ColumnIndex == 1)
            {
                DataGridViewRow row = this.dgSICKLEAVE.Rows[e.RowIndex];


                if (!row.IsNewRow)
                {
                    var date = row.Cells["Date"].Value;
                    DateTime dateTime = Convert.ToDateTime(date);
                    int SICKLEAVEID = Convert.ToInt16(row.Cells["SickLeaveIDCell"].Value);

                    if (_context.SickLeaves.Where(w => w.SickLeaveID == SICKLEAVEID).Select(s => s.SickLeaveID).Count() == 0)
                    {

                    }
                    else
                    {
                        if (_context.SickLeaves.Where(j => j.Date == dateTime && j.CardholderID == CARDHOLDERID).Select(s => s.SickLeaveID).Count() != 0)
                        {
                            MessageBox.Show("Save operation was not successful. Input date already exists.", "Error",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);


                            _context = new MojaEntities();
                            ListaSICKLEAVE = _context.SickLeaves.OrderBy(o => o.Date).ToList();
                            dgSICKLEAVE.DataSource = ListaSICKLEAVE.Where(j => j.CardholderID == CARDHOLDERID).ToList();


                        }
                        else
                        {
                            //SICKLEAVEID = _context.SickLeaves.Where(w => w.CardholderID == CARDHOLDERID && w.Date == dateTime).Select(s => s.SickLeaveID).First();
                            var leaveQuery = _context.SickLeaves.Where(w => w.SickLeaveID == SICKLEAVEID).ToList();
                            var sickleavesave = leaveQuery[0];
                            sickleavesave.Date = Convert.ToDateTime(row.Cells["Date"].Value);

                            _context.SaveChanges();

                            MessageBox.Show("Sick leave date has been successfully changed.", "Successful",
                                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }

                    }

                }
            }

            //BRISANJE SELEKTOVANOG REDA

            if (e.ColumnIndex == 2)
            {
                try
                {
                    DataGridViewRow row = this.dgSICKLEAVE.Rows[e.RowIndex];

                    if (!row.IsNewRow)
                    {
                        var date = row.Cells["Date"].Value;
                        DateTime dateTime = Convert.ToDateTime(date);

                        if (_context.SickLeaves.Where(w => w.Date == dateTime).Select(s => s.SickLeaveID).Count() == 0)
                        {

                        }
                        else
                        {
                            if (MessageBox.Show("Do you really want to delete sick leave date?", "Delete",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                            {
                                SICKLEAVEID = _context.SickLeaves.Where(w => w.Date == dateTime && w.CardholderID == CARDHOLDERID).Select(s => s.SickLeaveID).First();

                                System.Data.EntityKey sickleaveKey = new System.Data.EntityKey("MojaEntities.SickLeaves", "SickLeaveID", SICKLEAVEID);
                                var SickLeaveDelete = _context.GetObjectByKey(sickleaveKey);
                                _context.DeleteObject(SickLeaveDelete);
                                _context.SaveChanges();

                                MessageBox.Show("Contract has been successfully deleted!", "Success",
                                   MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                                ListaSICKLEAVE = _context.SickLeaves.OrderBy(o => o.Date).ToList();
                                dgSICKLEAVE.DataSource = ListaSICKLEAVE.Where(j => j.CardholderID == CARDHOLDERID).ToList();
                            }
                        }

                    }
                }
                catch
                {
                    MessageBox.Show("Delete operation was not successful. Please, contact your administrator.", "Error",
                                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
    }

}
