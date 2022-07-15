using System.Management;

namespace ironcheckerWF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // get videocart
            foreach (ManagementObject mo in new ManagementObjectSearcher("root\\cimv2", "select * from win32_videocontroller").Get())
                lblres_videocar.Text = $"{(string)mo[("Name")]}";
            //get mother
            foreach (ManagementObject mo in new ManagementObjectSearcher("root\\cimv2", "select * from win32_baseboard").Get())
                lblres_mom.Text = $"{(string)mo[("product")]}{(string)mo[("manufacturer")]}";
            //get processor
            foreach (ManagementObject mo in new ManagementObjectSearcher("root\\cimv2", "select * from win32_Processor").Get())
                lblres_proc.Text = $"{(string)mo[("Name")]}";
            //get hard disk
            foreach (ManagementObject mo in new ManagementObjectSearcher("root\\cimv2", "select * from Win32_DiskDrive").Get())
                lblres_disk.Text = $"{(string)mo["Model"]}";
            //get keyboard
            foreach (ManagementObject mo in new ManagementObjectSearcher("root\\cimv2", "select * from Win32_keyboard").Get())
                lblres_clava.Text = $"{(string)mo[("Name")]}";
            //get tv
            foreach (ManagementObject mo in new ManagementObjectSearcher("root\\wmi", "select * from WmiMonitorID").Get())
                foreach (var monitor in (ushort[])mo[("UserFriendlyName")])
                {
                    lblres_ekran.Text += (char)monitor;
                }
        }
    }
}