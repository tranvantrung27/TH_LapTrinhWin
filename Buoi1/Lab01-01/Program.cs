using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01_01
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("╔═══════════════════════════════════════════════╗");
            Console.WriteLine("║         🎮 TRÒ CHƠI ĐOÁN SỐ 3 CHỮ SỐ          ║");
            Console.WriteLine("╠═══════════════════════════════════════════════╣");
            Console.WriteLine("║ ★ Hướng dẫn:                                  ║");
            Console.WriteLine("║ - Máy tính sẽ chọn ngẫu nhiên số từ 100–999.  ║");
            Console.WriteLine("║ - Bạn có 7 lần để đoán số này.                ║");
            Console.WriteLine("║ - Phản hồi sau mỗi lần đoán:                  ║");
            Console.WriteLine("║    + : đúng số, đúng vị trí                   ║");
            Console.WriteLine("║    ? : đúng số, sai vị trí                    ║");
            Console.WriteLine("║    _ : không đúng số nào                      ║");
            Console.WriteLine("╚═══════════════════════════════════════════════╝\n");

            Random random = new Random();
            int targetNumber = random.Next(100, 1000);
            string targetString = targetNumber.ToString();

            int attempt = 1;
            const int MAX_GUESS = 7;
            string guess, feedback = "";

            while (feedback != "+++" && attempt <= MAX_GUESS)
            {
                Console.Write($"🔢 Lần đoán thứ {attempt} - nhập số 3 chữ số: ");
                guess = Console.ReadLine();

                if (guess.Length != 3 || !int.TryParse(guess, out _))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("⚠️ Vui lòng nhập đúng một số có 3 chữ số!\n");
                    Console.ResetColor();
                    continue;
                }

                feedback = GetFeedback(targetString, guess);

                Console.Write("→ 📩 Phản hồi: ");
                for (int i = 0; i < feedback.Length; i++)
                {
                    switch (feedback[i])
                    {
                        case '+':
                            Console.ForegroundColor = ConsoleColor.Green;
                            break;
                        case '?':
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Gray;
                            break;
                    }
                    Console.Write(feedback[i]);
                }
                Console.ResetColor();
                Console.WriteLine("\n");

                if (feedback == "+++")
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("🎉🎉🎉 CHÚC MỪNG! Bạn đã đoán đúng số: {0}", targetNumber);
                    Console.ResetColor();
                    break;
                }

                attempt++;
            }

            if (feedback != "+++")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("❌ Bạn đã hết lượt đoán. Số đúng là: {0}", targetNumber);
                Console.ResetColor();
            }

            Console.WriteLine("🎯 Cảm ơn bạn đã chơi trò chơi!");
            Console.ReadLine();
        }

        static string GetFeedback(string target, string guess)
        {
            char[] feedback = new char[3];
            bool[] matchedInTarget = new bool[3];

            for (int i = 0; i < 3; i++)
            {
                if (guess[i] == target[i])
                {
                    feedback[i] = '+';
                    matchedInTarget[i] = true;
                }
                else
                {
                    feedback[i] = '_';
                }
            }

            for (int i = 0; i < 3; i++)
            {
                if (feedback[i] == '_')
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (!matchedInTarget[j] && guess[i] == target[j] && i != j)
                        {
                            feedback[i] = '?';
                            matchedInTarget[j] = true;
                            break;
                        }
                    }
                }
            }

            return new string(feedback);
        }
    }

}
