using System;
using System.Drawing;
using System.Windows.Forms;
namespace Test
{
    public partial class FormBody : Form
    {
        public FormBody()
        {
            InitializeComponent();
        }
        private const double x_focus = 0;
        private const double y_focus = 0;
        private const double z_focus = 0;
        //Сферические координаты глаза наблюдателя (точки E):
        private float r_Eye;
        private float phi_Eye;
        private float theta_Eye;
        //Переменные и матрица (как массив) MatrixProjection:
        //(во всех массивах нулевые индексы не используем):
        private const double pi = Math.PI;
        private int Cube;
        private float[,] MatrixProjection = new float[5, 5];
        //Для параллельного проецирования объекта на экран
        //(parallel projection) задаем константу:
        private const int ParallelProjection = 0;
        //Для перспективного проецирования объекта на экран
        //(perspective projection) задаем константу:
        private const int PerspectiveProjection = 1;
        private void FormBody_Load(object sender, EventArgs e)
        {
            //Задаем координаты глаза наблюдателя, например:
            r_Eye = 4;
            phi_Eye = (float)(0.05 * pi);
            theta_Eye = (float)(0.3 * pi);
            //Вызываем метод для перспективного проецирования,
            //когда type_of_projection = PerspectiveProjection
            //(для параллельного проецирования вместо
            Projection(ref MatrixProjection, PerspectiveProjection, r_Eye, phi_Eye, theta_Eye, (float)x_focus, (float)y_focus, (float)z_focus, 0, 1, 0);
            //Рассчитываем параметры геометрического тела:
            СalculateParameters();
            //Связываем элемент PictureBox1 с классом Bitmap:
            //Bitmap — объект, используемый для работы с изображениями, определяемыми данными пикселей.
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            //Проектируем и в PictureBox рисуем выбранное нами тело:
            Designing1((Bitmap)pictureBox1.Image);
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //Задаем угол поворота фигуры после нажатия клавиши:
            const float delta_theta = (float)pi / 20; ;
            //Рассчитываем новые координаты глаза наблюдателя:
            if (keyData == Keys.Left)
                theta_Eye = theta_Eye - delta_theta;
            if (keyData == Keys.Right)
                theta_Eye = theta_Eye + delta_theta;
            if (keyData == Keys.Up)
                phi_Eye = phi_Eye - delta_theta;
            if (keyData == Keys.Down)
                phi_Eye = phi_Eye + delta_theta;
            //Проектируем выбранное нами геометрическое тело:
            Projection(ref MatrixProjection, PerspectiveProjection, r_Eye, phi_Eye, theta_Eye, (float)x_focus, (float)y_focus, (float)z_focus, 0, 1, 0);
            Designing1((Bitmap)pictureBox1.Image);
            //В элементе PictureBox перерисовываем объект:
            pictureBox1.Refresh();
            return true;
        }
        //Проектируем и при помощи процедуры DrawSolid
        //рисуем выбранное флажком CheckBox геом-е тело:
        private void Designing1(Bitmap bmp)
        {
            //Создаем объект g класса Graphics:
            Graphics g;
            //Связываем объект g с изображением bmp:
            g = Graphics.FromImage(bmp);
            //Задаем белый цвет типа Control
            //для элемента управления PictureBox1:
            g.Clear(SystemColors.Control);
            //Высвобождаем ресурсы от графического объекта g:
            g.Dispose();
            //Преобразуем точки:
            TransformAllDataFull(ref MatrixProjection);
            //Проектируем и рисуем выбранное на CheckBox тело:
            DrawSolid(bmp, Cube, NumLines, Color.Black, false);
        }
        //Рассчитываем параметры геометрических тел и осей:
        private void СalculateParameters()
        {
            //Оси координат:
            DesigningLine(0, 0, 0, 0.5f, 0, 0); //Ось x.
            DesigningLine(0, 0, 0, 0, 0.5f, 0); //Ось y.
            DesigningLine(0, 0, 0, 0, 0, 0.5f); //Ось z.
            //Куб (Cube):
            Cube = NumLines + 1;
            DesigningLine(-1, -1, -1, -1, 1, -1);
            DesigningLine(-1, 1, -1, 1, 1, -1);
            DesigningLine(1, 1, -1, 1, -1, -1);
            DesigningLine(1, -1, -1, -1, -1, -1);
            DesigningLine(-1, -1, 1, -1, 1, 1);
            DesigningLine(-1, 1, 1, 1, 1, 1);
            DesigningLine(1, 1, 1, 1, -1, 1);
            DesigningLine(1, -1, 1, -1, -1, 1);
            DesigningLine(-1, -1, -1, -1, -1, 1);
            DesigningLine(-1, 1, -1, -1, 1, 1);
            DesigningLine(1, 1, -1, 1, 1, 1);
            DesigningLine(1, -1, -1, 1, -1, 1);
        }
        //Объявляем структуру Line и массивы этой структуры:
        public struct Line
        {
            //Объявляем массивы для соединения точек (points):
            public float[] fr_points;
            public float[] to_points;
            //Массивы для соединения преобразованных точек:
            //(transformed (tr) points):
            public float[] fr_tr_points;
            public float[] to_tr_points;
            //Создаем и инициализируем массивы, т.е.
            //всем пяти элементам каждого массива присваиваем 0:
            public void Initialize()
            {
                fr_points = new float[5];
                to_points = new float[5];
                fr_tr_points = new float[5];
                to_tr_points = new float[5];
            }
        }
        //Объявляем массив Lines структуры Line, оператором new
        //создаем массив из 100 элементов и инициализируем его,
        //т.е всем элементам этого массива присваиваем значение null:
        public Line[] Lines = new Line[100];
        //Объявляем и инициализируем переменную для индекса массива:
        public int NumLines = 0;
        //Проектируем линию между точками (x1,y1,z1),(x2,y2,z2):
        public void DesigningLine(float x1, float y1, float z1, float x2, float y2, float z2)
        {
            NumLines = NumLines + 1;
            //Инициализируем и рассчитываем массив:
            Lines[NumLines].Initialize();
            Lines[NumLines].fr_points[1] = x1;
            Lines[NumLines].fr_points[2] = y1;
            Lines[NumLines].fr_points[3] = z1;
            Lines[NumLines].fr_points[4] = 1;
            Lines[NumLines].to_points[1] = x2;
            Lines[NumLines].to_points[2] = y2;
            Lines[NumLines].to_points[3] = z2;
            Lines[NumLines].to_points[4] = 1;
        }
        //Применяем матрицу переноса (translation matrix)
        //ко всем линиям, используя MatrixApplyFull.
        //Преобразование не имеет 0, 0, 0, 1 в последнем столбце:
        public void TransformAllDataFull(ref float[,] M)
        {
            TransformDataFull(ref M, 1, NumLines);
        }


