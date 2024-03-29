﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 库存管理系统
{
    public partial class DelUser : Form
    {
        public Admin _admin;
        public DelUser(Admin _admin,string usr="")
        {
            InitializeComponent();
            this._admin = _admin;
            _usr.Text = usr;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            Msql sql = new Msql();
            string authority = "1";
            // 检测是否为外键
            if (sql.exist(String.Format("select * from record where usr='{0}' limit 1;", _usr.Text)))
            {
                if (MessageBox.Show("检测到此用户操作过商品库存，\n删除此用户将会把相应的库存记录一并删除，\n确定继续删除此用户吗？", "", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                {
                    return;
                }
            }
            var ans = sql.modify(String.Format("delete from user where usr='{0}' and authority='{1}'", _usr.Text, authority));
            if (ans == false)
            {
                MessageBox.Show("用户不存在或你无权限删除此用户！");
                return;
            }
            else
            {
                MessageBox.Show("删除成功！");
                _admin.flashPerson();
                this.Close();
            }
        }
    }
}
