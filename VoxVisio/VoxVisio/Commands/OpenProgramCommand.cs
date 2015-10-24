﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace VoxVisio.Commands
{
    public class OpenProgramCommand : Command
    {
        // How to start a program System.Diagnostics.Process.Start("C:/Program Files (x86)/OptiKey/OptiKey.exe");
        private string ProgramLocation;
        private string KeyWord;

        public OpenProgramCommand(string programLocation, string KeyWord)
        {
            this.ProgramLocation = programLocation;
            this.KeyWord = KeyWord;
        }

        public OpenProgramCommand(JObject jsonData)
        {
            LoadFromJson(jsonData);
        }

        public void RunCommand()
        {
            Process.Start(ProgramLocation);
        }

        public void LoadFromJson(JObject jsonData)
        {
            ProgramLocation = (string)jsonData["program location"];
            KeyWord = (string)jsonData["keyword"];
        }

        public JObject SaveToJson()
        {
            JObject toReturn = new JObject();
            toReturn["program location"] = ProgramLocation;
            toReturn["keyword"] = KeyWord;
            toReturn["command type"] = GetCommandType().ToString();
            return toReturn;
        }

        public string GetKeyWord()
        {
            return KeyWord;
        }

        public string GetProgramLocation()
        {
            return ProgramLocation;
        }
        public eCommandType GetCommandType()
        {
            return eCommandType.OpenProgramCommand;
        }
    }
}