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
    public partial class frmCARDHOLDERFIRM : Form
    {

        konekcija.MojaEntities _context;
        
        List<Cardholder> ListaCARDHOLDER;
        List<Firm> ListaFIRM;


        int CARDHOLDERID;
        int? FIRMID;


        public frmCARDHOLDERFIRM()
        {
            _context = new MojaEntities();

            InitializeComponent();
            ListaCARDHOLDER = _context.Cardholders.ToList();
            foreach (var item in ListaCARDHOLDER)
            {
                checkComboBox1.Items.Add(new CheckComboBox.ComboboxData(item.Name, false));
            }

        }

        private void frmCARDHOLDERFIRM_Load(object sender, EventArgs e)
        {            
            ListaCARDHOLDER = _context.Cardholders.ToList();
            cboxCARDHOLDER.DataSource = ListaCARDHOLDER.OrderBy(o => o.Name).ToList();

            ListaFIRM = _context.Firms.ToList();
            cboxFIRM.DataSource = ListaFIRM.OrderBy(o => o.Name).ToList();           

            cboxCARDHOLDER.Text = "";
            cboxFIRM.Text = "";
        }

        private void btnADD_Click(object sender, EventArgs e)
        {

            if (_context.Firms.Where(j => j.Name == cboxFIRM.Text).Select(s => s.FirmID).Count() == 0)
            {
                if (cboxFIRM.Text == "")
                {

                }
                else
                {
                    var queryFirm = new Firm();
                    queryFirm.Name = cboxFIRM.Text;
                    queryFirm.StartDate = System.DateTime.Now;

                    _context.Firms.AddObject(queryFirm);
                    _context.SaveChanges();

                    MessageBox.Show("You have successfully added new firm to database.", "Successful",
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    cboxFIRM.DataSource = _context.Firms.OrderBy(o => o.Name).ToList();
                }
                
            }                        
            
        }

        private void btnREMOVE_Click(object sender, EventArgs e)
        {
            try
            {
                if (_context.Firms.Where(j => j.Name == cboxFIRM.Text).Select(s => s.FirmID).Count() != 0)
                {
                    if (MessageBox.Show("Do you really want to delete shift?", "Delete",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {

                        FIRMID = _context.Firms.Where(j => j.Name == cboxFIRM.Text).Select(s => s.FirmID).First();

                        System.Data.EntityKey firmKey = new System.Data.EntityKey("MojaEntities.Firms", "FirmID", FIRMID);
                        var firmDelete = _context.GetObjectByKey(firmKey);
                        _context.DeleteObject(firmDelete);
                        _context.SaveChanges();

                        MessageBox.Show("You have successfully deleted firm from database.", "Successful",
                                MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        cboxFIRM.Text = "";
                        
                        cboxFIRM.DataSource = _context.Firms.OrderBy(o => o.Name).ToList();


                    }
                }
            }
            catch
            {
                MessageBox.Show("Delete operation was not successful. Please, contact your administrator.", "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            
        }

        private void btnASSIGN_Click(object sender, EventArgs e)
        {
            try
            {
                if (_context.Cardholders.Where(j => j.Name == cboxCARDHOLDER.Text).Select(s => s.CardholderID).Count() == 0
                || _context.Firms.Where(j => j.Name == cboxFIRM.Text).Select(s => s.FirmID).Count() == 0)
                {

                }
                else
                {
                    FIRMID = _context.Firms.Where(j => j.Name == cboxFIRM.Text).Select(s => s.FirmID).First();
                    CARDHOLDERID = _context.Cardholders.Where(j => j.Name == cboxCARDHOLDER.Text).Select(s => s.CardholderID).First();

                    var queryCARDFIRM = _context.Cardholders.Where(j => j.CardholderID == CARDHOLDERID).ToList();
                    var CARDFIRM = queryCARDFIRM[0];
                    CARDFIRM.FirmID = FIRMID;                    
                    
                    _context.SaveChanges();

                    MessageBox.Show("You have successfully assigned worker and firm.", "Successful",
                                MessageBoxButtons.OK, MessageBoxIcon.Asterisk);


                }
            }
            catch
            {
                MessageBox.Show("Firm assigning was not successfully. Please, contact your administrator.", "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnMODIFY_Click(object sender, EventArgs e)
        {
            try
            {
                if (_context.Cardholders.Where(j => j.Name == cboxCARDHOLDER.Text).Select(s => s.CardholderID).Count() == 0
                || _context.Firms.Where(j => j.Name == cboxFIRM.Text).Select(s => s.FirmID).Count() == 0)
                {

                }
                else
                {

                    FIRMID = _context.Firms.Where(j => j.Name == cboxFIRM.Text).Select(s => s.FirmID).First();
                    CARDHOLDERID = _context.Cardholders.Where(j => j.Name == cboxCARDHOLDER.Text).Select(s => s.CardholderID).First();

                    var queryCARDFIRM = _context.Cardholders.Where(j => j.CardholderID == CARDHOLDERID).ToList();
                    var query = queryCARDFIRM[0];

                    query.FirmID = FIRMID;
                    query.CardholderID = CARDHOLDERID;

                    _context.SaveChanges();

                    MessageBox.Show("Changes are seuccesffully saved!", "Success",
                                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch
            {
                MessageBox.Show("Changes were not saved. Please, contact your administrator.", "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                if (_context.Cardholders.Where(j => j.CardholderID == CARDHOLDERID).Select(s => s.FirmID).First() == null)
                {
                    cboxFIRM.Text = "";
                }
                else
                {                    
                    FIRMID = _context.Cardholders.Where(j => j.CardholderID == CARDHOLDERID).Select(s => s.FirmID).First();
                    cboxFIRM.Text = _context.Firms.Where(j => j.FirmID == FIRMID).Select(s => s.Name).First();
                }
            }                       
        }
    }
}