        //Применяем матрицу переноса (translation matrix)
        //ко всем выделенным линиям, используя MatrixApplyFull.
        //Преобразование не имеет 0, 0, 0, 1 в последнем столбце:
        public void TransformDataFull(ref float[,] M, int line1, int line2)
        {
            for (int i = line1; i <= line2; i++)
            {
                MatrixApplyFull(ref Lines[i].fr_points, ref M, ref Lines[i].fr_tr_points);
                MatrixApplyFull(ref Lines[i].to_points, ref M, ref Lines[i].to_tr_points);
            }
        }


        //Рисуем выделенные преобразованные линии:
        public void DrawSolid(Bitmap bmp, int first_line, int last_line, Color color, bool clear)
        {
            float x1, y1, x2, y2;
            Graphics g;
            Pen pen;
            //Задаем толщину линии рисования, например, 2
            //(цвет линии мы задали в процедуре Designing):
            pen = new Pen(color, 2);
            //Связываем объект g с изображением bmp:
            g = Graphics.FromImage(bmp);
            if (clear) g.Clear(Color.Black);
            //Рисуем линии:
            for (int i = first_line; i <= last_line; i++)
            {
                x1 = Lines[i].fr_tr_points[1];
                y1 = Lines[i].fr_tr_points[2];
                x2 = Lines[i].to_tr_points[1];
                y2 = Lines[i].to_tr_points[2];
                //Нормализуем и рисуем многогранник:
                g.DrawLine(pen, (x1 * bmp.Width / 4) + bmp.Width / 2.0F, bmp.Height / 2.0F - (y1 * bmp.Height / 4), (x2 * bmp.Width / 4) + bmp.Width / 2.0F, bmp.Height / 2.0F - (y2 * bmp.Height / 4));
            }
            //Высвобождаем ресурсы от объектов g и pen:
            g.Dispose();
            pen.Dispose();
        }
        //Строим единичную матрицу:
        public void MatrixIdentity(ref float[,] M)
        {
            for (int i = 1; i <= 4; i++)
            {
                for (int j = 1; j <= 4; j++)
                {
                    if (i == j) M[i, j] = 1;
                    else M[i, j] = 0;
                }
            }
        }
        //Строим матрицу преобразования (3-D transformation matrix)
        //для перспективной проекции вдоль оси z на плоскость x,y
        //с центром объекта (фокусом) в начале координат
        //и c центром проецирования на расстоянии (0, 0, Distance):
        public void MatrixPerspectiveXZ(ref float[,] M, float Distance)
        {
            MatrixIdentity(ref M);
            if (Distance != 0)
                M[3, 4] = -1 / Distance;
        }


