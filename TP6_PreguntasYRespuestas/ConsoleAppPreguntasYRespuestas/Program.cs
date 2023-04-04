using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppPreguntasYRespuestas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n************************INICIO****************************\n");

            int numeroPreguntas = 0;
            do
            {

                Console.WriteLine("Por favor Ingrese Cuantas preguntas tendra el examen: ");
                Console.WriteLine("Recuerde que por lo menos debe haber 1 pregunta: ");
                numeroPreguntas = Convert.ToInt16(Console.ReadLine());

            } while (numeroPreguntas < 1);

            int numeroRespuestas = 0;
            do
            {
                Console.WriteLine("Por favor Ingrese Cuantas opciones tendran las preguntas");
                Console.WriteLine("Recuerde que por lo menos debe haber 2 opciones: ");
                numeroRespuestas = Convert.ToInt16(Console.ReadLine());

            } while (numeroRespuestas < 2);

            //creo un arreglo para guardar las preguntas y cual es la opcion correcta
            string[,] preguntas = new string[numeroPreguntas, 2];
            //creo otro arreglo para guardar las opciones de cada pregunta 
            string[,] respuestas = new string[numeroPreguntas, numeroRespuestas];

            for (int i = 0; i < numeroPreguntas; i++)
            {
                //carga las preguntas
                Console.WriteLine("\n\n**********************************************************\n");
                Console.WriteLine("\nIngrese pregunta numero " + (i + 1) + ":");
                preguntas[i, 0] = Console.ReadLine();

                for (int j = 0; j < numeroRespuestas; j++)
                {
                    //carga las respuestas
                    Console.WriteLine("\nIngrese la opcion " + (j + 1) + " para la pregunta numero " + (i + 1) + ":");
                    respuestas[i, j] = Console.ReadLine();
                }
                Console.WriteLine("\nIngrese la opcion correcta para la pregunta numero " + (i + 1) + ":");
                preguntas[i, 1] = Console.ReadLine();

                Console.WriteLine("\n\n**********************************************************");
            }

            //metodo declarado en la clase Program
            examen(preguntas, respuestas, numeroPreguntas, numeroRespuestas);

            Console.WriteLine("\n*************************FIN******************************\n");
        }

        //metodo que se encargara de mostar las preguntas y mostrar la nota final
        public static void examen(string[,] pregustas, string[,] respuestas, int numeroPreguntas, int numeroRespuestas)
        {
            decimal valorPregunta = 10 / (Convert.ToDecimal(numeroPreguntas));//cuanto puntua cada pregunta
            decimal calificacion = 0;//contador nota final

            string opcion = "";//manejara las opciones que se ingresen por consola

            Console.WriteLine("\n\n****************  Comienza el examen *********************\n");
            Console.WriteLine("\n\n************* cada pregunta vale {0:N2}  puntos ***********\n", valorPregunta);
            for (int i = 0; i < numeroPreguntas; i++)
            {
                //muestra la pregunta
                Console.WriteLine("\n\n**********************************************************\n");
                Console.WriteLine("--> Pregunta numero " + (i + 1) + ": \n\n" + pregustas[i, 0] + "?\n");

                //muestra las opciones
                for (int j = 0; j < numeroRespuestas; j++)
                {
                    Console.WriteLine("Opcion " + (j + 1) + ") " + respuestas[i, j] + "\n");


                }
                Console.WriteLine("\n Escriba el numero de la opcion que crea correcta y precione 'Enter'");
                Console.WriteLine("\n Ingrese su respuesta: ");
                opcion = Console.ReadLine();
                //si la respuesta es correcta suma en el contador de la calificacion final
                if (opcion.Equals(pregustas[i, 1]))
                {
                    calificacion += valorPregunta;
                }
                Console.WriteLine("\n\n**********************************************************");

            }
            //muestra la calificacion final
            Console.WriteLine("\n\n************ Su calificacion fue: {0:N2} ******************\n", calificacion);

        }

    }
}
