using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OTP
{
    public partial class OTP : Form
    {

        FileSystemWatcher fsw;
        bool secondFileChange = false;
        bool keyStatus = false;
        int programLogCounter = 0;
        ProgramState.ProgramStateHelper programStateHelper;
        //ProgramState.ProgramState programState;
        public OTP()
        {
            InitializeComponent();
        }
        
        private void inputLocationBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult dr = fbd.ShowDialog();

            if(!string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                inputLbl.Text = fbd.SelectedPath;

                fsw.Path = fbd.SelectedPath;
                programStateHelper.directoryPathChange();
                programStateHelper.setLastUsedInputPath(fbd.SelectedPath);
            }
        }
        private void outputLocationBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult dr = fbd.ShowDialog();

            if (!string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                outputLbl.Text = fbd.SelectedPath;
                programStateHelper.setLastUsedOutputPath(fbd.SelectedPath);
            }
        }
        private void decryptBtn_Click(object sender, EventArgs e)
        {
            if (!keyStatus)
            {
                MessageBox.Show("Key is empty or not valid!");
                return;
            }
            fsw.EnableRaisingEvents = false;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            openFileDialog1.Filter = "txt files (*.txt)|*.txt";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.Multiselect = false;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            { 
                FileSystemHelper fsh = new FileSystemHelper();
                string filePath = System.IO.Path.GetDirectoryName(openFileDialog1.FileName);               
                string fileNameWithPath = openFileDialog1.FileName;

                string newFileName = (openFileDialog1.SafeFileName).Replace(".txt","-decrypted.txt");
                
                int bytesLenght;
                byte[] decryptedBytes;

                string key = textBoxKey.Text;

                OneTimePadAlgorithm.decrypt(fsh.readBytesFromFile(fileNameWithPath), key, out decryptedBytes, out bytesLenght);

                fsh.writeBtytesToFile(decryptedBytes, bytesLenght, filePath+"\\"+newFileName);
                newProgramLog(openFileDialog1.SafeFileName, "Decryped");
                if(fileSystemWatcherCB.Checked)
                    fsw.EnableRaisingEvents = true;
            }
        }
        private void encryptBtn_Click(object sender, EventArgs e)
        {
            if (!keyStatus)
            {
                MessageBox.Show("Key is empty or not valid!");
                return;
            }
            fsw.EnableRaisingEvents = false;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            openFileDialog1.Filter = "txt files (*.txt)|*.txt";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.Multiselect = false;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileSystemHelper fsh = new FileSystemHelper();
                string filePath = System.IO.Path.GetDirectoryName(openFileDialog1.FileName);
                string fileNameWithPath = openFileDialog1.FileName;

                string newFileName = (openFileDialog1.SafeFileName).Replace(".txt", "-encrypted.txt");

                int bytesLenght;
                byte[] encryptedBytes;

                string key = textBoxKey.Text;

                OneTimePadAlgorithm.encrypt(fsh.readBytesFromFile(fileNameWithPath), key, out encryptedBytes, out bytesLenght);

                fsh.writeBtytesToFile(encryptedBytes, bytesLenght, filePath + "\\" + newFileName);
                newProgramLog(openFileDialog1.SafeFileName,"Encrypted");
                if (fileSystemWatcherCB.Checked)
                    fsw.EnableRaisingEvents = true;
            }
        }
        private void fileSystemWatcherCB_CheckedChanged(object sender, EventArgs e)
        {
            if (fileSystemWatcherCB.Checked)
            {
                fsw.EnableRaisingEvents = true;
                programStateHelper.setFileSystemWathcer(true);
            }
            else
            {
                fsw.EnableRaisingEvents = false;
                programStateHelper.setFileSystemWathcer(false);
            }
        }
        private void setupFileSystemWatcher(string folderPath)
        {
            fsw = new FileSystemWatcher();
            fsw.Path = folderPath;

            fsw.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
           | NotifyFilters.FileName | NotifyFilters.DirectoryName;

            fsw.Filter = "*.txt";

            fsw.Changed += new FileSystemEventHandler(OnChanged);
            //fsw.Created += new FileSystemEventHandler(OnChanged);
            fsw.Deleted += new FileSystemEventHandler(OnDelete);
            fsw.Renamed += new RenamedEventHandler(OnRenamed);  
        }
        private void OnDelete(object source,FileSystemEventArgs e)
        {
            programStateHelper.fileDeleted(e.Name);
            this.Invoke((MethodInvoker)delegate
            {
                newProgramLog(e.Name, "Deleted");
            });
            
        }
        private void OnChanged(object source, FileSystemEventArgs e)
        {
            
            if (secondFileChange)
            {
                secondFileChange = false;
                return;
            }
            //MessageBox.Show(e.ChangeType.ToString() + "\n"+ e.Name);
            secondFileChange = true;
            if (!keyStatus)
            {
                MessageBox.Show("File with name: \""+e.Name+"\" has changed externaly, but key is not valid so encryption is aborted!");
                return;
            }
            //only procceed plaintext files
            if (e.Name.Contains("-encrypted") || e.Name.Contains("-decrypted"))
                return;

            
            FileSystemHelper fsh = new FileSystemHelper();
            //string filePath = System.IO.Path.GetDirectoryName(e.FullPath);
            bool ignore;
            string filePath =programStateHelper.getLastUsedOutputPath(out ignore);
            string fileNameWithPath = e.FullPath;

            string newFileName = (e.Name).Replace(".txt", "-encrypted.txt");

            int bytesLenght;
            byte[] encryptedBytes;

            string key = textBoxKey.Text;

            OneTimePadAlgorithm.encrypt(fsh.readBytesFromFile(fileNameWithPath), key, out encryptedBytes, out bytesLenght);


            fsw.EnableRaisingEvents = false;
            fsh.writeBtytesToFile(encryptedBytes, bytesLenght, filePath + "\\" + newFileName);
            fsw.EnableRaisingEvents = true;

            programStateHelper.addEncryptedFile(e.Name);
                
            if (encryptedBytes !=null)
                this.Invoke((MethodInvoker)delegate
                { 
                    newProgramLog(e.Name, "Encrypted");                    
                });
        }
        private void OnRenamed(object source, RenamedEventArgs e)
        {
            programStateHelper.fileNameChanged(e.OldName, e.Name);
            this.Invoke((MethodInvoker)delegate
            {
                newProgramLog(e.Name + " (" + e.OldName + ")", "Renamed");
            });  
        }
        private void OTG_FormClosing(object sender, FormClosingEventArgs e)
        {
            programStateHelper.saveProgramState();
        }
        private void OTP_Load(object sender, EventArgs e)
        {
            this.FormClosing += new FormClosingEventHandler(OTG_FormClosing);
            this.Shown += new EventHandler(OTP_Shown);
        }
        //called just after the OTG is shown
        private void OTP_Shown(object sender,EventArgs e)
        {
            programStateHelper = new ProgramState.ProgramStateHelper();

            bool inputPathIsChanged,outputPathIsChanged;

            string inputPath = programStateHelper.getLastUsedInputPath(out inputPathIsChanged);
            string outputPath = programStateHelper.getLastUsedOutputPath(out outputPathIsChanged);

            inputLbl.Text = inputPath;
            outputLbl.Text = outputPath;
            setupFileSystemWatcher(inputPath);
            fileSystemWatcherCB.Checked = programStateHelper.getFileSystemWatcher();

            if (programStateHelper.getFileSystemWatcher() && !inputPathIsChanged)//if is fileSystemWatcher checked then check all files and encrypt new files
            {
                encryptMultypleFiles();
            }
                 
        }
        private void encryptMultypleFiles()
        {
            bool inputPathIsChanged, outputPathIsChanged;

            string inputPath = programStateHelper.getLastUsedInputPath(out inputPathIsChanged);
            string outputPath = programStateHelper.getLastUsedOutputPath(out outputPathIsChanged);

            if (inputPathIsChanged)
            {
                MessageBox.Show("Input path is not valid anymore!\nInput path is changed to default value (aplication base directory).");
                inputLbl.Text = inputPath;
                return;
            }
            if (outputPathIsChanged)
            {
                MessageBox.Show("Output path is not valid anymore!\nOutput path is changed to Input path (if is valid) or default value (aplication base directory).");
                outputLbl.Text = outputPath;
            }
            DirectoryInfo dinfo = new DirectoryInfo(inputPath);

            FileInfo[] files = dinfo.GetFiles("*.txt");

            foreach (FileInfo file in files)
            {
                //if file is't early encrypted or if does't contains string -encrypted or -decrypted then this file is new file
                if (!(programStateHelper.checkFileName(file.Name) || file.Name.Contains("-encrypted") || file.Name.Contains("-decrypted")))
                {
                    KeyForm keyForm = new KeyForm(file.Name);

                    DialogResult dialogResult = keyForm.ShowDialog();
                    if (dialogResult == DialogResult.Ignore)
                    {
                        continue;
                    }
                    else if (dialogResult == DialogResult.OK)
                    {
                        FileSystemHelper fsh = new FileSystemHelper();
                        string filePath = System.IO.Path.GetDirectoryName(file.FullName);

                        string newFileName = (file.Name).Replace(".txt", "-encrypted.txt");

                        int bytesLenght;
                        byte[] encryptedBytes;

                        string key = keyForm.Key;

                        OneTimePadAlgorithm.encrypt(fsh.readBytesFromFile(file.FullName), key, out encryptedBytes, out bytesLenght);

                        fsh.writeBtytesToFile(encryptedBytes, bytesLenght, outputPath + "\\" + newFileName);
                        
                        programStateHelper.addEncryptedFile(file.Name);
                        newProgramLog(file.Name, "Encrypted");
                    }
                    else
                    {
                        break;
                    }

                }
            }
        }
        private void newProgramLog(string fileName,string action)
        {
            programLogCounter++;
            ListViewItem item = new ListViewItem(programLogCounter.ToString());
            item.SubItems.Add(fileName);
            item.SubItems.Add(action);

            programLogLv.Items.Add(item);
        }
        private void textBoxKey_TextChanged(object sender, EventArgs e)
        {
            if (!textBoxKey.Text.All(chr => char.IsLetter(chr)) || string.IsNullOrEmpty(textBoxKey.Text))
            {
                keyStatusLbl.ForeColor = Color.Red;
                keyStatusLbl.Text = "Invalid!";
                keyStatus = false;
            }else
            {
                keyStatusLbl.ForeColor = Color.Green;
                keyStatusLbl.Text = "Valid.";
                keyStatus = true;
            }
        }
        private void encryptAllBtn_Click(object sender, EventArgs e)
        {
            encryptMultypleFiles();
        }
    }
}
