using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace CountingRules
{
    public sealed class FileWriter
    {
        #region Singleton Constructor
        private static readonly Lazy<FileWriter> lazy = new Lazy<FileWriter>(() => new FileWriter());

        /// <summary>
        /// Gets the instance.
        /// </summary>
        public static FileWriter Instance { get { return lazy.Value; } }

        /// <summary>
        ///     Prevents a default instance of the <see cref="FileWriter"/> class from being created.
        /// </summary>
        private FileWriter()
        {
            _fileExtension = ".txt";
            _resultsDirectory = string.Empty;
        }
        #endregion

        #region Properties
        private string _fileExtension;
        private string _resultsDirectory;
        public string ResultsDirectory
        {
            get
            {
                if (string.IsNullOrEmpty(_resultsDirectory))
                    _resultsDirectory = Path.Combine(Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName, "Results");
                return _resultsDirectory;
            }
        }
        #endregion

        #region Methods
        /// <summary>
        ///     Creates the folder if no folder exisits on the specified path.
        /// </summary>
        /// <param name="folderPath">The folder path.</param>
        internal void CreateFolder(string folderPath)
        {
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);
        }

        /// <summary>
        ///     Writes to text file.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="textContents">The text contents.</param>
        public void WriteToTextFile(string fileName, IList<string> textContents)
        {
            CreateFolder(ResultsDirectory);
            var filePath = Path.Combine(ResultsDirectory, fileName + _fileExtension);
            
            if (File.Exists(filePath))
                File.Delete(filePath);

            using (var stream = File.Open(filePath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read))
            {
                foreach (var text in textContents)
                {
                    AddText(stream, text);
                    AddText(stream, Environment.NewLine);
                }
            }
        }
        
        private static void AddText(FileStream fs, string value)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(value);
            fs.Write(info, 0, info.Length);
        }
        #endregion
    }
}