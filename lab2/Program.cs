using System;
namespace labVec {

    class Program
    {
        static string vectorsFile = "input.txt";
        static string resultsFile = "results.txt";

        static List<Vector> vectors = new List<Vector>();
        static List<string> log = new List<string>();

        static void Main(string[] args)
        {
            LoadVectors();

            if (vectors.Count < 2)
            {
                log.Add("Помилка: у файлі має бути 2 вектори");
                SaveLog();
                Console.WriteLine("Все збережено в " + resultsFile);
                return;
            }

            Vector a = vectors[0];
            Vector b = vectors[1];

            log.Add("Вектор A: " + a.ToString());
            log.Add("Вектор B: " + b.ToString());
            log.Add("");

            if (a.GetSize() != b.GetSize())
            {
                log.Add("Помилка: розміри векторів різні, так не можна");
                SaveLog();
                Console.WriteLine("Все збережено в " + resultsFile);
                return;
            }

            DoOperation(a, b, "+");
            DoOperation(a, b, "-");
            DoOperation(a, b, "*");
            if (b.hasZero())
            {
                log.Add(a.ToString() + "/" + b.ToString() + "=ділення неможливе, вдругому векторі є нуль"); }
                else {
                    DoOperation(a, b, "/"); }

                SaveLog();

                Console.WriteLine("Все збережено в " + resultsFile);
            }
            static void LoadVectors()
            {
                try
                {
                    if (!File.Exists(vectorsFile))
                    {
                        log.Add("Помилка: файл " + vectorsFile + " не знайдено");
                        return;
                    }

                    string[] lines = File.ReadAllLines(vectorsFile);

                    foreach (string line in lines)
                    {
                        if (line.Trim() == "")
                        {
                            continue;
                        }

                        try
                        {
                            string[] parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                            double[] coords = new double[parts.Length];

                            for (int i = 0; i < parts.Length; i++)
                            {
                                coords[i] = double.Parse(parts[i].Trim());
                            }

                            Vector v = new Vector(coords);
                            vectors.Add(v);
                        }
                        catch (FormatException)
                        {
                            log.Add("Пропускаю кривий рядок у файлі: " + line);
                        }
                    }
                }
                catch (IOException ex)
                {
                    log.Add("Помилка читання файлу: " + ex.Message);
                }
            }
            static void DoOperation(Vector a, Vector b, string op)
            {
                string[] result = new string[a.GetSize()];

                for (int i = 0; i < a.GetSize(); i++)
                {
                    try
                    {
                        double value;

                        if (op == "+")
                        {
                            value = a.Coords[i] + b.Coords[i];
                        }
                        else if (op == "-")
                        {
                            value = a.Coords[i] - b.Coords[i];
                        }
                        else if (op == "*")
                        {
                            value = a.Coords[i] * b.Coords[i];
                        }
                        else
                        {
                            if (b.Coords[i] == 0)
                            {
                                throw new DivideByZeroException();
                            }
                            value = a.Coords[i] / b.Coords[i];
                        }

                        result[i] = value.ToString();
                    }
                    catch (DivideByZeroException) {
                        result[i] = "ділення на нуль";
                    }
                    catch (Exception ex)
                    {
                        result[i] = "помилка (" + ex.Message + ")";
                    }
                }

                string logLine = a.ToString() + " " + op + " " + b.ToString() + " = (" + string.Join(", ", result) + ")";
                log.Add(logLine);
            }

            static void SaveLog()
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(resultsFile, false))
                    {
                        foreach (string line in log)
                        {
                            sw.WriteLine(line);
                        }
                    }
                }
                catch (IOException ex)
                {
                    Console.WriteLine("Помилка запису в файл результатів: " + ex.Message);
                }
            }
        }
    }
