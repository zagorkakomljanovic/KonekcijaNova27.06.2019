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
    public partial class frmNONWORKINGDAYS : Form
    {

        konekcija.MojaEntities _context;
        int CARDHOLDERID;
        int FIRMID;
        int CONTRACTID;
        int bud;

        List<Cardholder> ListaCARDHOLDER;
        List<Firm> ListaFIRMA;
        List<Religion> ListaRELIGIJA;
        List<NonWorkingDay> ListaNONWORKINGDAY;
        double a;

        public frmNONWORKINGDAYS()
        {
            _context = new konekcija.MojaEntities();

            InitializeComponent();
        }

        private void frmNONWORKINGDAYS_Load(object sender, EventArgs e)
        {
            ListaCARDHOLDER = _context.Cardholders.OrderBy(o => o.Name).ToList();
            ListaFIRMA = _context.Firms.OrderBy(o => o.Name).ToList();
            ListaRELIGIJA = _context.Religions.OrderBy(o => o.Name).ToList();
            cardholderBindingSource.DataSource = ListaCARDHOLDER;
            firmBindingSource.DataSource = ListaFIRMA;
            cbxReligion.DataSource = ListaRELIGIJA;
            cboxCARDHOLDER.Text = "";
            cboxFIRM.Text = "";
            cbxReligion.Text = "";
        }


        private void cboxCARDHOLDER_SelectedIndexChanged(object sender, EventArgs e)
        {
            CARDHOLDERID = 0;
            if (cboxCARDHOLDER.Text == "")
            {
                cbxReligion.Text = "";
            }
            else
            {
                CARDHOLDERID = _context.Cardholders.Where(w => w.Name == cboxCARDHOLDER.Text).Select(s => s.CardholderID).First();
                if (_context.Cardholders.Where(w => w.CardholderID == CARDHOLDERID).Select(s => s.ReligionID).First() is null)
                {
                    cbxReligion.Text = "";
                }
                else
                {
                    int? ReligionID = _context.Cardholders.Where(w => w.Name == cboxCARDHOLDER.Text).Select(s => s.ReligionID).First();
                    String a = _context.Religions.Where(w => w.ReligionID == ReligionID).Select(s => s.Name).First();
                    cbxReligion.Text = a;
                }

                if (_context.NonWorkingDays.Where(w => w.CardholderID == CARDHOLDERID).Select(s => s.TotalNWD).Count() == 0)
                {
                    txtTOTAL.Text = "";
                }
                else
                {
                    txtTOTAL.Text = _context.Cardholders.Where(w => w.CardholderID == CARDHOLDERID).Select(s => s.SumNWD).First().ToString();
                }
            }

            //Prikazivanje datuma ugovora


            if (_context.Contracts.Where(j => j.CardholderID == CARDHOLDERID && j.ActiveState == true).ToList().Count() == 0)
            {
                dateTimePicker1.Value = System.DateTime.Now;
                dateTimePicker2.Value = System.DateTime.Now;
            }
            else
            {
                dateTimePicker1.Value = _context.Contracts.Where(j => j.CardholderID == CARDHOLDERID && j.ActiveState == true).Select(s => s.FromDate).First();
                dateTimePicker2.Value = _context.Contracts.Where(j => j.CardholderID == CARDHOLDERID && j.ActiveState == true).Select(s => s.ToDate).First();
            }


        }

        private void txtTOTAL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar > (char)Keys.D9 || e.KeyChar < (char)Keys.D0) && e.KeyChar != (char)Keys.Back)//&& e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void btnSAVE_Click(object sender, EventArgs e)
        {
            if (_context.NonWorkingDays.Where(j => j.CardholderID == CARDHOLDERID).Select(s => s.Non_working_daysID).Count() == 0)
            {
            }
            else
            {
                try
                {
                    if (_context.NonWorkingDays.Where(j => j.CardholderID == CARDHOLDERID).Select(s => s.Non_working_daysID).Count() != 0)
                    {
                        var queryNONWD = _context.NonWorkingDays.Where(j => j.CardholderID == CARDHOLDERID).ToList();
                        var NONWD = queryNONWD[0];
                        NONWD.TotalNWD = Convert.ToDouble(txtTOTAL.Text);
                        _context.SaveChanges();

                        MessageBox.Show("Number of non-working days are successfully changed.", "Successful",
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    }
                    else
                    {
                        bud = _context.Cardholders.Where(w => w.Name == cboxCARDHOLDER.Text).Select(s => s.CardholderID).First();

                        var i = new NonWorkingDay();
                        i.CardholderID = CARDHOLDERID;
                        i.TotalNWD = Convert.ToInt32(txtTOTAL.Text);
                        _context.NonWorkingDays.AddObject(i);
                        _context.SaveChanges();


                        MessageBox.Show("Number of non-working days are successfully added.", "Successful",
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
                catch
                {
                    MessageBox.Show("Something went wrong. Please try again.", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }


                cboxCARDHOLDER.Text = "";
                txtTOTAL.Text = "";

            }
        }

        private void btnAddNewReligion_Click(object sender, EventArgs e)
        {
            Form form = new frmRELIGION();
            form.ShowDialog();
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
            if(dateTimePicker1.Value > dateTimePicker2.Value)
            {
                errorProvider2.SetError(cboxCARDHOLDER, "Incorect dates.");
                dateTimePicker1.Focus();
                dateTimePicker1.TextChanged += (s, ex) => { errorProvider1.SetError(dateTimePicker1, ""); };
                return;
            }

            if (dateTimePicker2.Value.Date <= System.DateTime.Now  || _context.Contracts.Where(j => j.CardholderID == CARDHOLDERID && j.ActiveState == true).Select(s => s.ContractID).Count() != 0)
            {
                MessageBox.Show("Sorry, but you did not put valid date or active contract already exists. Delete it or contact your administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                try
                {
                    var i = new Contract();
                    i.ActiveState = true;
                    i.CardholderID = CARDHOLDERID;
                    i.FromDate = dateTimePicker1.Value.Date;
                    i.ToDate = dateTimePicker2.Value.Date;
                    a = ((((dateTimePicker1.Value.Year - dateTimePicker2.Value.Year) * 12) + dateTimePicker2.Value.Month - dateTimePicker1.Value.Month) * 1.66);
                    i.FreeDays= a;
                    MessageBox.Show((i.FreeDays) + "");
                    _context.Contracts.AddObject(i);
                    _context.SaveChanges();

                    var k = new NonWorkingDay();
                    k.CardholderID = CARDHOLDERID;
                    k.TotalNWD = a;
                    k.Description = "Contract +"+a;
                    _context.NonWorkingDays.AddObject(k);
                    _context.SaveChanges();

                    var queryCARDHOLDER = _context.Cardholders.Where(j => j.CardholderID == CARDHOLDERID).ToList();
                    var CardholderVar = queryCARDHOLDER[0];
                    CardholderVar.SumNWD =+ a;
                    _context.SaveChanges();

                    txtTOTAL.Text = CardholderVar.SumNWD.ToString();
                    if (_context.Cardholders.Where(w => w.CardholderID == CARDHOLDERID).Select(s => s.SumNWD).First() is null)
                    {                        txtTOTAL.Text = ""; }
                    else
                    { txtTOTAL.Text = queryCARDHOLDER.First().SumNWD.ToString(); }
                    MessageBox.Show("New contract has been successfully added.", "Successful",
                                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    gbCONTRACT.BackColor = Color.FromArgb(0, 255, 0);
                }
                catch
                {
                    MessageBox.Show("Something went wrong. Please try again or contact your administrator.", "Error",
                                   MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }

        }

        private void cboxFIRM_TextChanged(object sender, EventArgs e)
        {
            if (cboxFIRM.Text == "" || _context.Firms.Where(j => j.Name == cboxFIRM.Text).Select(s => s.FirmID).Count() == 0)
            {
                cboxCARDHOLDER.DataSource = _context.Cardholders.OrderBy(o => o.Name).ToList();
            }
            else
            {
                FIRMID = _context.Firms.Where(j => j.Name == cboxFIRM.Text).Select(s => s.FirmID).First();
                cboxCARDHOLDER.DataSource = _context.Cardholders.Where(j => j.FirmID == FIRMID).OrderBy(o => o.Name).ToList();
            }
        }

        //private void btnMODIFY_Click(object sender, EventArgs e)
        //{
        //    if (_context.Contracts.Where(j => j.CardholderID == CARDHOLDERID && j.ActiveState == true).Select(s => s.ContractID).Count() == 0)
        //    {

        //    }
        //    else
        //    {
        //        CONTRACTID = _context.Contracts.Where(j => j.CardholderID == CARDHOLDERID).Select(s => s.ContractID).First();

        //        try
        //        {

        //            var queryCONTRACT = _context.Contracts.Where(j => j.ContractID == CONTRACTID).ToList();
        //            var CONTR = queryCONTRACT[0];
        //            CONTR.FromDate = dateTimePicker1.Value.Date;
        //            CONTR.ToDate = dateTimePicker2.Value.Date;

        //            _context.SaveChanges();

        //            MessageBox.Show("Contract has been successfully changed.", "Successful",
        //                            MessageBoxButtons.OK, MessageBoxIcon.Asterisk);


        //        }
        //        catch
        //        {
        //            MessageBox.Show("Something went wrong. Please try again or contact your administrator.", "Error",
        //            MessageBoxButtons.OK, MessageBoxIcon.Hand);
        //        }

        //    }
        //}

        private void CreateQueryACTIVECOTRACT()
        {
            if (cboxCARDHOLDER.Text != "" && _context.Cardholders.Where(j => j.Name == cboxCARDHOLDER.Text).Select(s => s.CardholderID).Count() != 0)
            {
                if (_context.Contracts.Where(j => j.CardholderID == CARDHOLDERID && j.ActiveState == true).Select(s => s.ActiveState).Count() != 0)
                {
                    gbCONTRACT.BackColor = Color.FromArgb(0, 255, 0);
                }
                else
                {
                    gbCONTRACT.BackColor = System.Drawing.SystemColors.ControlLightLight;
                }
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            // Indikator statusa ugovora

            CreateQueryACTIVECOTRACT();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            // Indikator statusa ugovora

            CreateQueryACTIVECOTRACT();
        }

        private void btnDELETE_Click(object sender, EventArgs e)
        {
            if (CARDHOLDERID == 0) {
                errorProvider1.SetError(cboxCARDHOLDER, "Please, choose the worker.");
                cboxCARDHOLDER.Focus();
                cboxCARDHOLDER.TextChanged += (s, ex) => { errorProvider1.SetError(cboxCARDHOLDER, ""); };
                return;
            }
            if (_context.Contracts.Where(j => j.CardholderID == CARDHOLDERID && j.ActiveState == true).Select(s => s.ContractID).Count() == 0)
            {

            }
            else
            {
                try
                {
                    if (MessageBox.Show("Do you really want to delete contract?", "Delete",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        CONTRACTID = _context.Contracts.Where(j => j.CardholderID == CARDHOLDERID && j.ActiveState == true).Select(s => s.ContractID).First();
                        double? b= _context.Contracts.Where(j => j.CardholderID == CARDHOLDERID && j.ActiveState == true).Select(s => s.FreeDays).First();

                        var k = new NonWorkingDay();
                        k.CardholderID = CARDHOLDERID;
                        k.TotalNWD = a;
                        k.Description = "Contract -" + b;
                        _context.NonWorkingDays.AddObject(k);
                        _context.SaveChanges();

                        var queryCARDHOLDER = _context.Cardholders.Where(j => j.CardholderID == CARDHOLDERID).ToList();
                        var CardholderVar = queryCARDHOLDER[0];
                        CardholderVar.SumNWD = CardholderVar.SumNWD - b; 
                        _context.SaveChanges();

                        txtTOTAL.Text = CardholderVar.SumNWD.ToString();
                        if (_context.Cardholders.Where(w => w.CardholderID == CARDHOLDERID).Select(s => s.SumNWD).First() is null)
                        { txtTOTAL.Text = ""; }
                        else
                        { txtTOTAL.Text = queryCARDHOLDER.First().SumNWD.ToString(); }
                        gbCONTRACT.BackColor = Color.FromArgb(255, 0, 0);

                        System.Data.EntityKey contractKey = new System.Data.EntityKey("MojaEntities.Contracts", "ContractID", CONTRACTID);
                        var ContractDelete = _context.GetObjectByKey(contractKey);
                        _context.DeleteObject(ContractDelete);
                        _context.SaveChanges();


                        MessageBox.Show("Contract has been successfully deleted!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        cboxCARDHOLDER.Text = "";
                        gbCONTRACT.BackColor = System.Drawing.SystemColors.ControlLightLight;
                    }
                }
                catch
                {
                    MessageBox.Show("Delete operation was not successful. Please, contact your administrator.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void btnAssignReligion_Click(object sender, EventArgs e)
        {
            if (cboxCARDHOLDER.Text != "" && _context.Cardholders.Where(j => j.Name == cboxCARDHOLDER.Text).Select(s => s.CardholderID).Count() != 0 && cbxReligion.Text != "")
            {
                int ReligionID= _context.Religions.Where(k => k.Name == cbxReligion.Text).Select(s=>s.ReligionID).First();
                var Cardholder = _context.Cardholders.First(k => k.CardholderID == CARDHOLDERID);
                Cardholder.ReligionID = ReligionID;
                _context.SaveChanges();
                MessageBox.Show("You have successfully added religion.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            else
            {
                errorProvider1.SetError(cboxCARDHOLDER, "Please, choose the worker.");
                cboxCARDHOLDER.Focus();
                cboxCARDHOLDER.TextChanged += (s, ex) => { errorProvider1.SetError(cboxCARDHOLDER, ""); };
                return;
            }


        }

        private void cbxReligion_SelectedIndexChanged(object sender, EventArgs e)
        {


 //           cbxReligion.DataSource= _context.Religions.OrderBy(o => o.Name).ToList(); 
        }

        //private void cbxReligion_Click(object sender, EventArgs e) {
        //    ListaRELIGIJA = _context.Religions.OrderBy(o => o.Name).ToList();
        //    cbxReligion.DataSource = ListaRELIGIJA;
        //    cbxReligion.Text = "";
        //}
        //private void cbxReligion_TextChanged(object sender, EventArgs e)
        //{
        //    cboxCARDHOLDER_SelectedIndexChanged(sender, e);
        //}

    }
}
