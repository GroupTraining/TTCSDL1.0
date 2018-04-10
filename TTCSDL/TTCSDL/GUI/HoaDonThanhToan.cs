﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using BUS;

namespace TTCSDL.GUI
{
    public partial class HoaDonThanhToan : Form
    {
        CSDLConnected csdl = new CSDLConnected();
        TTCSDLDataContext data = new TTCSDLDataContext();
        
        public HoaDonThanhToan()
        {
            InitializeComponent();
            this.CenterToParent();
            data.Update_ThanhTien();
            data.Update_TongTien();
            data.CTHDTT();
            button4.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridViewHDTT.DataSource = csdl.getDataHDTT(textTenKH.Text);
            dataGridViewHDTT.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewHDTT.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            button4.Hide();
            button2.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            button2.Hide();
            button4.Show();
            dataGridViewHDTT.DataSource = csdl.getDataHDDV(textTenKH.Text);
            dataGridViewHDTT.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewHDTT.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewHDTT.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void dataGridViewHDTT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowindex = dataGridViewHDTT.CurrentCell.RowIndex;
            int columnindex = dataGridViewHDTT.CurrentCell.ColumnIndex;
            textTenKH.Text = dataGridViewHDTT.Rows[rowindex].Cells[1].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            GUI.HoaDonThanhToan hdtt = new GUI.HoaDonThanhToan();
            hdtt.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GUI.EditHDDichVu edit_hddv = new GUI.EditHDDichVu();
            edit_hddv.Show();
        }
    }
}
