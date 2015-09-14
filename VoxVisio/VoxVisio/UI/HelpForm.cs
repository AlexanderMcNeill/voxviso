﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VoxVisio.UI
{
    public partial class HelpForm : Form
    {
        private CommandSingleton commandList;
        public HelpForm()
        {
            InitializeComponent();
            commandList = CommandSingleton.Instance();
            PopulateCommandList();
        }

        private void PopulateCommandList()
        {
            foreach (Command c in commandList.Commands)
            {
                lvCommandList.Items.Add(new ListViewItem(new string[] {c.VoiceKeyword, c.keyCombo.GetKeyString()}));
            }
        }
    }
}