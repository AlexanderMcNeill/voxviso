﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using VoxVisio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsInput;
using VoxVisio.Singletons;

namespace VoxVisio.Tests
{
    [TestClass()]
    public class CommandSingletonTests
    {
        [TestMethod()]
        public void InstanceTest()
        {
            SettingsSingleton cs = SettingsSingleton.Instance();
            SettingsSingleton cs2 = SettingsSingleton.Instance();
            Assert.AreEqual(cs, cs2);
        }

        [TestMethod()]
        public void SetCommandsTest()
        {
            SettingsSingleton cs = SettingsSingleton.Instance();
            SettingsSingleton cs2 = SettingsSingleton.Instance();
            List<VoiceCommand> commands = new List<VoiceCommand>();
            commands.Add(new VoiceCommand("open", "enter", new InputSimulator()));
            cs.SetCommands(commands);
            Assert.AreEqual(cs.Commands,cs2.Commands);
            commands.Add(new VoiceCommand("click", "m1", new InputSimulator()));
            Assert.AreEqual(cs.Commands.Count, 2);
            Assert.AreEqual(cs2.Commands.Count, 2);

        }
    }
}