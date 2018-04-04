using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_04_B
{
    class Model
    {
        string[] getNameFromPath(string[] path)
        {
            string[] names = new string[path.Length];
            int i = 0;
            foreach (var singlePath in path)
            {
                names[i] = System.IO.Path.GetFileName(singlePath);
                i++;
            }
            return names;
        }


        public string[] getListOfDrivers()
        {
            int i = System.IO.DriveInfo.GetDrives().Count();

            string[] lista = new string[i];
            i = 0;
            foreach (var drive in System.IO.DriveInfo.GetDrives())
            {
                lista[i] = drive.Name;
                i++;
            }
            return lista;
        }
        public string[] getListOfAvalibleDrivers()
        {
            int i = 0;
            foreach (var drive in System.IO.DriveInfo.GetDrives())
            {
                if (drive.IsReady)
                    i++;
            }

            string[] lista = new string[i];
            i = 0;
            foreach (var drive in System.IO.DriveInfo.GetDrives())
            {
                if (drive.IsReady)
                {
                    lista[i] = drive.Name;
                    i++;

                }

            }
            return lista;
        }
        public bool IsAvalibleDrive(string name)
        {
            foreach (var drive in getListOfAvalibleDrivers())
                if (drive == name) return true;
            return false;
        }
        public string[] FileNameList(string path)
        {

                return getNameFromPath(System.IO.Directory.GetFileSystemEntries(path));

        }
        public string PrimaryPath(string path)
        {
            return System.IO.Directory.GetParent(path).FullName;   
        }

        public bool IsDriveFromPath(string path)
        //return true if path hace coreect drive
        {
            string myDrive = System.IO.Path.GetPathRoot(path);
            foreach (var drive in System.IO.DriveInfo.GetDrives())
            {
                if (myDrive==drive.Name)
                {
                    return true;
                }
            }
            return false;
        }
        public string getDriveFromPath(string path)
        {
           return System.IO.Path.GetPathRoot(path);
        }
        public void errorMesage(string mesage)
        {
            System.Windows.Forms.MessageBox.Show(mesage,
                   "InValidComander");
        }
        public void Deltete(string filePath)
        {

            System.IO.FileAttributes attr = System.IO.File.GetAttributes(filePath);

            //detect whether its a directory or file
            if (attr.HasFlag(System.IO.FileAttributes.Directory))
            {
                System.IO.Directory.Delete(filePath, true);
            }
            else
            {
                System.IO.File.Delete(filePath);
            }
            

        }
        public void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new System.IO.DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            System.IO.DirectoryInfo[] dirs = dir.GetDirectories();
            // If the destination directory doesn't exist, create it.
            if (!System.IO.Directory.Exists(destDirName))
            {
                System.IO.Directory.CreateDirectory(destDirName);
            }

            // Get the files in the directory and copy them to the new location.
            System.IO.FileInfo[] files = dir.GetFiles();
            foreach (System.IO.FileInfo file in files)
            {
                string temppath = System.IO.Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, false);
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (System.IO.DirectoryInfo subdir in dirs)
                {
                    string temppath = System.IO.Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }

        public void FileCoppy(string source, string destD, bool replece)
        {
            System.IO.File.Copy(source, destD, replece);
        }

        public void coppy(string from, string to)
        {
            System.IO.FileAttributes attr = System.IO.File.GetAttributes(from);
            if (attr.HasFlag(System.IO.FileAttributes.Directory))
            {
                DirectoryCopy(from, to, true);
            }
            else
            {
               FileCoppy(from, to, true);
            }
     

        }
        public bool canCoppy(string from ,string to)
        {
            string driveTo = getDriveFromPath(to);
            string driveFrom = getDriveFromPath(from);
            if(!IsAvalibleDrive(driveTo)) return false;
            if (!IsAvalibleDrive(driveFrom)) return false;

            if(System.IO.Path.GetFullPath(to).StartsWith(System.IO.Path.GetFullPath(from)))
                return false;
            return true;


        }



    }
}