        //Строим матрицу преобразования (3-D transformation matrix)
        //для проецирования с координатами:
        //центр проецирования (cx, cy, cz), фокус (fx, fy, fx),
        //вектор от объекта до экрана UP <ux, yx, uz>,
        //тип проецирования (type_of_projection):
        //PerspectiveProjection или ParallelProjection:
        public void MatrixTransformation(ref float[,] M, int type_of_projection,
         float Cx, float Cy, float Cz,
         float Fx, float Fy, float Fz,
         float ux, float uy, float uz)
        {
            float[,] M1 = new float[5, 5];
            float[,] M2 = new float[5, 5];
            float[,] M3 = new float[5, 5];
            float[,] M4 = new float[5, 5];
            float[,] M5 = new float[5, 5];
            float[,] M12 = new float[5, 5];
            float[,] M34 = new float[5, 5];
            float[,] M1234 = new float[5, 5];
            float sin1 = 0, cos1 = 0;
            float sin2 = 0, cos2 = 0;
            float sin3, cos3;
            float A, B, C;
            float d1, d2, d3;
            float[] up1 = new float[5];
            float[] up2 = new float[5];
            //Переносим фокус (центр объекта) в начало координат:
            MatrixTranslate(ref M1, -Fx, -Fy, -Fz);
            A = Cx - Fx;
            B = Cy - Fy;
            C = Cz - Fz;
            d1 = (float)Math.Sqrt(A * A + C * C);
            if (d1 != 0)
            {
                sin1 = -A / d1;
                cos1 = C / d1;
            }
            d2 = (float)Math.Sqrt(A * A + B * B + C * C);
            if (d2 != 0)
            {
                sin2 = B / d2;
                cos2 = d1 / d2;
            }
            //Вращаем объект вокруг оси y, чтобы разместить
            //центр проекции в y-z плоскости:
            MatrixIdentity(ref M2);
            //Если d1 = 0, тогда центр проекции
            //уже находится на оси y и в y-z плоскости:
            if (d1 != 0)
            {
                M2[1, 1] = cos1;
                M2[1, 3] = -sin1;
                M2[3, 1] = sin1;
                M2[3, 3] = cos1;
            }
            //Вращаем вокруг оси x,
            //чтобы разместить центр проекции на оси z:
            MatrixIdentity(ref M3);
            //Если d2 = 0, то центр проекции
            //находится в начале координат.
            //Это делает проекцию невозможной:
            if (d2 != 0)
            {
                M3[2, 2] = cos2;
                M3[2, 3] = sin2;
                M3[3, 2] = -sin2;
                M3[3, 3] = cos2;
            }
            //Вращаем вектор UP:
            up1[1] = ux;
            up1[2] = uy;
            up1[3] = uz;
            up1[4] = 1;
            MatrixApply(ref up1, ref M2, ref up2);
            MatrixApply(ref up2, ref M3, ref up1);
            //Вращаем вокруг оси z, чтобы разместить
            //вектор UP в y-z плоскости:
            d3 = (float)Math.Sqrt(up1[1] * up1[1] + up1[2] * up1[2]);
            MatrixIdentity(ref M4);
            //Если d3 = 0, то вектор UP равен нулю:
            if (d3 != 0)
            {
                sin3 = up1[1] / d3;
                cos3 = up1[2] / d3;
                M4[1, 1] = cos3;
                M4[1, 2] = sin3;
                M4[2, 1] = -sin3;
                M4[2, 2] = cos3;
            }
            //Проецируем:
            if (type_of_projection == PerspectiveProjection)
                MatrixPerspectiveXZ(ref M5, d2);
            else
                MatrixIdentity(ref M5);
            if (d2 != 0)
                MatrixPerspectiveXZ(ref M5, d2);
            else
                MatrixIdentity(ref M5);
            //Комбинируем преобразования:
            m3MatMultiply(ref M12, ref M1, ref M2);
            m3MatMultiply(ref M34, ref M3, ref M4);
            m3MatMultiply(ref M1234, ref M12, ref M34);
            if (type_of_projection == PerspectiveProjection)
                m3MatMultiplyFull(ref M, ref M1234, ref M5);
            else
                m3MatMultiply(ref M, ref M1234, ref M5);
        }


