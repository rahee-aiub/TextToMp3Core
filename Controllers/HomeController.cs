using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Speech.Synthesis;
using System.Threading.Tasks;
using TextToSpeech.Models;

namespace TextToSpeech.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //SpeechSynthesizer _speechSynthesizer;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Speak()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Speak(string text)
        {
            try
            {
                SpeechSynthesizer _speechSynthesizer = new SpeechSynthesizer();
                _speechSynthesizer.SpeakAsync(text);
                return Json(new { success = true, responseText = "Success" });
            }
            catch (Exception)
            {
                return Json(new { success = false, responseText = "Please enter text" });
            }
            
        }

        [HttpPost]
        public void Download(string text)
        {
            //if (richTextBox1.Text == "")
            //{
            //    return;
            //}

            //SaveFileDialog savefile = new SaveFileDialog();
            //savefile.FileName = "unknown.mp3";
            //savefile.Filter = "Mp3 files (*.mp3)|*.mp3|All files (*.*)|*.*";
            //if (savefile.ShowDialog() == DialogResult.OK)
            //{
            //    using (SpeechSynthesizer synth = new SpeechSynthesizer())
            //    {
            //        synth.SetOutputToWaveFile(savefile.FileName);
            //        PromptBuilder builder = new PromptBuilder();
            //        builder.AppendText(richTextBox1.Text);
            //        synth.Speak(builder);

            //        //MessageBox.Show("Saved Succesfully");
            //    }
            //}
            //return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
