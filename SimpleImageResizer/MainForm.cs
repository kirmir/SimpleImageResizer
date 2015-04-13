using System;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace SimpleImageResizer
{
	public partial class MainForm : Form
	{
		//Функция управление состоянием системы (запрет на вход в режим сна и включение заставки)
		[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		static extern EXECUTION_STATE SetThreadExecutionState(EXECUTION_STATE esFlags);
		[FlagsAttribute]
		public enum EXECUTION_STATE : uint
		{
			ES_SYSTEM_REQUIRED = 0x00000001,
			ES_DISPLAY_REQUIRED = 0x00000002,
			ES_CONTINUOUS = 0x80000000
		}

		public MainForm()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Для обновления отчета
		/// </summary>
		/// <param name="text">Новая запись в логе</param>
		private delegate void changeLogCallback(string text);

		/// <summary>
		/// Изменение полосы прогресса
		/// </summary>
		/// <param name="position">Новая позиция в полосе прогресса или -1</param>
		/// <param name="maxPosition">Максимальное значение полосы прогресса или -1</param>
		private delegate void changeProgressCallback(int position, int maxPosition);

		/// <summary>
		/// Остановка процесса и обновление интерфейса
		/// </summary>
		private delegate void stopProcessCallback();

		/// <summary>
		/// Поток переименования файлов
		/// </summary>
		private Thread resizing;

		/// <summary>
		/// Признак остановки потока
		/// </summary>
		bool aborting;

		private void changeDirButton_Click(object sender, EventArgs e)
		{
			if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
				dirTextBox.Text = folderBrowserDialog.SelectedPath;
		}

		/// <summary>
		/// Списки файлов и папок для переименования
		/// </summary>
		private string[] files;

		/// <summary>
		/// Масимальная ширина изображения
		/// </summary>
		private int maxWidth;

		/// <summary>
		/// Масимальная высота изображения
		/// </summary>
		private int maxHeight;

		/// <summary>
		/// Выбранный тип сжатия
		/// </summary>
		private InterpolationMode interpolation;

		/// <summary>
		/// Выбранное качество сжатия
		/// </summary>
		private int quality;

		/// <summary>
		/// Формат сохраняемого изображения
		/// </summary>
		private ImageFormat format;
		private string extension;

		/// <summary>
		/// Набор параметров для сохранения изображений с выбранным качеством
		/// </summary>
		private EncoderParameters encoderParams;
		private ImageCodecInfo jpegCodec;

		private void resizeButton_Click(object sender, EventArgs e)
		{
			//Добавление слеша в конце пути при его отсутствии
			string dirName = dirTextBox.Text;
			if (dirName[dirName.Length - 1] != '\\')
				dirName += "\\";
			//Установка свойств поиска
			SearchOption options =
				subDirsCheckBox.Checked ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
			try
			{
				//Получение списка файлов к обработке
				files = Directory.GetFiles(dirName, maskTextBox.Text, options);
			}
			catch
			{
				MessageBox.Show("Нет доступа к одному или нескольким объектам выбранного каталога. " +
					"Пожалуйста, выберите другой каталог.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			//Создание процесса
			resizing = new Thread(ThreadProc);
			//Настройка интерфейса
			EnablingControls(false);
			logTextBox.Clear();
			progressBar.Value = 0;
			aborting = false;
			//Запуск переименования
			maxWidth = (int)maxWidthNumericUpDown.Value;
			maxHeight = (int)maxHeightNumericUpDown.Value;
			//Анализ выходного формата
			switch (outputFormatComboBox.Text)
			{
				case "PNG":
					format = ImageFormat.Png;
					extension = "png";
					break;
				case "BMP":
					format = ImageFormat.Bmp;
					extension = "bmp";
					break;
				case "GIF":
					format = ImageFormat.Gif;
					extension = "gif";
					break;
				case "TIFF":
					format = ImageFormat.Tiff;
					extension = "tiff";
					break;
				case "EMF":
					format = ImageFormat.Emf;
					extension = "emf";
					break;
				case "EXIF":
					format = ImageFormat.Exif;
					extension = "exif";
					break;
				case "WMF":
					format = ImageFormat.Wmf;
					extension = "wmf";
					break;
				default:
					format = ImageFormat.Jpeg;
					extension = "jpg";
					interpolation = interpolationTypeComboBox.SelectedIndex == 0 ?
						InterpolationMode.HighQualityBicubic : InterpolationMode.HighQualityBilinear;
					quality = (int)qualityNumericUpDown.Value;
					setQuality();
					break;
			}
			resizing.Start();
		}

		private void dirTextBox_TextChanged(object sender, EventArgs e)
		{
			resizeButton.Enabled = Directory.Exists(dirTextBox.Text);
		}

		/// <summary>
		/// Установка наилучшего качества для сохранения изображений
		/// </summary>
		private void setQuality()
		{
			EncoderParameter qualityParam = new EncoderParameter(Encoder.Quality, quality);
			jpegCodec = GetEncoderInfo("image/jpeg");
			encoderParams = new EncoderParameters(1);
			encoderParams.Param[0] = qualityParam;
		}

		/// <summary>
		/// Получение информации о кодеке
		/// </summary>
		/// <param name="mimeType">Кодек</param>
		/// <returns>Информация</returns>
		private static ImageCodecInfo GetEncoderInfo(String mimeType)
		{
			ImageCodecInfo[] encoders = ImageCodecInfo.GetImageEncoders();
			for (int i = 0; i < encoders.Length; i++)
				if (encoders[i].MimeType == mimeType)
					return encoders[i];
			return null;
		}

		/// <summary>
		/// Изменение расширения в имени файла
		/// </summary>
		/// <param name="file">Исходное имя файла</param>
		/// <returns>Имя файла с новым расширением</returns>
		private string changeExtension(string file)
		{
			string newName;
			int ext = file.LastIndexOf(new FileInfo(file).Extension);
			newName = file.Remove(ext) + "." + extension;
			return newName;
		}

		/// <summary>
		/// Изменение размера изображения
		/// </summary>
		/// <param name="file">Имя файла изображения</param>
		/// <param name="maxw">Максимальная ширина</param>
		/// <param name="maxh">Максимальная высота</param>
		/// <returns>Имя нового файла</returns>
		private string resize(string file, int maxw, int maxh)
		{
			//Загрузка изображения
			Image curImage = Image.FromFile(file);

			//Проверка текущих размеров изображения
			if (curImage.Width <= maxw && curImage.Height <= maxh)
				return String.Empty;

			//Расчет новых размеров
			int newHeight = curImage.Height, newWidth = curImage.Width;
			if (curImage.Width > maxw)
			{
				newWidth = maxw;
				newHeight = curImage.Height * newWidth / curImage.Width;
			}
			if (newHeight > maxh)
			{
				newWidth = newWidth * maxh / newHeight;
				newHeight = maxh;
			}

			//Изменение размера изображения
			Bitmap newImage = new Bitmap(newWidth, newHeight, PixelFormat.Format24bppRgb);
			newImage.SetResolution(curImage.HorizontalResolution, curImage.VerticalResolution);
			Graphics g = Graphics.FromImage(newImage);
			g.InterpolationMode = interpolation;
			g.DrawImage(curImage, new Rectangle(0, 0, newWidth, newHeight),
				new Rectangle(0, 0, curImage.Width, curImage.Height), GraphicsUnit.Pixel);
			g.Dispose();

			//Очистка дескриптора для последующей перезаписи изображения
			curImage.Dispose();
			File.Delete(file);

			//Перезапись файла без потерь качества из-за кодека
			string newName = changeExtension(file);
			if (format == ImageFormat.Jpeg)
				newImage.Save(newName, jpegCodec, encoderParams);
			else
				newImage.Save(newName, format);
			return newName;
		}

		/// <summary>
		/// Сравнивает директории двух файлов на соответствие
		/// </summary>
		/// <param name="file1">Первый файл</param>
		/// <param name="file2">Второй файл</param>
		/// <returns>Истина в случае идентичности имен директорий</returns>
		private bool DirsEqual(string file1, string file2)
		{
			return Equals(new FileInfo(file1).DirectoryName, new FileInfo(file2).DirectoryName);
		}

		/// <summary>
		/// Функция потока изменения размеров изображений
		/// </summary>
		private void ThreadProc()
		{
			int max = files.Length, resized = 0, errors = 0;
			long sizeBefore, fullSize = 0, freeSpace = 0;
			FileInfo fi;
			DateTime time = DateTime.Now;
			string fileName;
			//Переименование файлов
			updateProgress(0, max);
			for (int i = 0; i < files.Length; i++)
			{
				try
				{
					fi = new FileInfo(files[i]);
					sizeBefore = fi.Length;
					fullSize += sizeBefore;
					if (i == 0 || !DirsEqual(files[i], files[i - 1]))
						updateLog("Обработка " + fi.DirectoryName);
					fileName = resize(files[i], maxWidth, maxHeight);
					if (fileName != string.Empty)
					{
						freeSpace += (sizeBefore - (new FileInfo(fileName).Length));
						resized++;
					}
				}
				catch
				{
				    updateLog("Невозможно обработать файл " + files[i]);
				    errors++;	
				}
				updateProgress(i + 1, max);
				if (aborting)
				{
					updateLog("Обработка прервана на файле " + files[i]);
					break;
				}
			}
			//Остановка процесса
			if (!aborting)
				updateLog("Обработано изображений: " + max);
			updateLog("Изменено изображений: " + resized);
			if (errors > 0)
				updateLog("Не удалось обработать: " + errors);
			updateLog("Время обработки: " + (DateTime.Now - time).Hours + " ч " +
				(DateTime.Now - time).Minutes + " м " + (DateTime.Now - time).Seconds + " с " +
				(DateTime.Now - time).Milliseconds + " мс");
			updateLog("Первоначальный объем: " + Math.Round((double)fullSize / 1048576, 3) + " МБ");
			updateLog("Конечный объем: " + Math.Round((double)(fullSize - freeSpace) / 1048576, 3) + " МБ");
			if (fullSize == 0 || fullSize < freeSpace)
				updateLog("Сэкономлено места: " + Math.Round((double)freeSpace / 1048576, 3) + " МБ");
			else
				updateLog("Сэкономлено места: " + Math.Round((double)freeSpace / 1048576, 3) + " МБ (" +
					Math.Round(((double)freeSpace / fullSize) * 100, 2) + "%)");
			stopProcess();
		}

		private void cancelButton_Click(object sender, EventArgs e)
		{
			aborting = true;
			cancelButton.Enabled = false;
		}

		/// <summary>
		/// Обновление интерфейса отчета об ошибках
		/// </summary>
		/// <param name="text">Новая запись в отчете</param>
		private void updateLog(string text)
		{
			if (logTextBox.InvokeRequired)
				Invoke(new changeLogCallback(updateLog), new object[] { text });
			else
			{
				if (logTextBox.Text.Length > 0)
					logTextBox.Text += "\r\n";
				logTextBox.Text += text;
				//Автопрокрутка
				logTextBox.SelectionStart = logTextBox.Text.Length;
				logTextBox.ScrollToCaret();
				logTextBox.Refresh();
			}
		}

		/// <summary>
		/// Изменение полосы прогресса
		/// </summary>
		/// <param name="position">Новая позиция в полосе прогресса или -1</param>
		/// <param name="maxPosition">Максимальное значение полосы прогресса или -1</param>
		private void updateProgress(int position, int maxPosition)
		{
			if (this.InvokeRequired)
				Invoke(new changeProgressCallback(updateProgress), new object[] { position, maxPosition });
			else
			{
				progressBar.Maximum = maxPosition;
				progressBar.Value = position;
				progressInfoLabel.Text = position.ToString() + "/" + maxPosition.ToString();
				
			}
		}

		/// <summary>
		/// Остановка процесса и обновление интерфейса
		/// </summary>
		private void stopProcess()
		{
			if (cancelButton.InvokeRequired)
				Invoke(new stopProcessCallback(stopProcess), new object[] { });
			else
			{
				EnablingControls(true);
				resizing.Abort();
				if (!aborting)
					MessageBox.Show("Обработка завершена", "Результат", MessageBoxButtons.OK,
						MessageBoxIcon.Information);
			}
		}

		/// <summary>
		/// Включение и отключение элементов управления
		/// </summary>
		/// <param name="val">Значение состояния доступности элементов управления</param>
		private void EnablingControls(bool val)
		{
			resizeButton.Enabled = val;
			cancelButton.Enabled = !val;
			maxHeightNumericUpDown.Enabled = val;
			maxWidthNumericUpDown.Enabled = val;
			dirTextBox.Enabled = val;
			changeDirButton.Enabled = val;
			maskTextBox.Enabled = val;
			subDirsCheckBox.Enabled = val;
			interpolationTypeComboBox.Enabled = val;
			qualityNumericUpDown.Enabled = val;
			outputFormatComboBox.Enabled = val;
			//Управление запретом на вхождение системы в режим сна
			if (val)
				SetThreadExecutionState(EXECUTION_STATE.ES_CONTINUOUS);
			else
				SetThreadExecutionState(EXECUTION_STATE.ES_CONTINUOUS | EXECUTION_STATE.ES_SYSTEM_REQUIRED);
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			interpolationTypeComboBox.SelectedIndex = 0;
			outputFormatComboBox.SelectedIndex = 0;
		}

		private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			SetThreadExecutionState(EXECUTION_STATE.ES_CONTINUOUS);
		}

		private void outputFormatComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			interpolationTypeComboBox.Enabled = (outputFormatComboBox.SelectedIndex == 0);
			qualityNumericUpDown.Enabled = (outputFormatComboBox.SelectedIndex == 0);
			qualityLabel.Enabled = (outputFormatComboBox.SelectedIndex == 0);
			interpolationTypeLabel.Enabled = (outputFormatComboBox.SelectedIndex == 0);			
		}
	}
}
