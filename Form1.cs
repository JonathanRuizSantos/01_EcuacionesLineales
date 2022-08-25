namespace SistemasEcuaciones
{
    public partial class Form1 : Form
    {
        string EcIzq;
        string EcDer;
        char caracter;
        string signo;
        string signo_menos_dos;
        string signoint;
        double Num1;
        double Num2;
        double result_suma;
        double result_resta;
        public Form1()
        {
            InitializeComponent();
        }

        private void btCalcular_Click(object sender, EventArgs e)
        {
            Enter_datas();
            string[] caract_izq_array = new string[EcIzq.Length];
            EcIzq = EcIzq.ToUpper();

           
            for(int i = 0; i < EcIzq.Length; i++)
            {
                caracter = EcIzq[i];
               
                caract_izq_array[i] = caracter.ToString();

            }

            string[] list2 = new string[EcIzq.Length];

            for (int j = 0; j < caract_izq_array.Length; j++)
            {

                try {
                signo= caract_izq_array[j];
                }
                catch
                {
                    signo = "+";
                }
                try { 
                signo_menos_dos = caract_izq_array[j-2];
                }
                catch
                {
                    signo_menos_dos = "0";
                }
                try
                {
                    signoint = caract_izq_array[j - 1];
                }
                catch
                {
                    signoint = "X";
                }
                //SUMA
                if (signo == "+" && signoint=="X" && (signo_menos_dos!="X" || signo_menos_dos!="+" || signo_menos_dos!="-"))
                {
                    list2[j] = signo_menos_dos;
       
                }
        
                for(int i = 0; i < list2.Length; i++)
                {
                    
                    if(i == 0)
                    {
                        result_suma = Convert.ToDouble(list2[i]);
                        
                    }
                    else if(i != 0)
                    {
                        result_suma = result_suma + Convert.ToDouble(list2[i]);
                    }

                }

                //RESTA
                if (signo == "-" && signoint == "X" && (signo_menos_dos != "X" || signo_menos_dos != "+" || signo_menos_dos != "-"))
                {
                    list2[j] = signo_menos_dos;
                }

                for (int i = 0; i < list2.Length; i++)
                {

                    if (caract_izq_array[0] != "X" || caract_izq_array[0] != "+" || caract_izq_array[0] != "-")
                    {
                        list2[0] = "0";
                    }
                    else if (caract_izq_array[0] == "X")
                    {
                        list2[0] = "0";
                    }

                    if (i == 0)
                    {
                        result_resta = Convert.ToDouble(list2[i]);
                        //tbX.Text = result_resta.ToString();

                    }
                    else if (i != 0)
                    {
                        result_resta = result_resta - Convert.ToDouble(list2[i]);
                        //lbtest.Items.Add(list2[i]);
                    }

                    tbX.Text = result_resta.ToString();
                }

            }
            
        }
        public void Enter_datas()
        {
            EcIzq = tbEcuations.Text;
            EcDer = tbDer.Text;
        }

    }
}