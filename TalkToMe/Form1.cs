using System;
using System.Speech.Synthesis;
using System.Windows.Forms;

namespace TalkToMe
{
    public partial class frmMain : Form
    {
        SpeechSynthesizer Synthesizer;

        public frmMain()
        {
            InitializeComponent();
            InitializeSpeech();
        }

        /// <summary>
        /// Initialization code for the speech synthesizer
        /// </summary>
        void InitializeSpeech()
        {
            Synthesizer = new SpeechSynthesizer(); // Create a speech synthesizer
            Synthesizer.SetOutputToDefaultAudioDevice(); // Set output to the default audio device

            // Get the names of all the voices available on this computer
            // Add them to a dropdown control for the user to select
            foreach (var voice in Synthesizer.GetInstalledVoices())
            {
                if (voice.Enabled)
                {
                    cboVoices.Items.Add(voice.VoiceInfo.Name);
                }
            }
            cboVoices.SelectedIndex = 0; // Default is the first voice detected
        }

        private void btnSpeak_Click(object sender, EventArgs e)
        {
            Synthesizer.Rate = (int)updnRate.Value;
            Synthesizer.Volume = (int)updnVolume.Value;
            Synthesizer.Speak(txtMessage.Text);
        }

        private void cboVoices_SelectedIndexChanged(object sender, EventArgs e)
        {
            Synthesizer.SelectVoice(cboVoices.SelectedItem.ToString());
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAboutBox About = new frmAboutBox();
            About.ShowDialog();
            About.Dispose();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtMessage.Clear();
        }
    }
}


