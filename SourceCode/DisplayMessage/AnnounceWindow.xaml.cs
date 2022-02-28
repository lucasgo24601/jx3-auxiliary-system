using System;
using System.Windows;
using System.Threading;
using System.ComponentModel;

namespace DisplayMessage
{
    public partial class AnnounceWindow : Window, INotifyPropertyChanged
    {
        #region 宣告區
        public event PropertyChangedEventHandler PropertyChanged;
        public int time = 1000;

        private Thread m_threadAnimate = null;
        private SynchronizationContext m_SyncContext = null;
        private double m_animateStartTime = 0;
        #endregion

        public AnnounceWindow()
        {
            this.Hide();
            this.WindowStartupLocation = WindowStartupLocation.Manual;
            this.DataContext = this;

            InitializeComponent();

            m_SyncContext = SynchronizationContext.Current;
        }

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        // Display Format
        #region 設定輸出格式
        private string message = "This is an announcement...";
        public string Message { get { return message; } set { message = value; OnPropertyChanged("Message"); } }
        private string messageBrush = "#FF51F7FF";
        public string MessageBrush { get { return messageBrush; } set { messageBrush = value; OnPropertyChanged("MessageBrush"); } }
        #endregion

        // Message Animation.
        #region 輸出訊息
        private void Hide(int animateDuring)
        {
            m_animateStartTime = (DateTime.Now - TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1))).TotalMilliseconds;
            if (m_threadAnimate == null || !m_threadAnimate.IsAlive)
            {
                m_threadAnimate = new System.Threading.Thread(() =>
                {
                    m_SyncContext.Post(SetMessageVisible, true);
                    while (GetCurrentTime() - m_animateStartTime < animateDuring)
                    {
                        m_SyncContext.Post(SetMessageOpacity, 1 - (GetCurrentTime() - m_animateStartTime) / animateDuring);
                        Thread.Sleep(50);
                    }
                    m_SyncContext.Post(SetMessageVisible, false);
                });
                m_threadAnimate.Start();
            }
        }
        private double GetCurrentTime()
        {
            return (DateTime.Now - TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1))).TotalMilliseconds;
        }
        private void SetMessageOpacity(object opacity)
        {
            this.Opacity = (double)opacity;
        }
        private void SetMessageVisible(object visible)
        {
            if ((bool)visible)
                this.Show();
            else
                this.Hide();
        }
        #endregion

        // OutputMessage
        public void OutputMessage(string Color, string _Message){

            if (Color.Contains("RED"))
                MessageBrush = "#FFFF0000";
            else if (Color.Contains("YELLOW"))
                MessageBrush = "#FFFFFF00";
            else if (Color.Contains("BLUE"))
                MessageBrush = "#FF51F7FF";
            Message = message;
            Hide(time);
        }
    }
}
