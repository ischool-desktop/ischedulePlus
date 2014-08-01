using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ischedulePlus
{
    /// <summary>
    /// 節次顯示物件
    /// </summary>
    public class DisplayCalendarRecord
    {
        /// <summary>
        /// 節次編號
        /// </summary>
        public int PeriodNo { get; set; }

        /// <summary>
        /// 週一內容
        /// </summary>
        public object Mon { get; set; }

        /// <summary>
        /// 週一背景顏色
        /// </summary>
        public string MonBackColor { get; set; }

        /// <summary>
        /// 週一前景顏色
        /// </summary>
        public string MonForeColor { get; set; }

        /// <summary>
        /// 週一圖片
        /// </summary>
        public string MonPicture { get; set; }

        /// <summary>
        /// 週一邊緣顏色
        /// </summary>
        public string MonBorderColor { get; set; }

        /// <summary>
        /// 週一邊緣大小
        /// </summary>
        public string MonBorderThickness { get; set; }

        /// <summary>
        /// 週二內容
        /// </summary>
        public object Tue { get; set; }

        /// <summary>
        /// 週二背景顏色
        /// </summary>
        public string TueBackColor { get; set; }

        /// <summary>
        /// 週二前景顏色
        /// </summary>
        public string TueForeColor { get; set; }

        /// <summary>
        /// 週二圖片
        /// </summary>
        public string TuePicture { get; set; }

        /// <summary>
        /// 週二邊緣顏色
        /// </summary>
        public string TueBorderColor { get; set; }

        /// <summary>
        /// 週二邊緣大小
        /// </summary>
        public string TueBorderThickness { get; set; }

        /// <summary>
        /// 週三內容
        /// </summary>
        public object Wed { get; set; }

        /// <summary>
        /// 週三背景顏色
        /// </summary>
        public string WedBackColor { get; set; }

        /// <summary>
        /// 週三前景顏色
        /// </summary>
        public string WedForeColor { get; set; }

        /// <summary>
        /// 週三圖片
        /// </summary>
        public string WedPicture { get; set; }

        /// <summary>
        /// 週三邊緣顏色
        /// </summary>
        public string WedBorderColor { get; set; }

        /// <summary>
        /// 週三邊緣大小
        /// </summary>
        public string WedBorderThickness { get; set; }

        /// <summary>
        /// 週四內容
        /// </summary>
        public object Thu { get; set; }

        /// <summary>
        /// 週四背景顏色
        /// </summary>
        public string ThuBackColor { get; set; }

        /// <summary>
        /// 週四前景顏色
        /// </summary>
        public string ThuForeColor { get; set; }

        /// <summary>
        /// 週四圖片
        /// </summary>
        public string ThuPicture { get; set; }

        /// <summary>
        /// 週四邊緣顏色
        /// </summary>
        public string ThuBorderColor { get; set; }

        /// <summary>
        /// 週四邊緣大小
        /// </summary>
        public string ThuBorderThickness { get; set; }

        /// <summary>
        /// 週五內容
        /// </summary>
        public object Fri { get; set; }

        /// <summary>
        /// 週五背景顏色
        /// </summary>
        public string FriBackColor { get; set; }

        /// <summary>
        /// 週五前景顏色
        /// </summary>
        public string FriForeColor { get; set; }

        /// <summary>
        /// 週五圖片
        /// </summary>
        public string FriPicture { get; set; }

        /// <summary>
        /// 週五邊緣顏色
        /// </summary>
        public string FriBorderColor { get; set; }

        /// <summary>
        /// 週五邊緣大小
        /// </summary>
        public string FriBorderThickness { get; set; }

        /// <summary>
        /// 週六內容
        /// </summary>
        public object Sat { get; set; }

        /// <summary>
        /// 週六背景顏色
        /// </summary>
        public string SatBackColor { get; set; }

        /// <summary>
        /// 週六前景顏色
        /// </summary>
        public string SatForeColor { get; set; }

        /// <summary>
        /// 週六圖片
        /// </summary>
        public string SatPicture { get; set; }

        /// <summary>
        /// 週六邊緣顏色
        /// </summary>
        public string SatBorderColor { get; set; }

        /// <summary>
        /// 週六邊緣大小
        /// </summary>
        public string SatBorderThickness { get; set; }

        /// <summary>
        /// 週日內容
        /// </summary>
        public object Sun { get; set; }

        /// <summary>
        /// 週日背景顏色
        /// </summary>
        public string SunBackColor { get; set; }

        /// <summary>
        /// 週日前景顏色
        /// </summary>
        public string SunForeColor { get; set; }

        /// <summary>
        /// 週日圖片
        /// </summary>
        public string SunPicture { get; set; }

        /// <summary>
        /// 週日邊緣顏色
        /// </summary>
        public string SunBorderColor { get; set; }

        /// <summary>
        /// 週日邊緣大小
        /// </summary>
        public string SunBorderThickness { get; set; }

        /// <summary>
        /// 建構式，將所有顏色設為白色，並將所有文字設為string.Empty。
        /// </summary>
        public DisplayCalendarRecord()
        {
            PeriodNo = 0;

            Mon = string.Empty;
            MonBackColor = "White";
            MonForeColor = "White";
            MonPicture = string.Empty;
            MonBorderColor = "Darkgray";
            MonBorderThickness = "1";

            Tue = string.Empty;
            TueBackColor = "White";
            TueForeColor = "White";
            TuePicture = string.Empty;
            TueBorderColor = "Darkgray";
            TueBorderThickness = "1";

            Wed = string.Empty;
            WedBackColor = "White";
            WedForeColor = "White";
            WedPicture = string.Empty;
            WedBorderColor = "Darkgray";
            WedBorderThickness = "1";

            Thu = string.Empty;
            ThuBackColor = "White";
            ThuForeColor = "White";
            ThuPicture = string.Empty;
            ThuBorderColor = "Darkgray";
            ThuBorderThickness = "1";

            Fri = string.Empty;
            FriBackColor = "White";
            FriForeColor = "White";
            FriPicture = string.Empty;
            FriBorderColor = "Darkgray";
            FriBorderThickness = "1";

            Sat = string.Empty;
            SatBackColor = "White";
            SatForeColor = "White";
            SatPicture = string.Empty;
            SatBorderColor = "Darkgray";
            SatBorderThickness = "1";

            Sun = string.Empty;
            SunBackColor = "White";
            SunForeColor = "White";
            SunPicture = string.Empty;
            SunBorderColor = "Darkgray";
            SunBorderThickness = "1";
        }

        /// <summary>
        /// 設定星期資訊
        /// </summary>
        /// <param name="WeekDay">星期幾</param>
        /// <param name="Text">文用</param>
        /// <param name="BackColor">背景顏色</param>
        /// <param name="ForeColor">前景顏色</param>
        /// <param name="Picture">圖片</param>
        /// <param name="Picture">邊緣顏色</param>
        public void SetWeekDayText(int WeekDay, object Text, string BackColor, string ForeColor, string Picture, string BorderColor, string BorderThickness)
        {
            switch (WeekDay)
            {
                case 1:
                    Mon = Text;
                    MonBackColor = BackColor;
                    MonForeColor = ForeColor;
                    MonPicture = Picture;
                    MonBorderColor = BorderColor;
                    MonBorderThickness = BorderThickness;
                    break;
                case 2:
                    Tue = Text;
                    TueBackColor = BackColor;
                    TueForeColor = ForeColor;
                    TuePicture = Picture;
                    TueBorderColor = BorderColor;
                    TueBorderThickness = BorderThickness;
                    break;
                case 3:
                    Wed = Text;
                    WedBackColor = BackColor;
                    WedForeColor = ForeColor;
                    WedPicture = Picture;
                    WedBorderColor = BorderColor;
                    WedBorderThickness = BorderThickness;
                    break;
                case 4:
                    Thu = Text;
                    ThuBackColor = BackColor;
                    ThuForeColor = ForeColor;
                    ThuPicture = Picture;
                    ThuBorderColor = BorderColor;
                    ThuBorderThickness = BorderThickness;
                    break;
                case 5:
                    Fri = Text;
                    FriBackColor = BackColor;
                    FriForeColor = ForeColor;
                    FriPicture = Picture;
                    FriBorderColor = BorderColor;
                    FriBorderThickness = BorderThickness;
                    break;
                case 6:
                    Sat = Text;
                    SatBackColor = BackColor;
                    SatForeColor = ForeColor;
                    SatPicture = Picture;
                    SatBorderColor = BorderColor;
                    SatBorderThickness = BorderThickness;
                    break;
                case 7:
                    Sun = Text;
                    SunBackColor = BackColor;
                    SunForeColor = ForeColor;
                    SunPicture = Picture;
                    SunBorderColor = BorderColor;
                    SunBorderThickness = BorderThickness;
                    break;
            }
        }

        /// <summary>
        /// 設定星期資訊
        /// </summary>
        /// <param name="WeekDay">星期幾</param>
        /// <param name="Text">文用</param>
        /// <param name="BackColor">背景顏色</param>
        /// <param name="ForeColor">前景顏色</param>
        /// <param name="Picture">圖片</param>
        public void SetWeekDayText(int WeekDay, object Text, string BackColor, string ForeColor, string Picture)
        {
            switch (WeekDay)
            {
                case 1:
                    Mon = Text;
                    MonBackColor = BackColor;
                    MonForeColor = ForeColor;
                    MonPicture = Picture;
                    break;
                case 2:
                    Tue = Text;
                    TueBackColor = BackColor;
                    TueForeColor = ForeColor;
                    TuePicture = Picture;
                    break;
                case 3:
                    Wed = Text;
                    WedBackColor = BackColor;
                    WedForeColor = ForeColor;
                    WedPicture = Picture;
                    break;
                case 4:
                    Thu = Text;
                    ThuBackColor = BackColor;
                    ThuForeColor = ForeColor;
                    ThuPicture = Picture;
                    break;
                case 5:
                    Fri = Text;
                    FriBackColor = BackColor;
                    FriForeColor = ForeColor;
                    FriPicture = Picture;
                    break;
                case 6:
                    Sat = Text;
                    SatBackColor = BackColor;
                    SatForeColor = ForeColor;
                    SatPicture = Picture;
                    break;
                case 7:
                    Sun = Text;
                    SunBackColor = BackColor;
                    SunForeColor = ForeColor;
                    SunPicture = Picture;
                    break;
            }
        }

        /// <summary>
        /// 設定星期前景及背景顏色
        /// </summary>
        /// <param name="WeekDay">星期幾</param>
        /// <param name="BackColor">背景顏色</param>
        /// <param name="ForeColor">前景顏色</param>
        public void SetWeekDayColor(int WeekDay, string BackColor, string ForeColor)
        {
            switch (WeekDay)
            {
                case 1:
                    MonBackColor = BackColor;
                    MonForeColor = ForeColor;
                    break;
                case 2:
                    TueBackColor = BackColor;
                    TueForeColor = ForeColor;
                    break;
                case 3:
                    WedBackColor = BackColor;
                    WedForeColor = ForeColor;
                    break;
                case 4:
                    ThuBackColor = BackColor;
                    ThuForeColor = ForeColor;
                    break;
                case 5:
                    FriBackColor = BackColor;
                    FriForeColor = ForeColor;
                    break;
                case 6:
                    SatBackColor = BackColor;
                    SatForeColor = ForeColor;
                    break;
                case 7:
                    SunBackColor = BackColor;
                    SunForeColor = ForeColor;
                    break;
            }
        }
    }
}
