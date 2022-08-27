namespace SistemasEcuaciones
{
    public partial class Form1 : Form
    {
        string EcIzq;
        string EcDer;
        char caracter;
        double Ax;
        double B;
        double Cx;
        double D;
        double Var_SumaX;
        double Var_Suma;
        double Var_RestaX;
        double Var_Resta;
        double Var_SumaX_der;
        double Var_Suma_der;
        double Var_RestaX_der;
        double Var_Resta_der;
        double Rx;
        double Ri;
        double X_Final;

        public Form1()
        {
            InitializeComponent();
        }

        private void btCalcular_Click(object sender, EventArgs e)
        {
            lbtest.Items.Clear();

            Enter_datas();
            char[] caract_izq_array = new char[EcIzq.Length+3];
            char[] caract_izq_array_copy = new char[EcIzq.Length+3];
            string[] Array_SumaX = new string[EcIzq.Length];
            string[] Array_Suma = new string[EcIzq.Length];
            string[] Array_RestaX = new string[EcIzq.Length];
            string[] Array_Resta = new string[EcIzq.Length];
            
            //-----------------------------------------------
            char[] caract_der_array = new char[EcDer.Length + 3];
            char[] caract_der_array_copy = new char[EcDer.Length + 3];
            string[] Array_SumaX_der = new string[EcDer.Length];
            string[] Array_Suma_der = new string[EcDer.Length];
            string[] Array_RestaX_der = new string[EcDer.Length];
            string[] Array_Resta_der = new string[EcDer.Length];

            

            //Descompone la cadena en un array
            for (int i = 0; i < EcIzq.Length; i++)
            {
                caracter = EcIzq[i];
                
                caract_izq_array[i] = caracter;
                caract_izq_array_copy[i] = caracter;
            }

            if (char.IsNumber(caract_izq_array[0]))
            {
                caract_izq_array[0] = '+';

                for(int i = 1; i <= EcIzq.Length; i++)
                {
                    caract_izq_array[i] = caract_izq_array_copy[i - 1];
                }
            }
            else if (caract_izq_array[0] == 'X')
            {
                caract_izq_array[0] = '+';
                caract_izq_array[1] = '1';

                for (int i = 2; i <= EcIzq.Length; i++)
                {
                    caract_izq_array[i] = caract_izq_array_copy[i - 1];
                }
            }
            else
            {
                for (int i = 0; i < EcIzq.Length; i++)
                {
                    caract_izq_array[i] = caract_izq_array_copy[i];
                }
            }
            
            // Recorre la cadena, encuentra los signos y guarda los coeficientes en un arreglo----------------------
            for (int i = 0; i <= EcIzq.Length; i++)
            {

                if (caract_izq_array[i] == '+' || caract_izq_array[i] == '-')
                {
                    try
                    {
                        if (caract_izq_array[i - 2] == '+' && char.IsNumber(caract_izq_array[i - 1]) && (caract_izq_array[i] == '+' || caract_izq_array[i] == '-'))
                        {
                            Array_Suma[i - 2] = caract_izq_array[i - 1].ToString();
                            
                        }
                        else if (caract_izq_array[i - 2] == '-' && char.IsNumber(caract_izq_array[i - 1]) && (caract_izq_array[i] == '+' || caract_izq_array[i] == '-'))
                        {
                            Array_Resta[i - 2] = caract_izq_array[i - 1].ToString();
                            
                        }
                        else if (caract_izq_array[i - 2] == '+' && caract_izq_array[i - 1] == 'X' && (caract_izq_array[i] == '+' || caract_izq_array[i] == '-')) // --> [-,X,DifX, ...] --> [-1, ...]
                        {
                            Array_SumaX[i - 3] = "1";
                            
                        }
                        else if (caract_izq_array[i - 2] == '-' && caract_izq_array[i - 1] == 'X' && (caract_izq_array[i] == '+' || caract_izq_array[i] == '-')) // --> [-,X,DifX, ...] --> [-1, ...]
                        {
                            Array_RestaX[i - 3] = "1";
                            
                        }
                        else if (caract_izq_array[i - 3] == '+' && char.IsNumber(caract_izq_array[i-2]) && caract_izq_array[i - 1] == 'X' && (caract_izq_array[i] == '+' || caract_izq_array[i] == '-'))
                        {
                            Array_SumaX[i - 3] = caract_izq_array[i - 2].ToString();
                            
                        }
                        else if (caract_izq_array[i - 3] == '-' && char.IsNumber(caract_izq_array[i - 2]) && caract_izq_array[i - 1] == 'X' && (caract_izq_array[i] == '+' || caract_izq_array[i] == '-'))
                        {
                            Array_RestaX[i - 3] = caract_izq_array[i - 2].ToString();
                            
                        }
                        
                    }
                    catch
                    {

                    }
                }

                //Sumar los elementos del Array que contiene los coeficientes -------------------------------------
                for (int j = 0; j < Array_SumaX.Length; j++)
                {
                    if (j == 0)
                    {
                        Var_SumaX = Convert.ToDouble(Array_SumaX[j]);
                    }
                    else
                    {
                        Var_SumaX = Var_SumaX + Convert.ToDouble(Array_SumaX[j]);
                    } 
                }
                for(int j = 0; j < Array_Suma.Length; j++)
                {
                    if (j == 0)
                    {
                        Var_Suma = Convert.ToDouble(Array_Suma[0]);
                    }
                    else
                    {
                        Var_Suma = Var_Suma + Convert.ToDouble(Array_Suma[j]);
                    }
                }
                for (int j = 0; j < Array_RestaX.Length; j++)
                {
                    if (j == 0)
                    {
                        Var_RestaX = Convert.ToDouble(Array_RestaX[0]);
                    }
                    else
                    {
                        Var_RestaX = Var_RestaX + Convert.ToDouble(Array_RestaX[j]);
                    }
                }
                for (int j = 0; j < Array_Resta.Length; j++)
                {
                    if (j == 0)
                    {
                        Var_Resta = Convert.ToDouble(Array_Resta[0]);
                    }
                    else
                    {
                        Var_Resta = Var_Resta + Convert.ToDouble(Array_Resta[j]);
                    }
                }

                // Restar RestaX a SumaX
                Ax = Var_SumaX - Var_RestaX;

                // Restar Resta a Suma
                B = Var_Suma - Var_Resta;
            }

            // ECUACION DE LA DERECHA -----------------------------------------------------------------------------

            //Descompone la cadena en un array
            for (int i = 0; i < EcDer.Length; i++)
            {
                caracter = EcDer[i];

                caract_der_array[i] = caracter;
                caract_der_array_copy[i] = caracter;
            }

            if (char.IsNumber(caract_der_array[0]))
            {
                caract_der_array[0] = '+';

                for (int i = 1; i <= EcDer.Length; i++)
                {
                    caract_der_array[i] = caract_der_array_copy[i - 1];
                }
            }
            else if (caract_der_array[0] == 'X')
            {
                caract_der_array[0] = '+';
                caract_der_array[1] = '1';

                for (int i = 2; i <= EcDer.Length; i++)
                {
                    caract_der_array[i] = caract_der_array_copy[i - 1];
                }
            }
            else
            {
                for (int i = 0; i < EcDer.Length; i++)
                {
                    caract_der_array[i] = caract_der_array_copy[i];
                }
            }

            // Recorre la cadena, encuentra los signos y guarda los coeficientes en un arreglo
            for (int i = 0; i <= EcDer.Length; i++)
            {
                if (caract_der_array[i] == '+' || caract_der_array[i] == '-')
                {
                    try
                    {
                        if (caract_der_array[i - 2] == '+' && char.IsNumber(caract_der_array[i - 1]) && (caract_der_array[i] == '+' || caract_der_array[i] == '-'))
                        {
                            Array_Suma_der[i - 2] = caract_der_array[i - 1].ToString();
                            
                        }
                        else if (caract_der_array[i - 2] == '-' && char.IsNumber(caract_der_array[i - 1]) && (caract_der_array[i] == '+' || caract_der_array[i] == '-'))
                        {
                            Array_Resta_der[i - 2] = caract_der_array[i - 1].ToString();
                            
                        }
                        else if (caract_der_array[i - 2] == '+' && caract_der_array[i - 1] == 'X' && (caract_der_array[i] == '+' || caract_der_array[i] == '-')) // --> [-,X,DifX, ...] --> [-1, ...]
                        {
                            Array_SumaX_der[i - 3] = "1";
                            
                        }
                        else if (caract_der_array[i - 2] == '-' && caract_der_array[i - 1] == 'X' && (caract_der_array[i] == '+' || caract_der_array[i] == '-')) // --> [-,X,DifX, ...] --> [-1, ...]
                        {
                            Array_RestaX_der[i - 3] = "1";

                        }
                        else if (caract_der_array[i - 3] == '+' && char.IsNumber(caract_der_array[i - 2]) && caract_der_array[i - 1] == 'X' && (caract_der_array[i] == '+' || caract_der_array[i] == '-'))
                        {
                            Array_SumaX_der[i - 3] = caract_der_array[i - 2].ToString();

                        }
                        else if (caract_der_array[i - 3] == '-' && char.IsNumber(caract_der_array[i - 2]) && caract_der_array[i - 1] == 'X' && (caract_der_array[i] == '+' || caract_der_array[i] == '-'))
                        {
                            Array_RestaX_der[i - 3] = caract_der_array[i - 2].ToString();

                        }
                        
                    }
                    catch
                    {

                    }
                }

                //Sumar los elementos del Array que contiene los coeficientes
                for (int j = 0; j < Array_SumaX_der.Length; j++)
                {
                    if (j == 0)
                    {
                        Var_SumaX_der = Convert.ToDouble(Array_SumaX_der[j]);
                    }
                    else
                    {
                        Var_SumaX_der = Var_SumaX_der + Convert.ToDouble(Array_SumaX_der[j]);
                    }
                }
                for (int j = 0; j < Array_Suma_der.Length; j++)
                {
                    if (j == 0)
                    {
                        Var_Suma_der = Convert.ToDouble(Array_Suma_der[0]);
                    }
                    else
                    {
                        Var_Suma_der = Var_Suma_der + Convert.ToDouble(Array_Suma_der[j]);
                    }
                }
                for (int j = 0; j < Array_RestaX_der.Length; j++)
                {
                    if (j == 0)
                    {
                        Var_RestaX_der = Convert.ToDouble(Array_RestaX_der[0]);
                    }
                    else
                    {
                        Var_RestaX_der = Var_RestaX_der + Convert.ToDouble(Array_RestaX_der[j]);
                    }
                }
                for (int j = 0; j < Array_Resta_der.Length; j++)
                {
                    if (j == 0)
                    {
                        Var_Resta_der = Convert.ToDouble(Array_Resta_der[0]);
                    }
                    else
                    {
                        Var_Resta_der = Var_Resta_der + Convert.ToDouble(Array_Resta_der[j]);
                    }
                }

                // Restar RestaX a SumaX
                Cx = Var_SumaX_der - Var_RestaX_der;

                // Restar Resta a Suma
                D = Var_Suma_der - Var_Resta_der;
            }

            lbtest.Items.Add("Solucion : ");
            lbtest.Items.Add(EcIzq + " = " + EcDer);
            lbtest.Items.Add(Ax + "X + " + B + " = " + Cx + "X + " + D);
            lbtest.Items.Add(Ax + "X - " + Cx + "X = " + B + " + " + D);
            

            Reacomodar_Terminos();
        }

        // Funciones ------------------------------------------------------------------------------------------------
        public void Enter_datas()
        {
            string EcIzq_Copy;
            string EcDer_Copy;

            EcIzq = tbEcuations.Text + "+0";
            EcDer = tbDer.Text + "+0";
            EcIzq_Copy = EcIzq;
            EcDer_Copy = EcDer;
            EcIzq = EcIzq.ToUpper();
            EcDer = EcDer.ToUpper();
            EcIzq_Copy = EcIzq_Copy.ToUpper();
            EcDer_Copy = EcDer_Copy.ToUpper();

            //Condiciones de la ecuacion Izquierda
            if ((EcIzq_Copy[0] == '-' || EcIzq_Copy[0] == '+') && char.IsNumber(EcIzq_Copy[1]) && ((EcIzq_Copy[2]) == '+' || (EcIzq_Copy[2]) == '-'))
            {
                EcIzq = EcIzq_Copy;
            }
            else if (EcIzq_Copy[0] == 'X')
            {
                EcIzq = "+1" + EcIzq_Copy;
            }
            else if (char.IsNumber(EcIzq_Copy[0]))
            {
                EcIzq = "+" + EcIzq_Copy;
            }
            else if (EcIzq_Copy[0] == '-' && EcIzq_Copy[1] == 'X' && ((EcIzq_Copy[2]) == '+' || (EcIzq_Copy[2]) == '-'))
            {
                for (int i = 0; i <= EcIzq_Copy.Length; i++)
                {
                    if(i == 0)
                    {
                        EcIzq = "-1" + EcIzq_Copy[1];
                    }
                    else if(i != 0)
                    {
                        int index = i + 1;
                        if(index < EcIzq_Copy.Length) 
                        { 
                        EcIzq = EcIzq + EcIzq_Copy[index];
                        }
                    }
                        
                }

            }
            else
            {

            }
            
            // Condiciones para la ecuacion derecha
            if ((EcDer_Copy[0] == '-' || EcDer_Copy[0] == '+') && char.IsNumber(EcDer_Copy[1]) && (EcDer_Copy[2] == '+' || EcDer_Copy[2] == '-'))
            {
                EcDer = EcDer_Copy;
            }
            else if (EcDer_Copy[0] == 'X')
            {
                EcDer = "+1" + EcDer_Copy;
            }
            else if (char.IsNumber(EcDer_Copy[0]))
            {
                EcDer = "+" + EcDer_Copy;
            }
            else if (EcDer_Copy[0] == '-' && EcDer_Copy[1] == 'X' && (EcDer_Copy[2] == '+' || EcDer_Copy[2] == '-'))
            {
                for (int i = 0; i <= EcDer_Copy.Length; i++)
                {
                    if (i == 0)
                    {
                        EcDer = "-1" + EcDer_Copy[1];
                    }
                    else if (i != 0)
                    {
                        int index = i + 1;
                        if (index < EcDer_Copy.Length)
                        {
                            EcDer = EcDer + EcDer_Copy[index];
                        }
                    }

                }

            }

        }
        public void Reacomodar_Terminos() 
        {

            Rx = Ax - Cx;
            Ri = D - B;
            if(Rx == 0)
            {
                MessageBox.Show("El denominador es cero por lo tanto la ecuacion no tiene solucion");
            }
            else
            {
                X_Final = Ri / Rx;
                tbX.Text = X_Final.ToString();
                lbtest.Items.Add(Rx + "X = " + Ri);
                lbtest.Items.Add("X = " + X_Final);
            }
        }

    }
}