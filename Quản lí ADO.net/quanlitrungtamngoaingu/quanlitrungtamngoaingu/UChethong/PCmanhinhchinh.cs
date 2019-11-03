using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using quanlitrungtamngoaingu.UCgiaovien;
using quanlitrungtamngoaingu.UChocvien;
using quanlitrungtamngoaingu.UClophoc;
using quanlitrungtamngoaingu.UCDiemso;
using quanlitrungtamngoaingu.UCkhoahoc;
using quanlitrungtamngoaingu.UCChungchi;
using quanlitrungtamngoaingu.Thoigian;
using quanlitrungtamngoaingu.UCDiemdanh;
using quanlitrungtamngoaingu.UCkhuyenmai;
using quanlitrungtamngoaingu.UClichgiang;
using quanlitrungtamngoaingu.UCThongke;
using quanlitrungtamngoaingu.UCGiupdo;


namespace quanlitrungtamngoaingu.UChethong
{
    public partial class PCmanhinhchinh : MetroFramework.Controls.MetroUserControl
    {
        public PCmanhinhchinh()
        {
            InitializeComponent();
        }
        int begin = 0;
        private void PCmanhinhchinh_Load(object sender, EventArgs e)
        {

        }




        private void metroPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
            if (begin>=mplmhc.Size.Width)
            {
                timer1.Stop();
                Ucgiaovienmanhinhchinh plgiaovien = new Ucgiaovienmanhinhchinh();
                plgiaovien.Dock = DockStyle.Fill;
                Frmmain.Frmain.mpanelcontainer.Controls.Add(plgiaovien);
                Frmmain.Frmain.mpanelcontainer.Controls["Ucgiaovienmanhinhchinh"].BringToFront();
                foreach (PCmanhinhchinh mhc in Frmmain.Frmain.mpanelcontainer.Controls.OfType<PCmanhinhchinh>())
                {
                    Frmmain.Frmain.mpanelcontainer.Controls.Remove(mhc);
                }
            }
            else
            {
                begin=begin+ 40;
                mplmhc.Location = new Point(begin, 0);
            }
        }

        private void mTilegiaovien_Click_1(object sender, EventArgs e)
        {
            timer1.Start();
        }
        private void mtilehocsinh_Click(object sender, EventArgs e)
        {
            try
            {
                UCHocvienmanhinhchinh plhocvien = new UCHocvienmanhinhchinh();
                plhocvien.Dock = DockStyle.Fill;
                Frmmain.Frmain.mpanelcontainer.Controls.Add(plhocvien);
                foreach (PCmanhinhchinh mhc in Frmmain.Frmain.mpanelcontainer.Controls.OfType<PCmanhinhchinh>())
                {
                    Frmmain.Frmain.mpanelcontainer.Controls.Remove(mhc);
                }
            }
            catch
            {
                MessageBox.Show("khong thuc hien duoc");
            }
        }

        private void mtilelophoc_Click(object sender, EventArgs e)
        {
            try
            {

                UClophoc.UClophocmanhinhchinh pllophoc = new UClophocmanhinhchinh();
               pllophoc.Dock = DockStyle.Fill;
                Frmmain.Frmain.mpanelcontainer.Controls.Add(pllophoc);
                foreach (PCmanhinhchinh mhc in Frmmain.Frmain.mpanelcontainer.Controls.OfType<PCmanhinhchinh>())
                {
                    Frmmain.Frmain.mpanelcontainer.Controls.Remove(mhc);
                }
            }
            catch
            {
                MessageBox.Show("khong thuc hien duoc");
            }
        }

        private void mtilediemso_Click(object sender, EventArgs e)
        {
            try
            {

               UCdiemsomanhinhchinh pldiemso = new UCdiemsomanhinhchinh();
                pldiemso.Dock = DockStyle.Fill;
                Frmmain.Frmain.mpanelcontainer.Controls.Add(pldiemso);
                foreach (PCmanhinhchinh mhc in Frmmain.Frmain.mpanelcontainer.Controls.OfType<PCmanhinhchinh>())
                {
                    Frmmain.Frmain.mpanelcontainer.Controls.Remove(mhc);
                }
            }
            catch
            {
                MessageBox.Show("khong thuc hien duoc");
            }

        }

        private void mtilekhoahoc_Click(object sender, EventArgs e)
        {
            try
            {

               UCkhoahocmanhinhchinh plkhoahoc = new UCkhoahocmanhinhchinh();
                plkhoahoc.Dock = DockStyle.Fill;
                Frmmain.Frmain.mpanelcontainer.Controls.Add(plkhoahoc);
                foreach (PCmanhinhchinh mhc in Frmmain.Frmain.mpanelcontainer.Controls.OfType<PCmanhinhchinh>())
                {
                    Frmmain.Frmain.mpanelcontainer.Controls.Remove(mhc);
                }
            }
            catch
            {
                MessageBox.Show("khong thuc hien duoc");
            }
        }

        private void mtilechungchi_Click(object sender, EventArgs e)
        {
            try
            {

                UCchungchimanhinhchinnh plchungchi = new UCchungchimanhinhchinnh();
                plchungchi.Dock = DockStyle.Fill;
                Frmmain.Frmain.mpanelcontainer.Controls.Add(plchungchi);
                foreach (PCmanhinhchinh mhc in Frmmain.Frmain.mpanelcontainer.Controls.OfType<PCmanhinhchinh>())
                {
                    Frmmain.Frmain.mpanelcontainer.Controls.Remove(mhc);
                }
            }
            catch
            {
                MessageBox.Show("khong thuc hien duoc");
            }
        }

