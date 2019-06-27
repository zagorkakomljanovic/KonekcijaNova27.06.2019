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
    public partial class frmSHIFT : Form
    {
        konekcija.MojaEntities _context { get; set; }

        int SHIFTID;
        int SHIFTIDW;
        int CARDHOLDERID;
        int CARDHOLDERSHIFTID;

        List<Cardholder> ListCARDHOLDER;
        List<Shift> ListSHIFT;

        public frmSHIFT()
        {
            InitializeComponent();

            _context = new MojaEntities();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar > (char)Keys.D9 || e.KeyChar < (char)Keys.D0) && e.KeyChar != (char)Keys.Back)//&& e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void frmSHIFT_Load(object sender, EventArgs e)
        {

            ListCARDHOLDER = _context.Cardholders.ToList();
            ListSHIFT = _context.Shifts.ToList();

            cboxCARDHOLDER.DataSource = _context.Cardholders.ToList();
            cboxSHIFTNAME.DataSource = _context.Shifts.ToList();
            cboxSHIFTNAMEW.DataSource = _context.Shifts.ToList();


            cboxCARDHOLDER.Text = "";
            cboxSHIFTNAME.Text = "";
            cboxSHIFTNAMEW.Text = "";
            cboxBREAKTIME.Text = null;
        }

        private void btnADD_Click(object sender, EventArgs e)
        {
            if (_context.Shifts.Where(w => w.ShiftName == cboxSHIFTNAME.Text).Select(s => s.ShiftID).Count() == 0)
            {
                SHIFTID = 0;
            }

            if (cboxBREAKTIME.Text == "" || cboxSHIFTNAME.Text == "" || txtWORKINGHOURS.Text == "" || SHIFTID != 0)
            {
                MessageBox.Show("You have missed some info or shift name already exists.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                var i = new Shift();
                i.BreakTime = Convert.ToDouble(cboxBREAKTIME.Text);
                i.WorkingHours = Convert.ToDouble(txtWORKINGHOURS.Text) * 60;
                i.ShiftName = cboxSHIFTNAME.Text;
                i.Monday = chkMODAY.Checked;
                i.Tuesday = chkTUESDAY.Checked;
                i.Wednesday = chkWEDNESDAY.Checked;
                i.Thuersday = chkTHUERSDAY.Checked;
                i.Friday = chkFRIDAY.Checked;
                i.Saturday = chkSATURDAY.Checked;
                i.Sunday = chkSUNDAY.Checked;

                _context.Shifts.AddObject(i);
                _context.SaveChanges();

                MessageBox.Show("New shift has been successfully added", "Successful",
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);


                // ListSHIFT = _context.Shifts.ToList();
                // shiftBindingSource.DataSource = ListSHIFT;
                // workershiftBindingSource.DataSource = ListSHIFT;

                cboxSHIFTNAME.DataSource = _context.Shifts.ToList();
                cboxSHIFTNAMEW.DataSource = _context.Shifts.ToList();
                cboxSHIFTNAME.Text = "";
                cboxSHIFTNAMEW.Text = "";

                SHIFTID = 0;
                cboxSHIFTNAME.Text = "";
                txtWORKINGHOURS.Text = "";
                cboxBREAKTIME.Text = "";
                chkMODAY.Checked = false;
                chkTUESDAY.Checked = false;
                chkWEDNESDAY.Checked = false;
                chkTHUERSDAY.Checked = false;
                chkFRIDAY.Checked = false;
                chkSATURDAY.Checked = false;
                chkSUNDAY.Checked = false;
            }

        }

        private void cboxSHIFTNAME_SelectedIndexChanged(object sender, EventArgs e)
        {

            var shift = from s in _context.Shifts
                        where s.ShiftName == cboxSHIFTNAME.Text
                        select new
                        {
                            s.Monday,
                            s.Tuesday,
                            s.Wednesday,
                            s.Thuersday,
                            s.Friday,
                            s.Saturday,
                            s.Sunday,
                            s.ShiftID,
                            s.WorkingHours,
                            s.BreakTime
                        };
            foreach (var i in shift)
            {
                chkMODAY.Checked = i.Monday;
                chkTUESDAY.Checked = i.Tuesday;
                chkWEDNESDAY.Checked = i.Wednesday;
                chkTHUERSDAY.Checked = i.Thuersday;
                chkFRIDAY.Checked = i.Friday;
                chkSATURDAY.Checked = i.Saturday;
                chkSUNDAY.Checked = i.Sunday;
                txtWORKINGHOURS.Text = (i.WorkingHours / 60).ToString();
                cboxBREAKTIME.Text = (Convert.ToInt32(i.BreakTime)).ToString();
            }

        }

        private void btnSAVECHANGE_Click(object sender, EventArgs e)
        {
            if (_context.Shifts.Where(w => w.ShiftName == cboxSHIFTNAME.Text).Select(s => s.ShiftID).Count() == 0)
            {

            }
            else
            {
                SHIFTID = _context.Shifts.Where(w => w.ShiftName == cboxSHIFTNAME.Text).Select(s => s.ShiftID).First();

                try
                {
                    var shiftQuery = _context.Shifts.Where(w => w.ShiftID == SHIFTID).ToList();
                    var shift = shiftQuery[0];

                    shift.Monday = chkMODAY.Checked;
                    shift.Tuesday = chkTUESDAY.Checked;
                    shift.Wednesday = chkWEDNESDAY.Checked;
                    shift.Thuersday = chkTHUERSDAY.Checked;
                    shift.Friday = chkFRIDAY.Checked;
                    shift.Saturday = chkSATURDAY.Checked;
                    shift.Sunday = chkSUNDAY.Checked;
                    shift.ShiftName = cboxSHIFTNAME.Text;
                    shift.WorkingHours = Convert.ToInt32(txtWORKINGHOURS.Text) * 60;
                    shift.BreakTime = Convert.ToDouble(cboxBREAKTIME.Text);

                    _context.SaveChanges();

                    //ListSHIFT = null;
                    //ListSHIFT = _context.Shifts.ToList();

                    MessageBox.Show("Changes are seuccesffully saved!", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                }
                catch
                {
                    MessageBox.Show("Changes are not saved. please, contact your administrator.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }

        private void cboxSHIFTNAME_TextChanged(object sender, EventArgs e)
        {
            if (_context.Shifts.Where(w => w.ShiftName == cboxSHIFTNAME.Text).Select(s => s.ShiftID).Count() == 0)
            {
                chkMODAY.Checked = false;
                chkTUESDAY.Checked = false;
                chkWEDNESDAY.Checked = false;
                chkTHUERSDAY.Checked = false;
                chkFRIDAY.Checked = false;
                chkSATURDAY.Checked = false;
                chkSUNDAY.Checked = false;
                txtWORKINGHOURS.Text = "";
                cboxBREAKTIME.Text = "";
                cboxSHIFTNAMEW.Text = "";
                cboxBREAKTIME.Text = null;
            }
            else
            {
                var shift = from s in _context.Shifts
                            where s.ShiftName == cboxSHIFTNAME.Text
                            select new
                            {
                                s.Monday,
                                s.Tuesday,
                                s.Wednesday,
                                s.Thuersday,
                                s.Friday,
                                s.Saturday,
                                s.Sunday,
                                s.ShiftID,
                                s.WorkingHours,
                                s.BreakTime
                            };
                foreach (var i in shift)
                {
                    chkMODAY.Checked = i.Monday;
                    chkTUESDAY.Checked = i.Tuesday;
                    chkWEDNESDAY.Checked = i.Wednesday;
                    chkTHUERSDAY.Checked = i.Thuersday;
                    chkFRIDAY.Checked = i.Friday;
                    chkSATURDAY.Checked = i.Saturday;
                    chkSUNDAY.Checked = i.Sunday;
                    txtWORKINGHOURS.Text = (i.WorkingHours / 60).ToString();
                    cboxBREAKTIME.Text = (Convert.ToInt32(i.BreakTime)).ToString();
                }

                cboxSHIFTNAMEW.Text = "";
            }
        }

        private void cboxSHIFTNAMEW_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_context.Shifts.Where(w => w.ShiftName == cboxSHIFTNAMEW.Text).Select(s => s.ShiftID).Count() == 0)
            {

            }
            else
            {
                SHIFTIDW = _context.Shifts.Where(w => w.ShiftName == cboxSHIFTNAMEW.Text).Select(s => s.ShiftID).First();
            }
        }

        private void btnASSIGN_Click(object sender, EventArgs e)
        {
            if (_context.Cardholders.Where(w => w.Name == cboxCARDHOLDER.Text).Select(s => s.CardholderID).Count() == 0
                || _context.Shifts.Where(w => w.ShiftName == cboxSHIFTNAMEW.Text).Select(s => s.ShiftID).Count() == 0)
            {

            }
            else
            {
                try
                {
                    CARDHOLDERID = _context.Cardholders.Where(w => w.Name == cboxCARDHOLDER.Text).Select(s => s.CardholderID).First();
                    SHIFTIDW = _context.Shifts.Where(w => w.ShiftName == cboxSHIFTNAMEW.Text).Select(s => s.ShiftID).First();

                    var queryCholdshift = _context.Cardholders.Where(j => j.CardholderID == CARDHOLDERID).ToList();
                    var choldershift = queryCholdshift[0];

                    choldershift.CardholderID = CARDHOLDERID;
                    choldershift.ShiftID = SHIFTIDW;

                    _context.SaveChanges();


                    MessageBox.Show("You have successfully assigned shift!", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                catch
                {
                    MessageBox.Show("Shift is not assigned. Please, contact your administrator.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }


        }

        private void cboxCARDHOLDER_SelectedIndexChanged(object sender, EventArgs e)
        {
            // CARDHOLDERSHIFTID = _context.CardholderShifts.Where(w => w.CardholderID == CARDHOLDERID).Select(s => s.CardholderShiftID).First();
            if (_context.Cardholders.Where(w => w.Name == cboxCARDHOLDER.Text).Select(s => s.CardholderID).Count() == 0)
            {

            }
            else
            {
                CARDHOLDERID = _context.Cardholders.Where(w => w.Name == cboxCARDHOLDER.Text).Select(s => s.CardholderID).First();
                string SHIFTNAMEW;
                if (_context.Cardholders.Where(w => w.CardholderID == CARDHOLDERID).Select(s => s.Shift.ShiftName).Count() == 0)
                {
                    cboxSHIFTNAMEW.Text = "";
                }
                else
                {
                    SHIFTNAMEW = _context.Cardholders.Where(w => w.CardholderID == CARDHOLDERID).Select(s => s.Shift.ShiftName).First();
                    cboxSHIFTNAMEW.Text = SHIFTNAMEW;
                }

            }

        }
        private void Combo1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnDELETE_Click(object sender, EventArgs e)
        {
            if (_context.Shifts.Where(w => w.ShiftName == cboxSHIFTNAME.Text).Select(s => s.ShiftID).Count() == 0)
            {

            }
            else
            {
                SHIFTID = _context.Shifts.Where(w => w.ShiftName == cboxSHIFTNAME.Text).Select(s => s.ShiftID).First();


                try
                {
                    var shiftQuery = from i in _context.Shifts
                                     where i.ShiftName == cboxSHIFTNAME.Text
                                     select new { i.ShiftID };
                    foreach (var item in shiftQuery)
                    {
                        SHIFTID = item.ShiftID;
                    }
                    if (SHIFTID == 0)
                    {


                    }
                    else
                    {
                        if (MessageBox.Show("Do you really want to delete shift?", "Delete",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {

                            System.Data.EntityKey shiftsKey = new System.Data.EntityKey("MojaEntities.Shifts", "ShiftID", SHIFTID);
                            var shiftDelete = _context.GetObjectByKey(shiftsKey);
                            _context.DeleteObject(shiftDelete);
                            _context.SaveChanges();


                            MessageBox.Show("You have successfully deleted assigned shift!", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                            ListSHIFT = null;
                            ListSHIFT = _context.Shifts.ToList();
                            cboxSHIFTNAME.DataSource = _context.Shifts.ToList();
                            cboxSHIFTNAMEW.DataSource = _context.Shifts.ToList();
                            cboxSHIFTNAME.Text = "";
                            cboxSHIFTNAMEW.Text = "";
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

        private void btnREMOVE_Click(object sender, EventArgs e)
        {
            if (_context.Shifts.Where(w => w.ShiftName == cboxSHIFTNAMEW.Text).Select(s => s.ShiftID).Count() == 0 ||
                _context.Cardholders.Where(w => w.Name == cboxCARDHOLDER.Text).Select(s => s.CardholderID).Count() == 0)
            {

            }
            else
            {
                SHIFTID = _context.Shifts.Where(w => w.ShiftName == cboxSHIFTNAMEW.Text).Select(s => s.ShiftID).First();
                CARDHOLDERID = _context.Cardholders.Where(w => w.Name == cboxCARDHOLDER.Text).Select(s => s.CardholderID).First();

                try
                {
                    //var shiftQuery = from i in _context.Shifts
                    //                 where i.ShiftName == cboxSHIFTNAME.Text
                    //                 select new { i.ShiftID };
                    //foreach (var item in shiftQuery)
                    //{
                    //    SHIFTID = item.ShiftID;
                    //}
                    if (SHIFTID == 0)
                    {


                    }
                    else
                    {
                        if (MessageBox.Show("Do you really want to remove shift from selected worker?", "Delete",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {

                            System.Data.EntityKey cardholdershiftKey = new System.Data.EntityKey("MojaEntities.CardholderShifts", "CardholderShiftID", CARDHOLDERSHIFTID);
                            var cardholdershiftDelete = _context.GetObjectByKey(cardholdershiftKey);
                            _context.DeleteObject(cardholdershiftDelete);
                            _context.SaveChanges();


                            MessageBox.Show("You have successfully removed shift from selected worker!", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Asterisk);


                            if (cboxSHIFTNAME.Text != "")
                            {
                                cboxSHIFTNAME.DataSource = _context.Shifts.ToList();
                            }

                            ListSHIFT = null;
                            ListSHIFT = _context.Shifts.ToList();

                            cboxSHIFTNAMEW.DataSource = _context.Shifts.ToList();
                            cboxSHIFTNAME.Text = "";
                            cboxSHIFTNAMEW.Text = "";
                            cboxCARDHOLDER.Text = "";



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

        private void cboxCARDHOLDER_TextChanged(object sender, EventArgs e)
        {
            if (cboxCARDHOLDER.Text == "")
            {
                cboxSHIFTNAMEW.Text = "";
            }

        }
    }
}