        //Строим матрицу преобразования (3-D transformation matrix)
        //для перспективного проецирования (perspective projection):
        //центр проецирования (r, phi, theta),
        //фокус (fx, fy, fx),
        //вектор от объекта до экрана UP <ux, yx, uz>,
        //тип проецирования (type_of_projection):
        //PerspectiveProjection:
        public void Projection(ref float[,] M,
         int type_of_projection, float R,
         float phi, float theta,
         float Fx, float Fy, float Fz,
         float ux, float uy, float uz)
        {
            float Cx, Cy, Cz, r2;
            //Переходим к прямоугольным координатам:
            Cy = R * (float)Math.Sin(phi);
            r2 = R * (float)Math.Cos(phi);
            Cx = r2 * (float)Math.Cos(theta);
            Cz = r2 * (float)Math.Sin(theta);
            MatrixTransformation(ref M, type_of_projection, Cx, Cy, Cz, Fx, Fy, Fz, ux, uy, uz); //ref M
        }
        //Строим матрицу преобразования, чтобы получить
        //отражение напротив плоскости, проходящей
        //через (p1, p2, p3) с вектором нормали <n1, n2, n3>:
        public void m3Reflect(ref float[,] M,
        float p1, float p2, float p3,
        float n1, float n2, float n3)
        {
            float[,] T = new float[5, 5]; //Перенос.
            float[,] R1 = new float[5, 5]; //Вращение 1.
            float[,] r2 = new float[5, 5]; //Вращение 2.
            float[,] S = new float[5, 5]; //Отражение.
            float[,] R2i = new float[5, 5]; //Не вращать 2.
            float[,] R1i = new float[5, 5]; //Не вращать 1.
            float[,] Ti = new float[5, 5]; //Не переносить.
            float D, L;
            float[,] M12 = new float[5, 5];
            float[,] M34 = new float[5, 5];
            float[,] M1234 = new float[5, 5];
            float[,] M56 = new float[5, 5];
            float[,] M567 = new float[5, 5];
            //Переносим плоскость к началу координат:
            MatrixTranslate(ref T, -p1, -p2, -p3);
            MatrixTranslate(ref Ti, p1, p2, p3);
            //Вращаем вокруг оси z,
            //пока нормаль не будет в y-z плоскости:
            MatrixIdentity(ref R1);
            D = (float)Math.Sqrt(n1 * n1 + n2 * n2);
            R1[1, 1] = n2 / D;
            R1[1, 2] = n1 / D;
            R1[2, 1] = -R1[1, 2];
            R1[2, 2] = R1[1, 1];
            MatrixIdentity(ref R1i);
            R1i[1, 1] = R1[1, 1];
            R1i[1, 2] = -R1[1, 2];
            R1i[2, 1] = -R1[2, 1];
            R1i[2, 2] = R1[2, 2];
            //Вращаем вокруг оси x, когда нормаль будет по оси y:
            MatrixIdentity(ref r2);
            L = (float)Math.Sqrt(n1 * n1 + n2 * n2 + n3 * n3);
            r2[2, 2] = D / L;
            r2[2, 3] = -n3 / L;
            r2[3, 2] = -r2[2, 3];
            r2[3, 3] = r2[2, 2];
            MatrixIdentity(ref R2i);
            R2i[2, 2] = r2[2, 2];
            R2i[2, 3] = -r2[2, 3];
            R2i[3, 2] = -r2[3, 2];
            R2i[3, 3] = r2[3, 3];
            //Рисуем отражение объекта перпендикулярно x-z плоскости:
            MatrixIdentity(ref S);
            S[2, 2] = -1;
            //Комбинируем матрицы:
            m3MatMultiply(ref M12, ref T, ref R1);
            m3MatMultiply(ref M34, ref r2, ref S);
            m3MatMultiply(ref M1234, ref M12, ref M34);
            m3MatMultiply(ref M56, ref R2i, ref R1i);
            m3MatMultiply(ref M567, ref M56, ref Ti);
            m3MatMultiply(ref M, ref M1234, ref M567);
        }
        //Строим матрицу преобразования для поворота на угол theta
        //вокруг линии, проходящей через (p1, p2, p3)
        //в направлении <d1, d2, d3>.
        //Угол theta откладывается против часовой стрелки,
        //если мы смотрим вниз в направлении,
        //противоположном направлению линии:
        public void m3LineRotate(ref float[,] M,
         float p1, float p2, float p3,
         float d1, float d2, float d3, float theta)
        {
            float[,] T = new float[5, 5]; //Перенос.
            float[,] R1 = new float[5, 5]; //Вращение 1.
            float[,] r2 = new float[5, 5]; //Вращение 2.
            float[,] Rot3 = new float[5, 5]; //Вращение.
            float[,] R2i = new float[5, 5]; //Стоп вращению 2.
            float[,] R1i = new float[5, 5]; //Стоп вращению 1.
            float[,] Ti = new float[5, 5]; //Стоп переносу.
            float D, L;
            float[,] M12 = new float[5, 5];
            float[,] M34 = new float[5, 5];
            float[,] M1234 = new float[5, 5];
            float[,] M56 = new float[5, 5];
            float[,] M567 = new float[5, 5];
            //Переносим плоскость к началу координат:
            MatrixTranslate(ref T, -p1, -p2, -p3);
            MatrixTranslate(ref Ti, p1, p2, p3);
            //Вращаем вокруг оси z,
            //пока линия не окажется в y-z плоскости:
            MatrixIdentity(ref R1);
            D = (float)Math.Sqrt(d1 * d1 + d2 * d2);
            R1[1, 1] = d2 / D;
            R1[1, 2] = d1 / D;
            R1[2, 1] = -R1[1, 2];
            R1[2, 2] = R1[1, 1];
            MatrixIdentity(ref R1i);
            R1i[1, 1] = R1[1, 1];
            R1i[1, 2] = -R1[1, 2];
            R1i[2, 1] = -R1[2, 1];
            R1i[2, 2] = R1[2, 2];
            //Вращаем вокруг оси x, когда линия будет по оси y:
            MatrixIdentity(ref r2);
            L = (float)Math.Sqrt(d1 * d1 + d2 * d2 + d3 * d3);
            r2[2, 2] = D / L; r2[2, 3] = -d3 / L;
            r2[3, 2] = -r2[2, 3];
            r2[3, 3] = r2[2, 2];
            MatrixIdentity(ref R2i);
            R2i[2, 2] = r2[2, 2];
            R2i[2, 3] = -r2[2, 3];
            R2i[3, 2] = -r2[3, 2];
            R2i[3, 3] = r2[3, 3];
            //Вращаем вокруг линии (оси y):
            MatrixYRotate(ref Rot3, theta);
            //Комбинируем матрицы:
            m3MatMultiply(ref M12, ref T, ref R1);
            m3MatMultiply(ref M34, ref r2, ref Rot3);
            m3MatMultiply(ref M1234, ref M12, ref M34);
            m3MatMultiply(ref M56, ref R2i, ref R1i);
            m3MatMultiply(ref M567, ref M56, ref Ti);
            m3MatMultiply(ref M, ref M1234, ref M567);
        }