        private void mtilediemdanh_Click(object sender, EventArgs e)
        {
            try
            {

               UCDiemdanhmanhinhchinh pldiemdanh = new UCDiemdanhmanhinhchinh();
                pldiemdanh.Dock = DockStyle.Fill;
                Frmmain.Frmain.mpanelcontainer.Controls.Add(pldiemdanh);
                foreach (PCmanhinhchinh mhc in Frmmain.Frmain.mpanelcontainer.Controls.OfType<PCmanhinhchinh>())
                {
                    Frmmain.Frmain.mpanelcontainer.Controls.Remove(mhc);
                }
            }
            catch
            {
                MessageBox.Show("khong thuc hien duoc");
            }
        }

        private void mtilekhuyenmai_Click(object sender, EventArgs e)
        {
            try
            {

                UCkhuyenmaimanhinhchinh plkhuyenmai = new UCkhuyenmaimanhinhchinh();
               plkhuyenmai.Dock = DockStyle.Fill;
                Frmmain.Frmain.mpanelcontainer.Controls.Add(plkhuyenmai);
                foreach (PCmanhinhchinh mhc in Frmmain.Frmain.mpanelcontainer.Controls.OfType<PCmanhinhchinh>())
                {
                    Frmmain.Frmain.mpanelcontainer.Controls.Remove(mhc);
                }
            }
            catch
            {
                MessageBox.Show("khong thuc hien duoc");
            }
        }

        private void mtilethoigian_Click(object sender, EventArgs e)
        {
            try
            {

                UCthoigianmanhinhchinh plthoigian = new UCthoigianmanhinhchinh();
                plthoigian.Dock = DockStyle.Fill;
                Frmmain.Frmain.mpanelcontainer.Controls.Add(plthoigian);
                foreach (PCmanhinhchinh mhc in Frmmain.Frmain.mpanelcontainer.Controls.OfType<PCmanhinhchinh>())
                {
                    Frmmain.Frmain.mpanelcontainer.Controls.Remove(mhc);
                }
            }
            catch
            {
                MessageBox.Show("khong thuc hien duoc");
            }
        }

        private void mtilelichgiang_Click(object sender, EventArgs e)
        {
            try
            {

              UClichgiangmanhinhchinh pllichgiang = new UClichgiangmanhinhchinh();
                pllichgiang.Dock = DockStyle.Fill;
                Frmmain.Frmain.mpanelcontainer.Controls.Add(pllichgiang);
                foreach (PCmanhinhchinh mhc in Frmmain.Frmain.mpanelcontainer.Controls.OfType<PCmanhinhchinh>())
                {
                    Frmmain.Frmain.mpanelcontainer.Controls.Remove(mhc);
                }
            }
            catch
            {
                MessageBox.Show("khong thuc hien duoc");
            }
        }

        private void mtilethongke_Click(object sender, EventArgs e)
        {
            try
            {

             UCthongkemanhinhchinh plthongke = new UCthongkemanhinhchinh();
                plthongke.Dock = DockStyle.Fill;
                Frmmain.Frmain.mpanelcontainer.Controls.Add(plthongke);
                foreach (PCmanhinhchinh mhc in Frmmain.Frmain.mpanelcontainer.Controls.OfType<PCmanhinhchinh>())
                {
                    Frmmain.Frmain.mpanelcontainer.Controls.Remove(mhc);
                }
            }
            catch
            {
                MessageBox.Show("khong thuc hien duoc");
            }
        }

        private void mtiledangxuat_Click(object sender, EventArgs e)
        {
            try
            {

               UCdangnhap dangnhap = new UCdangnhap();
                dangnhap.Dock = DockStyle.Fill;
                Frmmain.Frmain.mpanelcontainer.Controls.Add(dangnhap);
                foreach (PCmanhinhchinh mhc in Frmmain.Frmain.mpanelcontainer.Controls.OfType<PCmanhinhchinh>())
                {
                    Frmmain.Frmain.mpanelcontainer.Controls.Remove(mhc);
                }
            }
            catch
            {
                MessageBox.Show("khong thuc hien duoc");
            }
        }

        private void mtilecaidat_Click(object sender, EventArgs e)
        {
            try
            {

               ucCaidat catdat = new ucCaidat();
                catdat.Dock = DockStyle.Fill;
                Frmmain.Frmain.mpanelcontainer.Controls.Add(catdat);
                foreach (PCmanhinhchinh mhc in Frmmain.Frmain.mpanelcontainer.Controls.OfType<PCmanhinhchinh>())
                {
                    Frmmain.Frmain.mpanelcontainer.Controls.Remove(mhc);
                }
            }
            catch
            {
                MessageBox.Show("khong thuc hien duoc");
            }
        }

        private void mtiletrogiup_Click(object sender, EventArgs e)
        {
            try
            {

               UCgiupdomanhinhchinh catdat = new UCgiupdomanhinhchinh();
                catdat.Dock = DockStyle.Fill;
                Frmmain.Frmain.mpanelcontainer.Controls.Add(catdat);
                foreach (PCmanhinhchinh mhc in Frmmain.Frmain.mpanelcontainer.Controls.OfType<PCmanhinhchinh>())
                {
                    Frmmain.Frmain.mpanelcontainer.Controls.Remove(mhc);
                }
            }
            catch
            {
                MessageBox.Show("khong thuc hien duoc");
            }
        }
    }
}

