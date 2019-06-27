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
    public partial class frmRELIGION : Form
    {
        int? RELIGIONID, TOTALRELIGIONDAYS, RELIGIONHOLIDAYSID;
        konekcija.MojaEntities _context;
        List<Religion> ListaRELIGION;
        List<ReligionHoliday> ListaRELIGIONHOLIDAY;
        public frmRELIGION()
        {
            InitializeComponent();
        }

        private void frmRELIGION_Load(object sender, EventArgs e)
        {
            _context = new konekcija.MojaEntities();
            ListaRELIGION = _context.Religions.ToList();
            ListaRELIGIONHOLIDAY = _context.ReligionHolidays.ToList();
            cbxReligionName.DataSource = ListaRELIGION;
            cbxReligionName.Text = "";
            txtTotalReligionDays.Text = "";
        }

        private void btnReligionName_Click(object sender, EventArgs e)
        {
            if (_context.Religions.Where(j => j.Name == cbxReligionName.Text).Select(s => s.ReligionID).Count() == 0)
            {
                if (cbxReligionName.Text == "")
                {
                }
                else
                {
                    var queryReligion = new Religion();
                    queryReligion.Name = cbxReligionName.Text;
                    queryReligion.TotalReligiousDays = 0;

                    _context.Religions.AddObject(queryReligion);
                    _context.SaveChanges();

                    MessageBox.Show("You have successfully added new religion to database.", "Successful",
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    RefreshDates();
                }

            }
            else
            { MessageBox.Show("Allready exist. "); }

        }

        private void btnReligiousDates_Click(object sender, EventArgs e)
        {

            if (cbxReligionName.Text == "") {            }
            else
            {
                var queryReligiousDate = new ReligionHoliday();
                queryReligiousDate.ReligionID = _context.Religions.Where(j => j.Name == cbxReligionName.Text).Select(s => s.ReligionID).First();
                RELIGIONID = _context.Religions.Where(j => j.Name == cbxReligionName.Text).Select(s => s.ReligionID).First();
                int a = _context.Religions.Where(j => j.Name == cbxReligionName.Text).Select(s => s.ReligionID).First();
                queryReligiousDate.ReligionHolidaysDate = dateTimePicker1.Value.Date;
                TOTALRELIGIONDAYS = _context.Religions.Where(w => w.Name == cbxReligionName.Text).Select(s => s.TotalReligiousDays).First();

                if (_context.ReligionHolidays.Where(j => j.ReligionID == queryReligiousDate.ReligionID && j.ReligionHolidaysDate == dateTimePicker1.Value.Date).Select(s => s.ReligionID).Count() == 0)
                {
                    _context.ReligionHolidays.AddObject(queryReligiousDate);
                    _context.SaveChanges();
                    MessageBox.Show("You have successfully added new date to database.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    TOTALRELIGIONDAYS += 1;
                    var Religion = _context.Religions.First(k => k.ReligionID == RELIGIONID);
                    Religion.TotalReligiousDays = TOTALRELIGIONDAYS;
                    txtTotalReligionDays.Text = "" + TOTALRELIGIONDAYS.ToString();
                    _context.SaveChanges();
                    RefreshDates();

                }
                else
                { MessageBox.Show("Date already exist."); }

            }

        }

        private void txtReligionName_TextChanged(object sender, EventArgs e)
        {
            RELIGIONID = 0;
            ListaRELIGIONHOLIDAY = null;
            if (cbxReligionName.Text == "")
            {
                dgReligionHolidays.DataSource = null;
            }
            else
            {
                if (_context.Religions.Where(w => w.Name == cbxReligionName.Text).Select(s => s.ReligionID).Count() == 0) { }
                else { RefreshDates(); }
            }
        }

        private void btnRemoveReligion_Click(object sender, EventArgs e)
        {
            try
            {

                if (_context.Religions.Where(j => j.Name == cbxReligionName.Text).Select(s => s.ReligionID).Count() != 0)
                {
                    if (MessageBox.Show("Do you really want to delete religion?", "Delete",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        RELIGIONID = _context.Religions.Where(j => j.Name == cbxReligionName.Text).Select(s => s.ReligionID).First();

                        System.Data.EntityKey religionKey = new System.Data.EntityKey("MojaEntities.Religions", "ReligionID", RELIGIONID);
                        var religionDelete = _context.GetObjectByKey(religionKey);
                        _context.DeleteObject(religionDelete);
                        _context.SaveChanges();

                        MessageBox.Show("You have successfully deleted religion from database.", "Successful",
                                MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        cbxReligionName.Text = "";

                        cbxReligionName.DataSource = _context.Religions.OrderBy(o => o.Name).ToList();
                    }
                }

            }
            catch
            {
                MessageBox.Show("Delete operation was not successful. Please, contact your administrator.", "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {   
            this.Close();
        }


        private void btnRemoveReligionDates_Click(object sender, EventArgs e)
        {
            try
            {
                RELIGIONID = _context.Religions.Where(j => j.Name == cbxReligionName.Text).Select(s => s.ReligionID).First();
                if ( _context.ReligionHolidays.Where(j => (j.ReligionID == RELIGIONID) && j.ReligionHolidaysDate==dateTimePicker1.Value.Date).Select(s => s.ReligionHolidaysDate).Count() != 0)
                {
                    if (MessageBox.Show("Do you really want to delete this date?", "Delete",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        RELIGIONHOLIDAYSID = _context.ReligionHolidays.Where(j => (j.ReligionID == RELIGIONID) && j.ReligionHolidaysDate == dateTimePicker1.Value.Date).Select(s => s.ReligionHolidaysID).First();
                        System.Data.EntityKey religionKey = new System.Data.EntityKey("MojaEntities.ReligionHolidays", "ReligionHolidaysID", RELIGIONHOLIDAYSID);
                        var religionHolidayDelete = _context.GetObjectByKey(religionKey);
                        _context.DeleteObject(religionHolidayDelete);
                        _context.SaveChanges();

                        MessageBox.Show("You have successfully deleted religion from database.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        TOTALRELIGIONDAYS = _context.Religions.Where(w => w.Name == cbxReligionName.Text).Select(s => s.TotalReligiousDays).First();
                        TOTALRELIGIONDAYS -= 1;
                        var Religion = _context.Religions.First(k => k.ReligionID == RELIGIONID);
                        Religion.TotalReligiousDays = TOTALRELIGIONDAYS;
                        txtTotalReligionDays.Text = "" + TOTALRELIGIONDAYS.ToString();
                        _context.SaveChanges();
                        RefreshDates();
                    }
                }
        }
            catch
            {
                MessageBox.Show("Delete operation was not successful. Please, contact your administrator.", "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
}


        private void RefreshDates()
        {
            RELIGIONID = _context.Religions.Where(w => w.Name == cbxReligionName.Text).Select(s => s.ReligionID).First();
            ListaRELIGIONHOLIDAY = _context.ReligionHolidays.Where(j => j.ReligionID == RELIGIONID).ToList();
            dgReligionHolidays.DataSource = ListaRELIGIONHOLIDAY;
            TOTALRELIGIONDAYS = _context.Religions.Where(w => w.Name == cbxReligionName.Text).Select(s => s.TotalReligiousDays).First();
            txtTotalReligionDays.Text = "" + TOTALRELIGIONDAYS.ToString();
        }
        
    }
}