        //Строим матрицу преобразования (3-D transformation matrix)
        //для переноса на Tx, Ty, Tz:
        public void MatrixTranslate(ref float[,] M, float Tx, float Ty, float Tz)
        {
            MatrixIdentity(ref M);
            M[4, 1] = Tx;
            M[4, 2] = Ty;
            M[4, 3] = Tz;
        }
        //Строим матрицу преобразования (3-D transformation matrix)
        //для поворота вокруг оси y (угол - в радианах):
        public void MatrixYRotate(ref float[,] M, float theta)
        {
            MatrixIdentity(ref M);
            M[1, 1] = (float)Math.Cos(theta);
            M[3, 3] = M[1, 1];
            M[3, 1] = (float)Math.Sin(theta);
            M[1, 3] = -M[3, 1];
        }
        //Применяем матрицу преобразования к точке,
        //где матрица не может иметь 0, 0, 0, 1
        //в последнем столбце. Нормализуем только
        //x и y компоненты результата, чтобы сохранить z информацию:
        public void MatrixApplyFull(ref float[] V, ref float[,] M, ref float[] Result)
        {
           int i, j;
            float value = 0;
            Result = new float[5] { 0, 0, 0, 0, 0 };
            for (i = 1; i <= 4; i++)
            {
                value = 0;
                for (j = 1; j <= 4; j++)
                {
                    value = value + V[j] * M[j, i];
                }
                Result[i] = value;
            }
            
            //Повторно нормализуем точку (value = Result[4]):
            if (value != 0)
            {
                Result[1] = Result[1] / value;
                Result[2] = Result[2] / value;
            }
            else
            {
                //Не преобразовываем z - составляющую.
                //Если значение z больше, чем от центра проекции,
                //эта точка будет удалена:
                Result[3] = Single.MaxValue;
            }
            Result[4] = 1;
        }
        //Применяем матрицу преобразования к точке:
        public void MatrixApply(ref float[] V,
        ref float[,] M, ref float[] Result)
        {
            Result[1] = V[1] * M[1, 1] + V[2] * M[2, 1] + V[3] * M[3, 1] + M[4, 1];
            Result[2] = V[1] * M[1, 2] + V[2] * M[2, 2] + V[3] * M[3, 2] + M[4, 2];
            Result[3] = V[1] * M[1, 3] + V[2] * M[2, 3] + V[3] * M[3, 3] + M[4, 3];
            Result[4] = 1;
        }
        //Умножаем две матрицы. Матрицы
        //не могут содержать 0, 0, 0, 1 в последних столбцах:
        public void m3MatMultiplyFull(ref float[,] Result, ref float[,] A, ref float[,] B)
        {
            int i, j, k;
            float value;
            Result = new float[5, 5];
            for (i = 1; i <= 4; i++)
            {
                for (j = 1; j <= 4; j++)
                {
                    value = 0;
                    for (k = 1; k <= 4; k++)
                        value = value + A[i, k] * B[k, j];
                    Result[i, j] = value;
                }
            }
        }
        //Умножаем две матрицы:
        public void m3MatMultiply(ref float[,] Result, ref float[,] A, ref float[,] B)
        {
            Result[1, 1] = A[1, 1] * B[1, 1] + A[1, 2] * B[2, 1] + A[1, 3] * B[3, 1];
            Result[1, 2] = A[1, 1] * B[1, 2] + A[1, 2] * B[2, 2] + A[1, 3] * B[3, 2];
            Result[1, 3] = A[1, 1] * B[1, 3] + A[1, 2] * B[2, 3] + A[1, 3] * B[3, 3];
            Result[1, 4] = 0;
            Result[2, 1] = A[2, 1] * B[1, 1] + A[2, 2] * B[2, 1] + A[2, 3] * B[3, 1];
            Result[2, 2] = A[2, 1] * B[1, 2] + A[2, 2] * B[2, 2] + A[2, 3] * B[3, 2];
            Result[2, 3] = A[2, 1] * B[1, 3] + A[2, 2] * B[2, 3] + A[2, 3] * B[3, 3];
            Result[2, 4] = 0;
            Result[3, 1] = A[3, 1] * B[1, 1] + A[3, 2] * B[2, 1] + A[3, 3] * B[3, 1];
            Result[3, 2] = A[3, 1] * B[1, 2] + A[3, 2] * B[2, 2] + A[3, 3] * B[3, 2];
            Result[3, 3] = A[3, 1] * B[1, 3] + A[3, 2] * B[2, 3] + A[3, 3] * B[3, 3];
            Result[3, 4] = 0;
            Result[4, 1] = A[4, 1] * B[1, 1] + A[4, 2] * B[2, 1] + A[4, 3] * B[3, 1] + B[4, 1];
            Result[4, 2] = A[4, 1] * B[1, 2] + A[4, 2] * B[2, 2] + A[4, 3] * B[3, 2] + B[4, 2];
            Result[4, 3] = A[4, 1] * B[1, 3] + A[4, 2] * B[2, 3] + A[4, 3] * B[3, 3] + B[4, 3];
            Result[4, 4] = 1;
        }
    }
}
