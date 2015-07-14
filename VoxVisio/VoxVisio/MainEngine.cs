﻿using System;
using System.Drawing;
using EyeXFramework;
using Tobii.EyeX.Framework;
using System.Speech.Recognition;

namespace VoxVisio
{
    public class MainEngine
    {
        private ControlContext controlState;
        private EyeXHost eyex;
        private SpeechRecognitionEngine speechRecognizer = new SpeechRecognitionEngine();
        private Grammar commandGrammar;
        private Grammar dictationGrammar;

        public MainEngine()
        {
            controlState = new ControlContext(new StandardState());
            eyex = new EyeXHost();
            controlState.changedState += StateChanged;
            eyex.CreateFixationDataStream(FixationDataMode.Sensitive).Next += (s, e) => Fixation(e.EventType ,(int)e.X, (int)e.Y, e.Timestamp);

            commandGrammar = null; //TODO: Add dans get grammar method
            dictationGrammar = new DictationGrammar();

            speechRecognizer.RequestRecognizerUpdate();
            speechRecognizer.LoadGrammar(commandGrammar);
            speechRecognizer.SpeechRecognized += SpeechRecognised;
            speechRecognizer.SetInputToDefaultAudioDevice();
            speechRecognizer.RecognizeAsync(RecognizeMode.Multiple);
        }


        public void Fixation(FixationDataEventType t, int x, int y, double timeStamp)
        {
            Fixation fx = null;
            if (t == FixationDataEventType.Begin)
            {
                fx = new Fixation(new Point(x, y), eFixationPhase.start);
            }
            if (t == FixationDataEventType.End)
            {
                fx = new Fixation(new Point(x,y),eFixationPhase.finished );
            }
            controlState.EyeRequest(fx);
        }

        public void SpeechRecognised(object sender, SpeechRecognizedEventArgs e)
        {
            controlState.VoiceRequest(e.Result.Text);
        }

        public void StateChanged()
        {
            
            if (controlState.ControlState.GetType() == typeof (StandardState))
            {
                speechRecognizer.LoadGrammar(commandGrammar);
            }
            else if (controlState.ControlState.GetType() == typeof(DictationState))
            {
                speechRecognizer.LoadGrammar(dictationGrammar);
                
            }
           
        }
    }
}
