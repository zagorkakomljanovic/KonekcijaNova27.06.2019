using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace konekcija
{
    public partial class frmHOLIDAY : Form
    {

        private konekcija.MojaEntities _context;


        int CARDHOLDERID;
        int? RELIGIONID,SHIFTID;
        double? TLEFT;
        double? NUMBEROFDAYS;
        List<DateTime> ListOfHoliDates;
        List<DateTime?> ListOfReligionDates;



        public frmHOLIDAY()
        {
            InitializeComponent();
        }

        private void frmHOLIDAY_Load(object sender, EventArgs e)
        {
            _context = new konekcija.MojaEntities();

            cardholderBindingSource.DataSource = _context.Cardholders.OrderBy(o => o.Name).ToList();
            cmbCARDHOLDER.Text = "";

        }
        IEnumerable<DateTime> GetDateRange(DateTime StartingDate, DateTime EndingDate)
        {
            while (StartingDate <= EndingDate)
            {
                yield return StartingDate;
                StartingDate = StartingDate.AddDays(1);
            }
        }
        private void CheckDates()
        {
            if (dateTimePicker2.Value <= dateTimePicker1.Value)
            {
                MessageBox.Show("Invalid return date");
            }
            else
            {
                double days = (dateTimePicker2.Value.Date - dateTimePicker1.Value.Date).TotalDays;
                NUMBEROFDAYS = Convert.ToDouble(days);
                ListOfHoliDates = GetDateRange(dateTimePicker1.Value.Date, dateTimePicker2.Value.Date).ToList();
                var b = _context.Cardholders.Where(w => w.CardholderID == CARDHOLDERID).Single();
                RELIGIONID = b.ReligionID;
                ListOfReligionDates = _context.ReligionHolidays.Where(w => w.ReligionID == RELIGIONID).Select(s => s.ReligionHolidaysDate).ToList();
                SHIFTID = b.ShiftID;
                var shift= _context.Shifts.Where(w => w.ShiftID == SHIFTID).Single();
                
                foreach (var item in ListOfHoliDates)
                {   
 //                 RELIGIONID = _context.Cardholders.Where(w => w.CardholderID == CARDHOLDERID).Select(s => s.ReligionID).First();
                    
                    if (ListOfReligionDates == null || item == ListOfHoliDates.Last())
                    { }
                    else
                    {
                        if (ListOfReligionDates.Contains(item.Date) )
                        {
                            NUMBEROFDAYS --;
                        }
                        else {
                            switch (item.DayOfWeek)
                            {
                                case DayOfWeek.Sunday:
                                    {
                                        MessageBox.Show(item.DayOfWeek.ToString());
                                        if (shift.Sunday == false)
                                            NUMBEROFDAYS--;
                                        break;
                                    }
                                case DayOfWeek.Monday:
                                    {
                                        MessageBox.Show(item.DayOfWeek.ToString());
                                        if (shift.Monday == false)
                                            NUMBEROFDAYS--;
                                        break;
                                    }
                                case DayOfWeek.Tuesday:
                                    {
                                        MessageBox.Show(item.DayOfWeek.ToString());
                                        if (shift.Thuersday == false)
                                            NUMBEROFDAYS--;
                                        break;
                                    }
                                case DayOfWeek.Wednesday:
                                    {
                                        MessageBox.Show(item.DayOfWeek.ToString());
                                        if (shift.Wednesday == false)
                                            NUMBEROFDAYS--;
                                        break;
                                    }
                                case DayOfWeek.Thursday:
                                    {
                                        MessageBox.Show(item.DayOfWeek.ToString());
                                        if (shift.Thuersday == false)
                                            NUMBEROFDAYS--;
                                        break;
                                    }
                                case DayOfWeek.Friday:
                                    {
                                        MessageBox.Show(item.DayOfWeek.ToString());
                                        if (shift.Friday == false)
                                            NUMBEROFDAYS--;
                                        break;
                                    }
                                case DayOfWeek.Saturday:
                                    {
                                        MessageBox.Show(item.DayOfWeek.ToString());
                                        if (shift.Saturday == false)
                                            NUMBEROFDAYS--;
                                        break;
                                    }
                                default:
                                    break;
                            }
                        }
                    }


                }
                txtTOTAL.Text = NUMBEROFDAYS.ToString();
                txtTOTALLEFT.Text = (TLEFT - NUMBEROFDAYS).ToString();
                TxtAVAILABLE.Text = TLEFT.ToString();
            }
        }
        private void btnACCEPT_Click(object sender, EventArgs e)
        {
            CheckDates();

            if (CARDHOLDERID == 0 || dateTimePicker2.Value <= dateTimePicker1.Value)
            {
                MessageBox.Show("Date or worker name is not valid.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                var holi = new Holiday();
                holi.CardholderID = CARDHOLDERID;
                holi.LeaveDate = dateTimePicker1.Value;
                holi.ReturnDate = dateTimePicker2.Value;
                holi.NumberOfDays = NUMBEROFDAYS;
                _context.Holidays.AddObject(holi);
                _context.SaveChanges();

                var queryCARDHOLDER = _context.Cardholders.Where(j => j.CardholderID == CARDHOLDERID).ToList();
                var CardholderVar = queryCARDHOLDER[0];
                CardholderVar.SumNWD = TLEFT - NUMBEROFDAYS;
                _context.SaveChanges();

                var k = new NonWorkingDay();
                k.CardholderID = CARDHOLDERID;
                k.TotalNWD = NUMBEROFDAYS;
                k.Description = "Holiday" + "-" + NUMBEROFDAYS+" from " +dateTimePicker1.Value.Date.ToString().Substring(0,8)+" to"+dateTimePicker2.Value.Date.ToString().Substring(0, 8);
                _context.NonWorkingDays.AddObject(k);
                _context.SaveChanges();
                MessageBox.Show("Leave request successfully added.", "Successful",
                MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                CARDHOLDERID = 0;
                NUMBEROFDAYS = 0;
                cmbCARDHOLDER.Text = "";
                RELIGIONID = 0;
                txtTOTAL.Text = "";
                txtTOTALLEFT.Text = "";
                TxtAVAILABLE.Text = "";
            }
        }



        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            //ODUZIMANJE DATUMA

            if (dateTimePicker2.Value <= dateTimePicker1.Value)
            {
                TxtAVAILABLE.Text = "ERROR";
                MessageBox.Show("Invalid return date");
                
            }
            else
            {
                //double days = (dateTimePicker2.Value - dateTimePicker1.Value).TotalDays;
                //NUMBEROFDAYS = Convert.ToDouble(days);
                CheckDates();
                //txtTOTAL.Text = Convert.ToInt16(days).ToString();
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

            //ODUZIMANJE DATUMA

            if (dateTimePicker2.Value <= dateTimePicker1.Value)
            {
                txtTOTAL.Text = "ERROR";
                MessageBox.Show("Invalid return date");
            }
            else
            {
                //double days = (dateTimePicker2.Value - dateTimePicker1.Value).TotalDays;
                //NUMBEROFDAYS = Convert.ToDouble(days);
                CheckDates();
                //txtTOTAL.Text = NUMBEROFDAYS.ToString();
            }
        }

        private void cmbCARDHOLDER_SelectedIndexChanged(object sender, EventArgs e)
        {
            CARDHOLDERID = 0;
            NUMBEROFDAYS = 0;
            TLEFT = 0;
            txtTOTAL.Text = "";
            txtTOTALLEFT.Text = "";
            TxtAVAILABLE.Text = "";

            if (cmbCARDHOLDER.Text == "")
            {

            }
            else
            {
                CARDHOLDERID = _context.Cardholders.Where(w => w.Name == cmbCARDHOLDER.Text).Select(s => s.CardholderID).First();
                TLEFT = _context.Cardholders.Where(w => w.CardholderID == CARDHOLDERID).Select(s => s.SumNWD).First();
                if (_context.NonWorkingDays.Where(w => w.CardholderID == CARDHOLDERID).Select(s => s.TotalNWD).Count() == 0)
                { }
                else
                {   
                    //NUMBEROFDAYS = Convert.ToInt32(_context.Holidays.Where(w => w.CardholderID == CARDHOLDERID).Select(s => s.NumberOfDays).Sum());

                    TxtAVAILABLE.Text = TLEFT.ToString();
                    CheckDates();
                }                               

            }
            
        }

        private void btnFREEDAYS_Click(object sender, EventArgs e)
        {   
            Form frm = new frmNONWORKINGDAYS();
            frm.ShowDialog();
        }
        private void btnFREEDAYS_TextChanged(object sender, EventArgs e)
        {
            Form frm = new frmNONWORKINGDAYS();
            frm.ShowDialog();
        }


        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar > (char)Keys.D9 || e.KeyChar < (char)Keys.D0) && e.KeyChar != (char)Keys.Back)//&& e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }
    }
}

