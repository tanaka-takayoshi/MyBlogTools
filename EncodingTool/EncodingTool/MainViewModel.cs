using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Browser;

namespace EncodingTool
{
    public class MainViewModel : NotificationObject
    {
        #region EncodingText
        private string encodingText = "";
        public string EncodingText
        {
            get { return encodingText; }
            set
            {
                if (encodingText == value)
                {
                    return;
                }
                encodingText = value;
                RaisePropertyChanged("EncodingText");
            }
        }
        #endregion

        #region DecodingText
        private string decodingText = "";
        public string DecodingText
        {
            get { return decodingText; }
            set
            {
                if (decodingText == value)
                {
                    return;
                }
                decodingText = value;
                RaisePropertyChanged("DecodingText");
            }
        }
        #endregion

        private DelegateCommand encodeCommand;
        public DelegateCommand EncodeCommand 
        {
            get
            {
                if (encodeCommand == null) encodeCommand = new DelegateCommand(BeginEncode);
                return encodeCommand;
            }
        }

        private void BeginEncode()
        {
            DecodingText = HttpUtility.HtmlEncode(EncodingText);
        }

        private DelegateCommand copyEncodeCommand;
        public DelegateCommand CopyEncodeCommand
        {
            get
            {
                if (copyEncodeCommand == null) copyEncodeCommand = new DelegateCommand(BeginCopyEncode);
                return copyEncodeCommand;
            }
        }

        private void BeginCopyEncode()
        {
            Clipboard.SetText(EncodingText);
        }

        private DelegateCommand decodeCommand;
        public DelegateCommand DecodeCommand
        {
            get
            {
                if (decodeCommand == null) decodeCommand = new DelegateCommand(BeginEncode);
                return decodeCommand;
            }
        }

        private void BeginDecode()
        {
            EncodingText = HttpUtility.HtmlEncode(DecodingText);
        }

        private DelegateCommand copyDecodeCommand;
        public DelegateCommand CopyDecodeCommand
        {
            get
            {
                if (copyDecodeCommand == null) copyDecodeCommand = new DelegateCommand(BeginCopyDecode);
                return copyDecodeCommand;
            }
        }

        private void BeginCopyDecode()
        {
            Clipboard.SetText(DecodingText);
        }
    }
}
