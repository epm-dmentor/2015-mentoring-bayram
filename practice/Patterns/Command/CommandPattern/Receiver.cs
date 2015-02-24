using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Linq;
using System.Windows;

namespace Epam.NetMentoring.CommandPattern
{
    public class Receiver
    {
        private ViewModel _viewModel;

        public Receiver(ViewModel viewModel)
        {
            _viewModel = viewModel;
        }
       
        public void ListFiles(string directory)
        {
            try
            {
                var output = Directory.GetFiles(directory);
                _viewModel.Text = string.Join("", output);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            
        }
        
        public void ShowProcess()
        {
            try
            {
                var allprocs = new List<string>();
                var processes = Process.GetProcesses();
                allprocs.AddRange(processes.Select(process => process.ProcessName));
                _viewModel.Text = string.Join("", allprocs);
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
            
        }

        public void ShowRestRequest()
        {
            const string url = @"http://www.thomas-bayer.com/sqlrest/CUSTOMER/3/";
            var client = new HttpClient {BaseAddress = new Uri(url)};
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            
            var response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var output = response.Content.ReadAsStringAsync().Result;
                _viewModel.Text = string.Join("", output);
            }
            else
            {
                MessageBox.Show("Code is:"+response.StatusCode, "Reason is: "+response.ReasonPhrase);
            }  

        }
    }
}
