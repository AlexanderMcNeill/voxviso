﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoxVisio.Screen_Overlay;

namespace VoxVisio.Singletons
{
    class SharedFormsSingleton
    {
        private static SharedFormsSingleton _singleton;

        //Form for displaying graphics over the screen
        public readonly OverlayForm overlayForm;

        //Form for the zoom click
        public readonly ZoomForm zoomForm;

        protected SharedFormsSingleton()
        {
            //Setting up the forms that need to always be available to the program
            overlayForm = new OverlayForm();
            zoomForm = new ZoomForm();
            overlayForm.Show();
        }

        public static SharedFormsSingleton Instance()
        {
            // Uses lazy initialization.
            // Note: this is not thread safe.
            if (_singleton == null)
            {
                _singleton = new SharedFormsSingleton();
            }

            return _singleton;
        }
    }
}