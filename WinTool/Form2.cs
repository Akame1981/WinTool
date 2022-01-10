using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace WinTool
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();


            List<Downloads> downloads = new List<Downloads>();


            downloads.Add(new Downloads
             ("Winrar", 
             "https://www.win-rar.com/fileadmin/winrar-versions/winrar/winrar-x64-602.exe", 
             "WinRAR is a powerful compression tool with many integrated additional functions to help you organize your compressed archives. ... WinRAR supports all popular compression formats (RAR, ZIP, CAB, ARJ, LZH, TAR, GZip, UUE, ISO, BZIP2, Z and 7-Zip). WinRAR is ideal for multimedia files.",
             "6.02", 
             ".exe", 
            new DateTime(1995, 04, 22)));


            downloads.Add(new Downloads
                ("Discord", 
                "https://discord.com/api/downloads/distributions/app/installers/latest?channel=stable&platform=win&arch=x86", 
                "Discord is a free voice, video, and text chat app that's used by tens of millions of people ages 13+ to talk and hang out with their communities and friends. ... The vast majority of servers are private, invite-only spaces for groups of friends and communities to stay in touch and spend time together.", 
                "latest", 
                ".exe", 
                new DateTime(2015, 05, 13)));
            

            downloads.Add(new Downloads
                ("Google Chrome",
                "https://dw.uptodown.com/dwn/RDqjZPRiyZgq6rQsS-XDwfWPeatdLERRfC2aY_96E7-iUQEnPcNNNzFqmSIB5WDIFEYLSowYCYRue4poacggF5J3Tjdr4QaoSCiBTJx4hxpzljj8JeccUx9jekvwo7XU/daHNBgQrMXigXIJR1z5bn9vl1IvhejOnk7TYJYA5eA28SKap8t-R88hACQoj-NTQ0k7AJnaJhXE8o16DpHrsyVNGEwiSVkQpX8JIYZWhtyYzSm4IyHTS-W8gQBznQSL5/L-FOKfKC_0Z6duIkMlcbwyEZDIVhboeZse1NvPm8BqTpzljMO4PcpKdyQtQqpdCtkrMNoeikLZKxtZC_uPq6HA==/",
                "Fast, easy and clean internet surfing experience by Google",
                "97.0.4692.71",
                ".msi",
                new DateTime(1998, 09, 04)));


           downloads.Add(new Downloads
            ("VLC",
            "https://mirrors.uni-ruse.bg/vlc/vlc/3.0.16/win32/vlc-3.0.16-win32.exe",
            "VLC is a free and open source cross-platform multimedia player and framework that plays most multimedia files, and various streaming protocols.",
            "latest",
            ".exe",
            new DateTime(2001, 02, 01)));


            downloads.Add(new Downloads
            ("Search Everything",
            "https://www.voidtools.com/Everything-1.4.1.1015.x64-Setup.exe",
            "Everything is an easy-to-use search application that can help you find any file or folder stored on your Windows computer. It only takes a few seconds to locate data from an unorganized storage space. To make things easier, the software provides various filters, sorters, and a user-friendly interface. .",
            "1.4.1.1015",
            ".exe",
            new DateTime(2001, 02, 01)));


            downloads.Add(new Downloads
                ("Psiphon3 VPN",
                "https://psiphon.ca/psiphon3.exe",
                "Psiphon is a free and open-source Internet censorship circumvention tool that uses a combination of secure communication and obfuscation technologies (VPN, SSH, and HTTP Proxy). Psiphon is a centrally managed and geographically diverse network of thousands of proxy servers.",
                "3.168",
                ".exe",
                new DateTime(2006, 01, 01)));
            /*
              
                downloads.Add(new Downloads
                ("Name", 
                "link", 
                "desc", 
                "ver", 
                ".exe", 
                new DateTime(2015, 05, 13)));
            
             */

            int distanceunit = 1;
            foreach (var downloads1 in downloads)
            {
                
                textBox1.Text = "Winrar";
                string searchTarget = textBox1.Text;
                if (downloads1.Name.Contains(searchTarget))
                {
                    

                    // Add the name of the program label
                    Label lbl = new Label();
                    this.Controls.Add(lbl);
                    lbl.Top = distanceunit * 87;
                    lbl.Text = downloads1.Name;

                    // Add the description of the program label
                    Label desc = new Label();
                    this.Controls.Add(desc);
                    desc.Top = distanceunit * 87;
                    desc.Text = downloads1.Description;
                    desc.Left = 300;
                    desc.MaximumSize = new Size(600, 0);
                    desc.AutoSize = true;


                    // Add the publish date label
                    Label date = new Label();
                    this.Controls.Add(date);
                    date.Top = lbl.Top + 21;
                    date.Text = Convert.ToString(downloads1.PublishedDate);

                    // Add the version label
                    Label version = new Label();
                    this.Controls.Add(version);
                    version.Top = date.Top + 21;
                    version.Text = downloads1.Version;



                    // Add the download button
                    Button btn = new Button();
                    this.Controls.Add(btn);
                    btn.Top = distanceunit * 87;
                    btn.Text = "Download";
                    btn.Left = 100;

                    //Add the progress Bar
                    ProgressBar pb = new ProgressBar();
                    this.Controls.Add(pb);
                    pb.Top = distanceunit * 87;
                    pb.Left = 180;


                    // If download button is clicked
                    btn.Click += btn_Click;



                    void btn_Click(Object sender, EventArgs e)
                    {


                        Button clickedButton = (Button)sender;
                        string FileN = downloads1.Name + downloads1.Extension;
                        //Download the file
                        using (WebClient wc = new WebClient())
                        {
                            wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                            wc.DownloadFileCompleted += Wc_DownloadFileCompleted;
                            wc.DownloadFileAsync(
                                // Param1 = Link of file
                                new System.Uri(downloads1.DownloadUrl),
                                // Param2 = Path to save
                                FileN
                            );


                        }
                    }

                    void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
                    {
                        pb.Value = e.ProgressPercentage;
                    }


                }



                void Wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
                {
                    runProgram(downloads1.Name + downloads1.Extension);
                }
                distanceunit++;



            }


            


        }


        void runProgram(string fileName)
        {
            Process proc = new Process();
            proc.StartInfo.FileName = fileName;
            proc.StartInfo.UseShellExecute = true;
            proc.Start();
            proc.WaitForExit();
            File.Delete(fileName);

        }
    }
}
